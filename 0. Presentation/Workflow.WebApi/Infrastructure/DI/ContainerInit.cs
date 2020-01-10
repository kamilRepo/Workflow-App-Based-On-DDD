using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow.Base.CQRS.Commands.Decorator;
using Workflow.Base.CQRS.Commands.Handler;
using Workflow.Base.CQRS.Query.Attributes;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.DDD.Infrastructure.Events;
using Workflow.Base.DDD.Infrastructure.Events.Implementation;
using Workflow.Base.DDD.Infrastructure.Sagas;
using Workflow.Base.DDD.Sagas;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Infrastructure.NHibernate;
using Workflow.Base.Infrastructure.NHibernate.Conventions;
using Castle.Facilities.Startable;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using NHibernate;
using Workflow.Basic.Presentation;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Base.CQRS.Commands.Attributes;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Dashboard.Infrastructure.Finders;
using Workflow.Base.DDD.Domain.Entities;
using Workflow.HR.Infrastructure.Repository;
using Workflow.Base.DDD.Application.Metadata;

namespace Workflow.Web.Api
{
    public class ContainerInit
    {
        public static WindsorContainer _container = new WindsorContainer();

        public static void RegisterDI()
        {
            AddResolversAndFacilities(_container);

            // Temp
            _container.Register(Classes.FromAssemblyContaining<SimpleEventPublisher>()
                                   .Where(x => x == typeof(SimpleEventPublisher))
                                   .WithServiceAllInterfaces()
                                   .LifestyleSingleton());

            // Register event component listeners
            // This line resolves IEventSubscriber
            _container.AddFacility<SubscribeEventListenerFacility>();

            _container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory))
                                   .Where(t => t.IsComponentLifestyle(ComponentLifestyle.Transient) ||
                                               t.IsDefined(typeof(DomainFactoryAttribute), true) ||
                                               t.IsDefined(typeof(DomainRepositoryImplementationAttribute), true) ||
                                               t.IsDefined(typeof(DomainServiceAttribute), true) ||
                                               t.IsDefined(typeof(FinderAttribute), true) ||
                                               t.IsDefined(typeof(ApplicationServiceAttribute), true))

                                   .WithServiceAllInterfaces()
                                   .WithServiceSelf()
                                   .LifestyleTransient()
                );

            _container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory))
                                   .Where(t => t.IsSaga())
                                   .WithServices(typeof(Saga))
                                   .WithServiceSelf()
                                   .LifestyleTransient());

            _container.Register(Component.For<ISagaFinderFactory>().AsFactory());

            _container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory))
                                   .Where(t => t.IsComponentLifestyle(ComponentLifestyle.Singleton))
                                   .StartIfNecessary()
                                   .WithServiceAllInterfaces()
                                   .WithServiceSelf()
                                   .LifestyleSingleton()
                );

            RegisterORMWeb(_container);

            RegisterStatefullComponents(_container);
            RegisterEventListeners(_container);


            RegisterCommandHandlers(_container);

            //_container.Resolve<ISagaEngine>();  
        }

        private static void RegisterORMWeb(IWindsorContainer container)
        {
            AutomappingConfiguration.IsEntityPredicate = t =>
                t.IsDefined(typeof(DomainEntityAttribute), true) ||
                t.IsDefined(typeof(SagaDataAttribute), true);

            AutomappingConfiguration.IsComponentPredicate =
                t => t.IsDefined(typeof(DomainValueObjectAttribute), true);
            EntityManager.GenerateSampleData = s => new SampleDataGenerator().Generate(s);
            EntityManager.GetAssemblies = () => new[]
                                                    {
                                                        typeof (B_ApplicationError).Assembly,
                                                        typeof (B_Events).Assembly,
                                                        typeof (EmployeesRepository).Assembly
                                                    };

            container.Register(Component.For<ISessionFactory>()
                                   .UsingFactoryMethod(() => EntityManager.SessionFactory)
                                   .LifestyleSingleton());

            container.Register(Component.For<ISession>()
                                   .UsingFactoryMethod(EntityManager.SessionFactory.OpenSession)
                                   .LifestylePerWebRequest());

            container.Register(Component.For<IPerRequestSessionFactory>()
                                   .AsFactory());

            container.Register(Component.For<IEntityManager>()
                                   .ImplementedBy<EntityManager>()
                                   .LifestyleSingleton());
        }

        private static void RegisterMvcControllers(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .LifestyleTransient());
        }

        private static void SetMvcContainer(IWindsorContainer container)
        {
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private static void RegisterStatefullComponents(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly()
                                   .Where(t => t.IsComponentLifestyle(ComponentLifestyle.PerSession))
                                   .WithServiceAllInterfaces()
                                   .WithServiceSelf()
                                   .LifestylePerSession());
        }

        private static void RegisterEventListeners(IWindsorContainer container)
        {

            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory))
                                   .Where(l => l.IsEventListener())
                                   .WithServiceAllInterfaces()
                                   .Configure(x => x.Start())
                                   .LifestyleSingleton());
        }

        private static void RegisterCommandHandlers(IWindsorContainer container)
        {
            // Register decorators
            container.Register(
                Component.For(typeof(ICommandHandler<>)).ImplementedBy(typeof(ExceptionCommandHandlerDecorator<>)),
                Component.For(typeof(ICommandHandler<>)).ImplementedBy(typeof(TransactionalCommandHandlerDecorator<>)),
                Component.For(typeof(ICommandHandler<>)).ImplementedBy(typeof(CommitNHibernateCommandHandlerDecorator<>)),
                Component.For(typeof(ICommandHandler<>)).ImplementedBy(typeof(ConatinerCommandHandlerDecorator<>))
                );

            foreach (var assembly in EntityManager.GetAssemblies())
            {
                foreach (var registration in from f in assembly.GetTypes()
                                             where f.IsClass
                                             from i in f.GetInterfaces()
                                             where
                                                 i.IsGenericType &&
                                                 i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
                                             let genericArgument = i.GetGenericArguments()[0]
                                             where !genericArgument.ContainsGenericParameters
                                             select new { Impl = f, Key = genericArgument.FullName })
                {
                    container.Register(Component.For<ICommandHandler>()
                                           .ImplementedBy(registration.Impl)
                                           .Named(registration.Key)
                                           .LifestyleTransient());
                }
            }
            container.Register(Component.For<ICommandHandlerFactory>()
                                   .AsFactory(f => f.SelectedWith(new CommandHandlerFactoryComponentSelector())));
        }

        private static void AddResolversAndFacilities(IWindsorContainer container)
        {
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            container.AddFacility<TypedFactoryFacility>();
            container.AddFacility<StartableFacility>();

            //container.Register(Component.For<IEmployeeFinder>()
            //                       .ImplementedBy<EmployeeFinder>()
            //                       .LifestyleSingleton());
        }
    }
}
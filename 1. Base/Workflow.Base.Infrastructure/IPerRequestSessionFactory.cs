using NHibernate;

namespace Workflow.Base.Infrastructure.NHibernate
{
    public interface IPerRequestSessionFactory
    {
        ISession Create();
    }
}
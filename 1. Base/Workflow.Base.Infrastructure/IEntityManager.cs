using NHibernate;

namespace Workflow.Base.Infrastructure.NHibernate
{
    public interface IEntityManager
    {
        ISession CurrentSession { get; }
    }
}
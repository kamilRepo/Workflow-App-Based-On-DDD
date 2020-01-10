using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Workflow.Base.Infrastructure.NHibernate.Conventions
{
    public class SetTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name);  //+ "s");
        }
    }
}
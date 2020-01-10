using System;
using Workflow.Base.DDD.Domain;
using Workflow.Base.DDD.Domain.Entities;
using Workflow.Base.DDD.Domain.Support;


namespace Workflow.Base.Infrastructure.NHibernate.Repositories
{
    public class GenericRepositoryForBaseEntity<TEntity> : GenericRepository<TEntity, int>
        where TEntity : Entity
    {
        public InjectorHelper InjectorHelper { get; set; }

        public override TEntity Load(int id)
        {
            TEntity entity = base.Load(id);
            if ( entity is AggregateRoot)
                InjectorHelper.InjectDependencies((AggregateRoot)(object)entity);

            return entity;
        }

        public void Delete(int id, int userId)
        {
            var muser = new B_User();
            muser.SetId(userId);

            TEntity entity = Load(id);
            entity.MarkAsRemoved();
            entity.SetMDate(DateTime.Now);
            entity.SetMUser(muser);
        }
    }
}
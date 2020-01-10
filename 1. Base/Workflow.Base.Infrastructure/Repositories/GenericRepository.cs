using System;
using System.Collections.Generic;
using Workflow.Base.DDD.Domain.Entities;
namespace Workflow.Base.Infrastructure.NHibernate.Repositories
{
    public class GenericRepository<TEntity, TKey> where TEntity : class
    {
        public IEntityManager EntityManager { get; set; }

        public virtual TEntity Load(TKey id)
        {
            return EntityManager.CurrentSession.Get<TEntity>(id);
        }

        public virtual IList<TEntity> GetAll()
        {
            return EntityManager.CurrentSession.QueryOver<TEntity>().List();
        }

        public virtual void Delete(TKey id)
        {
            EntityManager.CurrentSession.Delete(Load(id));
        }

        public virtual void Save(TEntity entity, int userId)
        {
            var user = new B_User();
            user.SetId(userId);
            var en = entity as Entity;
            if (en.Id == 0)
            {
                en.SetCDate(DateTime.Now);
                en.SetCUser(user);
            }
            else
            {
                en.SetMDate(DateTime.Now);
                en.SetMUser(user);
            }

            EntityManager.CurrentSession.SaveOrUpdate(entity);
        }

        public virtual void SaveAndFlush(TEntity entity, int userId)
        {
            var user = new B_User();
            user.SetId(userId);
            var en = entity as Entity;
            if (en.Id == 0)
            {
                en.SetCDate(DateTime.Now);
                en.SetCUser(user);
            }
            else
            {
                en.SetMDate(DateTime.Now);
                en.SetMUser(user);
            }

            EntityManager.CurrentSession.SaveOrUpdate(entity);
            EntityManager.CurrentSession.Flush();
        }

        public virtual void Flush()
        {
            EntityManager.CurrentSession.Flush();
        }
    }
}

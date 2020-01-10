using Workflow.Base.DDD.Domain.Annotations;
using System;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.DDD.Domain.Entities
{
    [DomainEntity]
    public abstract class Entity
    {
        public int Id { get; private set; }

        public EntityStatus Status { get; private set; }

        public B_User C_User { get; private set; }

        public Nullable<DateTime> C_Date { get; private set; }

        public B_User M_User { get; private set; }

        public Nullable<DateTime> M_Date { get; private set; }

        public void MarkAsRemoved()
        {
            Status = EntityStatus.Archived;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetCUser(B_User cuser)
        {
            C_User = cuser;
        }

        public void SetMUser(B_User muser)
        {
            M_User = muser;
        }

        public void SetCDate(Nullable<DateTime> cdate)
        {
            C_Date = cdate;
        }

        public void SetMDate(Nullable<DateTime> mdate)
        {
            M_Date = mdate;
        }
    }
}
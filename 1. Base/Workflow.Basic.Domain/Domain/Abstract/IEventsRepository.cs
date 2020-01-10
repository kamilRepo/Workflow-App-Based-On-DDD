using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Basic.Domain.Domain.Abstract
{
    public interface IEventsRepository
    {
        void Save(B_Events order, int userId);
        B_Events Load(int orderId);
    }
}

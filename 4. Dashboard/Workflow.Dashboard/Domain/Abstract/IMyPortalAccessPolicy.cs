﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Domain.Abstract
{
    public interface IMyPortalAccessPolicy
    {
        bool IsAccess(int userId);
    }
}
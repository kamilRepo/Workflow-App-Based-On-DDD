﻿using Workflow.Dashboard.Interface.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Abstract
{
    public interface IVacationsFinder
    {
        VacationsDto FindVacation(int employeeId, DateTime date);
    }
}

using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.HR.Interface.Application.Commands;
using Workflow.Base.CQRS.Commands;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class AddSalaryDeductionsController : BaseApiController
    {
        #region Query



        #endregion 
        #region Command

        public IDeductionsSalaryService _deductionsSalaryService;
        public IGate _gate;

        #endregion
        #region Dto



        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion

        #region Init

        public AddSalaryDeductionsController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _deductionsSalaryService = ContainerInit._container.Resolve<IDeductionsSalaryService>();
            _gate = ContainerInit._container.Resolve<IGate>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<SalaryDeductionsResultDto> AddSalaryDeductions([FromUri]SalaryDeductionsDto salaryDeductionsDto)
        {
            int id;
            var list = new List<SalaryDeductionsResultDto>();
            if(!string.IsNullOrEmpty(salaryDeductionsDto.FromDateST))
                salaryDeductionsDto.FromDate = Convert.ToDateTime(salaryDeductionsDto.FromDateST);
            if (!string.IsNullOrEmpty(salaryDeductionsDto.ToDateST))
                salaryDeductionsDto.ToDate = Convert.ToDateTime(salaryDeductionsDto.ToDateST);

            if (salaryDeductionsDto.Id == 0)
                id = SalaryDeductionsInsert(salaryDeductionsDto);
            else
                id = SalaryDeductionsUpdate(salaryDeductionsDto);

            list.Add(new SalaryDeductionsResultDto(id));

            return new Root<SalaryDeductionsResultDto> { Items = list }; 
        }

        #endregion
        #region Private

        public int SalaryDeductionsInsert(SalaryDeductionsDto salaryDeductionsDto)
        {
            var addDeductionsSalary = new AddDeductionsSalaryCommand(salaryDeductionsDto);
            _gate.Dispatch(addDeductionsSalary);

            return addDeductionsSalary.ReturnValue;
        }

        public int SalaryDeductionsUpdate(SalaryDeductionsDto salaryDeductionsDto)
        {
            _deductionsSalaryService.UpdateDeductionsSalary(salaryDeductionsDto);

            return salaryDeductionsDto.Id;
        }

        #endregion
    }
}
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.Abstract;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class DeleteSalaryDeductionsController : BaseApiController
    {
        #region Query



        #endregion 
        #region Command

        IDeductionsSalaryService _deductionsSalaryService;

        #endregion
        #region Dto



        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion

        #region Init

        public DeleteSalaryDeductionsController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _deductionsSalaryService = ContainerInit._container.Resolve<IDeductionsSalaryService>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<SalaryDeductionsResultDto> DeleteSalaryDeductions([FromUri]SalaryDeductionsDto salaryDeductionsDto)
        {
            var list = new List<SalaryDeductionsResultDto>();

            _deductionsSalaryService.DeleteDeductionsSalary(salaryDeductionsDto);

            list.Add(new SalaryDeductionsResultDto(salaryDeductionsDto.Id));

            return new Root<SalaryDeductionsResultDto> { Items = list }; 
        }

        #endregion
    }
}
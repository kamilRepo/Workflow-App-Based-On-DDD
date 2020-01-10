using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class SalaryDeductionsController : BaseApiController
    {
        #region Query

        ISalaryDeductionsFinder _salaryDeductionsFinder;

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

        public SalaryDeductionsController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _salaryDeductionsFinder = ContainerInit._container.Resolve<ISalaryDeductionsFinder>();
            _deductionsSalaryService = ContainerInit._container.Resolve<IDeductionsSalaryService>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<SalaryDeductionsDto> GetSalaryDeductions(int SalaryDeductionsType)
        {
            return new Root<SalaryDeductionsDto>
            {
                Items = _salaryDeductionsFinder.FindSalaryDeductions(SalaryDeductionsType, 0)
            };
        }

        [HttpGet]
        public Root<SalaryDeductionsDto> GetSalaryDeductions(int SalaryDeductionsType, int employeeId)
        {
            return new Root<SalaryDeductionsDto> { 
                Items = _salaryDeductionsFinder.FindSalaryDeductions(SalaryDeductionsType, employeeId) 
            };
        }

        [HttpPut]
        public Root<SalaryDeductionsResultDto> AddSalaryDeductions([FromUri]SalaryDeductionsDto salaryDeductionsDto)
        {
            int id;
            var list = new List<SalaryDeductionsResultDto>();

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
            return _deductionsSalaryService.AddDeductionsSalary(salaryDeductionsDto);
        }

        public int SalaryDeductionsUpdate(SalaryDeductionsDto salaryDeductionsDto)
        {
            _deductionsSalaryService.UpdateDeductionsSalary(salaryDeductionsDto);

            return salaryDeductionsDto.Id;
        }

        #endregion
    }
}
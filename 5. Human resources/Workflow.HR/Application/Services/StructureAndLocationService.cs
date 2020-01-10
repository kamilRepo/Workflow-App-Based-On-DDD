using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Workflow.Base.CQRS.Commands.Attributes;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.HR.Domain.Abstract;
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.DDD.Application.Metadata;

namespace Workflow.HR.Application.Services
{
    [ApplicationService]
    public class StructureAndLocationService : IStructureAndLocationService
    {
        #region Finders



        #endregion
        #region DomainServices



        #endregion
        #region AppServices



        #endregion
        #region Repositories

        public IEmployeeMembershipCoefficientsRepository EmployeeMembershipCoefficientsRepository { get; set; }

        #endregion

        #region IStructureAndLocationService members

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.StructureAndLocationServiceDeleteCoefficients, "DeleteCoefficients")]
        public StructureAndLocationResultDto DeleteCoefficients(StructureAndLocationDto structureAndLocationDto)
        {
            EmployeeMembershipCoefficientsRepository.Delete(structureAndLocationDto.Id, structureAndLocationDto.UserId);

            var result = new StructureAndLocationResultDto();
            result.Success = true;

            return result;
        }

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.StructureAndLocationServiceSaveCoefficients, "SaveCoefficients")]
        public StructureAndLocationResultDto SaveCoefficients(StructureAndLocationDto structureAndLocationDto)
        {
            B_EmployeeMembershipCoefficients coefficients; 
            B_OrganizationalUnit organizationalUnit = new B_OrganizationalUnit();
            B_OrganizationalCell organizationalCell = new B_OrganizationalCell();
            B_Silo silo = new B_Silo();

            organizationalUnit.SetId(structureAndLocationDto.OrganizationalUnitId);
            organizationalCell.SetId(structureAndLocationDto.OrganizationalCellId);
            silo.SetId(structureAndLocationDto.SiloId);

            if (structureAndLocationDto.Id == 0)
            {       
                var employee = new B_Employee();
                employee.SetId(structureAndLocationDto.EmployeeId);

                coefficients = new B_EmployeeMembershipCoefficients()
                {
                    Employee = employee,
                    FromDate = DateTime.Now,            
                };
            }
            else
                coefficients = EmployeeMembershipCoefficientsRepository.Load(structureAndLocationDto.Id);            

            coefficients.OrganizationalUnit = organizationalUnit;
            coefficients.OrganizationalCell = organizationalCell;
            coefficients.Silo = silo;
            coefficients.Coefficient = (float)structureAndLocationDto.Coefficient;

            EmployeeMembershipCoefficientsRepository.SaveAndFlush(coefficients, structureAndLocationDto.UserId);

            var result = new StructureAndLocationResultDto();
            result.Success = true;
            result.Id = coefficients.Id;

            return result;
        }

        #endregion
    }
}

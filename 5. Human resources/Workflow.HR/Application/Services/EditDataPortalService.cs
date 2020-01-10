using Workflow.Base.CQRS.Commands.Attributes;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.HR.Domain.Abstract;
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.DDD.Application.Metadata;

namespace Workflow.HR.Application.Services
{
    [ApplicationService]
    public class EditDataPortalService : IEditDataPortalService
    {
        #region Finders

        public IEmployeeFinder EmployeeFinder { get; set; }
        public IEmployeeMembershipFinder EmployeeMembershipFinder { get; set; }

        #endregion
        #region DomainServices



        #endregion
        #region AppServices



        #endregion
        #region Repositories

        public IEmployeesAddressRepository EmployeesAddressRepository { get; set; }
        public IEmployeesRepository EmployeesRepository { get; set; }
        public IEmployeeMembershipRepository EmployeeMembershipRepository { get; set; }

        #endregion

        #region IEditDataPortalService members

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.EditDataPortalServiceEditDataPortal, "EditDataPortal")]
        public EditDataPortalResultDto EditDataPortal(EditDataPortalResultDto editDataPortalResultDto)
        {
            B_EmployeeAddress employeeAddress;
            B_EmployeeAddress employeeAddressCo;

            var employee = EmployeesRepository.Load(editDataPortalResultDto.EmployeeId);
            var listEmployeeAddress = EmployeeFinder.FindEmployeeAdress(editDataPortalResultDto.EmployeeId);
            var addressCoDto = listEmployeeAddress.Where(x => x.IsCorrespondence == true).FirstOrDefault();
            var addressDto = listEmployeeAddress.Where(x => x.IsCorrespondence == false).FirstOrDefault();

            employee.PhoneNumber = editDataPortalResultDto.PhoneNumber;
            employee.MobilePhoneNumber = editDataPortalResultDto.MobilePhoneNumber;
            employee.Email = editDataPortalResultDto.Email;
            employee.Pesel = editDataPortalResultDto.Pesel;
            employee.Education = editDataPortalResultDto.Education;

            EmployeesRepository.SaveAndFlush(employee, editDataPortalResultDto.UserId);

            employeeAddress= EmployeesAddressRepository.Load(addressDto.Id);
            employeeAddress.Employee = employee;
            employeeAddress.Street = editDataPortalResultDto.Street;
            employeeAddress.BuildingNo = editDataPortalResultDto.BuildingNo;
            employeeAddress.LocalNo = editDataPortalResultDto.LocalNo;
            employeeAddress.PostalCode = editDataPortalResultDto.PostalCode;
            employeeAddress.City = editDataPortalResultDto.City;
            employeeAddress.PostOffice = editDataPortalResultDto.PostOffice;
            employeeAddress.IsCorrespondence = false;

            if (addressCoDto == null)
                employeeAddressCo = new B_EmployeeAddress();            
            else
                employeeAddressCo = EmployeesAddressRepository.Load(addressCoDto.Id);

            employeeAddressCo.Employee = employee;
            employeeAddressCo.Street = editDataPortalResultDto.StreetCo;
            employeeAddressCo.BuildingNo = editDataPortalResultDto.BuildingNoCo;
            employeeAddressCo.LocalNo = editDataPortalResultDto.LocalNoCo;
            employeeAddressCo.PostalCode = editDataPortalResultDto.PostalCodeCo;
            employeeAddressCo.City = editDataPortalResultDto.CityCo;
            employeeAddressCo.PostOffice = editDataPortalResultDto.PostOfficeCo;
            employeeAddressCo.IsCorrespondence = true;

            EmployeesAddressRepository.SaveAndFlush(employeeAddress, editDataPortalResultDto.UserId);
            EmployeesAddressRepository.SaveAndFlush(employeeAddressCo, editDataPortalResultDto.UserId);

            editDataPortalResultDto.Success = true;

            return editDataPortalResultDto;
        }

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.EditDataPortalServiceEditAllocationStructure, "EditAllocationStructure")]
        public EditAllocationStructureResultDto EditAllocationStructure(EditAllocationStructureResultDto editAllocationStructureResultDto)
        {
            var employeeMembership = EmployeeMembershipRepository.Load(editAllocationStructureResultDto.EmployeeMembershipId);

            var section = new B_Section();
            var organizationalCell = new B_OrganizationalCell();
            var organizationalUnit = new B_OrganizationalUnit();
            var employee = new B_Employee();

            section.SetId(editAllocationStructureResultDto.SectionId);
            organizationalUnit.SetId(editAllocationStructureResultDto.OrganizationalUnitId);
            organizationalCell.SetId(editAllocationStructureResultDto.OrganizationalCellId);
            employee.SetId(editAllocationStructureResultDto.DirectSupervisorId);

            if (editAllocationStructureResultDto.SectionId == 0)
                section = null;
            if (editAllocationStructureResultDto.OrganizationalCellId == 0)
                organizationalCell = null;
            if (editAllocationStructureResultDto.OrganizationalUnitId == 0)
                organizationalUnit = null;
            if (editAllocationStructureResultDto.DirectSupervisorId == 0)
                employee = null;

            employeeMembership.Position = editAllocationStructureResultDto.Position;
            employeeMembership.Section = section;
            employeeMembership.OrganizationalCell = organizationalCell;
            employeeMembership.OrganizationalUnit = organizationalUnit;
            employeeMembership.DirectSupervisor = employee;

            EmployeeMembershipRepository.SaveAndFlush(employeeMembership, editAllocationStructureResultDto.UserId);

            editAllocationStructureResultDto.Success = true;

            return editAllocationStructureResultDto;
        }

        #endregion
    }
}

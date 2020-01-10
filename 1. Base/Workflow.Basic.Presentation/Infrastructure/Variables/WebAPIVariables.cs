using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Basic.Presentation.Infrastructure
{
    public static class WebAPIVariables
    {
        #region CardIndex

        public static readonly string employee = "CardIndex/Employee";
        public static readonly string employeeAddress = "CardIndex/EmployeeAddress";
        public static readonly string employeeContract = "CardIndex/EmployeeContract";
        public static readonly string employeeMembership = "CardIndex/EmployeeMembership";
        public static readonly string employeeSalary = "CardIndex/EmployeeSalary";
        public static readonly string myPortal = "CardIndex/MyPortal";
        public static readonly string organizationalCells = "CardIndex/OrganizationalCells";
        public static readonly string organizationalUnits = "CardIndex/OrganizationalUnits";
        public static readonly string searchEmployee = "CardIndex/SearchEmployee";
        public static readonly string sections = "CardIndex/Sections";
        public static readonly string vacation = "CardIndex/Vacation";
        public static readonly string works = "CardIndex/Works";
        public static readonly string productSection = "CardIndex/ProductSection";
        public static readonly string placeWhereCostsArise = "CardIndex/PlaceWhereCostsArise";
        public static readonly string szparta = "CardIndex/Szparta";

        #endregion 
        #region ApplicationHR

        public static readonly string addSalaryDeductions = "ApplicationsHR/AddSalaryDeductions";
        public static readonly string deleteSalaryDeductions = "ApplicationsHR/DeleteSalaryDeductions";
        public static readonly string salaryDeductions = "ApplicationsHR/SalaryDeductions";
        public static readonly string deleteCoefficients = "ApplicationsHR/DeleteCoefficients";
        public static readonly string editDataPortal = "ApplicationsHR/EditDataPortal";
        public static readonly string structureAndLocation = "ApplicationsHR/StructureAndLocation";
        public static readonly string editAllocationStructure = "ApplicationsHR/EditAllocationStructure";
        public static readonly string saveCoefficients = "ApplicationsHR/SaveCoefficients";
        
        #endregion
    }
}

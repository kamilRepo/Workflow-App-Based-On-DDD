namespace Workflow.Base.Interface.Domain.Dictionaries
{
    public enum ErrorNumbers : long
    {
        //Znaczenie błędów - znajduje się w TFS w pliku "Błędy oznaczenia.docx" w katalogu "Documentations"

        #region User error numbers

        WorkflowWebAppLifestylePerSession = 1010001011,

        #endregion
        #region Application error numbers

        EmployeeFinderFindEmployee = 1010001012,
        EmployeeFinderFindEmployees = 2010001012,
        EmployeeFinderFindEmployeeMembership = 3010001012,
        EmployeeFinderFindEmployeeAccessSystems = 4010001012,
        UnhandledException = 5010001012,
        VacationsFinderFindVacation = 6010001012,
        PersonalInformationGetData = 7010001012,
        EmployeeListGetData = 8010001012,
        EmployeeGetData = 9010001012,
        EmployeeFinderFindEmployeeAdress = 10010001012,
        MyPortalFinancesGetData = 11010001012,
        DictionaryFinderFindPosition = 12010001012,
        DictionaryFinderFindSection = 13010001012,
        DictionaryFinderFindOrganizationalUnit = 14010001012,
        DictionaryFinderFindOrganizationalCell = 15010001012,
        SearchEmployeeGetData = 16010001012,
        MyPortalGetData = 17010001012,
        MyEmployeeGetData = 18010001012,
        EmployeeSalaryFinderFindEmployeeSalary = 19010001012,
        EmployeeContractFinderFindEmployeeContract = 20010001012,
        MyPortalAccessPolicyFactoryCreateMyPortalAccessPolicy = 21010001012,
        EmployeeMembershipFinderFindDirectSupervisorId = 22010001012,
        MyPortalServiceCheckAccessPolicy = 23010001012,
        WUC_SearchEmployeesGetData = 24010001012,
        WUC_SearchEmployeesbtn_SearchFor_Click = 25010001012,
        WUC_SearchEmployeesGv_EmployeeList_PageIndexChanging = 26010001012,
        SalaryDeductionsFinderFindSalaryDeductions = 27010001012,
        DeductionsSalaryServiceAddDeductionsSalary = 28010001012,
        DeductionsSalaryServiceUpdateDeductionsSalary = 29010001012,
        DeductionsSalaryServiceDeleteDeductionsSalary = 30010001012,
        SearchEmployeesGetData = 31010001012,
        EditDataPortalServiceEditDataPortal = 32010001012,
        ApplicationsHRMyPortalGetData = 33010001012,
        DictionaryFinderFindWorks = 34010001012,
        EditDataPortalServiceEditAllocationStructure = 35010001012,
        EmployeeMembershipFinderFindBranchOrganizationalCellId = 36010001012,
        DictionaryFinderFindProductSection = 37010001012,
        DictionaryFinderFindPlaceWhereCostsArise = 38010001012,
        ApplicationsHRStructureAndLocationGetData = 39010001012,
        DictionaryFinderFindSilo = 40010001012,
        StructureAndLocationFinderFindStructureEmployee = 41010001012,
        StructureAndLocationServiceDeleteCoefficients = 42010001012,
        StructureAndLocationServiceSaveCoefficients = 43010001012,
        AddDeductionsSalaryCommand = 44010001012,
        ErrorView = 45010001012,
        AccountLoginCommand = 46010001012,
        RolesFinderFindRoles = 47010001012,
        RolesFinderFindUserRoles = 48010001012

        #endregion
    }
}

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CardIndex/Shared/CardIndexMainLayout.master" AutoEventWireup="true" CodeBehind="MyPortalFinances.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.CardIndex.MyPortalFinances" %>

<%@ Register TagPrefix="uc_dfs" TagName="DeductionsFromSalary" Src="~/Views/CardIndex/Shared/DeductionsFromSalary.ascx" %>
<%@ Register TagPrefix="uc_dz" TagName="DeductionsZFSS" Src="~/Views/CardIndex/Shared/DeductionsZFSS.ascx" %>
<%@ Register TagPrefix="uc_dlo" TagName="DeductionsLoansOther" Src="~/Views/CardIndex/Shared/DeductionsLoansOther.ascx" %>
<%@ Register TagPrefix="uc_dcc" TagName="DeductionsCompanyCar" Src="~/Views/CardIndex/Shared/DeductionsCompanyCar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong>
        <asp:Label ID="lbl_nameSurname" CssClass="username" runat="server" Text="" style="text-transform: uppercase"></asp:Label>
    </strong>
    <div class="user-number">
        (<asp:Label ID="lbl_No" runat="server" Text="<%$ Resources: Common, No %>"></asp:Label>: 
                    <asp:Label ID="lbl_EmployeeNumber" runat="server" Text=""></asp:Label>)
    </div>
    <div class="clearfix"></div>

    <asp:Label ID="lbl_Position" CssClass="place" runat="server" Text=""></asp:Label><br />
    <br />
    <div class="menu-contener">
        <div class="btn-group" role="group" aria-label="...">
            <asp:Button ID="lnk_BasicSalary" runat="server" Text="<%$ Resources: Common, BasicSalary %>" class="btn btn-default" OnClick="lnk_BasicSalary_Click"></asp:Button>
            <asp:Button ID="lnk_Deductions" runat="server" Text="<%$ Resources: Common, Deductions %>" class="btn btn-default" OnClick="lnk_Deductions_Click"></asp:Button>
            <asp:Button ID="lnk_Contracts" runat="server" Text="<%$ Resources: Common, Contracts %>" class="btn btn-default" OnClick="lnk_Contracts_Click"></asp:Button>
        </div>
    </div>

    <asp:Panel ID="pnl_BasicSalary" runat="server">
        <br />
        <h3>
            <asp:Label ID="lbl_RemunerationCurrentPeriodLabel" runat="server" Text="<%$ Resources: CardIndex, RemunerationCurrentPeriodLabel %>"></asp:Label></h3>
        <br />
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>
                        <asp:Label ID="lbl_ComponentRemunerationLabel" runat="server" Text="<%$ Resources: CardIndex, ComponentRemunerationLabel %>"></asp:Label></th>
                    <th class="text-right">
                        <asp:Label ID="lbl_AmountLabel" runat="server" Text="<%$ Resources: Common, AmountLabel %>"></asp:Label></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="lbl_BaseSalaryLabel" runat="server" Text="<%$ Resources: CardIndex, BaseSalary %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_BaseSalary" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_DiscretionaryBonusLabel" runat="server" Text="<%$ Resources: CardIndex, DiscretionaryBonus %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_DiscretionaryBonus" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_MasterBonusLabel" runat="server" Text="<%$ Resources: CardIndex, MasterBonus %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_MasterBonus" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_BonusLabel" runat="server" Text="<%$ Resources: CardIndex, Bonus %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_Bonus" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_EquivalentVacationLabel" runat="server" Text="<%$ Resources: CardIndex, EquivalentVacationLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_EquivalentVacation" runat="server" Text=""></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnl_Deductions" runat="server" Visible="false">
        <br />
    <div class="container-fluid">
        <div class="row">
            
            <div class="menu-contener">
                <div class="btn-group" role="group" aria-label="...">
                    <asp:Button ID="lnk_Hestia" runat="server" Text="<%$ Resources: HR, Hestia %>" class="btn btn-default" OnClick="lnk_Hestia_Click"></asp:Button>
                    <asp:Button ID="lnk_MedicalCare" runat="server" Text="<%$ Resources: HR, MedicalCare %>" class="btn btn-default" OnClick="lnk_MedicalCare_Click"></asp:Button>
                    <asp:Button ID="lnk_PZUInsurance" runat="server" Text="<%$ Resources: HR, PZUInsurance %>" class="btn btn-default" OnClick="lnk_PZUInsurance_Click"></asp:Button>
                    <asp:Button ID="lnk_ZFSS" runat="server" Text="<%$ Resources: HR, ZFSS %>" class="btn btn-default" OnClick="lnk_ZFSS_Click"></asp:Button>
                    <asp:Button ID="lnk_LoansOther" runat="server" Text="<%$ Resources: HR, LoansOther %>" class="btn btn-default" OnClick="lnk_LoansOther_Click"></asp:Button>
                    <asp:Button ID="lnk_Multisport" runat="server" Text="<%$ Resources: HR, Multisport %>" class="btn btn-default" OnClick="lnk_Multisport_Click"></asp:Button>
                    <asp:Button ID="lnk_CompanyCar" runat="server" Text="<%$ Resources: HR, CompanyCar %>" class="btn btn-default" OnClick="lnk_CompanyCar_Click"></asp:Button>
                </div>
            </div>
        </div>
        <div class="row">
            <br />
            <uc_dfs:DeductionsFromSalary ID="uc_DeductionsFromSalary" runat="server" />
            <uc_dz:DeductionsZFSS ID="uc_DeductionsZFSS" runat="server" />
            <uc_dlo:DeductionsLoansOther ID="uc_DeductionsLoansOther" runat="server" />
            <uc_dcc:DeductionsCompanyCar ID="uc_DeductionsCompanyCar" runat="server" />
        </div>
    </div>
    </asp:Panel>

    <asp:Panel ID="pnl_Contracts" runat="server" Visible="false">
        <br />
        <br />
        <table class="table table-striped">
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="lbl_TypeEmploymentContractLabel" runat="server" Text="<%$ Resources: CardIndex, TypeEmploymentContractLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_TypeEmploymentContract" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_DimensionTimeLabel" runat="server" Text="<%$ Resources: CardIndex, DimensionTimeLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_DimensionTime" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_DateAgreementLabel" runat="server" Text="<%$ Resources: CardIndex, DateAgreementLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_DateAgreement" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_EndDateContractLabel" runat="server" Text="<%$ Resources: CardIndex, EndDateContractLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_EndDateContract" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_DateDismissalLabel" runat="server" Text="<%$ Resources: CardIndex, DateDismissalLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_DateDismissal" runat="server" Text=""></asp:Label></td>
                </tr>                
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>

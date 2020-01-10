<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ApplicationsHR/Shared/ApplicationHRMainLayout.master" AutoEventWireup="true" CodeBehind="MyPortalFinances.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.MyPortalFinances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong>
        <asp:Label ID="lbl_nameSurname" CssClass="username" runat="server" Text=""></asp:Label>
    </strong>
    <div class="user-number">
        (<asp:Label ID="lbl_No" runat="server" Text="<%$ Resources: Common, No %>"></asp:Label>: 
                    <asp:Label ID="lbl_EmployeeNumber" runat="server" Text=""></asp:Label>)
    </div>
    <div class="clearfix"></div>

    <asp:Label ID="lbl_Position" CssClass="place" runat="server" Text=""></asp:Label><br />
    <br />
    <asp:Label ID="lbl_PhoneNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, PhoneNumberLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_PhoneNumber" CssClass="row-desc" runat="server" Text=""></asp:Label><br />
    <div class="divider"></div>
    <asp:Label ID="lbl_MobileNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, MobileNumberLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_MobileNumber" CssClass="row-desc" runat="server" Text=""></asp:Label><br />
    <div class="divider"></div>
    <asp:Label ID="lbl_EmailLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, EmailLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_Email" CssClass="row-desc" runat="server" Text=""></asp:Label><br />
    <br />
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
                    <th>
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
        <asp:Label ID="Label1" runat="server" Text="Deductions"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
    </asp:Panel>

    <asp:Panel ID="pnl_Contracts" runat="server" Visible="false">
        <br />
        <br />
        <table class="table table-striped">
            <tbody>
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
                <tr>
                    <td>
                        <asp:Label ID="lbl_TypeEmploymentContractLabel" runat="server" Text="<%$ Resources: CardIndex, TypeEmploymentContractLabel %>"></asp:Label></td>
                    <td class="text-right">
                        <asp:Label ID="lbl_TypeEmploymentContract" runat="server" Text=""></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>

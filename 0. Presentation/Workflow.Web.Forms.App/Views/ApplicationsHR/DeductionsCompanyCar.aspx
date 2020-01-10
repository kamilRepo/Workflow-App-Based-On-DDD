<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ApplicationsHR/Shared/DeductionsFromSalaryMainLayout.master" AutoEventWireup="true" CodeBehind="DeductionsCompanyCar.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.DeductionsCompanyCar" %>
<%@ Register TagPrefix="uc" TagName="SearchEmployees" Src="~/Views/Shared/Partials/WUC_SearchEmployees.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
    <style>
        .panel-primary {
            width: 750px;
        }

        .modal-content {
            width: 850px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView ID="gv_Deductions" runat="server" AutoGenerateColumns="False"
             OnRowCommand="gv_Deductions_RowCommand" CssClass="table table-hover table-bordered table-striped">
            <Columns>
                <asp:TemplateField HeaderText="Id" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                    <ItemTemplate>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EmployeeIdId" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                    <ItemTemplate>
                        <asp:Label ID="EmployeeIdLabel" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, EmployeeNumberLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="EmployeeNumberLabel" runat="server" Text='<%# Eval("EmployeeNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, SurnameName %>">
                    <ItemTemplate>
                        <asp:Label ID="LastFirstNameLabel" runat="server" Text='<%# Eval("LastFirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, RegistrationNumberLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="RegistrationNumberLabel" runat="server" Text='<%# Eval("RegistrationNumber") %>'></asp:Label>
                        <asp:TextBox ID="RegistrationNumber" runat="server" Text='<%# Eval("RegistrationNumber") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, FromDate %>">
                    <ItemTemplate>
                        <asp:Label ID="FromDateSTLabel" runat="server" Text='<%# Eval("FromDateST") %>'></asp:Label>
                        <asp:TextBox ID="FromDateST" runat="server" Text='<%# Eval("FromDateST") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, ToDate %>">
                    <ItemTemplate>
                        <asp:Label ID="ToDateSTLabel" runat="server" Text='<%# Eval("ToDateST") %>'></asp:Label>
                        <asp:TextBox ID="ToDateST" runat="server" Text='<%# Eval("ToDateST") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, AmountLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                        <asp:TextBox ID="Amount" runat="server" Text='<%# Eval("Amount") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_Edit" CssClass="edit-row" runat="server" Text="<%$ Resources: Common, Edit %>" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="CommandEdit"/>
                            <asp:LinkButton ID="btn_Delete" CssClass="delete-row" runat="server" Text="<%$ Resources: Common, Delete %>"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="CommandDelete"/>
                            <asp:LinkButton ID="btn_Save" CssClass="save-row" runat="server" Text="<%$ Resources: Common, Save %>"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="CommandSave" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#myModal">
            <asp:Label ID="lbl_AddEmployeeInsurance" runat="server" Text="<%$ Resources: Common, Add %>"></asp:Label>
        </button>
        <p>
            <asp:LinkButton runat="server" ID="AddRow" Text="Add Row" OnClick="AddRow_Click" style="display:none;"></asp:LinkButton>
        </p>
        <asp:UpdatePanel ID="up_SearchForss" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hf_EmployeeID" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <uc:SearchEmployees ID="WUC_SearchEmployees" runat="server" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ApplicationsHR/Shared/ApplicationHRMainLayout.master" AutoEventWireup="true" CodeBehind="MyEmployee.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.MyEmployee" %>
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
    <div class="menu-contener">
        <div class="btn-group" role="group" aria-label="...">
            <asp:Label ID="lbl_DirectReports"  runat="server" Text="<%$ Resources: CardIndex, DirectReports %>" class="btn btn-default"></asp:Label><br />
        </div>
    </div>
    <br />
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
                <asp:TemplateField ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_Delete" CssClass="delete-row" runat="server" Text="<%$ Resources: Common, Delete %>"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="CommandDelete"/>
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




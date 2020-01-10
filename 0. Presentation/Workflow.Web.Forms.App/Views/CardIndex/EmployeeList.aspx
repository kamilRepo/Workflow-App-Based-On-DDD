<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Mercedes.WebApp.Views.CardIndex.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="row">        
        <div class="col-sm-4 col-md-4">
            <asp:TextBox ID="tb_Search" runat="server" class="form-control" placeholder="<%$ Resources:Common, Search %>"></asp:TextBox>
        </div>
        <div class="col-sm-2 col-md-2">
            <asp:Button ID="btn_Search" runat="server" Text="<%$ Resources:Common, Search %>" CssClass="btn btn-primary" OnClick="btn_Search_Click"/>
        </div>
    </div>
    <br />
    <asp:GridView ID="gv_EmployeeList" runat="server" AutoGenerateColumns="false" AllowPaging="True" EmptyDataText="<%$ Resources:Common,NoItems %>"
        OnRowCommand="gv_EmployeeList_RowCommand"
        OnPageIndexChanging="gv_EmployeeList_PageIndexChanging" 
        CssClass="table table-hover table-striped" PageSize="5">
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<%$ Resources:Common,First %>" LastPageText="<%$ Resources:Common,Last %>" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                <ItemStyle CssClass="hiden" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btn_Check"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        CommandName="Check" runat="server" Text="<%$ Resources:Common, Check %>" CssClass="btn btn-primary" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SurnameName" HeaderText="<%$ Resources:Common, SurnameName %>" ReadOnly="true" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="<%$ Resources:Common, PhoneNumberLabel %>" ReadOnly="true" />
            <asp:BoundField DataField="MobileNumber" HeaderText="<%$ Resources:Common, MobileNumberLabel %>" ReadOnly="true" />
            <asp:BoundField DataField="Email" HeaderText="<%$ Resources:Common, EmailLabel %>" ReadOnly="true" />
        </Columns>
    </asp:GridView>
</asp:Content>


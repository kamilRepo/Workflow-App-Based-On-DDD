<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchEmployees.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.SearchEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-search"></span>
                <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">

            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_FirstNameLabel" runat="server" Text="<%$ Resources: Common, FirstNameLabel %>"></asp:Label>
                </label>
                <asp:TextBox ID="tb_FirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_LastNameLabel" runat="server" Text="<%$ Resources: Common, LastNameLabel %>"></asp:Label>
                </label>
                <asp:TextBox ID="tb_LastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_PositionLabel" runat="server" Text="<%$ Resources: Common, PositionLabel %>"></asp:Label>
                </label>
                <asp:TextBox ID="tb_Position" runat="server" CssClass="form-control"></asp:TextBox>
            </div>



            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_SectionLabel" runat="server" Text="<%$ Resources: Common, SectionLabel %>"></asp:Label>
                </label>
                <asp:DropDownList ID="ddl_Section" runat="server" CssClass="form-control">
                    <asp:ListItem
                        Text="string"
                        Value="string" />
                </asp:DropDownList>
            </div>
            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_OrganizationalUnitLabel" runat="server" Text="<%$ Resources: Common, OrganizationalUnitLabel %>"></asp:Label>
                </label>
                <asp:DropDownList ID="ddl_OrganizationalUnit" runat="server" CssClass="form-control">
                    <asp:ListItem
                        Text="string"
                        Value="string" />
                </asp:DropDownList>
            </div>
            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_OrganizationalCellLabel" runat="server" Text="<%$ Resources: Common, OrganizationalCellLabel %>"></asp:Label>
                </label>
                <asp:DropDownList ID="ddl_OrganizationalCell" runat="server" CssClass="form-control">
                    <asp:ListItem
                        Text="string"
                        Value="string" />
                </asp:DropDownList>
            </div>
            <div class="form-group col-xs-8 col-sm-4">
                <label>
                    <asp:Label ID="lbl_EmployeeNumberLabel" runat="server" Text="<%$ Resources: Common, EmployeeNumberLabel %>"></asp:Label>
                </label>
                <asp:TextBox ID="tb_EmployeeNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="clearfix"></div>

            <div class="col-xs-5 col-xs-offset-7" style="text-align: right">
                <asp:Button ID="btn_Clear" runat="server" Text="<%$ Resources: Common, Clear %>" OnClick="btn_Clear_Click" class="btn btn-default right" UseSubmitBehavior="false" />
                <asp:Button ID="btn_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>" OnClick="btn_SearchFor_Click" class="btn btn-primary right" />
            </div>

        </div>
    </div>
    <asp:Panel ID="pnl_SearchResults" runat="server" Visible="false">
        <div class="panel panel-gray">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <span class="glyphicon glyphicon-list"></span>
                    <asp:Label ID="lbl_SearchResults" runat="server" Text="<%$ Resources: Common, SearchResults %>"></asp:Label>
                </h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gv_EmployeeList" runat="server" ShowHeader="False" AutoGenerateColumns="false"
                    AllowPaging="True" EmptyDataText="<%$ Resources:Common,NoItems %>" BorderStyle="None" GridLines="None"
                    OnRowCommand="gv_EmployeeList_RowCommand"
                    OnPageIndexChanging="gv_EmployeeList_PageIndexChanging"
                    OnRowDataBound="gv_EmployeeList_RowDataBound"
                    CssClass="table table-hover table-striped employee-list" PageSize="5">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<%$ Resources:Common,First %>" LastPageText="<%$ Resources:Common,Last %>" />
                    <PagerStyle CssClass="pagination" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                            <ItemStyle CssClass="hiden" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Check"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    CommandName="Check" runat="server" CssClass="btn btn-primary thumbnail"
                                    alt="<%$ Resources: Common, Lack %>" Height="100" Width="100" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="GridValue" ReadOnly="true" HtmlEncode="false" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

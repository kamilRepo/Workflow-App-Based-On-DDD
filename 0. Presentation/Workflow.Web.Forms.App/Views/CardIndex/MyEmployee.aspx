<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CardIndex/Shared/CardIndexMainLayout.master" AutoEventWireup="true" CodeBehind="MyEmployee.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.CardIndex.MyEmployee" %>

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
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-search"></span><asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <table class="table">
                <tbody>
                    <tr>
                        <td><asp:Label ID="lbl_FirstNameLabel" runat="server" Text="<%$ Resources: Common, FirstNameLabel %>"></asp:Label></td>
                        <td><asp:TextBox ID="tb_FirstName" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td><asp:Label ID="lbl_LastNameLabel" runat="server" Text="<%$ Resources: Common, LastNameLabel %>"></asp:Label></td>
                        <td><asp:TextBox ID="tb_LastName" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbl_SectionLabel" runat="server" Text="<%$ Resources: Common, SectionLabel %>"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_Section" runat="server" CssClass="form-control">
                                <asp:ListItem
                                    Text="string"
                                    Value="string" />
                            </asp:DropDownList>
                        </td>
                        <td><asp:Label ID="lbl_OrganizationalUnitLabel" runat="server" Text="<%$ Resources: Common, OrganizationalUnitLabel %>"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_OrganizationalUnit" runat="server" CssClass="form-control">
                                <asp:ListItem
                                    Text="string"
                                    Value="string" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbl_OrganizationalCellLabel" runat="server" Text="<%$ Resources: Common, OrganizationalCellLabel %>"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_OrganizationalCell" runat="server" CssClass="form-control">
                                <asp:ListItem
                                    Text="string"
                                    Value="string" />
                            </asp:DropDownList>
                        </td>
                        <td><asp:Label ID="lbl_EmployeeNumberLabel" runat="server" Text="<%$ Resources: Common, EmployeeNumberLabel %>"></asp:Label></td>
                        <td><asp:TextBox ID="tb_EmployeeNumber" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class="text-right">
                            <asp:Button ID="btn_Clear" runat="server" Text="<%$ Resources: Common, Clear %>" OnClick="btn_Clear_Click" class="btn btn-default right" UseSubmitBehavior="false" />
                            <asp:Button ID="btn_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>" OnClick="btn_SearchFor_Click" class="btn btn-primary right" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:Panel ID="pnl_EmployeeList" runat="server">
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-list"></span><asp:Label ID="lbl_SearchResults" runat="server" Text="<%$ Resources: Common, SearchResults %>"></asp:Label>
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
                <PagerStyle CssClass="pagination" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"/>
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                        <ItemStyle CssClass="hiden" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_Check"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="Check" runat="server" CssClass="btn btn-primary"
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

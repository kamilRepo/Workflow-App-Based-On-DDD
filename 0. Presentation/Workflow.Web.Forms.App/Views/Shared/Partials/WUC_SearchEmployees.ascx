<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUC_SearchEmployees.ascx.cs" Inherits="Workflow.Web.Forms.App.Views.Shared.Partials.WUC_SearchEmployees" %>

<script>
    function AddDeduction() {
        var clickButton = document.getElementById("<%= btn_CloseLabel.ClientID %>");
        clickButton.click(); 
        var clickButton = document.getElementById("MainContent_MainContent_AddRow");
        clickButton.click();
    }
</script>

<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">
                    <span class="glyphicon glyphicon-search"></span><asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>"></asp:Label>
                </h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="up_SearchFor" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_FirstNameLabel" runat="server" Text="<%$ Resources: Common, FirstNameLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="tb_FirstName" CssClass="form-control" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="lbl_LastNameLabel" runat="server" Text="<%$ Resources: Common, LastNameLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="tb_LastName" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_SectionLabel" runat="server" Text="<%$ Resources: Common, SectionLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Section" runat="server" CssClass="form-control">
                                            <asp:ListItem
                                                Text="string"
                                                Value="string" />
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_OrganizationalUnitLabel" runat="server" Text="<%$ Resources: Common, OrganizationalUnitLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_OrganizationalUnit" CssClass="form-control" runat="server">
                                            <asp:ListItem
                                                Text="string"
                                                Value="string" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_OrganizationalCellLabel" runat="server" Text="<%$ Resources: Common, OrganizationalCellLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_OrganizationalCell" CssClass="form-control" runat="server">
                                            <asp:ListItem
                                                Text="string"
                                                Value="string" />
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_EmployeeNumberLabel" runat="server" Text="<%$ Resources: Common, EmployeeNumberLabel %>"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="tb_EmployeeNumber" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        
                                        <asp:Button ID="btn_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>" OnClick="btn_SearchFor_Click" class="btn btn-primary pull-right" UseSubmitBehavior="false" CausesValidation="False" ValidationGroup="changeNameGroup"/>
                                        <asp:Button ID="btn_Clear" runat="server" Text="<%$ Resources: Common, Clear %>" OnClick="btn_Clear_Click" class="btn btn-default pull-right" UseSubmitBehavior="false" CausesValidation="False" ValidationGroup="changeNameGroup" style="margin-right: 10px;"/>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="panel panel-gray">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <asp:Label ID="lbl_SearchResults" runat="server" Text="<%$ Resources: Common, SearchResults %>"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="gv_EmployeeList" runat="server" ShowHeader="False" AutoGenerateColumns="false"
                                    AllowPaging="True" EmptyDataText="<%$ Resources:Common,NoItems %>" BorderStyle="None" GridLines="None"
                                    OnRowCommand="gv_EmployeeList_RowCommand"
                                    OnPageIndexChanging="gv_EmployeeList_PageIndexChanging"
                                    OnRowDataBound="gv_EmployeeList_RowDataBound"
                                    CssClass="table table-hover table-striped employee-list" PageSize="3">
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
                                                    alt="<%$ Resources: Common, Lack %>" Height="100" Width="100" 
                                                    OnClientClick="AddDeduction()"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GridValue" ReadOnly="true" HtmlEncode="false" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btn_CloseLabel" runat="server" Text="<%$ Resources: Common, CloseLabel %>" type="button" class="btn btn-default" data-dismiss="modal"/>
            </div>
        </div>
    </div>
</div>

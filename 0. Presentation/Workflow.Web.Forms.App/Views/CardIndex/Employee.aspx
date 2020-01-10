<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Workflow.Web.Forms.App.Employee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-envelope"></span>
                <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, ContactDetails %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="col-sm-2 col-md-2">
                <div class="thumbnail">
                    <asp:Image ID="btn_Image" runat="server" alt="<%$ Resources: Common, Lack %>" Height="120" Width="120" />
                </div>
            </div>
            <div class="col-sm-8 col-md-8">
                <strong>
                    <div style="text-transform: uppercase">
                        <asp:Label ID="lbl_nameSurname" CssClass="username" runat="server" Text=""></asp:Label>
                    </div>
                </strong>
                <div class="user-number">
                    (<asp:Label ID="lbl_No" runat="server" Text="<%$ Resources: Common, No %>"></asp:Label>: 
                    <asp:Label ID="lbl_EmployeeNumber" runat="server" Text=""></asp:Label>)
                </div>
                <div class="clearfix"></div>
                <asp:Label ID="lbl_Position" runat="server" CssClass="place" Text=""></asp:Label><br />
                <br />

                <asp:Label ID="lbl_PhoneNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, PhoneNumberLabel %>"></asp:Label>:
                <strong>
                    <asp:Label ID="lbl_PhoneNumber" CssClass="row-name" runat="server" Text=""></asp:Label><br />
                </strong>
                <asp:Label ID="lbl_MobileNumberLabel" runat="server" Text="<%$ Resources: Common, MobileNumberLabel %>"></asp:Label>:
               <strong>
                   <asp:Label ID="lbl_MobileNumber" CssClass="row-name" runat="server" Text=""></asp:Label><br />
               </strong>
                <asp:Label ID="lbl_EmailLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, EmailLabel %>"></asp:Label>:
                <strong>
                    <asp:Label ID="lbl_Email" runat="server" Text="" style="text-transform: lowercase"></asp:Label><br />
                </strong>
            </div>
        </div>
    </div>
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-info-sign"></span>
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources: CardIndex, StructureAndLocation %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-4 col-md-4">
                    <strong>
                        <asp:Label ID="lbl_SectionLabel" runat="server" Text="<%$ Resources: Common, SectionLabel %>"></asp:Label>:
                    </strong>
                    <asp:Label ID="lbl_Section" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4 col-md-4">
                    <strong>
                        <asp:Label ID="lbl_OrganizationalUnitLabel" runat="server" Text="<%$ Resources: Common, OrganizationalUnitLabel %>"></asp:Label>:
                    </strong>
                    <asp:Label ID="lbl_OrganizationalUnit" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4 col-md-4">
                    <strong>
                        <asp:Label ID="lbl_OrganizationalCellLabel" runat="server" Text="<%$ Resources: Common, OrganizationalCellLabel %>"></asp:Label>:
                    </strong>
                    <asp:Label ID="lbl_OrganizationalCell" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4">
                    <strong>
                        <asp:Label ID="lbl_RoomLabel" runat="server" Text="<%$ Resources: Common, RoomLabel %>"></asp:Label>:
                    </strong>
                    <asp:Label ID="lbl_Room" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4 col-md-4">
                    <strong>
                        <asp:Label ID="lbl_ManagerOfBranchLabel" runat="server" Text="<%$ Resources: Common, ManagerOfBranchLabel %>"></asp:Label>:
                    </strong>
                    <asp:Label ID="lbl_ManagerOfBranch" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-user"></span>
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources: Common, Coworkers %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-6 col-md-6">
                    <div class="panel panel-personal">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <span class="glyphicon glyphicon-duplicate"></span>
                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources: CardIndex, ReportsTo %>"></asp:Label>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gv_ReportsTo" runat="server" ShowHeader="False" AutoGenerateColumns="false"
                                AllowPaging="True" EmptyDataText="<%$ Resources:Common,NoItems %>" BorderStyle="None" GridLines="None"
                                OnRowDataBound="gv_ReportsTo_RowDataBound"
                                OnPageIndexChanging="gv_ReportsTo_PageIndexChanging"
                                OnRowCommand="gv_ReportsTo_RowCommand"
                                CssClass="table table-hover table-striped employee-list" PageSize="5">
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<%$ Resources:Common,First %>" LastPageText="<%$ Resources:Common,Last %>" />
                                <PagerStyle CssClass="pagination" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                                        <ItemStyle CssClass="hiden" />
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_ReportsTo"
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
                </div>
                <div class="col-sm-6 col-md-6">
                    <div class="panel panel-personal">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <span class="glyphicon glyphicon-list-alt"></span>
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources: CardIndex, DirectReports %>"></asp:Label>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gv_DirectReports" runat="server" ShowHeader="False" AutoGenerateColumns="false"
                                AllowPaging="True" EmptyDataText="<%$ Resources:Common,NoItems %>" BorderStyle="None" GridLines="None"
                                OnRowDataBound="gv_DirectReports_RowDataBound"
                                OnPageIndexChanging="gv_DirectReports_PageIndexChanging"
                                OnRowCommand="gv_DirectReports_RowCommand"
                                CssClass="table table-hover table-striped employee-list" PageSize="5">
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<%$ Resources:Common,First %>" LastPageText="<%$ Resources:Common,Last %>" />
                                <PagerStyle CssClass="pagination" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                                        <ItemStyle CssClass="hiden" />
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_DirectReports"
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>

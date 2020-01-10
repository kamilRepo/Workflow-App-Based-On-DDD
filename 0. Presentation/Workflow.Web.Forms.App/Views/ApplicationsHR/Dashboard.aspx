<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.Applications_HR.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
    <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-th"></span>
                <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, Applications %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-4 col-sm-2">
                    <asp:LinkButton ID="LinkButton1" class="link" href="../ApplicationsHR/SearchEmployees.aspx" runat="server">
                    <div class="tile">
                            <span class="glyphicon glyphicon-duplicate tile-ico"></span>
                            <div class="clearfix"></div>
                            <span class="tile-title">
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources: Common, Zadania %>"></asp:Label>
                            </span>
                        </div>


                        </asp:LinkButton>
                    </div>
                <div class="col-xs-4 col-sm-2">
                    <asp:LinkButton ID="lnk_SearchEmployees" class="link" href="../ApplicationsHR/SearchEmployees.aspx" runat="server">
                    <div class="tile">
                            <span class="glyphicon glyphicon-user tile-ico"></span>
                            <div class="clearfix"></div>
                            <span class="tile-title">
                                <asp:Label ID="lbl_SearchEmployeesLabel" runat="server" Text="<%$ Resources: Common, Employees %>"></asp:Label>
                            </span>
                        </div>


                        </asp:LinkButton>
                    </div>
                <div class="col-xs-4 col-sm-2">
                    <asp:LinkButton ID="lnk_DeductionsFromSalary" class="link" href="../ApplicationsHR/DeductionsFromSalary.aspx" runat="server">

                    <div class="tile">
                            <span class="glyphicon glyphicon-stats tile-ico"></span>
                            <div class="clearfix"></div>
                            <span class="tile-title">
                            <asp:Label ID="lbl_DeductionsFromSalary" runat="server" Text="<%$ Resources: Common, Deductions %>"></asp:Label>
                            </span>
                        </div>

                        
                        </asp:LinkButton>
                    </div>
                <div class="col-xs-4 col-sm-2">
                    <asp:LinkButton ID="lnk_Reports" class="link" href="../ApplicationsHR/Reports.aspx" runat="server">

                    <div class="tile">
                            <span class="glyphicon glyphicon-duplicate tile-ico"></span>
                            <div class="clearfix"></div>
                            <span class="tile-title">
                            <asp:Label ID="lbl_Reports" runat="server" Text="<%$ Resources: Common, Reports %>"></asp:Label>
                            </span>
                        </div>
                        
                        </asp:LinkButton>
                    </div>

                <div class="col-xs-4 col-sm-2">
                    <asp:LinkButton ID="lnk_Import" class="link" href="../ApplicationsHR/Import.aspx" runat="server">

                    <div class="tile">
                            <span class="glyphicon glyphicon-duplicate tile-ico"></span>
                            <div class="clearfix"></div>
                            <span class="tile-title">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources: Common, Import %>"></asp:Label>
                            </span>
                        </div>
                        
                        </asp:LinkButton>
                    </div>

            </div>
        </div>
    </div>
</asp:Content>
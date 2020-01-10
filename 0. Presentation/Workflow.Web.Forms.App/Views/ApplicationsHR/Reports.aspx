<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-gray">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="glyphicon glyphicon-th"></span>
                <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, Reports %>"></asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                Raports
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CriticalError.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.Shared.CriticalError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SteelsheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="nav navbar-stacked">
        <li>
            <asp:Label ID="lbl_Error" runat="server" Text="<%$ Resources: Common, Error %>"></asp:Label>:</li>
        <br />
        <li><asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label></li>
    </ul>
</asp:Content>

﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeductionsFromSalary.ascx.cs" Inherits="Workflow.Web.Forms.App.Views.CardIndex.Shared.DeductionsFromSalary" %>
<asp:UpdatePanel ID="up_Deductions" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="gv_Deductions" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None"
            CssClass="table table-hover table-bordered table-striped"
            EmptyDataText="<%$ Resources:Common,NoItems %>">
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
                <asp:TemplateField HeaderText="<%$ Resources: Common, AmountContribution %>">
                    <ItemTemplate>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                        <asp:TextBox ID="Amount" runat="server" Text='<%# Eval("Amount") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>

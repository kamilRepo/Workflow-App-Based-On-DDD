<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeductionsZFSS.ascx.cs" Inherits="Workflow.Web.Forms.App.Views.CardIndex.Shared.DeductionsZFSS" %>

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
                <asp:TemplateField HeaderText="<%$ Resources: Common, ContractNumberLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="ContractNumberLabel" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                        <asp:TextBox ID="ContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: HR, DateFirstDeduction %>">
                    <ItemTemplate>
                        <asp:Label ID="FromDateSTLabel" runat="server" Text='<%# Eval("FromDateST") %>'></asp:Label>
                        <asp:TextBox ID="FromDateST" runat="server" Text='<%# Eval("FromDateST") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: HR, DateLastDeduction %>">
                    <ItemTemplate>
                        <asp:Label ID="ToDateSTLabel" runat="server" Text='<%# Eval("ToDateST") %>'></asp:Label>
                        <asp:TextBox ID="ToDateST" runat="server" Text='<%# Eval("ToDateST") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: Common, AmountGrantedLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                        <asp:TextBox ID="Amount" runat="server" Text='<%# Eval("Amount") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: HR, FirstInstallmentCapitalLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="FirstInstallmentCapitalLabel" runat="server" Text='<%# Eval("FirstInstallmentCapital") %>'></asp:Label>
                        <asp:TextBox ID="FirstInstallmentCapital" runat="server" Text='<%# Eval("FirstInstallmentCapital") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: HR, FirstInstallmentInterestLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="FirstInstallmentInterestLabel" runat="server" Text='<%# Eval("FirstInstallmentInterest") %>'></asp:Label>
                        <asp:TextBox ID="FirstInstallmentInterest" runat="server" Text='<%# Eval("FirstInstallmentInterest") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources: HR, MonthlyCycleLabel %>">
                    <ItemTemplate>
                        <asp:Label ID="MonthlyCycleLabel" runat="server" Text='<%# Eval("MonthlyCycle") %>'></asp:Label>
                        <asp:TextBox ID="MonthlyCycle" runat="server" Text='<%# Eval("MonthlyCycle") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>

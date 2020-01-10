<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ApplicationsHR/Shared/ApplicationHRMainLayout.master" AutoEventWireup="true" CodeBehind="StructureAndLocation.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.StructureAndLocation" %>

<%@ Register TagPrefix="uc" TagName="SearchEmployees" Src="~/Views/Shared/Partials/WUC_SearchEmployees.ascx" %>

<asp:Content ID="cnt_SteelsheetContent" ContentPlaceHolderID="SteelsheetContent" runat="server">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
        }

        .info, .success, .warning, .error, .validation {
            border: 1px solid;
            margin: 10px 0px;
            padding: 15px 10px 15px 50px;
            background-repeat: no-repeat;
            background-position: 10px center;
        }

        .info {
            color: #00529B;
            background-color: #BDE5F8;
            background-image: url('info.png');
        }

        .success {
            color: #4F8A10;
            background-color: #DFF2BF;
            background-image: url('success.png');
        }

        .warning {
            color: #9F6000;
            background-color: #FEEFB3;
            background-image: url('warning.png');
        }

        .error {
            color: #D8000C;
            background-color: #FFBABA;
            background-image: url('error.png');
        }

        .panel-primary {
            width: 750px;
        }

        .modal-content {
            width: 850px;
        }
    </style>
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function HideMessage() {
            var element = document.getElementById('MainContent_MainContent_pnl_SuccessMessage');
            if (element != null)
                element.style.display = 'none';
            window.setTimeout(function () { Execute() }, 5000);
        }

        function Execute() {
            var element = document.getElementById('MainContent_MainContent_pnl_SuccessMessage');
            element.style.display = 'none';
        }
    </script>

    <strong>
        <asp:Label ID="lbl_nameSurname" CssClass="username" runat="server" Text="" Style="text-transform: uppercase"></asp:Label>
    </strong>
    <div class="user-number">
        (<asp:Label ID="lbl_No" runat="server" Text="<%$ Resources: Common, No %>"></asp:Label>: 
                    <asp:Label ID="lbl_EmployeeNumber" runat="server" Text=""></asp:Label>)
    </div>
    <div class="clearfix"></div>

    <asp:Label ID="lbl_Position" CssClass="place" runat="server" Text=""></asp:Label><br />
    <br />
    <div class="menu-contener">
        <div class="btn-group" role="group" aria-label="...">
            <asp:Button ID="lnk_AllocationDefault" runat="server" Text="<%$ Resources: HR, AllocationDefault %>" class="btn btn-default" OnClick="lnk_AllocationDefault_Click"></asp:Button>
            <asp:Button ID="lnk_Coefficients" runat="server" Text="<%$ Resources: HR, Coefficients %>" class="btn btn-default" OnClick="lnk_Coefficients_Click"></asp:Button>
        </div>
    </div>
    <asp:UpdatePanel ID="up_PersonalInformation" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnl_SuccessMessage" runat="server" Visible="false">
                <div class="success">
                    <asp:Label ID="lbl_success" runat="server" Text="<%$ Resources: Common, Success %>"></asp:Label>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_AllocationDefault" runat="server">
                <br />
                <table class="table">
                    <tbody>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_PositionLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, PositionLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_PositionTable" CssClass="form-control" runat="server" Text="" ></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_SectionLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, SectionLabel %>"></asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Section" runat="server" CssClass="form-control">
                                    <asp:ListItem
                                        Text="string"
                                        Value="string" />
                                </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_OrganizationalUnitLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, OrganizationalUnitLabel %>"></asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_OrganizationalUnit" runat="server" CssClass="form-control">
                                    <asp:ListItem
                                        Text="string"
                                        Value="string" />
                                </asp:DropDownList>
                            </td>
                        </tr>                        
                        <tr>
                            <td>

                                <asp:Label ID="lbl_OrganizationalCellLabel" runat="server" Text="<%$ Resources: Common, OrganizationalCellLabel %>"></asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_OrganizationalCell" runat="server" CssClass="form-control">
                                    <asp:ListItem
                                        Text="string"
                                        Value="string" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_DirectSupervisorLabel" runat="server" Text="<%$ Resources: Common, DirectSupervisorLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:Label ID="lbl_DirectSupervisor" runat="server" Text=""></asp:Label>
                                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#myModal">
                                    <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, SearchFor %>"></asp:Label>
                                </button>
                                <br />
                            </strong></td>
                        </tr>
                        <tbody>
                </table>
                <div class="pull-right">
                    <asp:Button ID="btn_Restore" runat="server" Text="<%$ Resources: Common, Reject %>" OnClick="btn_Restore_Click" OnClientClick="HideMessage()" UseSubmitBehavior="false" class="btn btn-primary"/>&nbsp
                    <asp:Button ID="btn_Save" runat="server" Text="<%$ Resources: Common, Save %>" OnClick="btn_Save_Click" OnClientClick="HideMessage()" UseSubmitBehavior="false" class="btn btn-primary"/>
                </div>
            </asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
            <asp:Panel ID="pnl_Coefficients" runat="server" Visible="false">
                <br />
                <asp:GridView ID="gv_Coefficients" runat="server" AutoGenerateColumns="False" EmptyDataText="<%$ Resources:Common,NoItems %>"
                    OnRowCommand="gv_Coefficients_RowCommand" 
                    CssClass="table table-hover table-bordered table-striped">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" ItemStyle-CssClass="hiden" HeaderStyle-CssClass="hiden">
                            <ItemTemplate>
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, Code %>">
                            <ItemTemplate>
                                <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, OrganizationalUnitLabel %>">
                            <ItemTemplate>
                                <asp:Label ID="OrganizationalUnitLabel" runat="server" Text='<%# Eval("OrganizationalUnit") %>'></asp:Label>
                                <asp:DropDownList ID="ddl_OrganizationalUnit" runat="server" Visible="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, OrganizationalCellLabel %>">
                            <ItemTemplate>
                                <asp:Label ID="OrganizationalCellLabel" runat="server" Text='<%# Eval("OrganizationalCell") %>'></asp:Label>
                                <asp:DropDownList ID="ddl_OrganizationalCell" runat="server" Visible="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, Silo %>">
                            <ItemTemplate>
                                <asp:Label ID="SiloLabel" runat="server" Text='<%# Eval("Silo") %>'></asp:Label>
                                <asp:DropDownList ID="ddl_Silo" runat="server" Visible="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, Coefficient %>">
                            <ItemTemplate>
                                <asp:Label ID="CoefficientLabel" runat="server" Text='<%# Eval("CoefficientDecimal") %>'></asp:Label>
                                <asp:TextBox ID="Coefficient" runat="server" Text='' Width="175px" Visible="false"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="120px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_Edit" CssClass="edit-row" runat="server" Text="<%$ Resources: Common, Edit %>"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    CommandName="CommandEdit" />
                                <asp:LinkButton ID="btn_Delete" CssClass="delete-row" runat="server" Text="<%$ Resources: Common, Delete %>"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    CommandName="CommandDelete" />
                                <asp:LinkButton ID="btn_Save" CssClass="save-row" runat="server" Text="<%$ Resources: Common, Save %>"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    CommandName="CommandSave" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button runat="server" ID="btn_AddRows" Text="<%$ Resources: Common, Add %>" OnClick="btn_AddRow_Click" class="btn btn-primary pull-right"></asp:Button>
            </asp:Panel>
        
    <uc:SearchEmployees ID="WUC_SearchEmployees" runat="server" />
    <asp:UpdatePanel ID="up_SearchForss" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hf_EmployeeID" runat="server" />
            <asp:HiddenField ID="hf_DirectSupervisorId" runat="server" />
            <asp:HiddenField ID="hf_EmployeeMembershipId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:LinkButton runat="server" ID="AddRow" Text="Add Row" OnClick="AddRow_Click" Style="display: none;"></asp:LinkButton>
</asp:Content>



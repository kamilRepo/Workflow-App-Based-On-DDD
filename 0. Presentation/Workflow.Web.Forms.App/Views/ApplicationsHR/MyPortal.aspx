<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ApplicationsHR/Shared/ApplicationHRMainLayout.master" AutoEventWireup="true" CodeBehind="MyPortal.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.ApplicationsHR.MyPortal" %>

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
            <asp:Button ID="lnk_PersonalInformation" runat="server" Text="<%$ Resources: Common, PersonalInformation %>" class="btn btn-default" OnClick="lnk_PersonalInformation_Click"></asp:Button>
        </div>
    </div>
    <asp:UpdatePanel ID="up_PersonalInformation" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnl_SuccessMessage" runat="server" Visible="false">
                <div class="success">
                    <asp:Label ID="lbl_success" runat="server" Text="<%$ Resources: Common, Success %>"></asp:Label></div>
            </asp:Panel>
            <asp:Panel ID="pnl_PersonalInformation" runat="server">
                <br />
                <table class="table">
                    <tbody>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_PhoneNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, PhoneNumberLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_PhoneNumber" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_MobileNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, MobileNumberLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_MobileNumber" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_EmailLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, EmailLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_Email" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_PeselLabel" runat="server" Text="<%$ Resources: Common, PeselLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_Pesel" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lbl_EducationLabel" runat="server" Text="<%$ Resources: Common, EducationLabel %>"></asp:Label>

                            </td>
                            <td><strong>
                                <asp:TextBox ID="tb_Education" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </strong></td>
                        </tr>
                        <tbody>
                </table>

                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-6">
                        <div class="panel panel-personal">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-home"></span>
                                    <asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, RegisteredAddressLabel %>"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <table class="table">
                                    <tbody>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_SpotLabel" runat="server" Text="<%$ Resources: Common, SpotLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_Spot" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_CommunityLabel" runat="server" Text="<%$ Resources: Common, CommunityLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_Community" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_PostalCodeLabel" runat="server" Text="<%$ Resources: Common, PostalCodeLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_PostalCode" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_StreetLabel" runat="server" Text="<%$ Resources: Common, StreetLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_Street" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_StreetNoLabel" runat="server" Text="<%$ Resources: Common, StreetNoLabel %>"></asp:Label>

                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:TextBox ID="tb_StreetNo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                                </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_PremisesLabel" runat="server" Text="<%$ Resources: Common, PremisesLabel %>"></asp:Label>

                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:TextBox ID="tb_Premises" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                                </strong></td>
                                        </tr>
                                        <tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-6">
                        <div class="panel panel-personal">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-envelope"></span>
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources: Common, AddressForCorrespondenceLabel %>"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <table class="table">
                                    <tbody>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_SpotLabelCo" runat="server" Text="<%$ Resources: Common, SpotLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_SpotCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_CommunityLabelCo" runat="server" Text="<%$ Resources: Common, CommunityLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_CommunityCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_PostalCodeLabelCo" runat="server" Text="<%$ Resources: Common, PostalCodeLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_PostalCodeCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_StreetLabelCo" runat="server" Text="<%$ Resources: Common, StreetLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_StreetCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_StreetNoLabelCo" runat="server" Text="<%$ Resources: Common, StreetNoLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_StreetNoCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_PremisesLabelCo" runat="server" Text="<%$ Resources: Common, PremisesLabel %>"></asp:Label>

                                            </td>
                                            <td><strong>
                                                <asp:TextBox ID="tb_PremisesCo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                            </strong></td>
                                        </tr>
                                        <tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="pull-right">
                    <asp:Button ID="btn_Restore" runat="server" Text="<%$ Resources: Common, Reject %>" OnClick="btn_Restore_Click" OnClientClick="HideMessage()" UseSubmitBehavior="false" class="btn btn-primary" />&nbsp
                    <asp:Button ID="btn_Save" runat="server" Text="<%$ Resources: Common, Save %>" OnClick="btn_Save_Click" OnClientClick="HideMessage()" UseSubmitBehavior="false" class="btn btn-primary" />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnl_MedicalExamination" runat="server" Visible="false">
                <br />
                <asp:GridView ID="gv_MedicalExamination" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-bordered table-striped">
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
                        <asp:TemplateField HeaderText="<%$ Resources: Common, Entitlement %>">
                            <ItemTemplate>
                                <asp:Label ID="RegistrationNumberLabel" runat="server" Text='<%# Eval("RegistrationNumber") %>'></asp:Label>
                                <asp:TextBox ID="RegistrationNumber" runat="server" Text='<%# Eval("RegistrationNumber") %>' Width="175px" Visible="false"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources: Common, ExpiryDate %>">
                            <ItemTemplate>
                                <asp:Label ID="FromDateSTLabel" runat="server" Text='<%# Eval("FromDateST") %>'></asp:Label>
                                <asp:TextBox ID="FromDateST" runat="server" Text='<%# Eval("FromDateST") %>' Width="175px" Visible="false"></asp:TextBox>
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
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#myModal">
                    <asp:Label ID="lbl_AddEmployeeInsurance" runat="server" Text="<%$ Resources: Common, Add %>"></asp:Label>
                </button>
            </asp:Panel>

            <asp:Panel ID="pnl_Additions" runat="server" Visible="false">
                <br />
                <asp:GridView ID="gv_Additions" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-bordered table-striped">
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
                        <asp:TemplateField HeaderText="<%$ Resources: Common, Name %>">
                            <ItemTemplate>
                                <asp:Label ID="RegistrationNumberLabel" runat="server" Text='<%# Eval("RegistrationNumber") %>'></asp:Label>
                                <asp:TextBox ID="RegistrationNumber" runat="server" Text='<%# Eval("RegistrationNumber") %>' Width="175px" Visible="false"></asp:TextBox>
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
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#myModal">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources: Common, Add %>"></asp:Label>
                </button>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



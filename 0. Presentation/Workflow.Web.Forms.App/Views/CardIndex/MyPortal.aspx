<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CardIndex/Shared/CardIndexMainLayout.master" AutoEventWireup="true" CodeBehind="MyPortal.aspx.cs" Inherits="Workflow.Web.Forms.App.Views.CardIndex.MyPortal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <strong>
        <asp:Label ID="lbl_nameSurname" CssClass="username" runat="server" Text="" style="text-transform: uppercase"></asp:Label>
    </strong>
    <div class="user-number">
    (<asp:Label ID="lbl_No" runat="server" Text="<%$ Resources: Common, No %>"></asp:Label>: 
                    <asp:Label ID="lbl_EmployeeNumber" runat="server" Text=""></asp:Label>)</div>
    <div class="clearfix"></div>
                    
    <asp:Label ID="lbl_Position" CssClass="place" runat="server" Text=""></asp:Label><br />
    <br />
    <asp:Label ID="lbl_PhoneNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, PhoneNumberLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_PhoneNumber" CssClass="row-desc" runat="server" Text=""></asp:Label><br />
 
    <asp:Label ID="lbl_MobileNumberLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, MobileNumberLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_MobileNumber" CssClass="row-desc" runat="server" Text=""></asp:Label><br />
       
     <asp:Label ID="lbl_EmailLabel" CssClass="row-name" runat="server" Text="<%$ Resources: Common, EmailLabel %>"></asp:Label>:
                    <asp:Label ID="lbl_Email" CssClass="row-desc" runat="server" Text="" style="text-transform: lowercase"></asp:Label><br />
    <br />
    <div class="menu-contener">
        <div class="btn-group" role="group" aria-label="...">
            <asp:Button ID="lnk_PersonalInformation"  runat="server" Text="<%$ Resources: Common, PersonalInformation %>" class="btn btn-default" OnClick="lnk_PersonalInformation_Click"></asp:Button>
            <asp:Button ID="lnk_HolidaysDue" runat="server" Text="<%$ Resources: Common, HolidaysDue %>" class="btn btn-default" OnClick="lnk_HolidaysDue_Click"></asp:Button>
        </div>
    </div>
    <asp:Panel ID="pnl_PersonalInformation" runat="server">
        <br />
        <table class="table">
            <tbody>
                <tr>
                    <td>
                        
                            <asp:Label ID="lbl_PeselLabel" runat="server" Text="<%$ Resources: Common, PeselLabel %>"></asp:Label>
                        
                    </td>
                    <td><strong>
                        <asp:Label ID="lbl_Pesel" runat="server" Text=""></asp:Label><br />
                   </strong> </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:Label ID="lbl_EducationLabel" runat="server" Text="<%$ Resources: Common, EducationLabel %>"></asp:Label>
                        
                    </td>
                    <td><strong>
                        <asp:Label ID="lbl_Education" runat="server" Text=""></asp:Label><br />
                    </strong></td>
                </tr>
                <tbody>
        </table>
        <br />
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-6">
                <div class="panel panel-personal">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <span class="glyphicon glyphicon-home"></span><asp:Label ID="lbl_SearchFor" runat="server" Text="<%$ Resources: Common, RegisteredAddressLabel %>"></asp:Label>
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
                                        <asp:Label ID="lbl_Spot" runat="server" Text=""></asp:Label><br />
                                    </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_CommunityLabel" runat="server" Text="<%$ Resources: Common, CommunityLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_Community" runat="server" Text=""></asp:Label><br />
                                   </strong> </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_PostalCodeLabel" runat="server" Text="<%$ Resources: Common, PostalCodeLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_PostalCode" runat="server" Text=""></asp:Label><br />
                                  </strong>  </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_StreetLabel" runat="server" Text="<%$ Resources: Common, StreetLabel %>"></asp:Label>
                                       
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_Street" runat="server" Text=""></asp:Label><br />
                                    </strong> </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_StreetNoLabel" runat="server" Text="<%$ Resources: Common, StreetNoLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td>
                                       <strong> <asp:Label ID="lbl_StreetNo" runat="server" Text=""></asp:Label><br />
                                    </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_PremisesLabel" runat="server" Text="<%$ Resources: Common, PremisesLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td>
                                        <strong><asp:Label ID="lbl_Premises" runat="server" Text=""></asp:Label><br />
                                   </strong> </td>
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
                            <span class="glyphicon glyphicon-envelope"></span><asp:Label ID="Label1" runat="server" Text="<%$ Resources: Common, AddressForCorrespondenceLabel %>"></asp:Label>
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
                                        <asp:Label ID="lbl_SpotCo" runat="server" Text=""></asp:Label><br />
                                     </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_CommunityLabelCo" runat="server" Text="<%$ Resources: Common, CommunityLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_CommunityCo" runat="server" Text=""></asp:Label><br />
                                    </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_PostalCodeLabelCo" runat="server" Text="<%$ Resources: Common, PostalCodeLabel %>"></asp:Label>
                                       
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_PostalCodeCo" runat="server" Text=""></asp:Label><br />
                                     </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_StreetLabelCo" runat="server" Text="<%$ Resources: Common, StreetLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_StreetCo" runat="server" Text=""></asp:Label><br />
                                   </strong> </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_StreetNoLabelCo" runat="server" Text="<%$ Resources: Common, StreetNoLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_StreetNoCo" runat="server" Text=""></asp:Label><br />
                                    </strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                            <asp:Label ID="lbl_PremisesLabelCo" runat="server" Text="<%$ Resources: Common, PremisesLabel %>"></asp:Label>
                                        
                                    </td>
                                    <td><strong>
                                        <asp:Label ID="lbl_PremisesCo" runat="server" Text=""></asp:Label><br />
                                   </strong> </td>
                                </tr>
                                <tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnl_HolidaysDue" runat="server" Visible="false">
        <br />
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>
                        <asp:Label ID="lbl_ReportForDayLabel" runat="server" Text="<%$ Resources: CardIndex, ReportForDay %>"></asp:Label></th>
                    <th>
                        <asp:Label ID="lbl_ReportForDay" runat="server" Text=""></asp:Label></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="lbl_HolidaysDueLabel" runat="server" Text="<%$ Resources: CardIndex, HolidaysDue %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_HolidaysDue" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_HolidaysCalculatedLabel" runat="server" Text="<%$ Resources: CardIndex, HolidaysCalculated %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_HolidaysCalculated" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_HolidaysUnderpaidLabel" runat="server" Text="<%$ Resources: CardIndex, HolidaysUnderpaid %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_HolidaysUnderpaid" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_HolidaysRehabilitationLabel" runat="server" Text="<%$ Resources: CardIndex, HolidaysRehabilitation %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_HolidaysRehabilitation" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_HolidaysUsedLabel" runat="server" Text="<%$ Resources: CardIndex, HolidaysUsed %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_HolidaysUsed" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_Art188KPLabel" runat="server" Text="<%$ Resources: CardIndex, Art188KP %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_Art188KP" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_RemainedUnusedLabel" runat="server" Text="<%$ Resources: CardIndex, RemainedUnused %>"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbl_RemainedUnused" runat="server" Text=""></asp:Label></td>
                </tr>
            </tbody>
        </table>
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
                    </Columns>
                </asp:GridView>
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
                    </Columns>
                </asp:GridView>
            </asp:Panel>
</asp:Content>


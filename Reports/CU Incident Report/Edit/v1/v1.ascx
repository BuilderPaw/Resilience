<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Incident_Report_Edit_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div class="body3">
            <h4 style="margin-left: 57.5%">
                <asp:Label ID="lblReportName" runat="server" Text=""></asp:Label>
                Report ID No.
        <b>
            <asp:Label ID="lblReportId" Style="color: red;" runat="server" Text=""></asp:Label></b>
            </h4>
            <table class="table-incident">
                <tr>
                    <th colspan="5">Shift Details</th>
                </tr>
                <tr style="border: solid .5px;">
                    <td>Staff Name:</td>
                    <td style="width: 285px">
                        <asp:Label ID="lblStaffName" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: right;">Entry Details:</td>
                    <td>
                        <asp:Label ID="lblEntryDetails" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 19%">Shift Type: 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlShift" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default">
                            <asp:ListItem Enabled="true" Text="Select Shift" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Morning" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Afternoon" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Evening" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Night" Value="4"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="text-align: right;">Shift Date:</td>
                    <td>
                        <asp:TextBox ID="txtDatePicker" OnTextChanged="TextChanged_TextChanged" runat="server" Width="245px" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDatePicker" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th style="width: 500px">Is there any Person involved in this Incident Report?</th>
                    <th id="noOfPerson" visible="false" runat="server">Number of Persons Involved
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbAddPerson1" AutoPostBack="true" OnCheckedChanged="cbAddPerson1_CheckedChanged" Checked="false" runat="server" /></td>
                    <td id="noOfPerson1" visible="false" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNoOfPerson" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Accordion ID="acdPerson" runat="server"
                HeaderCssClass="accordion-header-incident"
                HeaderSelectedCssClass="accordion-header-selected-incident"
                ContentCssClass="accordionContent1"
                AutoSize="None"
                FadeTransitions="true"
                TransitionDuration="250"
                FramesPerSecond="40"
                RequireOpenedPane="true"
                SuppressHeaderPostbacks="true">
                <Panes>
                    <asp:AccordionPane runat="server" ID="acpPerson1" HeaderCssClass="accordion-header-incident"
                        HeaderSelectedCssClass="accordion-header-selected-incident"
                        ContentCssClass="accordionContent1">
                        <Header>Person 1</Header>
                        <Content>
                            <table id="tblPerson1" class="table-incident" runat="server">
                                <tr>
                                    <td colspan="1"><b>Party Type : </b>
                                    </td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="ddlPartyType1" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType1_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Contractor" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Minor" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Liquor and Gaming" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Unknown" Value="8"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td id="witness1l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                                    </td>
                                    <td id="witness1" visible="false" runat="server" colspan="1">
                                        <asp:CheckBox ID="cbWitness1" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff11l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                    </td>
                                    <td id="staff11" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffEmpNo1" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member12l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                    </td>
                                    <td id="member12" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbCardHeld1" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="member11l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                    </td>
                                    <td id="member11" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtMemberNo1" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td id="visitor11l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                    </td>
                                    <td id="visitor11" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbSignInSlip1" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="visitor12l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                    </td>
                                    <td id="visitor12" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtSignInBy1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff12l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="staff12" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffAddress1" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        <br />
                                        <br />
                                        <b>Member Since : </b>
                                    </td>
                                    <td id="member13" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOB1" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender22" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtMemberSince1" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member15l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                    </td>
                                    <td id="member15" runat="server" visible="false" colspan="1">
                                        <asp:Image ID="imgMember1" Height="110px" Width="140px" runat="server" />
                                    </td>
                                    <td id="visitor13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                    </td>
                                    <td id="visitor13" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOBv1" OnTextChanged="TextChanged_TextChanged" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td id="visitor14l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                    </td>
                                    <td id="visitor14" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtIDProof1" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="member14l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="member14" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddress1" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="visitor15l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="visitor15" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddressv1" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><b>First Name : </b>
                                        <asp:TextBox ID="txtFirstName1" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2"><b>Last Name : </b>
                                        <asp:TextBox ID="txtLastName1" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Alias : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtAlias1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Contact Details : (Could be Mobile No., Home No., and Email Address)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtContact1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 106px">
                                        <b>Age : </b>
                                        <asp:TextBox ID="txtAge1" AutoPostBack="true" OnTextChanged="txtAge1_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Age Group : </b>
                                        <asp:DropDownList ID="ddlAgeGroup1" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="ddlAgeGroup1_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Enabled="true" Text="Select One" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Under 18" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="26-34" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="35-40" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="41-45" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="46-50" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="51-60" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="61+" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Gender : </b>
                                        <asp:DropDownList ID="ddlGender1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="170px">
                                            <asp:ListItem Enabled="true" Text="Select Gender" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>For Any Assault Related Incidents, Record When the Patron Entered the Club</u></b></td>
                                </tr>
                                <tr>
                                    <td style="width: 173px">
                                        <asp:TextBox ID="txtPDate1" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1" style="width: 8px">
                                        <asp:DropDownList ID="ddlPTimeH1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:DropDownList ID="ddlPTimeM1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Build : </b>
                                        <%--<asp:TextBox ID="txtWeight1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlWeight1" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="TextChanged_TextChanged">
                                            <asp:ListItem Enabled="true" Text="Select One" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                            <asp:ListItem Text="Muscular" Value="Muscular"></asp:ListItem>
                                            <asp:ListItem Text="Obese" Value="Obese"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Height : </b>
                                        <asp:TextBox ID="txtHeight1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="width: 106px">
                                        <b>Hair : </b>
                                        <asp:TextBox ID="txtHair1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Clothing - Top : </b>
                                        <asp:TextBox ID="txtClothingTop1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Clothing - Bottom : </b>
                                        <asp:TextBox ID="txtClothingBottom1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Shoes : </b>
                                        <asp:TextBox ID="txtShoes1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <b>Weapon : </b>
                                        <asp:TextBox ID="txtWeapon1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtDistFeatures1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Injury Description</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryDesc1" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryCause1" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Incident Comments</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtIncidentComm1" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1"><b><u>Injury Diagram</u></b></td>
                                    <td colspan="1">
                                        <asp:CheckBox ID="cbHumanBody" AutoPostBack="true" OnCheckedChanged="cbHumanBody_CheckedChanged" runat="server" />
                                        <asp:Label ID="lblImage1" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnDelete1" OnClick="btnDelete1_Click" Height="40px" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Injury Diagram" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image1" Height="300px" Width="400px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane runat="server" ID="acpPerson2" HeaderCssClass="accordion-header-incident"
                        HeaderSelectedCssClass="accordion-header-selected-incident"
                        ContentCssClass="accordionContent1">
                        <Header>Person 2</Header>
                        <Content>
                            <table id="tblPerson2" class="table-incident" runat="server">
                                <tr>
                                    <td colspan="1"><b>Party Type : </b>
                                    </td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="ddlPartyType2" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType2_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Contractor" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Minor" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Liquor and Gaming" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Unknown" Value="8"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td id="witness2l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                                    </td>
                                    <td id="witness2" visible="false" runat="server" colspan="1">
                                        <asp:CheckBox ID="cbWitness2" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff21l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                    </td>
                                    <td id="staff21" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffEmpNo2" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member22l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                    </td>
                                    <td id="member22" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbCardHeld2" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="member21l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                    </td>
                                    <td id="member21" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtMemberNo2" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td id="visitor21l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                    </td>
                                    <td id="visitor21" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbSignInSlip2" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="visitor22l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                    </td>
                                    <td id="visitor22" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtSignInBy2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff22l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="staff22" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffAddress2" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        <br />
                                        <br />
                                        <b>Member Since : </b>
                                    </td>
                                    <td id="member23" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOB2" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender24" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtMemberSince2" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member25l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                    </td>
                                    <td id="member25" runat="server" visible="false" colspan="1">
                                        <asp:Image ID="imgMember2" Height="110px" Width="140px" runat="server" />
                                    </td>
                                    <td id="visitor23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                    </td>
                                    <td id="visitor23" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOBv2" OnTextChanged="TextChanged_TextChanged" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender25" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td id="visitor24l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                    </td>
                                    <td id="visitor24" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtIDProof2" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="member24l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="member24" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddress2" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="visitor25l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="visitor25" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddressv2" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><b>First Name : </b>
                                        <asp:TextBox ID="txtFirstName2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2"><b>Last Name : </b>
                                        <asp:TextBox ID="txtLastName2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Alias : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtAlias2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Contact Details : (Could be Mobile No., Home No., and Email Address)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtContact2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 106px">
                                        <b>Age : </b>
                                        <asp:TextBox ID="txtAge2" AutoPostBack="true" OnTextChanged="txtAge2_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Age Group : </b>
                                        <asp:DropDownList ID="ddlAgeGroup2" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="ddlAgeGroup2_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Enabled="true" Text="Select One" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Under 18" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="26-34" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="35-40" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="41-45" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="46-50" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="51-60" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="61+" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Gender : </b>
                                        <asp:DropDownList ID="ddlGender2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="170px">
                                            <asp:ListItem Enabled="true" Text="Select Gender" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>For Any Assault Related Incidents, Record When the Patron Entered the Club</u></b></td>
                                </tr>
                                <tr>
                                    <td style="width: 173px">
                                        <asp:TextBox ID="txtPDate2" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1" style="width: 8px">
                                        <asp:DropDownList ID="ddlPTimeH2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:DropDownList ID="ddlPTimeM2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Build : </b>
                                        <%--<asp:TextBox ID="txtWeight2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlWeight2" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="TextChanged_TextChanged">
                                            <asp:ListItem Enabled="true" Text="Select One" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                            <asp:ListItem Text="Muscular" Value="Muscular"></asp:ListItem>
                                            <asp:ListItem Text="Obese" Value="Obese"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Height : </b>
                                        <asp:TextBox ID="txtHeight2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="width: 106px">
                                        <b>Hair : </b>
                                        <asp:TextBox ID="txtHair2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Clothing - Top : </b>
                                        <asp:TextBox ID="txtClothingTop2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Clothing - Bottom : </b>
                                        <asp:TextBox ID="txtClothingBottom2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Shoes : </b>
                                        <asp:TextBox ID="txtShoes2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <b>Weapon : </b>
                                        <asp:TextBox ID="txtWeapon2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtDistFeatures2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Injury Description</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryDesc2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryCause2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Incident Comments</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtIncidentComm2" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1"><b><u>Injury Diagram</u></b></td>
                                    <td colspan="1">
                                        <asp:CheckBox ID="cbHumanBody2" AutoPostBack="true" OnCheckedChanged="cbHumanBody2_CheckedChanged" runat="server" />
                                        <asp:Label ID="lblImage2" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnDelete2" Height="40px" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Injury Diagram" OnClick="btnDelete2_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image2" Height="300px" Width="400px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane runat="server" ID="acpPerson3" HeaderCssClass="accordion-header-incident"
                        HeaderSelectedCssClass="accordion-header-selected-incident"
                        ContentCssClass="accordionContent1">
                        <Header>Person 3</Header>
                        <Content>
                            <table id="tblPerson3" class="table-incident" runat="server">
                                <tr>
                                    <td colspan="1"><b>Party Type : </b>
                                    </td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="ddlPartyType3" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType3_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Contractor" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Minor" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Liquor and Gaming" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Unknown" Value="8"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td id="witness3l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                                    </td>
                                    <td id="witness3" visible="false" runat="server" colspan="1">
                                        <asp:CheckBox ID="cbWitness3" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff31l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                    </td>
                                    <td id="staff31" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffEmpNo3" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member32l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                    </td>
                                    <td id="member32" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbCardHeld3" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="member31l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                    </td>
                                    <td id="member31" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtMemberNo3" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td id="visitor31l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                    </td>
                                    <td id="visitor31" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbSignInSlip3" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="visitor32l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                    </td>
                                    <td id="visitor32" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtSignInBy3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff32l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="staff32" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffAddress3" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        <br />
                                        <br />
                                        <b>Member Since : </b>
                                    </td>
                                    <td id="member33" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOB3" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender26" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtMemberSince3" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member35l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                    </td>
                                    <td id="member35" runat="server" visible="false" colspan="1">
                                        <asp:Image ID="imgMember3" Height="110px" Width="140px" runat="server" />
                                    </td>
                                    <td id="visitor33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                    </td>
                                    <td id="visitor33" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOBv3" OnTextChanged="TextChanged_TextChanged" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender27" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td id="visitor34l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                    </td>
                                    <td id="visitor34" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtIDProof3" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="member34l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="member34" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddress3" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="visitor35l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="visitor35" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddressv3" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><b>First Name : </b>
                                        <asp:TextBox ID="txtFirstName3" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2"><b>Last Name : </b>
                                        <asp:TextBox ID="txtLastName3" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Alias : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtAlias3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Contact Details : (Could be Mobile No., Home No., and Email Address)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtContact3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 106px">
                                        <b>Age : </b>
                                        <asp:TextBox ID="txtAge3" AutoPostBack="true" OnTextChanged="txtAge3_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Age Group : </b>
                                        <asp:DropDownList ID="ddlAgeGroup3" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="ddlAgeGroup3_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Enabled="true" Text="Select One" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Under 18" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="26-34" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="35-40" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="41-45" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="46-50" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="51-60" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="61+" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Gender : </b>
                                        <asp:DropDownList ID="ddlGender3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="170px">
                                            <asp:ListItem Enabled="true" Text="Select Gender" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>For Any Assault Related Incidents, Record When the Patron Entered the Club</u></b></td>
                                </tr>
                                <tr>
                                    <td style="width: 173px">
                                        <asp:TextBox ID="txtPDate3" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1" style="width: 8px">
                                        <asp:DropDownList ID="ddlPTimeH3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:DropDownList ID="ddlPTimeM3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Build : </b>
                                        <%--<asp:TextBox ID="txtWeight3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlWeight3" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="TextChanged_TextChanged">
                                            <asp:ListItem Enabled="true" Text="Select One" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                            <asp:ListItem Text="Muscular" Value="Muscular"></asp:ListItem>
                                            <asp:ListItem Text="Obese" Value="Obese"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Height : </b>
                                        <asp:TextBox ID="txtHeight3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="width: 106px">
                                        <b>Hair : </b>
                                        <asp:TextBox ID="txtHair3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Clothing - Top : </b>
                                        <asp:TextBox ID="txtClothingTop3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Clothing - Bottom : </b>
                                        <asp:TextBox ID="txtClothingBottom3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Shoes : </b>
                                        <asp:TextBox ID="txtShoes3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <b>Weapon : </b>
                                        <asp:TextBox ID="txtWeapon3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtDistFeatures3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Injury Description</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryDesc3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryCause3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Incident Comments</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtIncidentComm3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1"><b><u>Injury Diagram</u></b></td>
                                    <td colspan="1">
                                        <asp:CheckBox ID="cbHuman3" AutoPostBack="true" OnCheckedChanged="cbHuman3_CheckedChanged" runat="server" />
                                        <asp:Label ID="lblImage3" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnDelete3" Height="40px" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Injury Diagram" OnClick="btnDelete3_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image3" Height="300px" Width="400px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane runat="server" ID="acpPerson4" HeaderCssClass="accordion-header-incident"
                        HeaderSelectedCssClass="accordion-header-selected-incident"
                        ContentCssClass="accordionContent1">
                        <Header>Person 4</Header>
                        <Content>
                            <table id="tblPerson4" class="table-incident" runat="server">
                                <tr>
                                    <td colspan="1"><b>Party Type : </b>
                                    </td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="ddlPartyType4" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType4_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Contractor" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Minor" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Liquor and Gaming" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Unknown" Value="8"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td id="witness4l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                                    </td>
                                    <td id="witness4" visible="false" runat="server" colspan="1">
                                        <asp:CheckBox ID="cbWitness4" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff41l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                    </td>
                                    <td id="staff41" runat="server" visible="false" colspan="4">
                                        <asp:TextBox ID="txtStaffEmpNo4" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member42l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                    </td>
                                    <td id="member42" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbCardHeld4" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="member41l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                    </td>
                                    <td id="member41" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtMemberNo4" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td id="visitor41l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                    </td>
                                    <td id="visitor41" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbSignInSlip4" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="visitor42l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                    </td>
                                    <td id="visitor42" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtSignInBy4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff42l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="staff42" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffAddress4" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        <br />
                                        <br />
                                        <b>Member Since : </b>
                                    </td>
                                    <td id="member43" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOB4" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender28" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtMemberSince4" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member45l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                    </td>
                                    <td id="member45" runat="server" visible="false" colspan="1">
                                        <asp:Image ID="imgMember4" Height="110px" Width="140px" runat="server" />
                                    </td>
                                    <td id="visitor43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                    </td>
                                    <td id="visitor43" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOBv4" OnTextChanged="TextChanged_TextChanged" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender29" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td id="visitor44l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                    </td>
                                    <td id="visitor44" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtIDProof4" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="member44l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="member44" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddress4" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="visitor45l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="visitor45" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddressv4" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><b>First Name : </b>
                                        <asp:TextBox ID="txtFirstName4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2"><b>Last Name : </b>
                                        <asp:TextBox ID="txtLastName4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Alias : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtAlias4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtContact4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 106px">
                                        <b>Age : </b>
                                        <asp:TextBox ID="txtAge4" AutoPostBack="true" OnTextChanged="txtAge4_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Age Group : </b>
                                        <asp:DropDownList ID="ddlAgeGroup4" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="ddlAgeGroup4_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Enabled="true" Text="Select One" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Under 18" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="26-34" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="35-40" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="41-45" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="46-50" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="51-60" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="61+" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Gender : </b>
                                        <asp:DropDownList ID="ddlGender4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="170px">
                                            <asp:ListItem Enabled="true" Text="Select Gender" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>For Any Assault Related Incidents, Record When the Patron Entered the Club</u></b></td>
                                </tr>
                                <tr>
                                    <td style="width: 173px">
                                        <asp:TextBox ID="txtPDate4" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1" style="width: 8px">
                                        <asp:DropDownList ID="ddlPTimeH4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:DropDownList ID="ddlPTimeM4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Build : </b>
                                        <%--<asp:TextBox ID="txtWeight4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlWeight4" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="TextChanged_TextChanged">
                                            <asp:ListItem Enabled="true" Text="Select One" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                            <asp:ListItem Text="Muscular" Value="Muscular"></asp:ListItem>
                                            <asp:ListItem Text="Obese" Value="Obese"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Height : </b>
                                        <asp:TextBox ID="txtHeight4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="width: 106px">
                                        <b>Hair : </b>
                                        <asp:TextBox ID="txtHair4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Clothing - Top : </b>
                                        <asp:TextBox ID="txtClothingTop4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Clothing - Bottom : </b>
                                        <asp:TextBox ID="txtClothingBottom4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Shoes : </b>
                                        <asp:TextBox ID="txtShoes4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <b>Weapon : </b>
                                        <asp:TextBox ID="txtWeapon4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtDistFeatures4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Injury Description</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryDesc4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryCause4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Incident Comments</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtIncidentComm4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1"><b><u>Injury Diagram</u></b></td>
                                    <td colspan="1">
                                        <asp:CheckBox ID="cbHuman4" AutoPostBack="true" OnCheckedChanged="cbHuman4_CheckedChanged" runat="server" />
                                        <asp:Label ID="lblImage4" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnDelete4" Height="40px" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Injury Diagram" OnClick="btnDelete4_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image4" Height="300px" Width="400px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane runat="server" ID="acpPerson5" HeaderCssClass="accordion-header-incident"
                        HeaderSelectedCssClass="accordion-header-selected-incident"
                        ContentCssClass="accordionContent1">
                        <Header>Person 5</Header>
                        <Content>
                            <table id="tblPerson5" class="table-incident" runat="server">
                                <tr>
                                    <td colspan="1"><b>Party Type : </b>
                                    </td>
                                    <td colspan="1">
                                        <asp:DropDownList ID="ddlPartyType5" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType5_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Contractor" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Minor" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Liquor and Gaming" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Unknown" Value="8"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td id="witness5l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                                    </td>
                                    <td id="witness5" visible="false" runat="server" colspan="1">
                                        <asp:CheckBox ID="cbWitness5" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff51l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                    </td>
                                    <td id="staff51" runat="server" visible="false" colspan="5">
                                        <asp:TextBox ID="txtStaffEmpNo5" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member52l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                    </td>
                                    <td id="member52" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbCardHeld5" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="member51l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                    </td>
                                    <td id="member51" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtMemberNo5" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td id="visitor51l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                    </td>
                                    <td id="visitor51" runat="server" visible="false" colspan="1">
                                        <asp:CheckBox ID="cbSignInSlip5" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                                    </td>
                                    <td id="visitor52l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                    </td>
                                    <td id="visitor52" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtSignInBy5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="staff52l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="staff52" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtStaffAddress5" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        <br />
                                        <br />
                                        <b>Member Since : </b>
                                    </td>
                                    <td id="member53" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOB5" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender30" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtMemberSince5" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="member55l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                    </td>
                                    <td id="member55" runat="server" visible="false" colspan="1">
                                        <asp:Image ID="imgMember5" Height="110px" Width="140px" runat="server" />
                                    </td>
                                    <td id="visitor53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                    </td>
                                    <td id="visitor53" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtDOBv5" OnTextChanged="TextChanged_TextChanged" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender31" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td id="visitor54l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                    </td>
                                    <td id="visitor54" runat="server" visible="false" colspan="1">
                                        <asp:TextBox ID="txtIDProof5" OnTextChanged="TextChanged_TextChanged" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="member54l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="member54" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddress5" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td id="visitor55l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                    </td>
                                    <td id="visitor55" runat="server" visible="false" colspan="3">
                                        <asp:TextBox ID="txtAddressv5" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><b>First Name : </b>
                                        <asp:TextBox ID="txtFirstName5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2"><b>Last Name : </b>
                                        <asp:TextBox ID="txtLastName5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Alias : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtAlias5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtContact5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 106px">
                                        <b>Age : </b>
                                        <asp:TextBox ID="txtAge5" AutoPostBack="true" OnTextChanged="txtAge5_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Age Group : </b>
                                        <asp:DropDownList ID="ddlAgeGroup5" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="ddlAgeGroup5_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Enabled="true" Text="Select One" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Under 18" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="26-34" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="35-40" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="41-45" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="46-50" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="51-60" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="61+" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="N/A" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Gender : </b>
                                        <asp:DropDownList ID="ddlGender5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="170px">
                                            <asp:ListItem Enabled="true" Text="Select Gender" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>For Any Assault Related Incidents, Record When the Patron Entered the Club</u></b></td>
                                </tr>
                                <tr>
                                    <td style="width: 173px">
                                        <asp:TextBox ID="txtPDate5" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1" style="width: 8px">
                                        <asp:DropDownList ID="ddlPTimeH5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:DropDownList ID="ddlPTimeM5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Build : </b>
                                        <%--<asp:TextBox ID="txtWeight5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlWeight5" runat="server" CssClass="object-default" Height="35px" Width="170px" OnSelectedIndexChanged="TextChanged_TextChanged">
                                            <asp:ListItem Enabled="true" Text="Select One" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                            <asp:ListItem Text="Muscular" Value="Muscular"></asp:ListItem>
                                            <asp:ListItem Text="Obese" Value="Obese"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1">
                                        <b>Height : </b>
                                        <asp:TextBox ID="txtHeight5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="width: 106px">
                                        <b>Hair : </b>
                                        <asp:TextBox ID="txtHair5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <b>Clothing - Top : </b>
                                        <asp:TextBox ID="txtClothingTop5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Clothing - Bottom : </b>
                                        <asp:TextBox ID="txtClothingBottom5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="1">
                                        <b>Shoes : </b>
                                        <asp:TextBox ID="txtShoes5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <b>Weapon : </b>
                                        <asp:TextBox ID="txtWeapon5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtDistFeatures5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Injury Description</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryDesc5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtInjuryCause5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><b><u>Incident Comments</u></b></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtIncidentComm5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1"><b><u>Injury Diagram</u></b></td>
                                    <td colspan="1">
                                        <asp:CheckBox ID="cbHuman5" AutoPostBack="true" OnCheckedChanged="cbHuman5_CheckedChanged" runat="server" />
                                        <asp:Label ID="lblImage5" runat="server" Visible="false" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnDelete5" Height="40px" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Injury Diagram" OnClick="btnDelete5_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image5" Height="300px" Width="400px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
            <table id="tblHuman" visible="false" class="table-incident search" runat="server">
                <tr>
                    <td class="search_es">Eraser
                        <img src="../../../images/eraser.png" onclick="init('Image')" />
                        <%--<INPUT TYPE ="Button" id="btnFillRect" VALUE=" FillRect " onClick="init('Image')">--%>
                    </td>
                    <td class="search_es">Highlight Section
                        <img src="../../../images/rect.png" onclick="init('FillRect')" />
                        <%--<INPUT TYPE ="Button" id="btnFillRect" VALUE=" FillRect " onClick="init('FillRect')">--%>
                    </td>
                    <td class="search_es">Save Image
                        <img src="../../../images/save.png" onclick="SaveImage1()" />
                        <%--    <INPUT TYPE ="Button" VALUE=" SaveImage " onClick="SaveImage1()">--%>
                    </td>
                    <%-- <td class="search_es">Erase</td>
                                        <td class="form_es"> <INPUT TYPE ="Button" id=btnErase" VALUE=" Erase " onClick="init('Erase')"></td>--%>
                </tr>
            </table>
            <section id="section1" visible="false" style="border-style: solid; border-width: 2px; width: 950px; margin-left: 6.6%" runat="server">
                <canvas height="720px" width="919px" id="canvas" onload="init">Your browser is not supporting HTML5 Canvas .Upgrade Browser to view this program or check with Chrome or in Firefox.
                </canvas>
            </section>
            <input type="hidden" name="imageData" id="imageData" runat="server" />
            <table id="tblAddPerson2" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="40%">&nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnAddPerson2" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Person" Height="40px" OnClick="btnAddPerson2_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblAddPerson3" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelPerson2" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Person 2" Height="40px" OnClick="btnDelPerson2_Click" />
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddPerson3" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Person" Height="40px" OnClick="btnAddPerson3_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblAddPerson4" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelPerson3" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Person 3" Height="40px" OnClick="btnDelPerson3_Click" />
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddPerson4" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Person" Height="40px" OnClick="btnAddPerson4_Click" />
                    </td>
                </tr>
            </table>

            <table id="tblAddPerson5" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelPerson4" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Person 4" Height="40px" OnClick="btnDelPerson4_Click" />
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddPerson5" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Person" Height="40px" OnClick="btnAddPerson5_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblDelPerson5" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="40%">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnDelPerson5" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Person 5" Height="40px" OnClick="btnDelPerson5_Click" />
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="5">Incident Date and Time</th>
                </tr>
                <tr style="display: inline-block;">
                    <td style="width: 173px">
                        <asp:TextBox ID="txtDate1" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 8px">
                        <asp:DropDownList ID="ddlHour" runat="server" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" CssClass="object-default" Height="30px" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlMinutes" runat="server" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" CssClass="object-default" Height="30px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">Location of Incident</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>(must be precise and include details of lighting, floor conditions etc. where applicable)</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_Location" RepeatLayout="table" RepeatColumns="5" Font-Size="9" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="List_Location_SelectedIndexChanged" runat="server" class="object-default">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th id="otherLocation" runat="server" visible="false" colspan="4">Other
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtLocation" OnTextChanged="TextChanged_TextChanged" Visible="false" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th>Is there any Camera Footage?</th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbCamera" AutoPostBack="true" OnCheckedChanged="cbCamera_CheckedChanged" Checked="false" runat="server" /></td>
                </tr>
            </table>
            <table class="table-incident" id="tblCamera1" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 1</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded1" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath1" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate1" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate1" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM1" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam2" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="40%">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam2" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam2_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera2" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 2</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded2" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath2" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate2" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate2" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM2" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam3" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelCam2" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 2" Height="40px" OnClick="btnDelCam2_Click" />
                    </td>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam3" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam3_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera3" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 3</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded3" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath3" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate3" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate3" runat="server" OnTextChanged="TextChanged_TextChanged" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM3" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam4" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelCam3" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 3" Height="40px" OnClick="btnDelCam3_Click" />
                    </td>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam4" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam4_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera4" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 4</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc4" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded4" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath4" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate4" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH4" runat="server" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate4" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM4" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam5" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelCam4" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 4" Height="40px" OnClick="btnDelCam4_Click" />
                    </td>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam5" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam5_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera5" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 5</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded5" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath5" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate5" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate5" runat="server" OnTextChanged="TextChanged_TextChanged" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender17" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM5" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam6" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelCam5" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 5" Height="40px" OnClick="btnDelCam5_Click" />
                    </td>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam6" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam6_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera6" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 6</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc6" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded6" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath6" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate6" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender18" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate6" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH6" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM6" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate6" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender19" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate6" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH6" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM6" runat="server" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblAddCam7" class="table-incident" runat="server">
                <tr>
                    <td colspan="2" width="23%">&nbsp;
                    </td>
                    <td colspan="2" width="37%">
                        <asp:Button ID="btnDelCam6" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 6" Height="40px" OnClick="btnDelCam6_Click" />
                    </td>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnAddCam7" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Add Another Camera" Height="40px" OnClick="btnAddCam7_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblCamera7" class="table-incident" runat="server">
                <tr>
                    <th colspan="5">CCTV Camera 7</th>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Description</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamDesc7" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <b>Recorded</b></td>
                    <td colspan="1" style="width: 186px">
                        <asp:CheckBox ID="cbRecorded7" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>File Path</b>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCamFilePath7" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>Start Date/Time</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCamSDate7" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender20" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate7" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamTimeH7" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamTimeM7" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 383px">
                        <b>End Date/Time</b>
                    </td>
                    <td style="width: 173px">
                        <asp:TextBox ID="txtCamEDate7" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender21" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate7" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 131px">
                        <asp:DropDownList ID="ddlCamETimeH7" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlCamETimeM7" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default" Height="35px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table id="tblDelCam7" class="table-incident" runat="server">
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                    <td colspan="1">
                        <asp:Button ID="btnDelCam7" Style="border-bottom-left-radius: .8em; border-bottom-right-radius: .8em; border-top-left-radius: .8em; border-top-right-radius: .8em;" runat="server" Text="Delete Camera 7" Height="40px" OnClick="btnDelCam7_Click" />
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">What Happened?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="cblWhatHappened1" AutoPostBack="true" RepeatLayout="table" RepeatColumns="5" Font-Size="9px" RepeatDirection="vertical" OnSelectedIndexChanged="cblWhatHappened1_SelectedIndexChanged" runat="server" class="object-default">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="refuseEntryReasons" visible="false" runat="server">
                    <th colspan="4">Refuse Entry Reason
                    </th>
                </tr>
                <tr id="refuseEntryReasons1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_RefuseReason" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" Font-Size="10px" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="object-default">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="additionalDetails" visible="false" runat="server">
                    <th colspan="4">Other
                    </th>
                </tr>
                <tr id="additionalDetails1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:TextBox ID="txtOthers" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr id="seriousOther" visible="false" runat="server">
                    <th colspan="4">Serious - Other
                    </th>
                </tr>
                <tr id="seriousOther1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:TextBox ID="txtOtherSerious" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr id="askedtoLeaveReasons" visible="false" runat="server">
                    <th colspan="4">Asked to Leave Reason
                    </th>
                </tr>
                <tr id="askedtoLeaveReasons1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_AskedToLeave" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" Font-Size="10px" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="object-default">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">Full Details of Incident & Injuries</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtDetails" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">Allegation</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>(statement from persons involved, staff and any witness to be obtained and annexed to report)</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtAllegation" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">Action Taken / Incident Details</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_ActionTaken" Font-Size="11px" AutoPostBack="true" OnSelectedIndexChanged="List_ActionTaken_SelectedIndexChanged" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="object-default">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="actionTakenOther" visible="false" runat="server">
                    <th colspan="4">Action Taken - Other
                    </th>
                </tr>
                <tr id="actionTakenOther1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:TextBox ID="txtActionTakenOther" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="70px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">Did Security Attend?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBox ID="cbSecurity" Checked="false" OnCheckedChanged="cbSecurity_CheckedChanged" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="tdSecurity1" runat="server" colspan="4">
                        <b>Name of Security Officer : </b>
                    </td>
                </tr>
                <tr>
                    <td id="tdSecurity2" runat="server" colspan="4">
                        <asp:TextBox ID="txtSecurityName" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">Were the Police Notified?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBox ID="cbPolice" Checked="false" AutoPostBack="true" OnCheckedChanged="cbPolice_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice1" runat="server" colspan="4">
                        <b>Police Station : </b>
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice2" runat="server" colspan="4">
                        <asp:TextBox ID="txtPoliceStation" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice3" runat="server" colspan="4">
                        <b>Officer's Name : </b>
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice4" runat="server" colspan="4">
                        <asp:TextBox ID="txtOfficersName" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice5" runat="server" colspan="4">
                        <b>Police Action : </b>
                    </td>
                </tr>
                <tr>
                    <td id="tdPolice6" runat="server" colspan="4">
                        <asp:TextBox ID="txtPoliceAction" OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

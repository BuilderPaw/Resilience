<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="v1.aspx.cs" Inherits="Reports_MR_Incident_Report_Create_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="jshumanbody.js"></script>
    <script type="text/javascript">
        function setHeight(txtdesc) {
            txtdesc.style.height = txtdesc.scrollHeight + "px";
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" CssClass="spell-button" />
            <div id="body" runat="server" class="body">
                <br />
                <h4 style="margin-left: 8%">MR Incident Report</h4>
                <table class="table-incident">
                    <tr>
                        <th colspan="4">Shift Details</th>
                    </tr>
                    <tr>
                        <td>Staff Name:</td>
                        <td style="width: 260px">
                            <asp:TextBox ID="txtStaffName" runat="server" ReadOnly="true" Style="background-color: white;" CssClass="object-default" />
                        </td>
                        <td>&nbsp</td>
                        <td>&nbsp</td>
                    </tr>
                    <tr>
                        <td style="width: 19%">Shift Type:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="object-default">
                                <asp:ListItem Enabled="true" Text="Select Shift" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Morning" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Afternoon" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Evening" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Night" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Shift Date:                   
                    <asp:RequiredFieldValidator ID="rfvDatePicker" runat="server" ControlToValidate="txtDatePicker"
                        Font-Bold="True" Font-Size="27px" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator></td>
                        <td>
                            <asp:TextBox ID="txtDatePicker" runat="server" Width="245px" class="object-default" autocomplete="off"></asp:TextBox>
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
                            <asp:CheckBox ID="cbAddPerson1" AutoPostBack="true" OnCheckedChanged="cbAddPerson1_CheckedChanged" runat="server" /></td>
                        <td id="noOfPerson1" visible="false" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNoOfPerson" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Accordion ID="acdPerson" runat="server"
                    HeaderCssClass="accordion-header-incident"
                    HeaderSelectedCssClass="accordion-header-selected-incident"
                    ContentCssClass="accordion-content1"
                    AutoSize="None"
                    FadeTransitions="true"
                    TransitionDuration="250"
                    FramesPerSecond="40"
                    RequireOpenedPane="true"
                    SuppressHeaderPostbacks="true">
                    <Panes>
                        <asp:AccordionPane runat="server" ID="acpPerson1">
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
                                            <asp:CheckBox ID="cbWitness1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff11l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                        </td>
                                        <td id="staff11" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffEmpNo1" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member12l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                        </td>
                                        <td id="member12" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbCardHeld1" runat="server" />
                                        </td>
                                        <td id="member11l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                        </td>
                                        <td id="member11" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtMemberNo1" OnTextChanged="txtMemberNo1_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr1', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>
                                        </td>
                                        <td id="visitor11l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                        </td>
                                        <td id="visitor11" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbSignInSlip1" runat="server" />
                                        </td>
                                        <td id="visitor12l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                        </td>
                                        <td id="visitor12" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtSignInBy1" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff12l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="staff12" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffAddress1" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member13l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                                            <br />
                                            <asp:TextBox ID="txtDOB1" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender22" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            <br />
                                            <br />
                                            <b>Member Since : </b>
                                            <br />
                                            <asp:TextBox ID="txtMemberSince1" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <br />
                                            <br />
                                            <b>Address : </b>
                                            <br />
                                            <asp:TextBox ID="txtAddress1" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member14l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                            <br />
                                            <asp:Image ID="imgMember1" Height="110px" Width="140px" runat="server" />
                                        </td>
                                        <td id="visitor13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        </td>
                                        <td id="visitor13" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtDOBv1" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td id="visitor14l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                        </td>
                                        <td id="visitor14" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtIDProof1" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="visitor15l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="visitor15" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtAddressv1" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><b>First Name : </b>
                                            <asp:TextBox ID="txtFirstName1" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="2"><b>Last Name : </b>
                                            <asp:TextBox ID="txtLastName1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Alias : </b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtAlias1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtContact1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 106px">
                                            <b>Age : </b>
                                            <asp:TextBox ID="txtAge1" AutoPostBack="true" OnTextChanged="txtAge1_TextChanged" class="object-default" runat="server" Height="35px" Width="220px" Style="resize: none;"></asp:TextBox>
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
                                        <td>
                                            <b>Gender : </b>
                                            <asp:DropDownList ID="ddlGender1" runat="server" CssClass="object-default" Height="35px" Width="170px">
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
                                            <asp:TextBox ID="txtPDate1" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td colspan="1" style="width: 8px">
                                            <asp:DropDownList ID="ddlPTimeH1" runat="server" CssClass="object-default" Width="150px">
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
                                            <asp:DropDownList ID="ddlPTimeM1" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                                            <%--<asp:TextBox ID="txtWeight1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeight1" runat="server" CssClass="object-default" Height="35px" Width="220px">
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
                                            <asp:TextBox ID="txtHeight1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1" style="width: 106px">
                                            <b>Hair : </b>
                                            <asp:TextBox ID="txtHair1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <b>Clothing - Top : </b>
                                            <asp:TextBox ID="txtClothingTop1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Clothing - Bottom : </b>
                                            <asp:TextBox ID="txtClothingBottom1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Shoes : </b>
                                            <asp:TextBox ID="txtShoes1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Weapon : </b>
                                            <asp:TextBox ID="txtWeapon1" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDistFeatures1" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Description</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryDesc1" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryCause1" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Incident Comments</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtIncidentComm1" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Diagram</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Add Human Body Form in Edit Mode</b></td>
                                    </tr>
                                </table>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="acpPerson2" HeaderCssClass="accordion-header-incident"
                            HeaderSelectedCssClass="accordion-header-selected-incident"
                            ContentCssClass="accordion-content1">
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
                                            <asp:CheckBox ID="cbWitness2" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff21l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                        </td>
                                        <td id="staff21" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffEmpNo2" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member22l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                        </td>
                                        <td id="member22" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbCardHeld2" runat="server" />
                                        </td>
                                        <td id="member21l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                        </td>
                                        <td id="member21" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtMemberNo2" OnTextChanged="txtMemberNo2_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton2" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr2', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>
                                        </td>
                                        <td id="visitor21l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                        </td>
                                        <td id="visitor21" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbSignInSlip2" runat="server" />
                                        </td>
                                        <td id="visitor22l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                        </td>
                                        <td id="visitor22" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtSignInBy2" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff22l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="staff22" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffAddress2" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member23l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                                            <br />
                                            <asp:TextBox ID="txtDOB2" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender24" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            <br />
                                            <br />
                                            <b>Member Since : </b>
                                            <br />
                                            <asp:TextBox ID="txtMemberSince2" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <br />
                                            <br />
                                            <b>Address : </b>
                                            <br />
                                            <asp:TextBox ID="txtAddress2" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member24l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                            <br />
                                            <asp:Image ID="imgMember2" Height="110px" Width="140px" runat="server" />
                                        </td>
                                        <td id="visitor23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        </td>
                                        <td id="visitor23" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtDOBv2" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender25" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td id="visitor24l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                        </td>
                                        <td id="visitor24" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtIDProof2" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="visitor25l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="visitor25" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtAddressv2" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><b>First Name : </b>
                                            <asp:TextBox ID="txtFirstName2" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="2"><b>Last Name : </b>
                                            <asp:TextBox ID="txtLastName2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Alias : </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtAlias2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtContact2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 106px">
                                            <b>Age : </b>
                                            <asp:TextBox ID="txtAge2" AutoPostBack="true" OnTextChanged="txtAge2_TextChanged" class="object-default" runat="server" Height="35px" Width="220px" Style="resize: none;"></asp:TextBox>
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
                                        <td>
                                            <b>Gender : </b>
                                            <asp:DropDownList ID="ddlGender2" runat="server" CssClass="object-default" Height="35px" Width="170px">
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
                                            <asp:TextBox ID="txtPDate2" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td colspan="1" style="width: 8px">
                                            <asp:DropDownList ID="ddlPTimeH2" runat="server" CssClass="object-default" Width="150px">
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
                                            <asp:DropDownList ID="ddlPTimeM2" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                                            <%--<asp:TextBox ID="txtWeight2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeight2" runat="server" CssClass="object-default" Height="35px" Width="220px">
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
                                            <asp:TextBox ID="txtHeight2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1" style="width: 106px">
                                            <b>Hair : </b>
                                            <asp:TextBox ID="txtHair2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <b>Clothing - Top : </b>
                                            <asp:TextBox ID="txtClothingTop2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Clothing - Bottom : </b>
                                            <asp:TextBox ID="txtClothingBottom2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Shoes : </b>
                                            <asp:TextBox ID="txtShoes2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Weapon : </b>
                                            <asp:TextBox ID="txtWeapon2" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDistFeatures2" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Description</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryDesc2" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryCause2" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Incident Comments</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtIncidentComm2" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Diagram</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Add Human Body Form in Edit Mode</b></td>
                                    </tr>
                                </table>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="acpPerson3" HeaderCssClass="accordion-header-incident"
                            HeaderSelectedCssClass="accordion-header-selected-incident"
                            ContentCssClass="accordion-content1">
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
                                            <asp:CheckBox ID="cbWitness3" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff31l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                        </td>
                                        <td id="staff31" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffEmpNo3" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member32l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                        </td>
                                        <td id="member32" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbCardHeld3" runat="server" />
                                        </td>
                                        <td id="member31l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                        </td>
                                        <td id="member31" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtMemberNo3" OnTextChanged="txtMemberNo3_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton3" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr3', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>
                                        </td>
                                        <td id="visitor31l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                        </td>
                                        <td id="visitor31" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbSignInSlip3" runat="server" />
                                        </td>
                                        <td id="visitor32l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                        </td>
                                        <td id="visitor32" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtSignInBy3" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff32l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="staff32" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffAddress3" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member33l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                                            <br />
                                            <asp:TextBox ID="txtDOB3" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender26" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            <br />
                                            <br />
                                            <b>Member Since : </b>
                                            <br />
                                            <asp:TextBox ID="txtMemberSince3" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <br />
                                            <br />
                                            <b>Address : </b>
                                            <br />
                                            <asp:TextBox ID="txtAddress3" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member34l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                            <br />
                                            <asp:Image ID="imgMember3" Height="110px" Width="140px" runat="server" />
                                        </td>
                                        <td id="visitor33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        </td>
                                        <td id="visitor33" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtDOBv3" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender27" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td id="visitor34l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                        </td>
                                        <td id="visitor34" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtIDProof3" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="visitor35l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="visitor35" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtAddressv3" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><b>First Name : </b>
                                            <asp:TextBox ID="txtFirstName3" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="2"><b>Last Name : </b>
                                            <asp:TextBox ID="txtLastName3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Alias : </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtAlias3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtContact3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 106px">
                                            <b>Age : </b>
                                            <asp:TextBox ID="txtAge3" AutoPostBack="true" OnTextChanged="txtAge3_TextChanged" class="object-default" runat="server" Height="35px" Width="220px" Style="resize: none;"></asp:TextBox>
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
                                        <td>
                                            <b>Gender : </b>
                                            <asp:DropDownList ID="ddlGender3" runat="server" CssClass="object-default" Height="35px" Width="170px">
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
                                            <asp:TextBox ID="txtPDate3" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td colspan="1" style="width: 8px">
                                            <asp:DropDownList ID="ddlPTimeH3" runat="server" CssClass="object-default" Width="150px">
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
                                            <asp:DropDownList ID="ddlPTimeM3" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                                            <%--<asp:TextBox ID="txtWeight3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeight3" runat="server" CssClass="object-default" Height="35px" Width="220px">
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
                                            <asp:TextBox ID="txtHeight3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1" style="width: 106px">
                                            <b>Hair : </b>
                                            <asp:TextBox ID="txtHair3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <b>Clothing - Top : </b>
                                            <asp:TextBox ID="txtClothingTop3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Clothing - Bottom : </b>
                                            <asp:TextBox ID="txtClothingBottom3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Shoes : </b>
                                            <asp:TextBox ID="txtShoes3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Weapon : </b>
                                            <asp:TextBox ID="txtWeapon3" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDistFeatures3" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Description</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryDesc3" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryCause3" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Incident Comments</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtIncidentComm3" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Diagram</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Add Human Body Form in Edit Mode</b></td>
                                    </tr>
                                </table>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="acpPerson4" HeaderCssClass="accordion-header-incident"
                            HeaderSelectedCssClass="accordion-header-selected-incident"
                            ContentCssClass="accordion-content1">
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
                                            <asp:CheckBox ID="cbWitness4" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff41l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                        </td>
                                        <td id="staff41" runat="server" visible="false" colspan="4">
                                            <asp:TextBox ID="txtStaffEmpNo4" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member42l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                        </td>
                                        <td id="member42" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbCardHeld4" runat="server" />
                                        </td>
                                        <td id="member41l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                        </td>
                                        <td id="member41" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtMemberNo4" OnTextChanged="txtMemberNo4_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton4" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr4', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>
                                        </td>
                                        <td id="visitor41l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                        </td>
                                        <td id="visitor41" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbSignInSlip4" runat="server" />
                                        </td>
                                        <td id="visitor42l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                        </td>
                                        <td id="visitor42" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtSignInBy4" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff42l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="staff42" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffAddress4" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member43l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                                            <br />
                                            <asp:TextBox ID="txtDOB4" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender28" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            <br />
                                            <br />
                                            <b>Member Since : </b>
                                            <br />
                                            <asp:TextBox ID="txtMemberSince4" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <br />
                                            <br />
                                            <b>Address : </b>
                                            <br />
                                            <asp:TextBox ID="txtAddress4" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member44l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                            <br />
                                            <asp:Image ID="imgMember4" Height="110px" Width="140px" runat="server" />
                                        </td>
                                        <td id="visitor43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        </td>
                                        <td id="visitor43" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtDOBv4" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender29" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td id="visitor44l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                        </td>
                                        <td id="visitor44" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtIDProof4" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="visitor45l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="visitor45" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtAddressv4" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><b>First Name : </b>
                                            <asp:TextBox ID="txtFirstName4" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="2"><b>Last Name : </b>
                                            <asp:TextBox ID="txtLastName4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Alias : </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtAlias4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtContact4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 106px">
                                            <b>Age : </b>
                                            <asp:TextBox ID="txtAge4" AutoPostBack="true" OnTextChanged="txtAge4_TextChanged" class="object-default" runat="server" Height="35px" Width="220px" Style="resize: none;"></asp:TextBox>
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
                                        <td>
                                            <b>Gender : </b>
                                            <asp:DropDownList ID="ddlGender4" runat="server" CssClass="object-default" Height="35px" Width="170px">
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
                                            <asp:TextBox ID="txtPDate4" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td colspan="1" style="width: 8px">
                                            <asp:DropDownList ID="ddlPTimeH4" runat="server" CssClass="object-default" Width="150px">
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
                                            <asp:DropDownList ID="ddlPTimeM4" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                                            <%--<asp:TextBox ID="txtWeight4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeight4" runat="server" CssClass="object-default" Height="35px" Width="220px">
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
                                            <asp:TextBox ID="txtHeight4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1" style="width: 106px">
                                            <b>Hair : </b>
                                            <asp:TextBox ID="txtHair4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <b>Clothing - Top : </b>
                                            <asp:TextBox ID="txtClothingTop4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Clothing - Bottom : </b>
                                            <asp:TextBox ID="txtClothingBottom4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Shoes : </b>
                                            <asp:TextBox ID="txtShoes4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Weapon : </b>
                                            <asp:TextBox ID="txtWeapon4" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDistFeatures4" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Description</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryDesc4" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryCause4" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Incident Comments</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtIncidentComm4" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Diagram</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Add Human Body Form in Edit Mode</b></td>
                                    </tr>
                                </table>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="acpPerson5" HeaderCssClass="accordion-header-incident"
                            HeaderSelectedCssClass="accordion-header-selected-incident"
                            ContentCssClass="accordion-content1">
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
                                            <asp:CheckBox ID="cbWitness5" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff51l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                                        </td>
                                        <td id="staff51" runat="server" visible="false" colspan="5">
                                            <asp:TextBox ID="txtStaffEmpNo5" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member52l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                                        </td>
                                        <td id="member52" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbCardHeld5" runat="server" />
                                        </td>
                                        <td id="member51l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                                        </td>
                                        <td id="member51" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtMemberNo5" OnTextChanged="txtMemberNo5_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr5', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>
                                        </td>
                                        <td id="visitor51l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                                        </td>
                                        <td id="visitor51" runat="server" visible="false" colspan="1">
                                            <asp:CheckBox ID="cbSignInSlip5" runat="server" />
                                        </td>
                                        <td id="visitor52l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                                        </td>
                                        <td id="visitor52" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtSignInBy5" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="staff52l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="staff52" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtStaffAddress5" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member53l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                                            <br />
                                            <asp:TextBox ID="txtDOB5" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender30" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            <br />
                                            <br />
                                            <b>Member Since : </b>
                                            <br />
                                            <asp:TextBox ID="txtMemberSince5" Enabled="false" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                            <br />
                                            <br />
                                            <b>Address : </b>
                                            <br />
                                            <asp:TextBox ID="txtAddress5" runat="server" Width="100%" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td id="member54l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                                            <br />
                                            <asp:Image ID="imgMember5" Height="110px" Width="140px" runat="server" />
                                        </td>
                                        <td id="visitor53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                                        </td>
                                        <td id="visitor53" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtDOBv5" runat="server" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender31" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td id="visitor54l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                                        </td>
                                        <td id="visitor54" runat="server" visible="false" colspan="1">
                                            <asp:TextBox ID="txtIDProof5" runat="server" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="visitor55l" runat="server" visible="false" colspan="1"><b>Address : </b>
                                        </td>
                                        <td id="visitor55" runat="server" visible="false" colspan="3">
                                            <asp:TextBox ID="txtAddressv5" runat="server" Style="resize: none;" class="object-default" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><b>First Name : </b>
                                            <asp:TextBox ID="txtFirstName5" class="object-default" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="2"><b>Last Name : </b>
                                            <asp:TextBox ID="txtLastName5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Alias : </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtAlias5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtContact5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 106px">
                                            <b>Age : </b>
                                            <asp:TextBox ID="txtAge5" AutoPostBack="true" OnTextChanged="txtAge5_TextChanged" class="object-default" runat="server" Height="35px" Width="220px" Style="resize: none;"></asp:TextBox>
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
                                        <td>
                                            <b>Gender : </b>
                                            <asp:DropDownList ID="ddlGender5" runat="server" CssClass="object-default" Height="35px" Width="170px">
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
                                            <asp:TextBox ID="txtPDate5" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtPDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                        </td>
                                        <td colspan="1" style="width: 8px">
                                            <asp:DropDownList ID="ddlPTimeH5" runat="server" CssClass="object-default" Width="150px">
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
                                            <asp:DropDownList ID="ddlPTimeM5" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                                            <%--<asp:TextBox ID="txtWeight5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeight5" runat="server" CssClass="object-default" Height="35px" Width="220px">
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
                                            <asp:TextBox ID="txtHeight5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1" style="width: 106px">
                                            <b>Hair : </b>
                                            <asp:TextBox ID="txtHair5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <b>Clothing - Top : </b>
                                            <asp:TextBox ID="txtClothingTop5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Clothing - Bottom : </b>
                                            <asp:TextBox ID="txtClothingBottom5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Shoes : </b>
                                            <asp:TextBox ID="txtShoes5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                            <b>Weapon : </b>
                                            <asp:TextBox ID="txtWeapon5" class="object-default" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <b>Distinguishing Features : (Other e.g. tattoos)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDistFeatures5" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Description</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryDesc5" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Cause of Injury</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtInjuryCause5" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Incident Comments</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtIncidentComm5" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine" onkeyup="setHeight(this);" onkeydown="setHeight(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b><u>Injury Diagram</u></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4"><b>Add Human Body Form in Edit Mode</b></td>
                                    </tr>
                                </table>
                            </Content>
                        </asp:AccordionPane>
                    </Panes>
                </asp:Accordion>
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
                        <td colspan="2">&nbsp;
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
                            <asp:TextBox ID="txtDate1" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 8px">
                            <asp:DropDownList ID="ddlHour" runat="server" CssClass="object-default" Height="30px" Width="150px">
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
                            <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="object-default" Height="30px" Width="180px">
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
                        <!--<td colspan="1" rowspan="1">    // Time Convention - AM/PM
                            <asp:DropDownList ID="ddlTimeCon" runat="server" CssClass="object-default" Height="30px" Width="200px">
                                <asp:ListItem Enabled="true" Text="Select Time Convention" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="1"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>-->
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
                            <asp:CheckBoxList ID="List_Location" RepeatLayout="table" RepeatColumns="5" Font-Size="8" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="List_Location_SelectedIndexChanged" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th id="otherLocation" runat="server" visible="false" colspan="4">Other
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtLocation" Visible="false" onkeyup="setHeight(this);" onkeydown="setHeight(this);" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table class="table-incident">
                    <tr>
                        <th>Is there any Camera Footage?</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCamera" AutoPostBack="true" OnCheckedChanged="cbCamera_CheckedChanged" runat="server" /></td>
                    </tr>
                </table>
                <table id="tblCamera1" class="table-incident" runat="server">
                    <tr>
                        <th colspan="5">CCTV Camera 1</th>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Description</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamDesc1" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath1" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate1" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH1" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM1" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate1" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH1" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM1" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc2" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath2" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate2" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH2" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM2" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate2" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate2" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH2" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM2" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc3" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath3" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate3" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH3" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM3" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate3" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate3" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH3" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM3" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc4" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded4" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath4" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate4" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH4" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM4" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate4" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate4" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH4" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM4" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc5" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded5" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath5" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate5" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH5" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM5" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate5" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender17" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate5" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH5" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM5" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc6" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded6" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath6" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate6" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender18" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate6" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH6" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM6" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate6" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender19" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate6" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH6" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM6" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamDesc7" class="object-default" runat="server" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <b>Recorded</b></td>
                        <td colspan="1" style="width: 186px">
                            <asp:CheckBox ID="cbRecorded7" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>File Path</b>
                        </td>
                        <td colspan="1">
                            <asp:TextBox ID="txtCamFilePath7" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 383px">
                            <b>Start Date/Time</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCamSDate7" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender20" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamSDate7" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamTimeH7" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamTimeM7" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                            <asp:TextBox ID="txtCamEDate7" runat="server" Width="220px" Placeholder="Select Date" class="object-default" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender21" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtCamEDate7" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        </td>
                        <td colspan="1" style="width: 131px">
                            <asp:DropDownList ID="ddlCamETimeH7" runat="server" CssClass="object-default" Width="150px">
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
                            <asp:DropDownList ID="ddlCamETimeM7" runat="server" CssClass="object-default" Height="35px" Width="180px">
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
                        <td colspan="2" width="40%">&nbsp;
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
                            <asp:CheckBoxList ID="cblWhatHappened1" Font-Size="11px" RepeatLayout="table" RepeatColumns="5" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="cblWhatHappened1_SelectedIndexChanged" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="refuseEntryReasons" visible="false" runat="server">
                        <th colspan="4">Refuse Entry Reason
                        </th>
                    </tr>
                    <tr id="refuseEntryReasons1" visible="false" runat="server">
                        <td colspan="4">
                            <asp:CheckBoxList ID="List_RefuseReason" Font-Size="11px" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="additionalDetails" visible="false" runat="server">
                        <th colspan="4">Other
                        </th>
                    </tr>
                    <tr id="additionalDetails1" visible="false" runat="server">
                        <td colspan="4">
                            <asp:TextBox ID="txtOthers" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="seriousOther" visible="false" runat="server">
                        <th colspan="4">Serious - Other
                        </th>
                    </tr>
                    <tr id="seriousOther1" visible="false" runat="server">
                        <td colspan="4">
                            <asp:TextBox ID="txtOtherSerious" class="object-default" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="askedtoLeaveReasons" visible="false" runat="server">
                        <th colspan="4">Asked to Leave Reason
                        </th>
                    </tr>
                    <tr id="askedtoLeaveReasons1" visible="false" runat="server">
                        <td colspan="4">
                            <asp:CheckBoxList ID="List_AskedToLeave" Font-Size="11px" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4">Full Details of Incident & Injuries</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtDetails" class="object-default" onkeyup="setHeight(this);" onkeydown="setHeight(this);" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:TextBox ID="txtAllegation" class="object-default" onkeyup="setHeight(this);" onkeydown="setHeight(this);" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4">Action Taken / Incident Details</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBoxList ID="List_ActionTaken" Font-Size="11px" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="List_ActionTaken_SelectedIndexChanged" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="actionTakenOther" visible="false" runat="server">
                        <th colspan="4">Action Taken - Other
                        </th>
                    </tr>
                    <tr id="actionTakenOther1" visible="false" runat="server">
                        <td colspan="4">
                            <asp:TextBox ID="txtActionTakenOther" class="object-default" runat="server" Height="70px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4">Did Security Attend?</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="cbSecurity" AutoPostBack="true" Checked="false" OnCheckedChanged="cbSecurity_CheckedChanged" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdSecurity1" runat="server" colspan="4">
                            <b>Name of Security Officer : </b>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdSecurity2" runat="server" colspan="4">
                            <asp:TextBox ID="txtSecurityName" onkeyup="setHeight(this);" onkeydown="setHeight(this);" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4">Were the Police Notified?</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="cbPolice" AutoPostBack="true" Checked="false" OnCheckedChanged="cbPolice_CheckedChanged" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice1" runat="server" colspan="4">
                            <b>Police Station : </b>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice2" runat="server" colspan="4">
                            <asp:TextBox ID="txtPoliceStation" onkeyup="setHeight(this);" onkeydown="setHeight(this);" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice3" runat="server" colspan="4">
                            <b>Officer's Name : </b>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice4" runat="server" colspan="4">
                            <asp:TextBox ID="txtOfficersName" onkeyup="setHeight(this);" onkeydown="setHeight(this);" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice5" runat="server" colspan="4">
                            <b>Police Action : </b>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdPolice6" runat="server" colspan="4">
                            <asp:TextBox ID="txtPoliceAction" onkeyup="setHeight(this);" onkeydown="setHeight(this);" class="object-default" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                        <td colspan="2">
                            <asp:Button ID="btnSubmit" Style="float: right; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Save Form" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
                            <asp:Button ID="btnSign" Style="float: right; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Sign Report" OnClick="btnSign_Click" />
                            <asp:Button ID="btnReset" Style="float: left; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Clear Form" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
                <div id="userSign" class="digital-signature" visible="false" runat="server">
                    <asp:CheckBox ID="cbUserSign" runat="server" CssClass="digital-signature-checkbox" />
                    <p class="digital-signature-paragraph">I have reviewed the incident report and all other relevant material available and I am satisfied as to its accuracy</p>
                    <br />
                    <br />
                    <asp:Button ID="btnUserSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnUserSign_Click" Text="Accept" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancelUserSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnCancelUserSign_Click" Text="Cancel" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

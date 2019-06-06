<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Incident_Report_View_v1_Link_v1" %>
<div class="table-link-view">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="reportNo"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
    </div>
    <div id="incidentReport" runat="server">
        <table class="table-view">
            <tr>
                <th colspan="5">Shift Details</th>
            </tr>
            <tr style="border: solid .5px;">
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffName").ToString())) ? Eval("StaffName") : (Eval("StaffName").ToString()).Replace("^", "'") %>
                </td>
                <td>Entry Details:</td>
                <td><%# Convert.ToDateTime(Eval("EntryDate")).ToString("dd/MM/yyyy HH:mm") %></td>
            </tr>
            <tr>
                <td style="width: 19%">Shift Type:
                </td>
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("ShiftName").ToString())) ? Eval("ShiftName") : (Eval("ShiftName").ToString()).Replace("^", "'") %>
                </td>
                <td>Shift Date:</td>
                <td>
                    <%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dddd, dd MMMM yyyy") %>
                </td>
            </tr>
        </table>
        <table id="tblPerson1" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 1</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType1" runat="server"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType1").ToString())) ? Eval("TxtPartyType1") : (Eval("TxtPartyType1").ToString()).Replace("^", "'") %>
                </td>
                <td id="witness1l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness1")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff11l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffEmpNo1").ToString())) ? Eval("StaffEmpNo1") : (Eval("StaffEmpNo1").ToString()).Replace("^", "'") %>
                </td>
                <td id="member12l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld1")) %>' />
                </td>
                <td id="member11l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu1', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo1").ToString())) ? Eval("MemberNo1") : (Eval("MemberNo1").ToString()).Replace("^", "'") %></asp:LinkButton>
                </td>
                <td id="visitor11l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip1")) %>' />
                </td>
                <td id="visitor12l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy1").ToString())) ? Eval("SignedInBy1") : (Eval("SignedInBy1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="staff12l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffAddress1").ToString())) ? Eval("StaffAddress1") : (Eval("StaffAddress1").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB1")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince1").ToString())) ? Eval("MemberSince1") : (Eval("MemberSince1").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress1").ToString())) ? Eval("MemberAddress1") : (Eval("MemberAddress1").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member14l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember1" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB1")) %>
                </td>
                <td id="visitor14l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID1").ToString())) ? Eval("VisitorProofID1") : (Eval("VisitorProofID1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor15l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress1").ToString())) ? Eval("VisitorAddress1") : (Eval("VisitorAddress1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName1").ToString())) ? Eval("FirstName1") : (Eval("FirstName1").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName1").ToString())) ? Eval("LastName1") : (Eval("LastName1").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias1").ToString())) ? Eval("Alias1") : (Eval("Alias1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact1").ToString())) ? Eval("Contact1") : (Eval("Contact1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
           <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Age1").ToString())) ? Eval("Age1") : (Eval("Age1").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup1" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtGender1").ToString())) ? Eval("TxtGender1") : (Eval("TxtGender1").ToString()).Replace("^", "'") %>
                </td>
            </tr>            
            <tr>
                <td id="physical1" runat="server" colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1" id="weight1" runat="server">
                    <b>Build :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weight1").ToString())) ? Eval("Weight1") : (Eval("Weight1").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="height1" runat="server">
                    <b>Height :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Height1").ToString())) ? Eval("Height1") : (Eval("Height1").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" runat="server" id="hair1">
                    <b>Hair :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Hair1").ToString())) ? Eval("Hair1") : (Eval("Hair1").ToString()).Replace("^", "'") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="clothingTop1">
                    <b>Clothing - Top :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingTop1").ToString())) ? Eval("ClothingTop1") : (Eval("ClothingTop1").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="clothingBottom1" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingBottom1").ToString())) ? Eval("ClothingBottom1") : (Eval("ClothingBottom1").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="shoes1" runat="server">
                    <b>Shoes :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Shoes1").ToString())) ? Eval("Shoes1") : (Eval("Shoes1").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="weapon1" runat="server">
                    <b>Weapon :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weapon1").ToString())) ? Eval("Weapon1") : (Eval("Weapon1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="p1DateEntryl" runat="server"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="p1DateEntry" runat="server">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate1")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeH1").ToString())) ? Eval("TxtPTimeH1") : (Eval("TxtPTimeH1").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeM1").ToString())) ? Eval("TxtPTimeM1") : (Eval("TxtPTimeM1").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeTC1").ToString())) ? Eval("TxtPTimeTC1") : (Eval("TxtPTimeTC1").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist1l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist1" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("DistFeatures1").ToString())) ? Eval("DistFeatures1") : (Eval("DistFeatures1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc1l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc1" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("InjuryDesc1").ToString())) ? Eval("InjuryDesc1") : (Eval("InjuryDesc1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj1l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj1" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("CauseInjury1").ToString())) ? Eval("CauseInjury1") : (Eval("CauseInjury1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom1l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom1" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments1").ToString())) ? Eval("Comments1") : (Eval("Comments1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image1l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image1" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson2" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 2</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType2" runat="server"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType2").ToString())) ? Eval("TxtPartyType2") : (Eval("TxtPartyType2").ToString()).Replace("^", "'") %>
                </td>
                <td id="witness2l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness2")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff21l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffEmpNo2").ToString())) ? Eval("StaffEmpNo2") : (Eval("StaffEmpNo2").ToString()).Replace("^", "'") %>
                </td>
                <td id="member22l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld2")) %>' />
                </td>
                <td id="member21l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu2', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo2").ToString())) ? Eval("MemberNo2") : (Eval("MemberNo2").ToString()).Replace("^", "'") %></asp:LinkButton>
                </td>
                <td id="visitor21l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip2")) %>' />
                </td>
                <td id="visitor22l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy2").ToString())) ? Eval("SignedInBy2") : (Eval("SignedInBy2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="staff22l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffAddress2").ToString())) ? Eval("StaffAddress2") : (Eval("StaffAddress2").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB2")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince2").ToString())) ? Eval("MemberSince2") : (Eval("MemberSince2").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress2").ToString())) ? Eval("MemberAddress2") : (Eval("MemberAddress2").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member24l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember2" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB2")) %>
                </td>
                <td id="visitor24l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID2").ToString())) ? Eval("VisitorProofID2") : (Eval("VisitorProofID2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor25l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress2").ToString())) ? Eval("VisitorAddress2") : (Eval("VisitorAddress2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName2").ToString())) ? Eval("FirstName2") : (Eval("FirstName2").ToString()).Replace("^", "'") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName2").ToString())) ? Eval("LastName2") : (Eval("LastName2").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias2").ToString())) ? Eval("Alias2") : (Eval("Alias2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact2").ToString())) ? Eval("Contact2") : (Eval("Contact2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
           <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Age2").ToString())) ? Eval("Age2") : (Eval("Age2").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup2" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtGender2").ToString())) ? Eval("TxtGender2") : (Eval("TxtGender2").ToString()).Replace("^", "'") %>
                </td>
            </tr>            
            <tr>
                <td id="physical2" runat="server" colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1" id="weight2" runat="server">
                    <b>Build :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weight2").ToString())) ? Eval("Weight2") : (Eval("Weight2").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="height2" runat="server">
                    <b>Height :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Height2").ToString())) ? Eval("Height2") : (Eval("Height2").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" runat="server" id="hair2">
                    <b>Hair :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Hair2").ToString())) ? Eval("Hair2") : (Eval("Hair2").ToString()).Replace("^", "'") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="clothingTop2">
                    <b>Clothing - Top :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingTop2").ToString())) ? Eval("ClothingTop2") : (Eval("ClothingTop2").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="clothingBottom2" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingBottom2").ToString())) ? Eval("ClothingBottom2") : (Eval("ClothingBottom2").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="shoes2" runat="server">
                    <b>Shoes :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Shoes2").ToString())) ? Eval("Shoes2") : (Eval("Shoes2").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="weapon2" runat="server">
                    <b>Weapon :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weapon2").ToString())) ? Eval("Weapon2") : (Eval("Weapon2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="p2DateEntryl" runat="server"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="p2DateEntry" runat="server">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate2")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeH2").ToString())) ? Eval("TxtPTimeH2") : (Eval("TxtPTimeH2").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeM2").ToString())) ? Eval("TxtPTimeM2") : (Eval("TxtPTimeM2").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeTC2").ToString())) ? Eval("TxtPTimeTC2") : (Eval("TxtPTimeTC2").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist2l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist2" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("DistFeatures2").ToString())) ? Eval("DistFeatures2") : (Eval("DistFeatures2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc2l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc2" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("InjuryDesc2").ToString())) ? Eval("InjuryDesc2") : (Eval("InjuryDesc2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj2l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj2" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("CauseInjury2").ToString())) ? Eval("CauseInjury2") : (Eval("CauseInjury2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom2l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom2" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments2").ToString())) ? Eval("Comments2") : (Eval("Comments2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image2l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image2" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson3" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 3</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType3" runat="server"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType3").ToString())) ? Eval("TxtPartyType3") : (Eval("TxtPartyType3").ToString()).Replace("^", "'") %>  
                </td>
                <td id="witness3l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness3")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff31l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffEmpNo3").ToString())) ? Eval("StaffEmpNo3") : (Eval("StaffEmpNo3").ToString()).Replace("^", "'") %>
                </td>
                <td id="member32l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld3")) %>' />
                </td>
                <td id="member31l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu3', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo3").ToString())) ? Eval("MemberNo3") : (Eval("MemberNo3").ToString()).Replace("^", "'") %></asp:LinkButton>
                </td>
                <td id="visitor31l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip3")) %>' />
                </td>
                <td id="visitor32l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy3").ToString())) ? Eval("SignedInBy3") : (Eval("SignedInBy3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="staff32l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffAddress3").ToString())) ? Eval("StaffAddress3") : (Eval("StaffAddress3").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB3")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince3").ToString())) ? Eval("MemberSince3") : (Eval("MemberSince3").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress3").ToString())) ? Eval("MemberAddress3") : (Eval("MemberAddress3").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member34l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember3" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB3")) %>
                </td>
                <td id="visitor34l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID3").ToString())) ? Eval("VisitorProofID3") : (Eval("VisitorProofID3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor35l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress3").ToString())) ? Eval("VisitorAddress3") : (Eval("VisitorAddress3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName3").ToString())) ? Eval("FirstName3") : (Eval("FirstName3").ToString()).Replace("^", "'") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName3").ToString())) ? Eval("LastName3") : (Eval("LastName3").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias3").ToString())) ? Eval("Alias3") : (Eval("Alias3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact3").ToString())) ? Eval("Contact3") : (Eval("Contact3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
             <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Age3").ToString())) ? Eval("Age3") : (Eval("Age3").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup3" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtGender3").ToString())) ? Eval("TxtGender3") : (Eval("TxtGender3").ToString()).Replace("^", "'") %>
                </td>
            </tr>            
            <tr>
                <td id="physical3" runat="server" colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1" id="weight3" runat="server">
                    <b>Build :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weight3").ToString())) ? Eval("Weight3") : (Eval("Weight3").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="height3" runat="server">
                    <b>Height :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Height3").ToString())) ? Eval("Height3") : (Eval("Height3").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" runat="server" id="hair3">
                    <b>Hair :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Hair3").ToString())) ? Eval("Hair3") : (Eval("Hair3").ToString()).Replace("^", "'") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="clothingTop3">
                    <b>Clothing - Top :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingTop3").ToString())) ? Eval("ClothingTop3") : (Eval("ClothingTop3").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="clothingBottom3" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingBottom3").ToString())) ? Eval("ClothingBottom3") : (Eval("ClothingBottom3").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="shoes3" runat="server">
                    <b>Shoes :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Shoes3").ToString())) ? Eval("Shoes3") : (Eval("Shoes3").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="weapon3" runat="server">
                    <b>Weapon :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weapon3").ToString())) ? Eval("Weapon3") : (Eval("Weapon3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="p3DateEntryl" runat="server"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="p3DateEntry" runat="server">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate3")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeH3").ToString())) ? Eval("TxtPTimeH3") : (Eval("TxtPTimeH3").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeM3").ToString())) ? Eval("TxtPTimeM3") : (Eval("TxtPTimeM3").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeTC3").ToString())) ? Eval("TxtPTimeTC3") : (Eval("TxtPTimeTC3").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist3l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist3" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("DistFeatures3").ToString())) ? Eval("DistFeatures3") : (Eval("DistFeatures3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc3l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc3" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("InjuryDesc3").ToString())) ? Eval("InjuryDesc3") : (Eval("InjuryDesc3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj3l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj3" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("CauseInjury3").ToString())) ? Eval("CauseInjury3") : (Eval("CauseInjury3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom3l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom3" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments3").ToString())) ? Eval("Comments3") : (Eval("Comments3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image3l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image3" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson4" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 4</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType4" runat="server"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType4").ToString())) ? Eval("TxtPartyType4") : (Eval("TxtPartyType4").ToString()).Replace("^", "'") %>  
                </td>
                <td id="witness4l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness4")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff41l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffEmpNo4").ToString())) ? Eval("StaffEmpNo4") : (Eval("StaffEmpNo4").ToString()).Replace("^", "'") %>
                </td>
                <td id="member42l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld4")) %>' />
                </td>
                <td id="member41l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu4', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo4").ToString())) ? Eval("MemberNo4") : (Eval("MemberNo4").ToString()).Replace("^", "'") %></asp:LinkButton>
                </td>
                <td id="visitor41l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip4")) %>' />
                </td>
                <td id="visitor42l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy4").ToString())) ? Eval("SignedInBy4") : (Eval("SignedInBy4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="staff42l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffAddress4").ToString())) ? Eval("StaffAddress4") : (Eval("StaffAddress4").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB4")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince4").ToString())) ? Eval("MemberSince4") : (Eval("MemberSince4").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress4").ToString())) ? Eval("MemberAddress4") : (Eval("MemberAddress4").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member44l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember4" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB4")) %>
                </td>
                <td id="visitor44l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID4").ToString())) ? Eval("VisitorProofID4") : (Eval("VisitorProofID4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor45l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress4").ToString())) ? Eval("VisitorAddress4") : (Eval("VisitorAddress4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName4").ToString())) ? Eval("FirstName4") : (Eval("FirstName4").ToString()).Replace("^", "'") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName4").ToString())) ? Eval("LastName4") : (Eval("LastName4").ToString()).Replace("^", "'") %>                
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias4").ToString())) ? Eval("Alias4") : (Eval("Alias4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact4").ToString())) ? Eval("Contact4") : (Eval("Contact4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Age4").ToString())) ? Eval("Age4") : (Eval("Age4").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup4" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtGender4").ToString())) ? Eval("TxtGender4") : (Eval("TxtGender4").ToString()).Replace("^", "'") %>
                </td>
            </tr>            
            <tr>
                <td id="physical4" runat="server" colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1" id="weight4" runat="server">
                    <b>Build :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weight4").ToString())) ? Eval("Weight4") : (Eval("Weight4").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="height4" runat="server">
                    <b>Height :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Height4").ToString())) ? Eval("Height4") : (Eval("Height4").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" runat="server" id="hair4">
                    <b>Hair :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Hair4").ToString())) ? Eval("Hair4") : (Eval("Hair4").ToString()).Replace("^", "'") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="clothingTop4">
                    <b>Clothing - Top :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingTop4").ToString())) ? Eval("ClothingTop4") : (Eval("ClothingTop4").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="clothingBottom4" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingBottom4").ToString())) ? Eval("ClothingBottom4") : (Eval("ClothingBottom4").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="shoes4" runat="server">
                    <b>Shoes :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Shoes4").ToString())) ? Eval("Shoes4") : (Eval("Shoes4").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="weapon4" runat="server">
                    <b>Weapon :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weapon4").ToString())) ? Eval("Weapon4") : (Eval("Weapon4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="p4DateEntryl" runat="server"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="p4DateEntry" runat="server">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate4")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeH4").ToString())) ? Eval("TxtPTimeH4") : (Eval("TxtPTimeH4").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeM4").ToString())) ? Eval("TxtPTimeM4") : (Eval("TxtPTimeM4").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeTC4").ToString())) ? Eval("TxtPTimeTC4") : (Eval("TxtPTimeTC4").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist4l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist4" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("DistFeatures4").ToString())) ? Eval("DistFeatures4") : (Eval("DistFeatures4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc4l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc4" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("InjuryDesc4").ToString())) ? Eval("InjuryDesc4") : (Eval("InjuryDesc4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj4l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj4" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("CauseInjury4").ToString())) ? Eval("CauseInjury4") : (Eval("CauseInjury4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom4l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom4" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments4").ToString())) ? Eval("Comments4") : (Eval("Comments4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image4l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image4" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson5" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 5</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType5" runat="server"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType5").ToString())) ? Eval("TxtPartyType5") : (Eval("TxtPartyType5").ToString()).Replace("^", "'") %>
                </td>
                <td id="witness5l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness5")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff51l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffEmpNo5").ToString())) ? Eval("StaffEmpNo5") : (Eval("StaffEmpNo5").ToString()).Replace("^", "'") %>
                </td>
                <td id="member52l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld5")) %>' />
                </td>
                <td id="member51l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu5', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo5").ToString())) ? Eval("MemberNo5") : (Eval("MemberNo5").ToString()).Replace("^", "'") %></asp:LinkButton>
                </td>
                <td id="visitor51l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip5")) %>' />
                </td>
                <td id="visitor52l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy5").ToString())) ? Eval("SignedInBy5") : (Eval("SignedInBy5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="staff52l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffAddress5").ToString())) ? Eval("StaffAddress5") : (Eval("StaffAddress5").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB5")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince5").ToString())) ? Eval("MemberSince5") : (Eval("MemberSince5").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress5").ToString())) ? Eval("MemberAddress5") : (Eval("MemberAddress5").ToString()).Replace("^", "'") %>
                </td>
                <td style="font-size: 12.5px" id="member54l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember5" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB5")) %>
                </td>
                <td id="visitor54l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID5").ToString())) ? Eval("VisitorProofID5") : (Eval("VisitorProofID5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor55l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress5").ToString())) ? Eval("VisitorAddress5") : (Eval("VisitorAddress5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName5").ToString())) ? Eval("FirstName5") : (Eval("FirstName5").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName5").ToString())) ? Eval("LastName5") : (Eval("LastName5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias5").ToString())) ? Eval("Alias5") : (Eval("Alias5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact5").ToString())) ? Eval("Contact5") : (Eval("Contact5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
             <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Age5").ToString())) ? Eval("Age5") : (Eval("Age5").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup5" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtGender5").ToString())) ? Eval("TxtGender5") : (Eval("TxtGender5").ToString()).Replace("^", "'") %>
                </td>
            </tr>            
            <tr>
                <td id="physical5" runat="server" colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1" id="weight5" runat="server">
                    <b>Build :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weight5").ToString())) ? Eval("Weight5") : (Eval("Weight5").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="height5" runat="server">
                    <b>Height :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Height5").ToString())) ? Eval("Height5") : (Eval("Height5").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" runat="server" id="hair5">
                    <b>Hair :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Hair5").ToString())) ? Eval("Hair5") : (Eval("Hair5").ToString()).Replace("^", "'") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="clothingTop5">
                    <b>Clothing - Top :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingTop5").ToString())) ? Eval("ClothingTop5") : (Eval("ClothingTop5").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="clothingBottom5" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("ClothingBottom5").ToString())) ? Eval("ClothingBottom5") : (Eval("ClothingBottom5").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" id="shoes5" runat="server">
                    <b>Shoes :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Shoes5").ToString())) ? Eval("Shoes5") : (Eval("Shoes5").ToString()).Replace("^", "'") %>    
                </td>
                <td colspan="1" id="weapon5" runat="server">
                    <b>Weapon :</b><br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Weapon5").ToString())) ? Eval("Weapon5") : (Eval("Weapon5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="p5DateEntryl" runat="server"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="p5DateEntry" runat="server">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate5")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeH5").ToString())) ? Eval("TxtPTimeH5") : (Eval("TxtPTimeH5").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeM5").ToString())) ? Eval("TxtPTimeM5") : (Eval("TxtPTimeM5").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtPTimeTC5").ToString())) ? Eval("TxtPTimeTC5") : (Eval("TxtPTimeTC5").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist5l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist5" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("DistFeatures5").ToString())) ? Eval("DistFeatures5") : (Eval("DistFeatures5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc5l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc5" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("InjuryDesc5").ToString())) ? Eval("InjuryDesc5") : (Eval("InjuryDesc5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj5l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj5" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("CauseInjury5").ToString())) ? Eval("CauseInjury5") : (Eval("CauseInjury5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom5l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom5" runat="server">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments5").ToString())) ? Eval("Comments5") : (Eval("Comments5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image5l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image5" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="2">Incident Date and Time</th>
                <th colspan="2">Number of Persons Involved</th>
            </tr>
            <tr>
                <td style="border-right: 1px solid black" colspan="2">
                    <%# Convert.ToDateTime(Eval("Date")).ToString("dddd, dd MMMM yyyy") %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtTimeH").ToString())) ? Eval("TxtTimeH") : (Eval("TxtTimeH").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtTimeM").ToString())) ? Eval("TxtTimeM") : (Eval("TxtTimeM").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtTimeTC").ToString())) ? Eval("TxtTimeTC") : (Eval("TxtTimeTC").ToString()).Replace("^", "'") %>-->
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%# (string.IsNullOrWhiteSpace(Eval("NoOfPerson").ToString())) ? Eval("NoOfPerson") : (Eval("NoOfPerson").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Location of Incident</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="List_Location" onclick="return false" readonly="true" Font-Size="8" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <th id="otherLocation" runat="server" visible="false" colspan="4">Other
                </th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("LocationOther").ToString())) ? Eval("LocationOther") : (Eval("LocationOther").ToString()).Replace("^", "'") %>     
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view">
            <tr>
                <th colspan="5">Is there any Camera Footage?</th>
            </tr>
            <tr>
                <td colspan="5">
                    <b>Yes/No : </b>
                    <asp:CheckBox ID="cbCameraFootage" runat="server" Enabled="false" Checked="false" />
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam1">
            <tr>
                <th colspan="5">CCTV Camera 1</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc1").ToString())) ? Eval("CamDesc1") : (Eval("CamDesc1").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded1")) %>' />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath1").ToString())) ? Eval("CamFilePath1") : (Eval("CamFilePath1").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate1")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH1").ToString())) ? Eval("TxtCamSTimeH1") : (Eval("TxtCamSTimeH1").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM1").ToString())) ? Eval("TxtCamSTimeM1") : (Eval("TxtCamSTimeM1").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC1").ToString())) ? Eval("TxtCamSTimeTC1") : (Eval("TxtCamSTimeTC1").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate1")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH1").ToString())) ? Eval("TxtCamETimeH1") : (Eval("TxtCamETimeH1").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM1").ToString())) ? Eval("TxtCamETimeM1") : (Eval("TxtCamETimeM1").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC1").ToString())) ? Eval("TxtCamETimeTC1") : (Eval("TxtCamETimeTC1").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam2">
            <tr>
                <th colspan="5">CCTV Camera 2</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc2").ToString())) ? Eval("CamDesc2") : (Eval("CamDesc2").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded2")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath2").ToString())) ? Eval("CamFilePath2") : (Eval("CamFilePath2").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate2")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH2").ToString())) ? Eval("TxtCamSTimeH2") : (Eval("TxtCamSTimeH2").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM2").ToString())) ? Eval("TxtCamSTimeM2") : (Eval("TxtCamSTimeM2").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC2").ToString())) ? Eval("TxtCamSTimeTC2") : (Eval("TxtCamSTimeTC2").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate2")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH2").ToString())) ? Eval("TxtCamETimeH2") : (Eval("TxtCamETimeH2").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM2").ToString())) ? Eval("TxtCamETimeM2") : (Eval("TxtCamETimeM2").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC2").ToString())) ? Eval("TxtCamETimeTC2") : (Eval("TxtCamETimeTC2").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam3">
            <tr>
                <th colspan="5">CCTV Camera 3</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc3").ToString())) ? Eval("CamDesc3") : (Eval("CamDesc3").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded3")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath3").ToString())) ? Eval("CamFilePath3") : (Eval("CamFilePath3").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate3")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH3").ToString())) ? Eval("TxtCamSTimeH3") : (Eval("TxtCamSTimeH3").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM3").ToString())) ? Eval("TxtCamSTimeM3") : (Eval("TxtCamSTimeM3").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC3").ToString())) ? Eval("TxtCamSTimeTC3") : (Eval("TxtCamSTimeTC3").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate3")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH3").ToString())) ? Eval("TxtCamETimeH3") : (Eval("TxtCamETimeH3").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM3").ToString())) ? Eval("TxtCamETimeM3") : (Eval("TxtCamETimeM3").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC3").ToString())) ? Eval("TxtCamETimeTC3") : (Eval("TxtCamETimeTC3").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam4">
            <tr>
                <th colspan="5">CCTV Camera 4</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc4").ToString())) ? Eval("CamDesc4") : (Eval("CamDesc4").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded4")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath4").ToString())) ? Eval("CamFilePath4") : (Eval("CamFilePath4").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate4")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH4").ToString())) ? Eval("TxtCamSTimeH4") : (Eval("TxtCamSTimeH4").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM4").ToString())) ? Eval("TxtCamSTimeM4") : (Eval("TxtCamSTimeM4").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC4").ToString())) ? Eval("TxtCamSTimeTC4") : (Eval("TxtCamSTimeTC4").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate4")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH4").ToString())) ? Eval("TxtCamETimeH4") : (Eval("TxtCamETimeH4").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM4").ToString())) ? Eval("TxtCamETimeM4") : (Eval("TxtCamETimeM4").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC4").ToString())) ? Eval("TxtCamETimeTC4") : (Eval("TxtCamETimeTC4").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam5">
            <tr>
                <th colspan="5">CCTV Camera 5</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc5").ToString())) ? Eval("CamDesc5") : (Eval("CamDesc5").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded5")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath5").ToString())) ? Eval("CamFilePath5") : (Eval("CamFilePath5").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate5")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH5").ToString())) ? Eval("TxtCamSTimeH5") : (Eval("TxtCamSTimeH5").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM5").ToString())) ? Eval("TxtCamSTimeM5") : (Eval("TxtCamSTimeM5").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC5").ToString())) ? Eval("TxtCamSTimeTC5") : (Eval("TxtCamSTimeTC5").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate5")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH5").ToString())) ? Eval("TxtCamETimeH5") : (Eval("TxtCamETimeH5").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM5").ToString())) ? Eval("TxtCamETimeM5") : (Eval("TxtCamETimeM5").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC5").ToString())) ? Eval("TxtCamETimeTC5") : (Eval("TxtCamETimeTC5").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam6">
            <tr>
                <th colspan="5">CCTV Camera 6</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc6").ToString())) ? Eval("CamDesc6") : (Eval("CamDesc6").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded6")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath6").ToString())) ? Eval("CamFilePath6") : (Eval("CamFilePath6").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate6")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH6").ToString())) ? Eval("TxtCamSTimeH6") : (Eval("TxtCamSTimeH6").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM6").ToString())) ? Eval("TxtCamSTimeM6") : (Eval("TxtCamSTimeM6").ToString()).Replace("^", "'") %><!-- <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC6").ToString())) ? Eval("TxtCamSTimeTC6") : (Eval("TxtCamSTimeTC6").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate6")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH6").ToString())) ? Eval("TxtCamETimeH6") : (Eval("TxtCamETimeH6").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM6").ToString())) ? Eval("TxtCamETimeM6") : (Eval("TxtCamETimeM6").ToString()).Replace("^", "'") %><!-- <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC6").ToString())) ? Eval("TxtCamETimeTC6") : (Eval("TxtCamETimeTC6").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam7">
            <tr>
                <th colspan="5">CCTV Camera 7</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# (string.IsNullOrWhiteSpace(Eval("CamDesc7").ToString())) ? Eval("CamDesc7") : (Eval("CamDesc7").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded7")) %>' />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# (string.IsNullOrWhiteSpace(Eval("CamFilePath7").ToString())) ? Eval("CamFilePath7") : (Eval("CamFilePath7").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate7")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeH7").ToString())) ? Eval("TxtCamSTimeH7") : (Eval("TxtCamSTimeH7").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeM7").ToString())) ? Eval("TxtCamSTimeM7") : (Eval("TxtCamSTimeM7").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamSTimeTC7").ToString())) ? Eval("TxtCamSTimeTC7") : (Eval("TxtCamSTimeTC7").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate7")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeH7").ToString())) ? Eval("TxtCamETimeH7") : (Eval("TxtCamETimeH7").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeM7").ToString())) ? Eval("TxtCamETimeM7") : (Eval("TxtCamETimeM7").ToString()).Replace("^", "'") %>
                    <!--<%# (string.IsNullOrWhiteSpace(Eval("TxtCamETimeTC7").ToString())) ? Eval("TxtCamETimeTC7") : (Eval("TxtCamETimeTC7").ToString()).Replace("^", "'") %>-->
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">What Happened</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="cblWhatHappened1" onclick="return false" Font-Size="8" readonly="true" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="refuseEntryReasons" visible="false" runat="server">
                <th colspan="4">Refuse Entry Reason
                </th>
            </tr>
            <tr id="refuseEntryReasons1" visible="false" runat="server">
                <td colspan="4">
                    <asp:CheckBoxList ID="List_RefuseReason" Font-Size="8" onclick="return false" readonly="true" Visible="false" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="additionalDetails" visible="false" runat="server">
                <th colspan="4">Other
                </th>
            </tr>
            <tr id="additionalDetails1" visible="false" runat="server">
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("HappenedOther").ToString())) ? Eval("HappenedOther") : (Eval("HappenedOther").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr id="otherSerious" visible="false" runat="server">
                <th colspan="4">Other - Serious
                </th>
            </tr>
            <tr id="otherSerious1" visible="false" runat="server">
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("HappenedSerious").ToString())) ? Eval("HappenedSerious") : (Eval("HappenedSerious").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr id="askedtoLeaveReasons" visible="false" runat="server">
                <th colspan="4">Asked to Leave Reason
                </th>
            </tr>
            <tr id="askedtoLeaveReasons1" visible="false" runat="server">
                <td colspan="4">
                    <asp:CheckBoxList ID="List_AskedToLeave" Font-Size="8" onclick="return false" readonly="true" Visible="false" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>           
            <tr>
                <th colspan="4">Full Details of Incident & Injuries</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Details").ToString())) ? Eval("Details") : (Eval("Details").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Allegation</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Allegation").ToString())) ? Eval("Allegation") : (Eval("Allegation").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Action Taken / Incident Details</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="List_ActionTaken" Font-Size="11px" onclick="return false" readonly="true" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="actionTakenOther" visible="false" runat="server">
                <th colspan="4">Action Taken - Other
                </th>
            </tr>
            <tr id="actionTakenOther1" visible="false" runat="server">
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("ActionTakenOther").ToString())) ? Eval("ActionTakenOther") : (Eval("ActionTakenOther").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">Did Security Attend</th>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Yes/No : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("SecurityAttend") %>' />
                </td>
            </tr>
            <tr>
                <td id="tdSecurity1" runat="server" colspan="4"><b>Name of Security Officer : </b><%# (string.IsNullOrWhiteSpace(Eval("SecurityName").ToString())) ? Eval("SecurityName") : (Eval("SecurityName").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Where Police Notified</th>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Yes/No : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("PoliceNotify") %>' />
                </td>
            </tr>
            <tr>
                <td id="tdPolice1" runat="server" colspan="4">
                    <b>Police Station : </b><%# (string.IsNullOrWhiteSpace(Eval("PoliceStation").ToString())) ? Eval("PoliceStation") : (Eval("PoliceStation").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="tdPolice2" runat="server" colspan="4">
                    <b>Officer's Name : </b><%# (string.IsNullOrWhiteSpace(Eval("OfficersName").ToString())) ? Eval("OfficersName") : (Eval("OfficersName").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="tdPolice3" runat="server" colspan="4">
                    <b>Police Action : </b><%# (string.IsNullOrWhiteSpace(Eval("PoliceAction").ToString())) ? Eval("PoliceAction") : (Eval("PoliceAction").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="5">Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Comments").ToString())) ? Eval("Comments") : (Eval("Comments").ToString()).Replace("^", "'") %>                  
                </td>
            </tr>
            <tr>
                <th colspan="4">Read By</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("ReadBy").ToString())) ? Eval("ReadBy") : (Eval("ReadBy").ToString()).Replace("^", "'") %>                    
                </td>
            </tr>
            <tr>
                <th style="width: 48%" colspan="2">Staff Signature
                </th>
                <th colspan="2">Manager Signature
                </th>
            </tr>
            <tr>
                <td style="border-right: 1px solid black" colspan="2">
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffSign").ToString())) ? Eval("StaffSign") : (Eval("StaffSign").ToString()).Replace("^", "'") %> 
                </td>
                <td colspan="2">
                    <%# (string.IsNullOrWhiteSpace(Eval("ManagerSign").ToString())) ? Eval("ManagerSign") : (Eval("ManagerSign").ToString()).Replace("^", "'") %> 
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <table id="tblRecords" runat="server" class="table-view">
        <tr>
            <th style="text-align: center; border-left: 1px solid black; border-right: 1px solid black;">RECOMMENDATION FOR DISCIPLINARY ACTION</th>
            <th style="border-left: 1px solid black; border-right: 1px solid black;">
                <asp:Label ID="lblIncidentNo" runat="server" Style="position: relative; left: 3px;" ForeColor="#fa8072" Font-Bold="true" Text="Incident No. "></asp:Label>
            </th>
        </tr>
        <tr>
            <th colspan="2" style="text-align: center; border: solid 1px Black;">Allegation</th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView runat="server" ID="gvRecommendation_Allegation" HeaderStyle-CssClass="gvHeader" Style="table-layout: fixed;" Width="100%" DataKeyNames="id"
                    Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_Allegation" EmptyDataText="There are No Data Records to Display.">
                    <EmptyDataTemplate>
                        <table style="table-layout: fixed; width: 100%;">
                            <tr>
                                <th colspan="8">
                                    <asp:Label ID="lblStatement1" runat="server" Text="" />
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                            <ItemTemplate>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Statement" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# (string.IsNullOrWhiteSpace(Eval("Statement").ToString())) ? Eval("Statement") : (Eval("Statement").ToString()).Replace("^", "'") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Entered" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ProcessMyDataItem(Eval("DateEntered")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gvHeader" />
                    <EmptyDataRowStyle CssClass="EmptyData" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp</td>
        </tr>
        <tr>
            <th colspan="2" style="text-align: center; border: solid 1px Black;">Disciplinary Action</th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView runat="server" ID="gvRecommendation_DisciplinaryAction" HeaderStyle-CssClass="gvHeader" Style="table-layout: fixed;" Width="100%" DataKeyNames="id"
                    Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_DisciplinaryAction" EmptyDataText="There are No Data Records to Display.">
                    <EmptyDataTemplate>
                        <table style="table-layout: fixed; width: 100%;">
                            <tr>
                                <th colspan="8">
                                    <asp:Label ID="lblStatement1" runat="server" Text="" />
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                            <ItemTemplate>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Statement" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# (string.IsNullOrWhiteSpace(Eval("Statement").ToString())) ? Eval("Statement") : (Eval("Statement").ToString()).Replace("^", "'") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStatement" class="form-control" TextMode="MultiLine" Height="50" runat="server" Text='<%# Bind("Statement") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Entered" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ProcessMyDataItem(Eval("DateEntered")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gvHeader" />
                    <EmptyDataRowStyle CssClass="EmptyData" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp</td>
        </tr>
        <tr>
            <th colspan="2" style="text-align: center; border: solid 1px Black;">Judiciary Committee/Board Decision</th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView runat="server" ID="gvRecommendation_Judiciary" HeaderStyle-CssClass="gvHeader" Style="table-layout: fixed;" Width="100%" DataKeyNames="id"
                    Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_Judiciary" EmptyDataText="There are No Data Records to Display.">
                    <EmptyDataTemplate>
                        <table style="table-layout: fixed; width: 100%;">
                            <tr>
                                <th colspan="2">
                                    <asp:Label ID="Label" runat="server" Text="" />
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                            <ItemTemplate>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Decision" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# (string.IsNullOrWhiteSpace(Eval("Decision").ToString())) ? Eval("Decision") : (Eval("Decision").ToString()).Replace("^", "'") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDecision" class="form-control" TextMode="MultiLine" Height="50" runat="server" Text='<%# Bind("Decision") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ProcessDate(Eval("Date")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ProcessDate(Eval("StartDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ProcessDate(Eval("EndDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gvHeader" />
                    <EmptyDataRowStyle CssClass="EmptyData" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource runat="server" ID="sdsRecommendation_Allegation"
        ConnectionString="<%$ ConnectionStrings:LocalDb %>"
        SelectCommand="SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_Allegation] WHERE ReportId=@ReportId"
        OnSelecting="sdsRecommendation_Allegation_Selecting">
        <SelectParameters>
            <asp:Parameter Name="ReportId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sdsRecommendation_DisciplinaryAction"
        ConnectionString="<%$ ConnectionStrings:LocalDb %>"
        SelectCommand="SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_DisciplinaryAction] WHERE ReportId=@ReportId"
        OnSelecting="sdsRecommendation_DisciplinaryAction_Selecting">
        <SelectParameters>
            <asp:Parameter Name="ReportId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sdsRecommendation_Judiciary"
        ConnectionString="<%$ ConnectionStrings:LocalDb %>"
        SelectCommand="SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [Recommendation_Judiciary] WHERE ReportId=@ReportId"
        OnSelecting="sdsRecommendation_Judiciary_Selecting">
        <SelectParameters>
            <asp:Parameter Name="ReportId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Supervisors_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="report-number"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
    </div>
    <div id="supReport" runat="server">
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
            <tr>
                <th colspan="4">Sign In Slip</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("SignInSlip").ToString())) ? Eval("SignInSlip") : (Eval("SignInSlip").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Reception</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Reception").ToString())) ? Eval("Reception") : (Eval("Reception").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Gaming</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Gaming").ToString())) ? Eval("Gaming") : (Eval("Gaming").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Bar</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Bar").ToString())) ? Eval("Bar") : (Eval("Bar").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">TAB / Keno</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("TabKeno").ToString())) ? Eval("TabKeno") : (Eval("TabKeno").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">House Keeping</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("HouseKeeping").ToString())) ? Eval("HouseKeeping") : (Eval("HouseKeeping").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Bistro</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Bistro").ToString())) ? Eval("Bistro") : (Eval("Bistro").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Food Hygiene</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("FoodHygiene").ToString())) ? Eval("FoodHygiene") : (Eval("FoodHygiene").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Events</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Events").ToString())) ? Eval("Events") : (Eval("Events").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Customer Service</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("CustomerService").ToString())) ? Eval("CustomerService") : (Eval("CustomerService").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("GeneralComments").ToString())) ? Eval("GeneralComments") : (Eval("GeneralComments").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Lucky Rewards</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("LuckyRewards").ToString())) ? Eval("LuckyRewards") : (Eval("LuckyRewards").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">RSA</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("RSA").ToString())) ? Eval("RSA") : (Eval("RSA").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">AML / CTF</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("AMLCTF").ToString())) ? Eval("AMLCTF") : (Eval("AMLCTF").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Comments</th>
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
    </div>
</div>

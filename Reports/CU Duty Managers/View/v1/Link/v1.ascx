<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Duty_Managers_View_v1_Link_v1" %>
<div class="table-link-view">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="reportNo"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
    </div>
    <div id="dmReport" runat="server">
        <table class="table-view">
            <tr>
                <th colspan="5">Shift Details</th>
            </tr>
            <tr style="border: solid .5px;">
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffName").ToString())) ? Eval("StaffName") : (Eval("StaffName").ToString()).Replace("^", "'") %>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 19%">Shift Type: 
                </td>
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("ShiftName").ToString())) ? Eval("ShiftName") : (Eval("ShiftName").ToString()).Replace("^", "'") %>
                </td>
                <td style="text-align: right;">Shift Date:</td>
                <td>
                    <%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dddd, dd MMMM yyyy") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Reception</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Supervisors").ToString())) ? Eval("Supervisors") : (Eval("Supervisors").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Bar</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Cameras").ToString())) ? Eval("Cameras") : (Eval("Cameras").ToString()).Replace("^", "'") %>                                    
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
                <th colspan="4">Food Hygiene</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("KeySecurity").ToString())) ? Eval("KeySecurity") : (Eval("KeySecurity").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">WHS Issues</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Whs").ToString())) ? Eval("Whs") : (Eval("Whs").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Cost Savings</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("CostSavings").ToString())) ? Eval("CostSavings") : (Eval("CostSavings").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Presentation</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("ClubPresent").ToString())) ? Eval("ClubPresent") : (Eval("ClubPresent").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Maintenance</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("ClubMaintenance").ToString())) ? Eval("ClubMaintenance") : (Eval("ClubMaintenance").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Absenteeism</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Absenteeism").ToString())) ? Eval("Absenteeism") : (Eval("Absenteeism").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Staff Issues</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("StaffIssues").ToString())) ? Eval("StaffIssues") : (Eval("StaffIssues").ToString()).Replace("^", "'") %>                                    
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
                <th colspan="4">Compliance</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# (string.IsNullOrWhiteSpace(Eval("Compliance").ToString())) ? Eval("Compliance") : (Eval("Compliance").ToString()).Replace("^", "'") %>                                    
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

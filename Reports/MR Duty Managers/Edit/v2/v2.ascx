<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v2.ascx.cs" Inherits="Reports_MR_Duty_Managers_Edit_v2_v2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <asp:DropDownList ID="ddlShift" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" runat="server" CssClass="object-default">
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
        <tr>
            <th colspan="4">Duty Manager Shift</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtSupervisors" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" TextMode="MultiLine" Text="" Style="resize: none;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Supervisor Shift</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtWhs" class="object-default" OnTextChanged="TextChanged_TextChanged" TextMode="MultiLine" runat="server" Height="130px" Text="" Style="resize: none;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Bars</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtCostSavings" class="object-default" OnTextChanged="TextChanged_TextChanged" TextMode="MultiLine" runat="server" Height="130px" Text="" Style="resize: none;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Gaming</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtClubPres" class="object-default" OnTextChanged="TextChanged_TextChanged" TextMode="MultiLine" runat="server" Height="130px" Text="" Style="resize: none;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Promotions and Events</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtClubMain" class="object-default" OnTextChanged="TextChanged_TextChanged" TextMode="MultiLine" runat="server" Height="130px" Text="" Style="resize: none;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Staff</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtAbsenteeism" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">IT Issues</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtStaffIssues" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Cleaners / Housekeeping</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtGaming" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Club Maintenance / Temperature</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtKeySec" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtCameras" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>

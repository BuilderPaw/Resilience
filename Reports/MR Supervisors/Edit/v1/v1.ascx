<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Supervisors_Edit_v1_v1" %>

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
            <th colspan="4">Sign In Slip</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtSignInSlip" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Reception</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtReception" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Gaming</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtGaming" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Bar</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtBar" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">TAB / Keno</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtTABKeno" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">House Keeping</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtHouseKeep" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Bistro</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtBistro" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Food Hygiene</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtFoodHygiene" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Events</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtEvents" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Customer Service</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtCustomerServ" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtGenComm" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">Lucky Rewards</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtLuckyRewards" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">RSA</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtRSA" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4">AML / CTF Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtAMLCTF" class="object-default" runat="server" OnTextChanged="TextChanged_TextChanged" Height="70px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>

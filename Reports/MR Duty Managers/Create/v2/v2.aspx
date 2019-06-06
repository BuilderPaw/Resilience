<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="v2.aspx.cs" Inherits="Reports_MR_Duty_Managers_Create_v2_v2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" CssClass="spell-button" />
    <div class="body">
        <br />
        <h4 style="margin-left: 8%;">MR Duty Manager Report</h4>
        <table class="table-create-report">
            <tr>
                <th colspan="4">Shift Details</th>
            </tr>
            <tr>
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <asp:Label ID="txtStaffName" runat="server" Style="background-color: white;" CssClass="object-default" />
                </td>
                <td></td>
                <td></td>
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
                    <asp:TextBox ID="txtDatePicker" runat="server" Width="220px" class="object-default" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDatePicker" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <th colspan="4">Duty Manager Shift</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtSupervisors" class="object-default" runat="server" Height="130px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Supervisor Shift</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtWHS" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Bars</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtCostSavings" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Gaming</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtClubPres" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Promotions and Events</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtClubMaint" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Staff</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtAbsenteeism" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">IT Issues</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtStaffIssues" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Cleaners / Housekeeping</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtGaming" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Maintenance / Temperature</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtKeySec" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtCameras" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" Style="float: right; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Submit Form" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
                    <asp:Button ID="btnReset" Style="float: left; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Clear Form" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

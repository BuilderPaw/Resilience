<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="v1.aspx.cs" Inherits="Reports_MR_Reception_Create_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" CssClass="spell-button" />
    <div class="body">
        <br />
        <h4 style="margin-left: 8%;">MR Reception Report</h4>
        <table class="table-create-report">
            <tr>
                <th colspan="4">Shift Details</th>
            </tr>
            <tr>
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <asp:TextBox ID="txtStaffName" runat="server" ReadOnly="true" Style="background-color: white;" CssClass="object-default" />
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
                <th colspan="4">Incidents</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtSignInSlip" class="object-default" runat="server" Height="80px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Refusals</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtRefusals" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">Events</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtEventsField" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtGeneralComms" class="object-default" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
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

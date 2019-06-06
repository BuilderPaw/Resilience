<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillManager.aspx.cs" Inherits="Web_Forms_BillManager" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Manager</title>
    <link rel="stylesheet" href="/CSS/BillManager.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-3.3.1.min.js"></script>
    <%--
        Paolo Santiago 18/12/2018
        Allow addEventListener() in IE 11.
        Added an HTTP Respone Header via IIS.
        In IIS Manager select the site then open HTTP Response Headers and click Add.
        reference: https://stackoverflow.com/questions/25077612/jquery-not-working-with-ie-11
    --%>
    <script type="text/javascript">
        // capture text change on the following textboxes
        $(function () {
            $('#txtCash').on('input', function (e) {
                BillTotal();
            });

            $('#txtEFTPOS').on('input', function (e) {
                BillTotal();
            });

            $('#txtPoints').on('input', function (e) {
                BillTotal();
            });

            $('#txtCheques').on('input', function (e) {
                BillTotal();
            });

            $('#txtMiscellaneous1').on('input', function (e) {
                BillTotal();
            });

            $('#txtMiscellaneous2').on('input', function (e) {
                BillTotal();
            });

            $('#btnSave').click(function () {
                /*
                 * Paolo Santiago 20/12/2018
                 * Detect if a validation group is valid.
                 * reference: https://forums.asp.net/t/1159790.aspx?Use+JavaScript+to+detect+if+a+validation+group+is+valid+
                */
                if (Page_ClientValidate('AddRecord')) {
                    var totalAmount = BillTotal();
                    if (!confirm('Save transaction with a total bill of $' + totalAmount + '?')) return false;
                }
            });
        });

        // every time a tex change occurs, get the sum of the the total bill

        function BillTotal() {
            var cash = parseFloat($('#txtCash').val()) || 0,
                eftpos = parseFloat($('#txtEFTPOS').val()) || 0,
                points = parseFloat($('#txtPoints').val()) || 0,
                cheques = parseFloat($('#txtCheques').val()) || 0,
                misc1 = parseFloat($('#txtMiscellaneous1').val()) || 0,
                misc2 = parseFloat($('#txtMiscellaneous2').val()) || 0,
                total;

            total = cash + eftpos + points + cheques + misc1 + misc2;

            var totalAmount = total.toString();

            $("#lblTotalAmount").empty();
            $("#lblTotalAmount").append(totalAmount);
            return totalAmount;
        }

        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'left=0,top=0,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }

        /* 
         * Paolo Santiago 11/12/2018
         * Allow only integers on textboxes.
         * check if the entered value is a number value
         * reference: https://stackoverflow.com/questions/9732455/how-to-allow-only-integers-in-a-textbox
        */
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table style="border: solid 1px; background-color: aliceblue; color: teal; float: left">
                <tr>
                    <td style="border: solid 1px">
                        <asp:Label runat="server" Font-Bold="true" Style="margin-left: 250px" Text="BILL MANAGER"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Member Number"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="First Name"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Last Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtMemberNo" runat="server" OnTextChanged="txtMemberNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMemberNo" Display="Dynamic" ValidationGroup="AddRecord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtFirstName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ValidationGroup="AddRecord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtLastName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName" Display="Dynamic" ValidationGroup="AddRecord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Biller"></asp:Label></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Confirmation ID"></asp:Label></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtBiller" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBiller" Display="Dynamic" ValidationGroup="AddRecord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtConfirmationId" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmationId" Display="Dynamic" ValidationGroup="AddRecord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Cash"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="EFTPOS"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Points"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtCash" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCash" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtEFTPOS" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEFTPOS" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtPoints" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPoints" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Miscellaneous 1"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Miscellaneous 2"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Cheques"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtMiscellaneous1" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMiscellaneous1" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtMiscellaneous2" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMiscellaneous2" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtCheques" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCheques" Display="Dynamic" ValidationGroup="AddRecord" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="WRONG INPUT" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Total Amount:"></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label Font-Bold="true" ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button class="btn" ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" ValidationGroup="AddRecord" />
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Button class="btn" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="Filter" runat="server" visible="true" style="border: solid 1px; background-color: aliceblue; color: teal; float: left">
                <tr>
                    <td style="border: solid 1px">
                        <asp:Label Font-Bold="true" runat="server" Style="margin-left: 140px;" Text="FILTER REPORT"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Start Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="End Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtStartDate" runat="server" ValidationGroup="FilterReport"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refvStartDate" runat="server" ControlToValidate="txtStartDate"
                                        InitialValue="" Font-Bold="True" Font-Size="12px" ForeColor="Red" ValidationGroup="FilterReport">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regExStartDate" runat="server"
                                        Font-Bold="True" Font-Size="10px" ForeColor="Red" ValidationGroup="FilterReport"
                                        ErrorMessage="dd/MM/YYYY"
                                        ControlToValidate="txtStartDate"
                                        ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" />
                                </td>
                                <td>
                                    <asp:TextBox Width="150px" class="object-default" ID="txtEndDate" runat="server" ValidationGroup="FilterReport"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refvEndDate" runat="server" ControlToValidate="txtEndDate"
                                        InitialValue="" Font-Bold="True" Font-Size="12px" ForeColor="Red" ValidationGroup="FilterReport">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regExEndDate" runat="server"
                                        Font-Bold="True" Font-Size="10px" ForeColor="Red" ValidationGroup="FilterReport"
                                        ErrorMessage="dd/MM/YYYY"
                                        ControlToValidate="txtEndDate"
                                        ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" />
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    <asp:CompareValidator ID="cmpValue" ControlToCompare="txtStartDate"
                                        ControlToValidate="txtEndDate" Type="Date" Operator="GreaterThanEqual" Font-Bold="True" Font-Size="12px" ForeColor="Red" ValidationGroup="FilterReport"
                                        ErrorMessage="Start & End Date" runat="server"></asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Font-Bold="true" runat="server" Text="Site"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="object-default">
                                        <asp:ListItem>Merrylands RSL</asp:ListItem>
                                        <asp:ListItem>Club Umina</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button Width="100px" class="btn" ID="btnFilter" runat="server" Text="Filter" ValidationGroup="FilterReport" OnClick="btnFilter_Click" />
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Button Width="100px" class="btn" ID="btnPrint" runat="server" Text="Print Report" Visible="false" OnClick="btnPrint_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="border: solid 1px; background-color: aliceblue; color: teal; width:100%;">
                <tr>
                    <td style="border: solid 1px">
                        <asp:Label Font-Bold="true" runat="server" Text="MEMBERS' BILL REPORT SUMMARY"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid 1px;">
                        <div id="gridview" style="width:100%;">                           
                            <asp:GridView ID="gvBillPayment" runat="server" ShowFooter="true" OnRowDeleting="gvBillPayment_RowDeleting" OnRowCreated="gvBillPayment_RowCreated" OnPageIndexChanging="gvBillPayment_PageIndexChanging" OnRowDataBound="gvBillPayment_RowDataBound" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="BillPaymentId" EmptyDataText="No record to list" Width="100%" Font-Names="Tahoma">
                                <Columns> 
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button class="btn" ID="btnDelete" runat="server" Text="DEL" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillPaymentId" runat="server" Text='<%# Bind("BillPaymentId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Site">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSite" runat="server" Text='<%# Bind("Site") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trading Date" SortExpression="TradingDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTradingDate" runat="server" Text='<%# Convert.ToDateTime(Eval("TradingDate")).ToString("dd/MM/yyyy") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member No" SortExpression="MemberNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberNo" runat="server" Text='<%# Bind("MemberNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                                            <%--<asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName").ToString().Length <= 7 ? Eval("FirstName") : Eval("FirstName").ToString().Remove(7) + "..." %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' />
                                            <%--<asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName").ToString().Length <= 7 ? Eval("LastName") : Eval("LastName").ToString().Remove(7) + "..." %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Biller" SortExpression="Biller">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBiller" runat="server" Text='<%# Eval("Biller") %>' />
                                            <%--<asp:Label ID="lblBiller" runat="server" Text='<%# Eval("Biller").ToString().Length <= 7 ? Eval("Biller") : Eval("Biller").ToString().Remove(7) + "..." %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ConfirmationID" SortExpression="ConfirmationId">
                                        <ItemTemplate>
                                            <asp:Label ID="lblConfirmationId" runat="server" Text='<%# Eval("ConfirmationId") %>' /> 
                                            <%--<asp:Label ID="lblConfirmationId" runat="server" Text='<%# Eval("ConfirmationId").ToString().Length <= 7 ? Eval("ConfirmationId") : Eval("ConfirmationId").ToString().Remove(7) + "..." %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cash" SortExpression="Cash" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCash" runat="server" Text='<%#  String.Format("{0:C}", Eval("Cash")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCash" runat="server" Font-Bold="true" Text="Cash"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EFTPOS" SortExpression="EFTPOS" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEFTPOS" runat="server" Text='<%# String.Format("{0:C}", Eval("EFTPOS")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblEFTPOS" runat="server" Font-Bold="true" Text="EFTPOS"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Points" SortExpression="Points" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPoints" runat="server" Text='<%# String.Format("{0:C}", Eval("Points")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblPoints" runat="server" Font-Bold="true" Text="Points"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc1" SortExpression="Miscellaneous1" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMiscellaneous1" runat="server" Text='<%# String.Format("{0:C}", Eval("Miscellaneous1")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblMiscellaneous1" runat="server" Font-Bold="true" Text="Miscellaneous1"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc2" SortExpression="Miscellaneous2" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMiscellaneous2" runat="server" Text='<%# String.Format("{0:C}", Eval("Miscellaneous2")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblMiscellaneous2" runat="server" Font-Bold="true" Text="Miscellaneous2"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheques" SortExpression="Cheques" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCheques" runat="server" Text='<%# String.Format("{0:C}", Eval("Cheques")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCheques" runat="server" Font-Bold="true" Text="Cheques"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%# String.Format("{0:C}", Eval("TotalAmount")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Staff" SortExpression="Staff">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName") %>' />
                                            <%--<asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName").ToString().Length <= 14 ? Eval("StaffName") : Eval("StaffName").ToString().Remove(14) + "..." %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnteredDate" runat="server" Text='<%# Bind("EnteredDate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

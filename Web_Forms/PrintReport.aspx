<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintReport.aspx.cs" Inherits="PrintReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/CSS/MasterStyle.css" type="text/css" />
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'left=0,top=0,width=2000,height=2000,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
        function printPage() {
            var getFormView = document.getElementById("<%=fvReport.ClientID%>");
            var MainWindow = window.open('', '', 'height=800,width=650,status=no,toolbar=no,scrollbars=yes');
                    MainWindow.document.write(getFormView.innerHTML);
                    MainWindow.document.close();
                    MainWindow.print();
                    MainWindow.close();
                    return false;
                }
        var redirectTimerId = 0;
        function closeWindow() {
            window.opener = top;
            redirectTimerId = window.setTimeout('redirect()', 8000);
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" id="btnPrint" value="Print" runat="Server" onclick="javascript: CallPrint('body1a');" />
        <div id="body2">
            <asp:FormView runat="server" ID="fvReport" Visible="true" DataKeyNames="ReportId" DataSourceID="sdsPrintReport" BorderStyle="Solid" BorderWidth="1">
                <ItemTemplate>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource runat="server" ID="sdsPrintReport"
                ConnectionString="<%$ ConnectionStrings:LocalDb %>"
                SelectCommand="SELECT s.StaffName, st.ShiftName, c.ReportName, *
                               FROM @Report_Table rt, [Staff] s, [Shift] st, [Category] c
                               WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId = @ReportId"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
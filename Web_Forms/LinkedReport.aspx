<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkedReport.aspx.cs" Inherits="Web_Forms_LinkedReport" %>

<!DOCTYPE html>

<meta http-equiv="X-UA-Compatible" content="IE=11">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linked Report</title>
    <link rel="stylesheet" href="/CSS/MasterStyle.css" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript">
    function ToTopOfPage(sender, args) {
        $("html, body").animate({ scrollTop: 0 }, 1000);
    }
    function ToBottomOfPage(sender, args) {
        $("html, body").animate({ scrollTop: $(document).height() }, 1000);
    }
    function closeWindow() {
        window.opener = top;
        redirectTimerId = window.setTimeout('redirect()', 8000);
        window.close();
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0 auto; width: 80%; height: 100%;">
            <asp:FormView runat="server" ID="fvReport1" DataKeyNames="ReportId" DataSourceID="SqlDataSource6" BorderStyle="None">
                <ItemTemplate>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource6"
                ConnectionString="<%$ ConnectionStrings:LocalDb %>"
                SelectCommand="SELECT s.StaffName, st.ShiftName, c.ReportName, *
                               FROM Report_MerrylandsRSLDutyManager rt, [Staff] s, [Shift] st, [Category] c
                               WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId = 1"></asp:SqlDataSource>
        </div>
        <asp:ImageButton ID="imgTopScreen" OnClientClick="ToTopOfPage(); return false;" runat="server" ImageUrl="~/Images/arrow-up.png" Width="25px" Style="position: fixed; top: 0%; right: 13%;" BorderStyle="None" />
        <asp:ImageButton ID="imgBottomScreen" OnClientClick="ToBottomOfPage(); return false;" runat="server" ImageUrl="~/Images/arrow-down.png" Width="25px" Style="position: fixed; top: 5%; right: 13%;" BorderStyle="None" />
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Style="position: fixed; top: 2%; right: 3.5%;" CssClass="btn btn-primary btn-large" Text="Print Report" />
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayVersion.aspx.cs" Inherits="Web_Forms_DisplayVersion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Versions</title>
    <link rel="stylesheet" href="/CSS/MasterStyle.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width: 20%; float: left; background: rgb(0,144,202); width: 20%; height: 100%; position: fixed; top: 0px; margin: 0px; padding: 0px; z-index: 3;">
                <img src="/Images/logo-MRSLGROUP.png" id="ImageButton1" runat="server" style="width: 80%; margin-left: 6%; margin-top: 5px;" />
                <div style="margin-left: 18%; margin-top:10%;">
                    <asp:Label runat="server" ID="lblReportIdH" Text="Report ID :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtReportId" CssClass="form-control" Width="175" Height="30" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblReportNameH" Text="Report Name :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlReport" Width="200" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" BorderColor="White" class="btn btn-primary" Width="200" OnClick="btnSubmit_Click" Text="Display Report" />
                </div>
            </div>
            <div style="width: 78%; float: right">
                <asp:GridView ID="gvDisplayReports" Visible="false" runat="server" AutoGenerateColumns="False" DataKeyNames="ReportID" DataSourceID="SqlDataSource1" HeaderStyle-CssClass="gvHeader"
                    Width="95%" Font-Size="14px" OnRowCommand="gvDisplayReports_RowCommand" PageSize="10"
                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvDisplayReports_PageIndexChanging" OnSorting="gvDisplayReports_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText=" "  HeaderStyle-BackColor="#555555" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" Font-Size="X-Small" runat="server" CssClass="btn btn-primary" CommandName="Select" Text="Select" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report ID" HeaderStyle-BackColor="#555555" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                            <ItemTemplate>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#555555" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="ReportStat">
                            <ItemTemplate>
                                <asp:Label ID="lblReportStat" runat="server" Text='<%# Bind("ReportStat") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modified Date" HeaderStyle-BackColor="#555555" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="ModifyDate">
                            <ItemTemplate>
                                <asp:Label ID="lblModifyDate" runat="server" Text='<%# Bind("ModifyDate") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Audit Version" HeaderStyle-BackColor="#555555" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="AuditVersion">
                            <ItemTemplate>
                                <asp:Label ID="lblAuditVersion" runat="server" Text='<%# Bind("AuditVersion") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Table" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Report_Table">
                            <ItemTemplate>
                                <asp:Label ID="lblReportTable" runat="server" Text='<%# Bind("Report_Table") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Version" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Report_Version">
                            <ItemTemplate>
                                <asp:Label ID="lblReportVersion" runat="server" Text='<%# Bind("Report_Version") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblSortDisplay" runat="server" Visible="false" Text="Set" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDb %>"
                    SelectCommand="SELECT * FROM [Report_MerrylandsRSLDutyManager]"></asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>

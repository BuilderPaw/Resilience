using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forms_LinkedReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // receive the query string gathered from Default.aspx - The selected link report
        Session["LinkRId"] = Request.QueryString["RId"].ToString();
        string ReportName = Request.QueryString["ReportName"].ToString();
        string ReportTable = Request.QueryString["ReportTable"].ToString();
        int Version = Int32.Parse(Request.QueryString["Version"]);
        try
        {
            Session["LinkAuditVersion"] = Request.QueryString["AuditVersion"].ToString(); // For Report Versions of the Linked Report selected
        }
        catch
        {
            Session["LinkAuditVersion"] = "";
        }

        string activeReport = "";

        if (string.IsNullOrEmpty(Session["LinkAuditVersion"].ToString()))
        {
            activeReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + " FROM " + ReportTable + " rt, [Staff] s, [Shift] st, [Category] c" +
                                  " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Session["LinkRId"].ToString() + " AND rt.AuditVersion=(SELECT MAX(AuditVersion) FROM " + ReportTable + " WHERE ReportId = " + Session["LinkRId"].ToString() + " AND ReportStat != 'Awaiting Completion')";
        }
        else
        {
            activeReport = "SELECT rt.StaffId, rt.StaffName, rt.ShiftId, st.ShiftName, c.ReportName, *" + " FROM " + ReportTable + " rt, [Staff] s, [Shift] st, [Category] c" +
                              " WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId=" + Session["LinkRId"].ToString() + " AND rt.AuditVersion=" + Session["LinkAuditVersion"].ToString();
        }
        Report.LinkedReport = activeReport;

        SqlDataSource6.SelectCommand = activeReport;
        fvReport1.ItemTemplate = Page.LoadTemplate("/Reports/" + ReportName + "/View/v" + Version + "/Link/v" + Version + ".ascx");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '/Web_Forms/PrintReport.aspx?LinkReport=1&ReportName=" + Request.QueryString["ReportName"].ToString() + "&Version=" + Request.QueryString["Version"].ToString() + "', null, 'height=2,width=2,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        if (!string.IsNullOrEmpty(Session["LinkAuditVersion"].ToString()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "closeWindow();", true);
        }
    }
}
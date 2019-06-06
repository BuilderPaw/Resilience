using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["LinkReport"])) // print linked report selected
        {
            sdsPrintReport.SelectCommand = Report.LinkedReport;
            fvReport.ItemTemplate = Page.LoadTemplate("~/Reports/" + Request.QueryString["ReportName"].ToString() + "/Print/v" + Request.QueryString["Version"].ToString() + "/Link/v" + Request.QueryString["Version"].ToString() + ".ascx");
        }
        else // print active report selected
        {
            sdsPrintReport.SelectCommand = Report.ActiveReport;
            fvReport.ItemTemplate = Page.LoadTemplate("~/Reports/" + Report.Name + "/Print/v" + Report.Version + "/Active/v" + Report.Version + ".ascx");
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "printPage", "printPage();", true);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "closeWindow();", true);
    }
}
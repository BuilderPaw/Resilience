using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forms_DisplayVersion : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    //string ipAddress;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // load appropriate image
            // get IP Address
            //ipAddress = GetUser_IP();
            // set Venue
            //setVenue(ipAddress);

            // REPORTS AND SEARCH PANES - Drop Down List - set the list of values shown in the dropdown list
            // use a global variable to check whether groups array is not empty
            if (!string.IsNullOrWhiteSpace(UserCredentials.Groups))
            {
                string groups = UserCredentials.Groups;
                bool contains = groups.Contains("MRReportsSeniorManagers"); // MRReportsAdmin should be part of group MRReportsSeniorManagers
                string[] array_groups = groups.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                int j = 0;
                int[] int_groups = new int[12];

                if (!contains)
                {
                    for (int i = 0; i < array_groups.Length; i++)
                    {
                        if (array_groups[i].ToString().Equals("MRReportsDutyManagers"))
                        {
                            int_groups[j] = 1; // assign this number in the array and increment variable 'j' to add the next value
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsSupervisors"))
                        {
                            int_groups[j] = 2;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsFunctionSupervisor"))
                        {
                            int_groups[j] = 3;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsReceptionSupervisor"))
                        {
                            int_groups[j] = 4;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("MRReportsReception"))
                        {
                            int_groups[j] = 5;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("CUReportsDutyManagers"))
                        {
                            int_groups[j] = 6;
                            j++;
                        }
                        else if (array_groups[i].ToString().Equals("CUReportsReception"))
                        {
                            int_groups[j] = 7;
                            j++;
                        }
                    }

                    // use Array.Sort to display the Report Types accordingly
                    Array.Sort(int_groups);
                    for (int i = 0; i < int_groups.Length; i++)
                    {
                        // display the reports in proper order, All MR Reports at the top followed by CU Reports
                        if (int_groups[i] == 1)
                        {
                            ddlReport.Items.Add(new ListItem("MR Incident Report", "Report_MerrylandsRSLIncident"));
                            ddlReport.Items.Add(new ListItem("MR Duty Managers", "Report_MerrylandsRSLDutyManager"));
                        }
                        else if (int_groups[i] == 2)
                        {
                            ddlReport.Items.Add(new ListItem("MR Supervisors", "Report_MerrylandsRSLSupervisor"));
                        }
                        else if (int_groups[i] == 3)
                        {
                            ddlReport.Items.Add(new ListItem("MR Function Supervisor", "Report_MerrylandsRSLFunctionSupervisor"));
                        }
                        else if (int_groups[i] == 4)
                        {
                            ddlReport.Items.Add(new ListItem("MR Reception Supervisor", "Report_MerrylandsRSLReceptionSupervisor"));
                        }
                        else if (int_groups[i] == 5)
                        {
                            ddlReport.Items.Add(new ListItem("MR Reception", "Report_MerrylandsRSLReception"));
                        }
                        else if (int_groups[i] == 6)
                        {
                            ddlReport.Items.Add(new ListItem("CU Incident Report", "Report_ClubUminaIncident"));
                            ddlReport.Items.Add(new ListItem("CU Duty Managers", "Report_ClubUminaDutyManager"));
                        }
                        else if (int_groups[i] == 7)
                        {
                            ddlReport.Items.Add(new ListItem("CU Reception", "Report_ClubUminaReception"));
                        }
                    }
                }
                else // if the user is a member of Senior Managers
                {
                    // add all reports
                    // MR Duty Manager & Incident Report
                    ddlReport.Items.Add(new ListItem("MR Incident Report", "Report_MerrylandsRSLIncident"));
                    // CU Incident Report
                    ddlReport.Items.Add(new ListItem("CU Incident Report", "Report_ClubUminaIncident"));
                    ddlReport.Items.Add(new ListItem("MR Duty Managers", "Report_MerrylandsRSLDutyManager"));
                    // MR Supervisor
                    ddlReport.Items.Add(new ListItem("MR Supervisors", "Report_MerrylandsRSLSupervisor"));
                    // MR Function Supervisor
                    ddlReport.Items.Add(new ListItem("MR Function Supervisor", "Report_MerrylandsRSLFunctionSupervisor"));
                    // MR Reception Supervisor
                    ddlReport.Items.Add(new ListItem("MR Reception Supervisor", "Report_MerrylandsRSLReceptionSupervisor"));
                    // MR Reception
                    ddlReport.Items.Add(new ListItem("MR Reception", "Report_MerrylandsRSLReception"));
                    // CU Duty Manager
                    ddlReport.Items.Add(new ListItem("CU Duty Managers", "Report_ClubUminaDutyManager"));
                    // CU Reception
                    ddlReport.Items.Add(new ListItem("CU Reception", "Report_ClubUminaReception"));
                }
            }
        }
    }

    protected string GetUser_IP()
    {
        // get User's Network IP Address
        string VisitorsIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr;
        throw new Exception("Local IP Address Not Found!");
    }

    protected void setVenue(string ipAddress)
    {
        int i = 0;

        // Split IP Address string with '.' and set the Venue /*GODisGood*/
        string[] subnet = ipAddress.Split('.');
        foreach (string net in subnet)
        {
            i++;
            if (i == 3)
            {
                if (net == "1")
                {
                    ImageButton1.Src = "~/Images/logo-MRSL.png";
                }
                else if (net == "5")
                {
                    ImageButton1.Src = "~/Images/logo-CU.png";
                }
            }
        }
        if (i < 3) // if there is no proper IP Address found, close the program
        {
            showAlert("Error Found! Please contact administrator.");
        }
    }

    protected void gvDisplayReports_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            Label lblID = (Label)row.FindControl("lblReportId");
            Label lblTable = (Label)row.FindControl("lblReportTable");
            Label lblVersion = (Label)row.FindControl("lblReportVersion");
            Label lblAuditVersion = (Label)row.FindControl("lblAuditVersion");
            Label lblReportStat = (Label)row.FindControl("lblReportStat");

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open('LinkedReport.aspx?RId=" + lblID.Text + "&ReportName=" + ddlReport.SelectedItem.Text + "&ReportTable=" + ddlReport.SelectedItem.Value + "&AuditVersion=" + lblAuditVersion.Text + "&Version=" + lblVersion.Text + "', 'ReportVersion', 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );", true);
        }
    }
    protected void gvDisplayReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SqlDataSource1.SelectCommand = Session["displaySearch"].ToString();
        gvDisplayReports.PageIndex = e.NewPageIndex;
        gvDisplayReports.DataBind();
    }
    protected void gvDisplayReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlDataSource1.SelectCommand = Session["displaySearch"].ToString();
        if (lblSortDisplay.Text.Equals("Set"))
        {
            e.SortDirection = SortDirection.Ascending;
            lblSortDisplay.Text = "Descending";
        }
        else if (lblSortDisplay.Text.Equals("Descending"))
        {
            e.SortDirection = SortDirection.Descending;
            lblSortDisplay.Text = "Ascending";
        }
        else if (lblSortDisplay.Text.Equals("Ascending"))
        {
            e.SortDirection = SortDirection.Ascending;
            lblSortDisplay.Text = "Descending";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string query = "SELECT * FROM " + ddlReport.SelectedItem.Value + " WHERE [ReportId]=" + txtReportId.Text + "";
        Session["displaySearch"] = query;
        // display Action required if not empty
        con.Open();
        SqlCommand checkExist = new SqlCommand(query, con);
        try
        {
            int ReportExist = (int)checkExist.ExecuteScalar();
            if (ReportExist > 0)
            {
                gvDisplayReports.Visible = true;
                SqlDataSource1.SelectCommand = query;
                con.Close();
            }
            else
            {
                showAlert("No Reports to Display. Please Check the Report ID.");
                con.Close();
            }
        }
        catch
        {
            showAlert("No Reports to Display. Please Check the Report ID.");
        }
    }

    // display a message box
    protected void showAlert(string message)
    {
        message = "alert(\"" + message + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", message, true);
    }
}
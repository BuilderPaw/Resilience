using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Function_Supervisor_Create_v1_v1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStaffName.Text = Session["DisplayName"].ToString();

            // check the current time then set appropriate date
            TimeSpan start = new TimeSpan(0, 0, 0); // 12am
            TimeSpan end = new TimeSpan(6, 0, 0);     // 6am
            TimeSpan now = DateTime.Now.TimeOfDay;  // current time
            DateTime dateTime;
            if ((now > start) && (now < end))
            {
                // current time is between 12am to 6am
                dateTime = DateTime.Now.Date.AddDays(-1);
            }
            else
            {
                // current time is greater than 6am
                dateTime = DateTime.Now.Date;
            }
            // display appropriate trading date
            txtDatePicker.Text = dateTime.ToString("dddd, dd MMMM yyyy");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

        // get the last Report ID
        string query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_MerrylandsRSLFunctionSupervisor";
        int lastRId, result, returnFlag = 2;
        DateTime temp, date = DateTime.Parse(DateTime.Now.ToShortDateString());
        Report.ErrorMessage = "";

        con.Open();
        SqlCommand getRId = new SqlCommand(query, con);
        try
        {
            lastRId = (int)getRId.ExecuteScalar();
            // add plus one to the current report id to be used in this report
            lastRId += 1;
        }
        catch
        {
            lastRId = 4000001;
        }
        con.Close();

        Report.LastReportId = lastRId.ToString();

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            returnFlag = 1;
        }
        else if (DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                returnFlag = 1;
            }
        }

        if (returnFlag == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"" + Report.ErrorMessage + "\");", true);
            return;
        }

        // change the format of the shift date to timestamp format
        DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
        string shift_tDate = shift_date.ToString("yyyyMMdd");

        // separate the shift date day of week value
        string shift_DOW = shift_date.DayOfWeek.ToString();

        // change the format of the entry date to timestamp format
        DateTime entry_date = DateTime.Now;

        // pop a message if shift is unchanged
        if (ddlShift.SelectedItem.Value == "-1")
        {
            showAlert("Please select Shift.");
            ddlShift.Focus();
            return;
        }

        // get staff's id
        string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
               variable = "getStaff";
        readFiles(cmdText, variable);

        // insert data to table
        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            Report_MerrylandsRSLFunctionSupervisor dm = new Report_MerrylandsRSLFunctionSupervisor();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 4; // MR Reception Category
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_MerrylandsRSLFunctionSupervisor";
            dm.AuditVersion = 1;
            dm.ReportStat = "Awaiting Completion";
            dm.Report_Version = 1; // current version
            dm.ReadByList = "," + UserCredentials.StaffId + ",";
            dm.FunctionName = txtFunctionName.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.NumberOfGuests = txtNoOfGuests.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.Setup = txtSetup.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.MenuFeedback = txtMenuFeedback.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.BarFeedback = txtBarFeedback.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.StaffIssues = txtStaffIssues.Text.Replace("\n","<br />").Replace("'", "^");;
            dm.GeneralComments = txtGenComms.Text.Replace("\n","<br />").Replace("'", "^");;
            dc.Report_MerrylandsRSLFunctionSupervisors.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

        //showAlert("Report Submitted.");
        //Response.Redirect("Default.aspx", false);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('Report Submitted.'); window.location='" +
        Request.ApplicationPath + "Default.aspx';", true);
        SearchReport.SetAccordion = "1";
        SearchReport.RunOnStart = true;
        SearchReport.FromCreateReport = true;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFunctionName.Text = "";
        txtNoOfGuests.Text = "";
        txtSetup.Text = "";
        txtMenuFeedback.Text = "";
        txtBarFeedback.Text = "";
        txtStaffIssues.Text = "";
        txtGenComms.Text = "";
    }

    protected void readFiles(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        try
        {
            con.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("getStaff"))
                    {
                        Session["currentStaffId"] = rdr["StaffId"].ToString();
                    }
                }
            }
        }
        catch (Exception er)
        {
            showAlert(er.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (con != null)
            {
                con.Close();
            }
        }
    }

    protected void showAlert(string message)
    {
        // display a message box
        message = "alert(\"" + message + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", message, true);
    }
}
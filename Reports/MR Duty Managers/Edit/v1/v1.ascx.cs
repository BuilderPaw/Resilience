using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Duty_Managers_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        readFiles(Report.ActiveReport, "getFields");
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
                    if (method.Equals("getFields"))
                    {
                        lblReportName.Text = rdr["ReportName"].ToString();
                        lblReportId.Text = rdr["ReportId"].ToString();
                        lblStaffName.Text = rdr["StaffName"].ToString();
                        Report.SelectedStaffId = rdr["StaffId"].ToString();
                        ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString());
                        Report.ShiftId = ddlShift.SelectedIndex.ToString();
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString();
                        txtSupervisors.Text = rdr["Supervisors"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWhs.Text = rdr["Whs"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCostSavings.Text = rdr["CostSavings"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClubPres.Text = rdr["ClubPresent"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClubMain.Text = rdr["ClubMaintenance"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAbsenteeism.Text = rdr["Absenteeism"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtStaffIssues.Text = rdr["StaffIssues"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGaming.Text = rdr["Gaming"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtKeySec.Text = rdr["KeySecurity"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCameras.Text = rdr["Cameras"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGenComm.Text = rdr["GeneralComments"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLuckyRewards.Text = rdr["LuckyRewards"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCompliance.Text = rdr["Compliance"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        // set the Global variables to the current fields
                        SetStaticVariable();
                        Report.RunEditMode = true;
                    }
                    if (method.Equals("checkChanges"))
                    {
                        int flag = 0;
                        if (Report.ShiftId != rdr["ShiftId"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftId";
                        }
                        if (Report.ShiftDate.ToString() != rdr["ShiftDate"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ShiftDate";
                        }
                        if (ReportDutyManagerMr.Sup != rdr["Supervisors"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Supervisors";
                        }
                        if (ReportDutyManagerMr.Whs != rdr["Whs"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Whs";
                        }
                        if (ReportDutyManagerMr.Cost != rdr["CostSavings"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CostSavings";
                        }
                        if (ReportDutyManagerMr.ClubPres != rdr["ClubPresent"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClubPresent";
                        }
                        if (ReportDutyManagerMr.ClubMain != rdr["ClubMaintenance"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClubMaintenance";
                        }
                        if (ReportDutyManagerMr.Absent != rdr["Absenteeism"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Absenteeism";
                        }
                        if (ReportDutyManagerMr.StaffIssues != rdr["StaffIssues"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffIssues";
                        }
                        if (ReportDutyManagerMr.Gaming != rdr["Gaming"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gaming";
                        }
                        if (ReportDutyManagerMr.KeySec != rdr["KeySecurity"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "KeySecurity";
                        }
                        if (ReportDutyManagerMr.Cameras != rdr["Cameras"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Cameras";
                        }
                        if (ReportDutyManagerMr.GenComm != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
                        }
                        if (ReportDutyManagerMr.LuckyRewards != rdr["LuckyRewards"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LuckyRewards";
                        }
                        if (ReportDutyManagerMr.Compliance != rdr["Compliance"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Compliance";
                        }
                        if (flag == 0)
                        {
                            Report.HasChange = false;
                            Report.WhereChangeHappened = "";
                        }
                        return;
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

    protected void TextChanged_TextChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        getChanges();
    }
    protected void getChanges()
    {
        int result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        Report.ErrorMessage = "";
        Report.HasErrorMessage = false;

        // General Incident Report Form
        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
            ddlShift.Focus();
            Report.HasErrorMessage = true;
        }
        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            Report.HasErrorMessage = true;
        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            Report.HasErrorMessage = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                Report.HasErrorMessage = true;
            }
        }

        Report.RunEditMode = true;
        Report.ShiftId = ddlShift.SelectedItem.Value;
        if (Report.HasErrorMessage.Equals(false))
        {
            Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
            Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        }
        SetStaticVariable();
        readFiles(Report.ActiveReport, "checkChanges");
    }

    protected void SetStaticVariable()
    {
        ReportDutyManagerMr.Sup = txtSupervisors.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Whs = txtWhs.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Cost = txtCostSavings.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.ClubPres = txtClubPres.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.ClubMain = txtClubMain.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Absent = txtAbsenteeism.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.StaffIssues = txtStaffIssues.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Gaming = txtGaming.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.KeySec = txtKeySec.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Cameras = txtCameras.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.GenComm = txtGenComm.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.LuckyRewards = txtLuckyRewards.Text.Replace("\n", "<br />");
        ReportDutyManagerMr.Compliance = txtCompliance.Text.Replace("\n", "<br />");
    }
}
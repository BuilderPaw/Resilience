using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Supervisors_Edit_v1_v1 : System.Web.UI.UserControl
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
                        txtSignInSlip.Text = rdr["SignInSlip"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtReception.Text = rdr["Reception"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGaming.Text = rdr["Gaming"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtBar.Text = rdr["Bar"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtTABKeno.Text = rdr["TABKeno"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHouseKeep.Text = rdr["HouseKeeping"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtBistro.Text = rdr["Bistro"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtFoodHygiene.Text = rdr["FoodHygiene"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtEvents.Text = rdr["Events"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCustomerServ.Text = rdr["CustomerService"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtGenComm.Text = rdr["GeneralComments"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLuckyRewards.Text = rdr["LuckyRewards"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtRSA.Text = rdr["RSA"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAMLCTF.Text = rdr["AMLCTF"].ToString().Replace("<br />", "\n").Replace("^", "'");

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
                        if (ReportSupervisorMr.SignInSlip != rdr["SignInSlip"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip";
                        }
                        if (ReportSupervisorMr.Reception != rdr["Reception"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Reception";
                        }
                        if (ReportSupervisorMr.Gaming != rdr["Gaming"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gaming";
                        }
                        if (ReportSupervisorMr.Bar != rdr["Bar"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Bar";
                        }
                        if (ReportSupervisorMr.TabKeno != rdr["TABKeno"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TABKeno";
                        }
                        if (ReportSupervisorMr.HouseKeeping != rdr["HouseKeeping"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "HouseKeeping";
                        }
                        if (ReportSupervisorMr.Bistro != rdr["Bistro"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Bistro";
                        }
                        if (ReportSupervisorMr.FoodHygiene != rdr["FoodHygiene"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "FoodHygiene";
                        }
                        if (ReportSupervisorMr.Events != rdr["Events"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Events";
                        }
                        if (ReportSupervisorMr.CustomerService != rdr["CustomerService"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CustomerService";
                        }
                        if (ReportSupervisorMr.GenComm != rdr["GeneralComments"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "GeneralComments";
                        }
                        if (ReportSupervisorMr.LuckyRewards != rdr["LuckyRewards"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "LuckyRewards";
                        }
                        if (ReportSupervisorMr.RSA != rdr["RSA"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "RSA";
                        }
                        if (ReportSupervisorMr.AMLCTF != rdr["AMLCTF"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AMLCTF";
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
        if (Report.HasErrorMessage == false)
        {
            Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
            Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        }
        // set the Global variables to the current fields
        SetStaticVariable();
        readFiles(Report.ActiveReport, "checkChanges");
    }

    protected void SetStaticVariable()
    {
        ReportSupervisorMr.SignInSlip = txtSignInSlip.Text.Replace("\n", "<br />");
        ReportSupervisorMr.Reception = txtReception.Text.Replace("\n", "<br />");
        ReportSupervisorMr.Gaming = txtGaming.Text.Replace("\n", "<br />");
        ReportSupervisorMr.Bar = txtBar.Text.Replace("\n", "<br />");
        ReportSupervisorMr.TabKeno = txtTABKeno.Text.Replace("\n", "<br />");
        ReportSupervisorMr.HouseKeeping = txtHouseKeep.Text.Replace("\n", "<br />");
        ReportSupervisorMr.Bistro = txtBistro.Text.Replace("\n", "<br />");
        ReportSupervisorMr.FoodHygiene = txtFoodHygiene.Text.Replace("\n", "<br />");
        ReportSupervisorMr.Events = txtEvents.Text.Replace("\n", "<br />");
        ReportSupervisorMr.CustomerService = txtCustomerServ.Text.Replace("\n", "<br />");
        ReportSupervisorMr.GenComm = txtGenComm.Text.Replace("\n", "<br />");
        ReportSupervisorMr.LuckyRewards = txtLuckyRewards.Text.Replace("\n", "<br />");
        ReportSupervisorMr.RSA = txtRSA.Text.Replace("\n", "<br />");
        ReportSupervisorMr.AMLCTF = txtAMLCTF.Text.Replace("\n", "<br />");
    }
}
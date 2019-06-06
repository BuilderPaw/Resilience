using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Incident_Report_Create_v1_v1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvantageDb"].ConnectionString);
    byte[] memberPhoto1 = null, memberPhoto2 = null, memberPhoto3 = null, memberPhoto4 = null, memberPhoto5 = null;
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // add the check box items for Location
            List_Location.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["LocationID"].ToString();
                        List_Location.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Incident Type
            cblWhatHappened1.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_IncidentType] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["IncidentId"].ToString();
                        cblWhatHappened1.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Asked to Leave
            List_AskedToLeave.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_AskedToLeave] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["AskedToLeaveID"].ToString();
                        List_AskedToLeave.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Refuse Reason
            List_RefuseReason.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_RefuseReason] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["RefuseReasonID"].ToString();
                        List_RefuseReason.Items.Add(item);
                    }
                }
                con.Close();
            }

            // add the check box items for Action Taken
            List_ActionTaken.Items.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [dbo].[List_ActionTaken] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'None of the above' THEN 1 ELSE 0 END, [Description]";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Description"].ToString();
                        item.Value = sdr["ActionID"].ToString();
                        List_ActionTaken.Items.Add(item);
                    }
                }
                con.Close();
            }

            txtStaffName.Text = Session["DisplayName"].ToString();

            // by default set the Person tables are hidden
            acpPerson1.Visible = false;
            acpPerson2.Visible = false;
            acpPerson3.Visible = false;
            acpPerson4.Visible = false;
            acpPerson5.Visible = false;
            tblAddPerson2.Visible = false;
            tblAddPerson3.Visible = false;
            tblAddPerson4.Visible = false;
            tblAddPerson5.Visible = false;
            tblDelPerson5.Visible = false;

            // by default set the extra Camera tables hidden
            tblCamera1.Visible = false;
            tblAddCam2.Visible = false;
            tblCamera2.Visible = false;
            tblAddCam3.Visible = false;
            tblCamera3.Visible = false;
            tblAddCam4.Visible = false;
            tblCamera4.Visible = false;
            tblAddCam5.Visible = false;
            tblCamera5.Visible = false;
            tblAddCam6.Visible = false;
            tblCamera6.Visible = false;
            tblAddCam7.Visible = false;
            tblCamera7.Visible = false;
            tblDelCam7.Visible = false;

            // Hide Security Details by Default
            tdSecurity1.Visible = false;
            tdSecurity2.Visible = false;

            // Hide Police Details by Default
            tdPolice1.Visible = false;
            tdPolice2.Visible = false;
            tdPolice3.Visible = false;
            tdPolice4.Visible = false;
            tdPolice5.Visible = false;
            tdPolice6.Visible = false;

            // check the current time then set appropriate date
            TimeSpan start = new TimeSpan(0, 0, 0);   // 12am
            TimeSpan end = new TimeSpan(8, 0, 0);     // 8am
            TimeSpan now = DateTime.Now.TimeOfDay;    // current time
            DateTime dateTime;
            if ((now > start) && (now < end))
            {
                // current time is between 12am to 8am
                dateTime = DateTime.Now.Date.AddDays(-1);
            }
            else
            {
                // current time is greater than 8am
                dateTime = DateTime.Now.Date;
            }
            // display appropriate trading date
            txtDatePicker.Text = dateTime.ToString("dddd, dd MMMM yyyy");
        }
    }

    // validates form. It calls the validateCameraForm and validatePersonForm methods
    protected int validateForm()
    {
        int returnedFlag = 0, result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";
            txtDatePicker.Focus();
            returnedFlag = 1;

        }
        else if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date is not in date format please select an appropriate date.";
            txtDatePicker.Focus();
            returnedFlag = 1;

        }
        else
        {
            // compare date entered to current date
            DateTime date1a = DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1a, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDatePicker.Focus();
                returnedFlag = 1;
            }
        }

        if (ddlShift.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Shift.";
            ddlShift.Focus();
            returnedFlag = 1;

        }

        // check if returnedFlag is already set 1
        int returnedFlag1 = validatePersonForm();
        if (returnedFlag == 1 || returnedFlag1 == 1)
        {
            returnedFlag = 1;
        }
        int returnedFlag2 = validateCameraForm();
        if (returnedFlag == 1 || returnedFlag2 == 1 || returnedFlag2 == 1)
        {
            returnedFlag = 1;
        }
        // General Incident Report Form
        if (txtDate1.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident Date shouldn't be empty.";
            txtDate1.Focus();
            returnedFlag = 1;

        }
        if (!DateTime.TryParse(txtDate1.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident's Date entry is not in date format please select an appropriate date.";
            txtDate1.Focus();
            returnedFlag = 1;

        }
        else
        {
            DateTime date1 = DateTime.Parse(DateTime.Parse(txtDate1.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                txtDate1.Focus();
                returnedFlag = 1;
            }
        }

        if (ddlHour.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour of the Incident.";
            ddlHour.Focus();
            returnedFlag = 1;

        }
        if (ddlMinutes.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes of the Incident.";
            ddlMinutes.Focus();
            returnedFlag = 1;

        }
        /*if (ddlTimeCon.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Time Convention of the Incident");
            ddlTimeCon.Focus();
            returnedFlag = 1;

        }*/
        if (List_Location.SelectedValue == String.Empty)
        {
            if (txtLocation.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the location in this Incident Report.";
                List_Location.Focus();
                returnedFlag = 1;

            }
        }
        else
        {
            foreach (ListItem item in List_Location.Items)
            {
                if (item.ToString() == "Other")
                {
                    if (item.Selected)
                    {
                        if (txtLocation.Text == "")
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify additional Other Location.";
                            txtLocation.Focus();
                            returnedFlag = 1;

                        }
                    }
                }
            }
        }
        if (txtDetails.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident's Full Details shouldn't be empty.";
            txtDetails.Focus();
            returnedFlag = 1;

        }
        if (txtAllegation.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident's Allegation shouldn't be empty.";
            txtAllegation.Focus();
            returnedFlag = 1;

        }
        if (cblWhatHappened1.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what happened in this Incident Report.";
            cblWhatHappened1.Focus();
            returnedFlag = 1;
        }
        else
        {
            foreach (ListItem item in cblWhatHappened1.Items)
            {
                if (item.ToString() == "Other")
                {
                    if (item.Selected)
                    {
                        if (txtOthers.Text == "")
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify additional details in the Incident.";
                            txtOthers.Focus();
                            returnedFlag = 1;

                        }
                    }
                }
                if (item.ToString() == "Other - Serious")
                {
                    if (item.Selected)
                    {
                        if (txtOtherSerious.Text == "")
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify Serious details in the Incident.";
                            txtOtherSerious.Focus();
                            returnedFlag = 1;

                        }
                    }
                }
                if (item.ToString() == "Refused Entry")
                {
                    if (item.Selected)
                    {
                        if (List_RefuseReason.SelectedValue == String.Empty)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify reason for refusing entry.";
                            List_RefuseReason.Focus();
                            returnedFlag = 1;

                        }
                    }
                }
                if (item.ToString() == "Asked to Leave")
                {
                    if (item.Selected)
                    {
                        if (List_AskedToLeave.SelectedValue == String.Empty)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify reason for asking the patron to leave the premises.";
                            List_AskedToLeave.Focus();
                            returnedFlag = 1;
                        }
                    }
                }
                if (item.ToString() == "Assault Patron" || item.ToString() == "Assault Staff" || item.ToString() == "Assault Security")
                {
                    if (item.Selected)
                    {
                        if (acpPerson1.Visible == true)
                        {
                            if (txtHeight1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 1.";
                                txtHeight1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtHair1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 1.";
                                txtHair1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtClothingTop1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 1.";
                                txtClothingTop1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtClothingBottom1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 1.";
                                txtClothingBottom1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtShoes1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 1.";
                                txtShoes1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtDistFeatures1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 1.";
                                txtDistFeatures1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtWeapon1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 1.";
                                txtWeapon1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtInjuryDesc1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 1.";
                                txtInjuryDesc1.Focus();
                                returnedFlag = 1;
                            }

                            if (txtPDate1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date entry shouldn't be empty.";
                                txtPDate1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;

                            }
                            if (!DateTime.TryParse(txtPDate1.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date entry is not in date format please select an appropriate date.";
                                txtPDate1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;

                            }
                            else
                            {
                                DateTime date1p = DateTime.Parse(DateTime.Parse(txtPDate1.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date1p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                                    txtPDate1.Focus();
                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = 1;

                                }
                            }

                            if (ddlPTimeH1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 1.";
                                ddlPTimeH1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;

                            }
                            if (ddlPTimeM1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 1.";
                                ddlPTimeM1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;

                            }
                        }
                        else if (acpPerson1.Visible == false)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Mandatory Fields required with this type of Incident. Please add details of Person(s) involved.";
                            returnedFlag = 1;
                        }
                        if (acpPerson2.Visible == true)
                        {
                            if (txtHeight2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 2.";
                                txtHeight2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtHair2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 2.";
                                txtHair2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingTop2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 2.";
                                txtClothingTop2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingBottom2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 2.";
                                txtClothingBottom2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtShoes2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 2.";
                                txtShoes2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtDistFeatures2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 2.";
                                txtDistFeatures2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtWeapon2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 2.";
                                txtWeapon2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtInjuryDesc2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 2.";
                                txtInjuryDesc2.Focus();
                                returnedFlag = 1;

                            }

                            if (txtPDate2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date entry shouldn't be empty.";
                                txtPDate2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;

                            }
                            if (!DateTime.TryParse(txtPDate2.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date entry is not in date format please select an appropriate date.";
                                txtPDate2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;

                            }
                            else
                            {
                                DateTime date2p = DateTime.Parse(DateTime.Parse(txtPDate2.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date2p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                                    txtPDate2.Focus();
                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = 1;

                                }
                            }

                            if (ddlPTimeH2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 2.";
                                ddlPTimeH2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;

                            }
                            if (ddlPTimeM2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 2.";
                                ddlPTimeM2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;

                            }
                        }
                        if (acpPerson3.Visible == true)
                        {
                            if (txtHeight3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 3.";
                                txtHeight3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtHair3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 3.";
                                txtHair3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingTop3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 3.";
                                txtClothingTop3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingBottom3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 3.";
                                txtClothingBottom3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtShoes3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 3.";
                                txtShoes3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtDistFeatures3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 3.";
                                txtDistFeatures3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtWeapon3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 3.";
                                txtWeapon3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtInjuryDesc3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 3.";
                                txtInjuryDesc3.Focus();
                                returnedFlag = 1;

                            }

                            if (txtPDate3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date entry shouldn't be empty.";
                                txtPDate3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;

                            }
                            if (!DateTime.TryParse(txtPDate3.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date entry is not in date format please select an appropriate date.";
                                txtPDate3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;

                            }
                            else
                            {
                                DateTime date3p = DateTime.Parse(DateTime.Parse(txtPDate3.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date3p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                                    txtPDate3.Focus();
                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = 1;

                                }
                            }

                            if (ddlPTimeH3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 3.";
                                ddlPTimeH3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;

                            }
                            if (ddlPTimeM3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 3.";
                                ddlPTimeM3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;

                            }
                        }
                        if (acpPerson4.Visible == true)
                        {
                            if (txtHeight4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 4.";
                                txtHeight4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtHair4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 4.";
                                txtHair4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingTop4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 4.";
                                txtClothingTop4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingBottom4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 4.";
                                txtClothingBottom4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtShoes4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 4.";
                                txtShoes4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtDistFeatures4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 4.";
                                txtDistFeatures4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtWeapon4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 4.";
                                txtWeapon4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtInjuryDesc4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 4.";
                                txtInjuryDesc4.Focus();
                                returnedFlag = 1;

                            }

                            if (txtPDate4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date entry shouldn't be empty.";
                                txtPDate4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;

                            }
                            if (!DateTime.TryParse(txtPDate4.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date entry is not in date format please select an appropriate date.";
                                txtPDate4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;

                            }
                            else
                            {
                                DateTime date4p = DateTime.Parse(DateTime.Parse(txtPDate4.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date4p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                                    txtPDate4.Focus();
                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = 1;

                                }
                            }

                            if (ddlPTimeH4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 4.";
                                ddlPTimeH4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;

                            }
                            if (ddlPTimeM4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 4.";
                                ddlPTimeM4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;

                            }
                        }
                        if (acpPerson5.Visible == true)
                        {
                            if (txtHeight5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 5.";
                                txtHeight5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtHair5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 5.";
                                txtHair5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingTop5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 5.";
                                txtClothingTop5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtClothingBottom5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 5.";
                                txtClothingBottom5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtShoes5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 5.";
                                txtShoes5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtDistFeatures5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 5.";
                                txtDistFeatures5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtWeapon5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 5.";
                                txtWeapon5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtInjuryDesc5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 5.";
                                txtInjuryDesc5.Focus();
                                returnedFlag = 1;

                            }

                            if (txtPDate5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date entry shouldn't be empty.";
                                txtPDate5.Focus();
                                acdPerson.SelectedIndex = 4;
                                returnedFlag = 1;

                            }
                            if (!DateTime.TryParse(txtPDate5.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date entry is not in date format please select an appropriate date.";
                                txtPDate5.Focus();
                                acdPerson.SelectedIndex = 4;
                                returnedFlag = 1;

                            }
                            else
                            {
                                DateTime date5p = DateTime.Parse(DateTime.Parse(txtPDate5.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date5p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                                    txtPDate5.Focus();
                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = 1;

                                }
                            }

                            if (ddlPTimeH5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 5.";
                                ddlPTimeH5.Focus();
                                acdPerson.SelectedIndex = 4;
                                returnedFlag = 1;

                            }
                            if (ddlPTimeM5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 5.";
                                ddlPTimeM5.Focus();
                                returnedFlag = 1;
                                acdPerson.SelectedIndex = 4;

                            }
                        }
                        if (List_ActionTaken.SelectedValue == String.Empty)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Action Taken is mandatory for this Incident.";
                            List_ActionTaken.Focus();
                            returnedFlag = 1;
                        }
                        else
                        {
                            foreach (ListItem item1 in List_ActionTaken.Items)
                            {
                                if (item1.ToString() == "Other")
                                {
                                    if (item1.Selected)
                                    {
                                        if (txtActionTakenOther.Text == "")
                                        {
                                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please specify other - action taken in the Incident.";
                                            txtActionTakenOther.Focus();
                                            returnedFlag = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (item.Selected)
                    {
                        if (acpPerson1.Visible == true)
                        {
                            if (ddlPartyType1.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName1.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's First Name shouldn't be empty.";
                                    txtFirstName1.Focus();
                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = 1;
                                }
                                if (txtLastName1.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Last Name shouldn't be empty.";
                                    txtLastName1.Focus();
                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = 1;
                                }

                                if (txtContact1.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 1.";
                                    txtContact1.Focus();
                                    returnedFlag = 1;
                                }
                            }
                            if (txtAge1.Text == "" && ddlAgeGroup1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Age.";
                                txtAge1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;
                            }

                            if (ddlGender1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 1's Gender.";
                                ddlGender1.Focus();
                                acdPerson.SelectedIndex = 0;
                                returnedFlag = 1;
                            }
                        }
                        else if (acpPerson1.Visible == false)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Mandatory Fields required with this type of Incident. Please add details of Person(s) involved.";
                            returnedFlag = 1;
                        }
                        if (acpPerson2.Visible == true)
                        {
                            if (ddlPartyType2.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's First Name shouldn't be empty.";
                                    txtFirstName2.Focus();
                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = 1;
                                }

                                if (txtLastName2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Last Name shouldn't be empty.";
                                    txtLastName2.Focus();
                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = 1;
                                }

                                if (txtContact2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 2.";
                                    txtContact2.Focus();
                                    returnedFlag = 1;
                                }
                            }

                            if (txtAge2.Text == "" && ddlAgeGroup2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Age.";
                                txtAge2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;
                            }

                            if (ddlGender2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 2's Gender.";
                                ddlGender2.Focus();
                                acdPerson.SelectedIndex = 1;
                                returnedFlag = 1;
                            }
                        }
                        if (acpPerson3.Visible == true)
                        {
                            if (ddlPartyType3.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's First Name shouldn't be empty.";
                                    txtFirstName3.Focus();
                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = 1;
                                }

                                if (txtLastName3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Last Name shouldn't be empty.";
                                    txtLastName3.Focus();
                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = 1;
                                }

                                if (txtContact3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 3.";
                                    txtContact3.Focus();
                                    returnedFlag = 1;
                                }
                            }

                            if (txtAge3.Text == "" && ddlAgeGroup3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Age.";
                                txtAge3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;
                            }
                            if (ddlGender3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 3's Gender.";
                                ddlGender3.Focus();
                                acdPerson.SelectedIndex = 2;
                                returnedFlag = 1;
                            }
                        }
                        if (acpPerson4.Visible == true)
                        {
                            if (ddlPartyType4.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's First Name shouldn't be empty.";
                                    txtFirstName4.Focus();
                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = 1;
                                }

                                if (txtLastName4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Last Name shouldn't be empty.";
                                    txtLastName4.Focus();
                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = 1;

                                }

                                if (txtContact4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 4.";
                                    txtContact4.Focus();
                                    returnedFlag = 1;
                                }

                            }

                            if (txtAge4.Text == "" && ddlAgeGroup4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Age.";
                                txtAge4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;
                            }

                            if (ddlGender4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 4's Gender.";
                                ddlGender4.Focus();
                                acdPerson.SelectedIndex = 3;
                                returnedFlag = 1;
                            }
                        }
                        if (acpPerson5.Visible == true)
                        {
                            if (ddlPartyType5.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's First Name shouldn't be empty.";
                                    txtFirstName5.Focus();
                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = 1;
                                }

                                if (txtLastName5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Last Name shouldn't be empty.";
                                    txtLastName5.Focus();
                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = 1;
                                }

                                if (txtContact5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 5.";
                                    txtContact5.Focus();
                                    returnedFlag = 1;
                                }
                            }

                            if (txtAge5.Text == "" && ddlAgeGroup5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Age.";
                                txtAge5.Focus();
                                acdPerson.SelectedIndex = 4;
                                returnedFlag = 1;
                            }

                            if (ddlGender5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 5's Gender.";
                                ddlGender5.Focus();
                                acdPerson.SelectedIndex = 4;
                                returnedFlag = 1;
                            }
                        }
                    }
                }
            }
        }

        // Security Officer
        if (cbSecurity.Checked == true)
        {
            if (txtSecurityName.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Security name shouldn't be empty.";
                txtSecurityName.Focus();
                returnedFlag = 1;

            }
        }

        // Police Station
        if (cbPolice.Checked == true)
        {
            if (txtPoliceStation.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Police Station shouldn't be empty.";
                txtPoliceStation.Focus();
                returnedFlag = 1;

            }
            if (txtOfficersName.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Officer's Name shouldn't be empty.";
                txtOfficersName.Focus();
                returnedFlag = 1;

            }
            if (txtPoliceAction.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Police's action shouldn't be empty.";
                txtPoliceAction.Focus();
                returnedFlag = 1;

            }
        }

        return returnedFlag;
    }
    protected int validateCameraForm()
    {
        DateTime temp;
        int returnedFlag = 0;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        // Camera Forms
        if (tblCamera1.Visible == true)
        {
            if (txtCamDesc1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc1.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Start Date shouldn't be empty.";
                txtCamSDate1.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate1.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Date entry is not in date format please select an appropriate date.";
                txtCamSDate1.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date1Sc = DateTime.Parse(DateTime.Parse(txtCamSDate1.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date1Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate1.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 1.";
                ddlCamTimeH1.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 1.";
                ddlCamTimeM1.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 1.";
                ddlCamTimeTC1.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's End Date shouldn't be empty.";
                txtCamEDate1.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate1.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Date entry is not in date format please select an appropriate date.";
                txtCamEDate1.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date1Ec = DateTime.Parse(DateTime.Parse(txtCamEDate1.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date1Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate1.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 1.";
                ddlCamETimeH1.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 1.";
                ddlCamETimeM1.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 1.";
                ddlCamETimeTC1.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera2.Visible == true)
        {
            if (txtCamDesc2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc2.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Start Date shouldn't be empty.";
                txtCamSDate2.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Start Date shouldn't be empty.";
                txtCamSDate2.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate2.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Date entry is not in date format please select an appropriate date.";
                txtCamSDate2.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date2Sc = DateTime.Parse(DateTime.Parse(txtCamSDate2.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date2Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate2.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 2.";
                ddlCamTimeH2.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 2.";
                ddlCamTimeM2.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 2.";
                ddlCamTimeTC2.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's End Date shouldn't be empty.";
                txtCamEDate2.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate2.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Date entry is not in date format please select an appropriate date.";
                txtCamEDate2.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date2Ec = DateTime.Parse(DateTime.Parse(txtCamEDate2.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date2Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate2.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 2.";
                ddlCamETimeH2.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 2.";
                ddlCamETimeM2.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 2.";
                ddlCamETimeTC2.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera3.Visible == true)
        {
            if (txtCamDesc3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc3.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Start Date shouldn't be empty.";
                txtCamSDate3.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Start Date shouldn't be empty.";
                txtCamSDate3.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate3.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Date entry is not in date format please select an appropriate date.";
                txtCamSDate3.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date3Sc = DateTime.Parse(DateTime.Parse(txtCamSDate3.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date3Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate3.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 3.";
                ddlCamTimeH3.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 3.";
                ddlCamTimeM3.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 3.";
                ddlCamTimeTC3.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's End Date shouldn't be empty.";
                txtCamEDate3.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate3.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Date entry is not in date format please select an appropriate date.";
                txtCamEDate3.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date3Ec = DateTime.Parse(DateTime.Parse(txtCamEDate3.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date3Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate3.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 3.";
                ddlCamETimeH3.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 3.";
                ddlCamETimeM3.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 3.";
                ddlCamETimeTC3.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera4.Visible == true)
        {
            if (txtCamDesc4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc4.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Start Date shouldn't be empty.";
                txtCamSDate4.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Start Date shouldn't be empty.";
                txtCamSDate4.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate4.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Date entry is not in date format please select an appropriate date.";
                txtCamSDate4.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date4Sc = DateTime.Parse(DateTime.Parse(txtCamSDate4.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date4Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate4.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 4.";
                ddlCamTimeH4.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 4.";
                ddlCamTimeM4.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 4.";
                ddlCamTimeTC4.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's End Date shouldn't be empty.";
                txtCamEDate4.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate4.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Date entry is not in date format please select an appropriate date.";
                txtCamEDate4.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date4Ec = DateTime.Parse(DateTime.Parse(txtCamEDate4.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date4Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate4.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 4.";
                ddlCamETimeH4.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 4.";
                ddlCamETimeM4.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 4.";
                ddlCamETimeTC4.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera5.Visible == true)
        {
            if (txtCamDesc5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc5.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Start Date shouldn't be empty.";
                txtCamSDate5.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Start Date shouldn't be empty.";
                txtCamSDate5.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate5.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Date entry is not in date format please select an appropriate date.";
                txtCamSDate5.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date5Sc = DateTime.Parse(DateTime.Parse(txtCamSDate5.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date5Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate5.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 5.";
                ddlCamTimeH5.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 5.";
                ddlCamTimeM5.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 5.";
                ddlCamTimeTC5.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's End Date shouldn't be empty.";
                txtCamEDate5.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate5.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Date entry is not in date format please select an appropriate date.";
                txtCamEDate5.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date5Ec = DateTime.Parse(DateTime.Parse(txtCamEDate5.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date5Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate5.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 5.";
                ddlCamETimeH5.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 5.";
                ddlCamETimeM5.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 5.";
                ddlCamETimeTC5.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera6.Visible == true)
        {
            if (txtCamDesc6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc6.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Start Date shouldn't be empty.";
                txtCamSDate6.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Start Date shouldn't be empty.";
                txtCamSDate6.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate6.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Date entry is not in date format please select an appropriate date.";
                txtCamSDate6.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date6Sc = DateTime.Parse(DateTime.Parse(txtCamSDate6.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date6Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate6.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 6.";
                ddlCamTimeH6.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 6.";
                ddlCamTimeM6.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 6.";
                ddlCamTimeTC6.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's End Date shouldn't be empty.";
                txtCamEDate6.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate6.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Date entry is not in date format please select an appropriate date.";
                txtCamEDate6.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date6Ec = DateTime.Parse(DateTime.Parse(txtCamEDate6.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date6Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate6.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 6.";
                ddlCamETimeH6.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 6.";
                ddlCamETimeM6.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 6.";
                ddlCamETimeTC6.Focus();
                returnedFlag = 1;

            }*/
        }
        if (tblCamera7.Visible == true)
        {
            if (txtCamDesc7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";
                txtCamDesc7.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Start Date shouldn't be empty.";
                txtCamSDate7.Focus();
                returnedFlag = 1;

            }
            if (txtCamSDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Start Date shouldn't be empty.";
                txtCamSDate7.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamSDate7.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Date entry is not in date format please select an appropriate date.";
                txtCamSDate7.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date7Sc = DateTime.Parse(DateTime.Parse(txtCamSDate7.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date7Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamSDate7.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamTimeH7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 7.";
                ddlCamTimeH7.Focus();
                returnedFlag = 1;

            }
            if (ddlCamTimeM7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 7.";
                ddlCamTimeM7.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamTimeTC7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 7.";
                ddlCamTimeTC7.Focus();
                returnedFlag = 1;

            }*/
            if (txtCamEDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's End Date shouldn't be empty.";
                txtCamEDate7.Focus();
                returnedFlag = 1;

            }
            if (!DateTime.TryParse(txtCamEDate7.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Date entry is not in date format please select an appropriate date.";
                txtCamEDate7.Focus();
                returnedFlag = 1;

            }
            else
            {
                DateTime date7Ec = DateTime.Parse(DateTime.Parse(txtCamEDate7.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date7Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                    txtCamEDate7.Focus();
                    returnedFlag = 1;

                }
            }

            if (ddlCamETimeH7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 7.";
                ddlCamETimeH7.Focus();
                returnedFlag = 1;

            }
            if (ddlCamETimeM7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 7.";
                ddlCamETimeM7.Focus();
                returnedFlag = 1;

            }
            /*if (ddlCamETimeTC7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 7.";
                ddlCamETimeTC7.Focus();
                returnedFlag = 1;

            }*/
        }

        return returnedFlag;
    }
    protected int validatePersonForm()
    {
        DateTime temp;
        int returnedFlag = 0;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        // Person 1
        if (acpPerson1.Visible == true)
        {

            if (ddlPartyType1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 1.";
                ddlPartyType1.Focus();
                acdPerson.SelectedIndex = 0;
                returnedFlag = 1;

            }

            if (ddlPartyType1.SelectedItem.Text == "Member")
            {
                if (txtMemberNo1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number of Person 1.";
                    txtMemberNo1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
                if (txtDOB1.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB1.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date of Birth is not in date format please select an appropriate date.";
                        txtDOB1.Focus();
                        acdPerson.SelectedIndex = 0;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datem1 = DateTime.Parse(DateTime.Parse(txtDOB1.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datem1, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOB1.Focus();
                            acdPerson.SelectedIndex = 0;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddress1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Address.";
                    txtAddress1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType1.SelectedItem.Text == "Staff")
            {
                if (txtStaffEmpNo1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Employee No.";
                    txtStaffEmpNo1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
                if (txtStaffAddress1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Address.";
                    txtStaffAddress1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType1.SelectedItem.Text == "Visitor")
            {
                if (cbSignInSlip1.Checked == true)
                {
                    if (txtSignInBy1.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the member.";
                        txtSignInBy1.Focus();
                        acdPerson.SelectedIndex = 0;
                        returnedFlag = 1;

                    }
                }
                if (txtDOBv1.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv1.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date of Birth is not in date format please select an appropriate date.";
                        txtDOBv1.Focus();
                        acdPerson.SelectedIndex = 0;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datev1 = DateTime.Parse(DateTime.Parse(txtDOBv1.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datev1, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOBv1.Focus();
                            acdPerson.SelectedIndex = 0;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddressv1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Address.";
                    txtAddress1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
                if (txtIDProof1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Proof ID.";
                    txtIDProof1.Focus();
                    acdPerson.SelectedIndex = 0;
                    returnedFlag = 1;

                }
            }
        }
        // Person 2
        if (acpPerson2.Visible == true)
        {

            if (ddlPartyType2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 2.";
                ddlPartyType2.Focus();
                acdPerson.SelectedIndex = 1;
                returnedFlag = 1;

            }

            if (ddlPartyType2.SelectedItem.Text == "Member")
            {
                if (txtMemberNo2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number of Person 2.";
                    txtMemberNo2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
                if (txtDOB2.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB2.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date of Birth is not in date format please select an appropriate date.";
                        txtDOB2.Focus();
                        acdPerson.SelectedIndex = 1;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datem2 = DateTime.Parse(DateTime.Parse(txtDOB2.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datem2, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOB2.Focus();
                            acdPerson.SelectedIndex = 1;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddress2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Address.";
                    txtAddress2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType2.SelectedItem.Text == "Staff")
            {
                if (txtStaffEmpNo2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Employee No.";
                    txtStaffEmpNo2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
                if (txtStaffAddress2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Address.";
                    txtStaffAddress2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType2.SelectedItem.Text == "Visitor")
            {
                if (cbSignInSlip2.Checked == true)
                {
                    if (txtSignInBy2.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the member.";
                        txtSignInBy2.Focus();
                        acdPerson.SelectedIndex = 1;
                        returnedFlag = 1;

                    }
                }
                if (txtDOBv2.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv2.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date of Birth is not in date format please select an appropriate date.";
                        txtDOBv2.Focus();
                        acdPerson.SelectedIndex = 1;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datev2 = DateTime.Parse(DateTime.Parse(txtDOBv2.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datev2, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOBv2.Focus();
                            acdPerson.SelectedIndex = 1;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddressv2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Address.";
                    txtAddress2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
                if (txtIDProof2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Proof ID.";
                    txtIDProof2.Focus();
                    acdPerson.SelectedIndex = 1;
                    returnedFlag = 1;

                }
            }
        }
        // Person 3
        if (acpPerson3.Visible == true)
        {

            if (ddlPartyType3.SelectedItem.Text == "Member")
            {
                if (txtMemberNo3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number of Person 3.";
                    txtMemberNo3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
                if (txtDOB3.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB3.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date of Birth is not in date format please select an appropriate date.";
                        txtDOB3.Focus();
                        acdPerson.SelectedIndex = 2;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datem3 = DateTime.Parse(DateTime.Parse(txtDOB3.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datem3, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOB3.Focus();
                            acdPerson.SelectedIndex = 2;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddress3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Address.";
                    txtAddress3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType3.SelectedItem.Text == "Staff")
            {
                if (txtStaffEmpNo3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Employee No.";
                    txtStaffEmpNo3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
                if (txtStaffAddress3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Address.";
                    txtStaffAddress3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType3.SelectedItem.Text == "Visitor")
            {
                if (cbSignInSlip3.Checked == true)
                {
                    if (txtSignInBy3.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the member.";
                        txtSignInBy3.Focus();
                        acdPerson.SelectedIndex = 2;
                        returnedFlag = 1;

                    }
                }
                if (txtDOBv3.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv3.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date of Birth is not in date format please select an appropriate date.";
                        txtDOBv3.Focus();
                        acdPerson.SelectedIndex = 2;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datev3 = DateTime.Parse(DateTime.Parse(txtDOBv3.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datev3, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOBv3.Focus();
                            acdPerson.SelectedIndex = 2;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddressv3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Address.";
                    txtAddress3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
                if (txtIDProof3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Proof ID.";
                    txtIDProof3.Focus();
                    acdPerson.SelectedIndex = 2;
                    returnedFlag = 1;

                }
            }
        }
        // Person 4
        if (acpPerson4.Visible == true)
        {
            if (ddlPartyType4.SelectedItem.Text == "Member")
            {
                if (txtMemberNo4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number of Person 4.";
                    txtMemberNo4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
                if (txtDOB4.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB4.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date of Birth is not in date format please select an appropriate date.";
                        txtDOB4.Focus();
                        acdPerson.SelectedIndex = 3;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datem4 = DateTime.Parse(DateTime.Parse(txtDOB4.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datem4, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOB4.Focus();
                            acdPerson.SelectedIndex = 3;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddress4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Address.";
                    txtAddress4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType4.SelectedItem.Text == "Staff")
            {
                if (txtStaffEmpNo4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Employee No.";
                    txtStaffEmpNo4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
                if (txtStaffAddress4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Address.";
                    txtStaffAddress4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType4.SelectedItem.Text == "Visitor")
            {
                if (cbSignInSlip4.Checked == true)
                {
                    if (txtSignInBy4.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the member.";
                        txtSignInBy4.Focus();
                        acdPerson.SelectedIndex = 3;
                        returnedFlag = 1;

                    }
                }
                if (txtDOBv4.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv4.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date of Birth is not in date format please select an appropriate date.";
                        txtDOBv4.Focus();
                        acdPerson.SelectedIndex = 3;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datev4 = DateTime.Parse(DateTime.Parse(txtDOBv4.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datev4, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOBv4.Focus();
                            acdPerson.SelectedIndex = 3;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddressv4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Address.";
                    txtAddress4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
                if (txtIDProof4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Proof ID.";
                    txtIDProof4.Focus();
                    acdPerson.SelectedIndex = 3;
                    returnedFlag = 1;

                }
            }
        }
        // Person 5
        if (acpPerson5.Visible == true)
        {
            if (ddlPartyType5.SelectedItem.Text == "Member")
            {
                if (txtMemberNo5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Membership number of Person 5.";
                    txtMemberNo5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
                if (txtDOB5.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB5.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date of Birth is not in date format please select an appropriate date.";
                        txtDOB5.Focus();
                        acdPerson.SelectedIndex = 4;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datem5 = DateTime.Parse(DateTime.Parse(txtDOB5.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datem5, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOB5.Focus();
                            acdPerson.SelectedIndex = 4;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddress5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Address.";
                    txtAddress5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType5.SelectedItem.Text == "Staff")
            {
                if (txtStaffEmpNo5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Employee No.";
                    txtStaffEmpNo5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
                if (txtStaffAddress5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Address.";
                    txtStaffAddress5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
            }
            else if (ddlPartyType5.SelectedItem.Text == "Visitor")
            {
                if (cbSignInSlip5.Checked == true)
                {
                    if (txtSignInBy5.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who Signed in the member.";
                        txtSignInBy5.Focus();
                        acdPerson.SelectedIndex = 4;
                        returnedFlag = 1;

                    }
                }
                if (txtDOBv5.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv5.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date of Birth is not in date format please select an appropriate date.";
                        txtDOBv5.Focus();
                        acdPerson.SelectedIndex = 4;
                        returnedFlag = 1;

                    }
                    else
                    {
                        DateTime datev5 = DateTime.Parse(DateTime.Parse(txtDOBv5.Text).ToShortDateString());
                        // compare selected date to current date
                        result = DateTime.Compare(datev5, date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";
                            txtDOBv5.Focus();
                            acdPerson.SelectedIndex = 4;
                            returnedFlag = 1;

                        }
                    }
                }

                if (txtAddressv5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Address.";
                    txtAddress5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
                if (txtIDProof5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Proof ID.";
                    txtIDProof5.Focus();
                    acdPerson.SelectedIndex = 4;
                    returnedFlag = 1;

                }
            }
        }

        return returnedFlag;
    }

    // reads the fields in the database
    protected void readFiles(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd;

        if (method.Contains("Member"))
        {
            cmd = new SqlCommand(sqlCommand, con1);
        }
        else
        {
            cmd = new SqlCommand(sqlCommand, con);
        }

        try
        {
            if (method.Contains("Member"))
            {
                con1.Open();
            }
            else
            {
                con.Open();
            }

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (method.Equals("getStaff"))
                    {
                        Session["currentStaffId"] = rdr["StaffId"].ToString();
                    }
                    if (method.Equals("SearchMember"))
                    {
                        if (Report.MemberNumberChanged.Equals("1"))
                        {
                            ReportIncidentCu.PlayerId1 = rdr["PlayerId"].ToString();
                            ReportIncidentCu.ViewPlayerId1 = rdr["PlayerId"].ToString();
                            txtFirstName1.Text = rdr["FirstName"].ToString();
                            txtLastName1.Text = rdr["LastName"].ToString();
                            txtAddress1.Text = rdr["Address"].ToString();
                            txtDOB1.Text = rdr["Birthday"].ToString();
                            txtMemberSince1.Text = rdr["MemberSince"].ToString();
                            txtContact1.Text = rdr["Contact"].ToString();

                            try
                            {
                                memberPhoto1 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto1, 0, memberPhoto1.Length);
                                imgMember1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto1 = null;
                                imgMember1.ImageUrl = "~/Images/no-image.png";
                            }

                            string Gender = rdr["Gender"].ToString();

                            if (Gender.Equals("M"))
                            {
                                ddlGender1.SelectedValue = "1";
                            }
                            else if (Gender.Equals("F"))
                            {
                                ddlGender1.SelectedValue = "2";
                            }
                            else
                            {
                                ddlGender1.SelectedValue = "-1";
                            }

                            if (string.IsNullOrEmpty(txtDOB1.Text))
                            {
                                txtAge1.Text = "";
                                ddlAgeGroup1.SelectedValue = "5";
                            }
                            else
                            {
                                DateTime dateOfBirth = DateTime.Parse(txtDOB1.Text);
                                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                                    dob = int.Parse(dateOfBirth.ToString("yyyyMMdd")),
                                    age = (now - dob) / 10000;

                                txtAge1.Text = age.ToString();
                                if (int.TryParse(txtAge1.Text, out age))
                                {
                                    if (age < 18)
                                    {
                                        ddlAgeGroup1.SelectedValue = "1";
                                    }
                                    else if (age >= 18 && age <= 25)
                                    {
                                        ddlAgeGroup1.SelectedValue = "2";
                                    }
                                    else if (age >= 26 && age <= 34)
                                    {
                                        ddlAgeGroup1.SelectedValue = "3";
                                    }
                                    else if (age >= 35 && age <= 40)
                                    {
                                        ddlAgeGroup1.SelectedValue = "4";
                                    }
                                    else if (age >= 41 && age <= 45)
                                    {
                                        ddlAgeGroup1.SelectedValue = "6";
                                    }
                                    else if (age >= 46 && age <= 50)
                                    {
                                        ddlAgeGroup1.SelectedValue = "7";
                                    }
                                    else if (age >= 51 && age <= 60)
                                    {
                                        ddlAgeGroup1.SelectedValue = "8";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup1.SelectedValue = "9";
                                    }
                                }
                            }
                            LinkButton1.Visible = true;
                        }
                        else if (Report.MemberNumberChanged.Equals("2"))
                        {
                            ReportIncidentCu.PlayerId2 = rdr["PlayerId"].ToString();
                            ReportIncidentCu.ViewPlayerId2 = rdr["PlayerId"].ToString();
                            txtFirstName2.Text = rdr["FirstName"].ToString();
                            txtLastName2.Text = rdr["LastName"].ToString();
                            txtAddress2.Text = rdr["Address"].ToString();
                            txtDOB2.Text = rdr["Birthday"].ToString();
                            txtMemberSince2.Text = rdr["MemberSince"].ToString();
                            txtContact2.Text = rdr["Contact"].ToString();

                            try
                            {
                                memberPhoto2 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto2, 0, memberPhoto2.Length);
                                imgMember2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto2 = null;
                                imgMember2.ImageUrl = "~/Images/no-image.png";
                            }

                            string Gender = rdr["Gender"].ToString();

                            if (Gender.Equals("M"))
                            {
                                ddlGender2.SelectedValue = "1";
                            }
                            else if (Gender.Equals("F"))
                            {
                                ddlGender2.SelectedValue = "2";
                            }
                            else
                            {
                                ddlGender2.SelectedValue = "-1";
                            }

                            if (string.IsNullOrEmpty(txtDOB2.Text))
                            {
                                txtAge2.Text = "";
                                ddlAgeGroup2.SelectedValue = "5";
                            }
                            else
                            {
                                DateTime dateOfBirth = DateTime.Parse(txtDOB2.Text);
                                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                                    dob = int.Parse(dateOfBirth.ToString("yyyyMMdd")),
                                    age = (now - dob) / 10000;

                                txtAge2.Text = age.ToString();
                                if (int.TryParse(txtAge2.Text, out age))
                                {
                                    if (age < 18)
                                    {
                                        ddlAgeGroup2.SelectedValue = "1";
                                    }
                                    else if (age >= 18 && age <= 25)
                                    {
                                        ddlAgeGroup2.SelectedValue = "2";
                                    }
                                    else if (age >= 26 && age <= 34)
                                    {
                                        ddlAgeGroup2.SelectedValue = "3";
                                    }
                                    else if (age >= 35 && age <= 40)
                                    {
                                        ddlAgeGroup2.SelectedValue = "4";
                                    }
                                    else if (age >= 41 && age <= 45)
                                    {
                                        ddlAgeGroup2.SelectedValue = "6";
                                    }
                                    else if (age >= 46 && age <= 50)
                                    {
                                        ddlAgeGroup2.SelectedValue = "7";
                                    }
                                    else if (age >= 51 && age <= 60)
                                    {
                                        ddlAgeGroup2.SelectedValue = "8";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup2.SelectedValue = "9";
                                    }
                                }
                            }
                            LinkButton2.Visible = true;
                        }
                        else if (Report.MemberNumberChanged.Equals("3"))
                        {
                            ReportIncidentCu.PlayerId3 = rdr["PlayerId"].ToString();
                            ReportIncidentCu.ViewPlayerId3 = rdr["PlayerId"].ToString();
                            txtFirstName3.Text = rdr["FirstName"].ToString();
                            txtLastName3.Text = rdr["LastName"].ToString();
                            txtAddress3.Text = rdr["Address"].ToString();
                            txtDOB3.Text = rdr["Birthday"].ToString();
                            txtMemberSince3.Text = rdr["MemberSince"].ToString();
                            txtContact3.Text = rdr["Contact"].ToString();

                            try
                            {
                                memberPhoto3 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto3, 0, memberPhoto3.Length);
                                imgMember3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto3 = null;
                                imgMember3.ImageUrl = "~/Images/no-image.png";
                            }

                            string Gender = rdr["Gender"].ToString();

                            if (Gender.Equals("M"))
                            {
                                ddlGender3.SelectedValue = "1";
                            }
                            else if (Gender.Equals("F"))
                            {
                                ddlGender3.SelectedValue = "2";
                            }
                            else
                            {
                                ddlGender3.SelectedValue = "-1";
                            }

                            if (string.IsNullOrEmpty(txtDOB3.Text))
                            {
                                txtAge3.Text = "";
                                ddlAgeGroup3.SelectedValue = "5";
                            }
                            else
                            {
                                DateTime dateOfBirth = DateTime.Parse(txtDOB3.Text);
                                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                                    dob = int.Parse(dateOfBirth.ToString("yyyyMMdd")),
                                    age = (now - dob) / 10000;

                                txtAge3.Text = age.ToString();
                                if (int.TryParse(txtAge3.Text, out age))
                                {
                                    if (age < 18)
                                    {
                                        ddlAgeGroup3.SelectedValue = "1";
                                    }
                                    else if (age >= 18 && age <= 25)
                                    {
                                        ddlAgeGroup3.SelectedValue = "2";
                                    }
                                    else if (age >= 26 && age <= 34)
                                    {
                                        ddlAgeGroup3.SelectedValue = "3";
                                    }
                                    else if (age >= 35 && age <= 40)
                                    {
                                        ddlAgeGroup3.SelectedValue = "4";
                                    }
                                    else if (age >= 41 && age <= 45)
                                    {
                                        ddlAgeGroup3.SelectedValue = "6";
                                    }
                                    else if (age >= 46 && age <= 50)
                                    {
                                        ddlAgeGroup3.SelectedValue = "7";
                                    }
                                    else if (age >= 51 && age <= 60)
                                    {
                                        ddlAgeGroup3.SelectedValue = "8";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup3.SelectedValue = "9";
                                    }
                                }
                            }
                            LinkButton3.Visible = true;
                        }
                        else if (Report.MemberNumberChanged.Equals("4"))
                        {
                            ReportIncidentCu.PlayerId4 = rdr["PlayerId"].ToString();
                            ReportIncidentCu.ViewPlayerId4 = rdr["PlayerId"].ToString();
                            txtFirstName4.Text = rdr["FirstName"].ToString();
                            txtLastName4.Text = rdr["LastName"].ToString();
                            txtAddress4.Text = rdr["Address"].ToString();
                            txtDOB4.Text = rdr["Birthday"].ToString();
                            txtMemberSince4.Text = rdr["MemberSince"].ToString();
                            txtContact4.Text = rdr["Contact"].ToString();

                            try
                            {
                                memberPhoto4 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto4, 0, memberPhoto4.Length);
                                imgMember4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto4 = null;
                                imgMember4.ImageUrl = "~/Images/no-image.png";
                            }

                            string Gender = rdr["Gender"].ToString();

                            if (Gender.Equals("M"))
                            {
                                ddlGender4.SelectedValue = "1";
                            }
                            else if (Gender.Equals("F"))
                            {
                                ddlGender4.SelectedValue = "2";
                            }
                            else
                            {
                                ddlGender4.SelectedValue = "-1";
                            }
                            if (string.IsNullOrEmpty(txtDOB4.Text))
                            {
                                txtAge4.Text = "";
                                ddlAgeGroup4.SelectedValue = "5";
                            }
                            else
                            {
                                DateTime dateOfBirth = DateTime.Parse(txtDOB4.Text);
                                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                                    dob = int.Parse(dateOfBirth.ToString("yyyyMMdd")),
                                    age = (now - dob) / 10000;

                                txtAge4.Text = age.ToString();
                                if (int.TryParse(txtAge4.Text, out age))
                                {
                                    if (age < 18)
                                    {
                                        ddlAgeGroup4.SelectedValue = "1";
                                    }
                                    else if (age >= 18 && age <= 25)
                                    {
                                        ddlAgeGroup4.SelectedValue = "2";
                                    }
                                    else if (age >= 26 && age <= 34)
                                    {
                                        ddlAgeGroup4.SelectedValue = "3";
                                    }
                                    else if (age >= 35 && age <= 40)
                                    {
                                        ddlAgeGroup4.SelectedValue = "4";
                                    }
                                    else if (age >= 41 && age <= 45)
                                    {
                                        ddlAgeGroup4.SelectedValue = "6";
                                    }
                                    else if (age >= 46 && age <= 50)
                                    {
                                        ddlAgeGroup4.SelectedValue = "7";
                                    }
                                    else if (age >= 51 && age <= 60)
                                    {
                                        ddlAgeGroup4.SelectedValue = "8";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup4.SelectedValue = "9";
                                    }
                                }
                            }
                            LinkButton4.Visible = true;
                        }
                        else if (Report.MemberNumberChanged.Equals("5"))
                        {
                            ReportIncidentCu.PlayerId5 = rdr["PlayerId"].ToString();
                            ReportIncidentCu.ViewPlayerId5 = rdr["PlayerId"].ToString();
                            txtFirstName5.Text = rdr["FirstName"].ToString();
                            txtLastName5.Text = rdr["LastName"].ToString();
                            txtAddress5.Text = rdr["Address"].ToString();
                            txtDOB5.Text = rdr["Birthday"].ToString();
                            txtMemberSince5.Text = rdr["MemberSince"].ToString();
                            txtContact5.Text = rdr["Contact"].ToString();

                            try
                            {
                                memberPhoto5 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto5, 0, memberPhoto5.Length);
                                imgMember5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto5 = null;
                                imgMember5.ImageUrl = "~/Images/no-image.png";
                            }

                            string Gender = rdr["Gender"].ToString();

                            if (Gender.Equals("M"))
                            {
                                ddlGender5.SelectedValue = "1";
                            }
                            else if (Gender.Equals("F"))
                            {
                                ddlGender5.SelectedValue = "2";
                            }
                            else
                            {
                                ddlGender5.SelectedValue = "-1";
                            }
                            if (string.IsNullOrEmpty(txtDOB5.Text))
                            {
                                txtAge5.Text = "";
                                ddlAgeGroup5.SelectedValue = "5";
                            }
                            else
                            {
                                DateTime dateOfBirth = DateTime.Parse(txtDOB5.Text);
                                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                                    dob = int.Parse(dateOfBirth.ToString("yyyyMMdd")),
                                    age = (now - dob) / 10000;

                                txtAge5.Text = age.ToString();
                                if (int.TryParse(txtAge5.Text, out age))
                                {
                                    if (age < 18)
                                    {
                                        ddlAgeGroup5.SelectedValue = "1";
                                    }
                                    else if (age >= 18 && age <= 25)
                                    {
                                        ddlAgeGroup5.SelectedValue = "2";
                                    }
                                    else if (age >= 26 && age <= 34)
                                    {
                                        ddlAgeGroup5.SelectedValue = "3";
                                    }
                                    else if (age >= 35 && age <= 40)
                                    {
                                        ddlAgeGroup5.SelectedValue = "4";
                                    }
                                    else if (age >= 41 && age <= 45)
                                    {
                                        ddlAgeGroup5.SelectedValue = "6";
                                    }
                                    else if (age >= 46 && age <= 50)
                                    {
                                        ddlAgeGroup5.SelectedValue = "7";
                                    }
                                    else if (age >= 51 && age <= 60)
                                    {
                                        ddlAgeGroup5.SelectedValue = "8";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup5.SelectedValue = "9";
                                    }
                                    else if (age >= 61)
                                    {
                                        ddlAgeGroup5.SelectedValue = "9";
                                    }
                                }
                            }
                            LinkButton5.Visible = true;
                        }
                    }
                    if (method.Equals("MemberPhoto"))
                    {
                        if (Report.MemberNumberChanged.Equals("1"))
                        {
                            ReportIncidentMr.PlayerId1 = rdr["PlayerId"].ToString();
                            ReportIncidentMr.ViewPlayerId1 = rdr["PlayerId"].ToString();

                            try
                            {
                                memberPhoto1 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto1, 0, memberPhoto1.Length);
                                imgMember1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto1 = null;
                                imgMember1.ImageUrl = "~/Images/no-image.png";
                            }
                        }
                        else if (Report.MemberNumberChanged.Equals("2"))
                        {
                            ReportIncidentMr.PlayerId2 = rdr["PlayerId"].ToString();
                            ReportIncidentMr.ViewPlayerId2 = rdr["PlayerId"].ToString();

                            try
                            {
                                memberPhoto2 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto2, 0, memberPhoto2.Length);
                                imgMember2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto2 = null;
                                imgMember2.ImageUrl = "~/Images/no-image.png";
                            }
                        }
                        else if (Report.MemberNumberChanged.Equals("3"))
                        {
                            ReportIncidentMr.PlayerId3 = rdr["PlayerId"].ToString();
                            ReportIncidentMr.ViewPlayerId3 = rdr["PlayerId"].ToString();

                            try
                            {
                                memberPhoto3 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto3, 0, memberPhoto3.Length);
                                imgMember3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto3 = null;
                                imgMember3.ImageUrl = "~/Images/no-image.png";
                            }
                        }
                        else if (Report.MemberNumberChanged.Equals("4"))
                        {
                            ReportIncidentMr.PlayerId4 = rdr["PlayerId"].ToString();
                            ReportIncidentMr.ViewPlayerId4 = rdr["PlayerId"].ToString();

                            try
                            {
                                memberPhoto4 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto4, 0, memberPhoto4.Length);
                                imgMember4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto4 = null;
                                imgMember4.ImageUrl = "~/Images/no-image.png";
                            }
                        }
                        else if (Report.MemberNumberChanged.Equals("5"))
                        {
                            ReportIncidentMr.PlayerId5 = rdr["PlayerId"].ToString();
                            ReportIncidentMr.ViewPlayerId5 = rdr["PlayerId"].ToString();

                            try
                            {
                                memberPhoto5 = (byte[])rdr["PlayerImage"];
                                // load image from database
                                string strBase64 = Convert.ToBase64String(memberPhoto5, 0, memberPhoto5.Length);
                                imgMember5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto5 = null;
                                imgMember5.ImageUrl = "~/Images/no-image.png";
                            }
                        }
                    }
                }
            }
            else // if Search Member doesn't have the member details
            {
                if (method.Equals("SearchMember"))
                {
                    if (Report.MemberNumberChanged.Equals("1"))
                    {
                        ReportIncidentCu.PlayerId1 = "";
                        ReportIncidentCu.ViewPlayerId1 = "";
                        txtFirstName1.Text = "";
                        txtLastName1.Text = "";
                        txtDOB1.Text = "";
                        txtAddress1.Text = "";
                        txtMemberSince1.Text = "";
                        txtContact1.Text = "";
                        txtAge1.Text = "";
                        ddlAgeGroup1.SelectedValue = "5";
                        imgMember1.ImageUrl = "~/Images/white-background.png";
                        LinkButton1.Visible = false;
                        alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                    }
                    else if (Report.MemberNumberChanged.Equals("2"))
                    {
                        ReportIncidentCu.PlayerId2 = "";
                        ReportIncidentCu.ViewPlayerId2 = "";
                        txtFirstName2.Text = "";
                        txtLastName2.Text = "";
                        txtDOB2.Text = "";
                        txtAddress2.Text = "";
                        txtMemberSince2.Text = "";
                        txtContact2.Text = "";
                        txtAge2.Text = "";
                        ddlAgeGroup2.SelectedValue = "5";
                        imgMember2.ImageUrl = "~/Images/white-background.png";
                        LinkButton2.Visible = false;
                        alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                    }
                    else if (Report.MemberNumberChanged.Equals("3"))
                    {
                        ReportIncidentCu.PlayerId3 = "";
                        ReportIncidentCu.ViewPlayerId3 = "";
                        txtFirstName3.Text = "";
                        txtLastName3.Text = "";
                        txtDOB3.Text = "";
                        txtAddress3.Text = "";
                        txtMemberSince3.Text = "";
                        txtContact3.Text = "";
                        txtAge3.Text = "";
                        ddlAgeGroup3.SelectedValue = "5";
                        imgMember3.ImageUrl = "~/Images/white-background.png";
                        LinkButton3.Visible = false;
                        alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                    }
                    else if (Report.MemberNumberChanged.Equals("4"))
                    {
                        ReportIncidentCu.PlayerId4 = "";
                        ReportIncidentCu.ViewPlayerId4 = "";
                        txtFirstName4.Text = "";
                        txtLastName4.Text = "";
                        txtDOB4.Text = "";
                        txtAddress4.Text = "";
                        txtMemberSince4.Text = "";
                        txtContact4.Text = "";
                        txtAge4.Text = "";
                        ddlAgeGroup4.SelectedValue = "5";
                        imgMember4.ImageUrl = "~/Images/white-background.png";
                        LinkButton4.Visible = false;
                        alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                    }
                    else if (Report.MemberNumberChanged.Equals("5"))
                    {
                        ReportIncidentCu.PlayerId5 = "";
                        ReportIncidentCu.ViewPlayerId5 = "";
                        txtFirstName5.Text = "";
                        txtLastName5.Text = "";
                        txtDOB5.Text = "";
                        txtAddress5.Text = "";
                        txtMemberSince5.Text = "";
                        txtContact5.Text = "";
                        txtAge5.Text = "";
                        ddlAgeGroup5.SelectedValue = "5";
                        imgMember5.ImageUrl = "~/Images/white-background.png";
                        LinkButton5.Visible = false;
                        alert.DisplayMessage("Member Not Found! Please enter another Member No.");
                    }
                }
            }
        }
        catch (Exception er)
        {
            alert.DisplayMessage(er.Message);
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }
            if (method.Contains("Member"))
            {
                if (con1 != null)
                {
                    con1.Close();
                }
            }
            else
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }

    // show/hide Visitor, Member, and Staff's fields for Person forms
    protected void ddlPartyType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType1.SelectedItem.Text == "Member")
        {
            staff11.Visible = false;
            staff11l.Visible = false;
            staff12.Visible = false;
            staff12l.Visible = false;
            witness1.Visible = true;
            witness1l.Visible = true;
            member11l.Visible = true;
            member11.Visible = true;
            member12l.Visible = true;
            member12.Visible = true;
            member13l.Visible = true;
            member14l.Visible = true;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName1.Enabled = false;
            txtLastName1.Enabled = false;
            txtAge1.Enabled = false;

            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtAddress1.Text = "";
            txtMemberSince1.Text = "";
            txtContact1.Text = "";
            txtMemberNo1.Text = "";
            txtDOB1.Text = "";
            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;
            imgMember1.ImageUrl = "~/Images/white-background.png";
        }
        else if (ddlPartyType1.SelectedItem.Text == "Visitor")
        {
            staff11.Visible = false;
            staff11l.Visible = false;
            staff12.Visible = false;
            staff12l.Visible = false;
            witness1.Visible = true;
            witness1l.Visible = true;
            member11l.Visible = false;
            member11.Visible = false;
            member12l.Visible = false;
            member12.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = true;
            visitor11.Visible = true;
            visitor12l.Visible = true;
            visitor12.Visible = true;
            visitor13l.Visible = true;
            visitor13.Visible = true;
            visitor14l.Visible = true;
            visitor14.Visible = true;
            visitor15l.Visible = true;
            visitor15.Visible = true;

            txtFirstName1.Enabled = true;
            txtLastName1.Enabled = true;
            txtAge1.Enabled = true;

            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtAddressv1.Text = "";
            txtContact1.Text = "";
            cbSignInSlip1.Text = "";
            txtSignInBy1.Text = "";
            txtDOBv1.Text = "";
            txtIDProof1.Text = "";
            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;
        }
        else if (ddlPartyType1.SelectedItem.Text == "Staff")
        {
            staff11.Visible = true;
            staff11l.Visible = true;
            staff12.Visible = true;
            staff12l.Visible = true;
            witness1.Visible = true;
            witness1l.Visible = true;
            member11l.Visible = false;
            member11.Visible = false;
            member12l.Visible = false;
            member12.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName1.Enabled = true;
            txtLastName1.Enabled = true;
            txtAge1.Enabled = true;

            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtStaffEmpNo1.Text = "";
            txtStaffAddress1.Text = "";
            txtContact1.Text = "";
            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;
        }
        else if (ddlPartyType1.SelectedItem.Text != "Select Type")
        {
            witness1.Visible = true;
            witness1l.Visible = true;
            staff11.Visible = false;
            staff11l.Visible = false;
            staff12.Visible = false;
            staff12l.Visible = false;

            member11l.Visible = false;
            member11.Visible = false;
            member12l.Visible = false;
            member12.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName1.Enabled = true;
            txtLastName1.Enabled = true;
            txtAge1.Enabled = true;

            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtContact1.Text = "";
            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;
        }
        else
        {
            staff11.Visible = false;
            staff11l.Visible = false;
            staff12.Visible = false;
            staff12l.Visible = false;
            witness1.Visible = false;
            witness1l.Visible = false;
            member11l.Visible = false;
            member11.Visible = false;
            member12l.Visible = false;
            member12.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;

            visitor11l.Visible = false;
            visitor11.Visible = false;
            visitor12l.Visible = false;
            visitor12.Visible = false;
            visitor13l.Visible = false;
            visitor13.Visible = false;
            visitor14l.Visible = false;
            visitor14.Visible = false;
            visitor15l.Visible = false;
            visitor15.Visible = false;

            txtFirstName1.Enabled = true;
            txtLastName1.Enabled = true;
            txtAge1.Enabled = true;

            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtContact1.Text = "";
            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;
        }
    }
    protected void ddlPartyType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType2.SelectedItem.Text == "Member")
        {
            staff21.Visible = false;
            staff21l.Visible = false;
            staff22.Visible = false;
            staff22l.Visible = false;
            witness2.Visible = true;
            witness2l.Visible = true;
            member21l.Visible = true;
            member21.Visible = true;
            member22l.Visible = true;
            member22.Visible = true;
            member23l.Visible = true;
            member24l.Visible = true;

            visitor21l.Visible = false;
            visitor21.Visible = false;
            visitor22l.Visible = false;
            visitor22.Visible = false;
            visitor23l.Visible = false;
            visitor23.Visible = false;
            visitor24l.Visible = false;
            visitor24.Visible = false;
            visitor25l.Visible = false;
            visitor25.Visible = false;

            txtFirstName2.Enabled = false;
            txtLastName2.Enabled = false;
            txtAge2.Enabled = false;

            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtAddress2.Text = "";
            txtMemberSince2.Text = "";
            txtContact2.Text = "";
            txtMemberNo2.Text = "";
            txtDOB2.Text = "";
            txtAge2.Text = "";
            ddlAgeGroup2.SelectedIndex = -1;
            imgMember2.ImageUrl = "~/Images/white-background.png";
        }
        else if (ddlPartyType2.SelectedItem.Text == "Visitor")
        {
            staff21.Visible = false;
            staff21l.Visible = false;
            staff22.Visible = false;
            staff22l.Visible = false;
            witness2.Visible = true;
            witness2l.Visible = true;
            member21l.Visible = false;
            member21.Visible = false;
            member22l.Visible = false;
            member22.Visible = false;
            member23l.Visible = false;
            member24l.Visible = false;

            visitor21l.Visible = true;
            visitor21.Visible = true;
            visitor22l.Visible = true;
            visitor22.Visible = true;
            visitor23l.Visible = true;
            visitor23.Visible = true;
            visitor24l.Visible = true;
            visitor24.Visible = true;
            visitor25l.Visible = true;
            visitor25.Visible = true;

            txtFirstName2.Enabled = true;
            txtLastName2.Enabled = true;
            txtAge2.Enabled = true;

            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtAddressv2.Text = "";
            txtContact2.Text = "";
            cbSignInSlip2.Text = "";
            txtSignInBy2.Text = "";
            txtDOBv2.Text = "";
            txtIDProof2.Text = "";
            txtAge2.Text = "";
            ddlAgeGroup2.SelectedIndex = -1;
        }
        else if (ddlPartyType2.SelectedItem.Text == "Staff")
        {
            staff21.Visible = true;
            staff21l.Visible = true;
            staff22.Visible = true;
            staff22l.Visible = true;
            witness2.Visible = true;
            witness2l.Visible = true;
            member21l.Visible = false;
            member21.Visible = false;
            member22l.Visible = false;
            member22.Visible = false;
            member23l.Visible = false;
            member24l.Visible = false;

            visitor21l.Visible = false;
            visitor21.Visible = false;
            visitor22l.Visible = false;
            visitor22.Visible = false;
            visitor23l.Visible = false;
            visitor23.Visible = false;
            visitor24l.Visible = false;
            visitor24.Visible = false;
            visitor25l.Visible = false;
            visitor25.Visible = false;

            txtFirstName2.Enabled = true;
            txtLastName2.Enabled = true;
            txtAge2.Enabled = true;

            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtStaffEmpNo2.Text = "";
            txtStaffAddress2.Text = "";
            txtContact2.Text = "";
            txtAge2.Text = "";
            ddlAgeGroup2.SelectedIndex = -1;
        }
        else if (ddlPartyType2.SelectedItem.Text != "Select Type")
        {
            witness2.Visible = true;
            witness2l.Visible = true;
            staff21.Visible = false;
            staff21l.Visible = false;
            staff22.Visible = false;
            staff22l.Visible = false;

            member21l.Visible = false;
            member21.Visible = false;
            member22l.Visible = false;
            member22.Visible = false;
            member23l.Visible = false;
            member24l.Visible = false;

            visitor21l.Visible = false;
            visitor21.Visible = false;
            visitor22l.Visible = false;
            visitor22.Visible = false;
            visitor23l.Visible = false;
            visitor23.Visible = false;
            visitor24l.Visible = false;
            visitor24.Visible = false;
            visitor25l.Visible = false;
            visitor25.Visible = false;

            txtFirstName2.Enabled = true;
            txtLastName2.Enabled = true;
            txtAge2.Enabled = true;

            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtContact2.Text = "";
            txtAge2.Text = "";
            ddlAgeGroup2.SelectedIndex = -1;
        }
        else
        {
            staff21.Visible = false;
            staff21l.Visible = false;
            staff22.Visible = false;
            staff22l.Visible = false;
            witness2.Visible = false;
            witness2l.Visible = false;
            member21l.Visible = false;
            member21.Visible = false;
            member22l.Visible = false;
            member22.Visible = false;
            member23l.Visible = false;
            member24l.Visible = false;

            visitor21l.Visible = false;
            visitor21.Visible = false;
            visitor22l.Visible = false;
            visitor22.Visible = false;
            visitor23l.Visible = false;
            visitor23.Visible = false;
            visitor24l.Visible = false;
            visitor24.Visible = false;
            visitor25l.Visible = false;
            visitor25.Visible = false;

            txtFirstName2.Enabled = true;
            txtLastName2.Enabled = true;
            txtAge2.Enabled = true;

            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtContact2.Text = "";
            txtAge2.Text = "";
            ddlAgeGroup2.SelectedIndex = -1;
        }
    }
    protected void ddlPartyType3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType3.SelectedItem.Text == "Member")
        {
            staff31.Visible = false;
            staff31l.Visible = false;
            staff32.Visible = false;
            staff32l.Visible = false;
            witness3.Visible = true;
            witness3l.Visible = true;
            member31l.Visible = true;
            member31.Visible = true;
            member32l.Visible = true;
            member32.Visible = true;
            member33l.Visible = true;
            member34l.Visible = true;

            visitor31l.Visible = false;
            visitor31.Visible = false;
            visitor32l.Visible = false;
            visitor32.Visible = false;
            visitor33l.Visible = false;
            visitor33.Visible = false;
            visitor34l.Visible = false;
            visitor34.Visible = false;
            visitor35l.Visible = false;
            visitor35.Visible = false;

            txtFirstName3.Enabled = false;
            txtLastName3.Enabled = false;
            txtAge3.Enabled = false;

            txtFirstName3.Text = "";
            txtLastName3.Text = "";
            txtAddress3.Text = "";
            txtMemberSince3.Text = "";
            txtContact3.Text = "";
            txtMemberNo3.Text = "";
            txtDOB3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;
            imgMember3.ImageUrl = "~/Images/white-background.png";
        }
        else if (ddlPartyType3.SelectedItem.Text == "Visitor")
        {
            staff31.Visible = false;
            staff31l.Visible = false;
            staff32.Visible = false;
            staff32l.Visible = false;
            witness3.Visible = true;
            witness3l.Visible = true;
            member31l.Visible = false;
            member31.Visible = false;
            member32l.Visible = false;
            member32.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;

            visitor31l.Visible = true;
            visitor31.Visible = true;
            visitor32l.Visible = true;
            visitor32.Visible = true;
            visitor33l.Visible = true;
            visitor33.Visible = true;
            visitor34l.Visible = true;
            visitor34.Visible = true;
            visitor35l.Visible = true;
            visitor35.Visible = true;

            txtFirstName3.Enabled = true;
            txtLastName3.Enabled = true;
            txtAge3.Enabled = true;

            txtFirstName3.Text = "";
            txtLastName3.Text = "";
            txtAddressv3.Text = "";
            txtContact3.Text = "";
            cbSignInSlip3.Text = "";
            txtSignInBy3.Text = "";
            txtDOBv3.Text = "";
            txtIDProof3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;
        }
        else if (ddlPartyType3.SelectedItem.Text == "Staff")
        {
            staff31.Visible = true;
            staff31l.Visible = true;
            staff32.Visible = true;
            staff32l.Visible = true;
            witness3.Visible = true;
            witness3l.Visible = true;
            member31l.Visible = false;
            member31.Visible = false;
            member32l.Visible = false;
            member32.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;

            visitor31l.Visible = false;
            visitor31.Visible = false;
            visitor32l.Visible = false;
            visitor32.Visible = false;
            visitor33l.Visible = false;
            visitor33.Visible = false;
            visitor34l.Visible = false;
            visitor34.Visible = false;
            visitor35l.Visible = false;
            visitor35.Visible = false;

            txtFirstName3.Enabled = true;
            txtLastName3.Enabled = true;
            txtAge3.Enabled = true;

            txtFirstName3.Text = "";
            txtLastName3.Text = "";
            txtContact3.Text = "";
            txtStaffEmpNo3.Text = "";
            txtStaffAddress3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;
        }
        else if (ddlPartyType3.SelectedItem.Text != "Select Type")
        {
            witness3.Visible = true;
            witness3l.Visible = true;
            staff31.Visible = false;
            staff31l.Visible = false;
            staff32.Visible = false;
            staff32l.Visible = false;

            member31l.Visible = false;
            member31.Visible = false;
            member32l.Visible = false;
            member32.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;

            visitor31l.Visible = false;
            visitor31.Visible = false;
            visitor32l.Visible = false;
            visitor32.Visible = false;
            visitor33l.Visible = false;
            visitor33.Visible = false;
            visitor34l.Visible = false;
            visitor34.Visible = false;
            visitor35l.Visible = false;
            visitor35.Visible = false;

            txtFirstName3.Enabled = true;
            txtLastName3.Enabled = true;
            txtAge3.Enabled = true;

            txtFirstName3.Text = "";
            txtLastName3.Text = "";
            txtContact3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;
        }
        else
        {
            staff31.Visible = false;
            staff31l.Visible = false;
            staff32.Visible = false;
            staff32l.Visible = false;
            witness3.Visible = false;
            witness3l.Visible = false;
            member31l.Visible = false;
            member31.Visible = false;
            member32l.Visible = false;
            member32.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;

            visitor31l.Visible = false;
            visitor31.Visible = false;
            visitor32l.Visible = false;
            visitor32.Visible = false;
            visitor33l.Visible = false;
            visitor33.Visible = false;
            visitor34l.Visible = false;
            visitor34.Visible = false;
            visitor35l.Visible = false;
            visitor35.Visible = false;

            txtFirstName3.Enabled = true;
            txtLastName3.Enabled = true;
            txtAge3.Enabled = true;

            txtFirstName3.Text = "";
            txtLastName3.Text = "";
            txtContact3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;
        }
    }
    protected void ddlPartyType4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType4.SelectedItem.Text == "Member")
        {
            staff41.Visible = false;
            staff41l.Visible = false;
            staff42.Visible = false;
            staff42l.Visible = false;
            witness4.Visible = true;
            witness4l.Visible = true;
            member41l.Visible = true;
            member41.Visible = true;
            member42l.Visible = true;
            member42.Visible = true;
            member43l.Visible = true;
            member44l.Visible = true;

            visitor41l.Visible = false;
            visitor41.Visible = false;
            visitor42l.Visible = false;
            visitor42.Visible = false;
            visitor43l.Visible = false;
            visitor43.Visible = false;
            visitor44l.Visible = false;
            visitor44.Visible = false;
            visitor45l.Visible = false;
            visitor45.Visible = false;

            txtFirstName4.Enabled = false;
            txtLastName4.Enabled = false;
            txtAge4.Enabled = false;

            txtFirstName4.Text = "";
            txtLastName4.Text = "";
            txtAddress4.Text = "";
            txtMemberSince4.Text = "";
            txtContact4.Text = "";
            txtMemberNo4.Text = "";
            txtDOB4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;
            imgMember4.ImageUrl = "~/Images/white-background.png";
        }
        else if (ddlPartyType4.SelectedItem.Text == "Visitor")
        {
            staff41.Visible = false;
            staff41l.Visible = false;
            staff42.Visible = false;
            staff42l.Visible = false;
            witness4.Visible = true;
            witness4l.Visible = true;
            member41l.Visible = false;
            member41.Visible = false;
            member42l.Visible = false;
            member42.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;

            visitor41l.Visible = true;
            visitor41.Visible = true;
            visitor42l.Visible = true;
            visitor42.Visible = true;
            visitor43l.Visible = true;
            visitor43.Visible = true;
            visitor44l.Visible = true;
            visitor44.Visible = true;
            visitor45l.Visible = true;
            visitor45.Visible = true;

            txtFirstName4.Enabled = true;
            txtLastName4.Enabled = true;
            txtAge4.Enabled = true;

            txtFirstName4.Text = "";
            txtLastName4.Text = "";
            txtAddressv4.Text = "";
            txtContact4.Text = "";
            cbSignInSlip4.Text = "";
            txtSignInBy4.Text = "";
            txtDOBv4.Text = "";
            txtIDProof4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;
        }
        else if (ddlPartyType4.SelectedItem.Text == "Staff")
        {
            staff41.Visible = true;
            staff41l.Visible = true;
            staff42.Visible = true;
            staff42l.Visible = true;
            witness4.Visible = true;
            witness4l.Visible = true;
            member41l.Visible = false;
            member41.Visible = false;
            member42l.Visible = false;
            member42.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;

            visitor41l.Visible = false;
            visitor41.Visible = false;
            visitor42l.Visible = false;
            visitor42.Visible = false;
            visitor43l.Visible = false;
            visitor43.Visible = false;
            visitor44l.Visible = false;
            visitor44.Visible = false;
            visitor45l.Visible = false;
            visitor45.Visible = false;

            txtFirstName4.Enabled = true;
            txtLastName4.Enabled = true;
            txtAge4.Enabled = true;

            txtFirstName4.Text = "";
            txtLastName4.Text = "";
            txtContact4.Text = "";
            txtStaffEmpNo4.Text = "";
            txtStaffAddress4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;
        }
        else if (ddlPartyType4.SelectedItem.Text != "Select Type")
        {
            witness4.Visible = true;
            witness4l.Visible = true;
            staff41.Visible = false;
            staff41l.Visible = false;
            staff42.Visible = false;
            staff42l.Visible = false;

            member41l.Visible = false;
            member41.Visible = false;
            member42l.Visible = false;
            member42.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;

            visitor41l.Visible = false;
            visitor41.Visible = false;
            visitor42l.Visible = false;
            visitor42.Visible = false;
            visitor43l.Visible = false;
            visitor43.Visible = false;
            visitor44l.Visible = false;
            visitor44.Visible = false;
            visitor45l.Visible = false;
            visitor45.Visible = false;

            txtFirstName4.Enabled = true;
            txtLastName4.Enabled = true;
            txtAge4.Enabled = true;

            txtFirstName4.Text = "";
            txtLastName4.Text = "";
            txtContact4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;
        }
        else
        {
            staff41.Visible = false;
            staff41l.Visible = false;
            staff42.Visible = false;
            staff42l.Visible = false;
            witness4.Visible = false;
            witness4l.Visible = false;
            member41l.Visible = false;
            member41.Visible = false;
            member42l.Visible = false;
            member42.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;

            visitor41l.Visible = false;
            visitor41.Visible = false;
            visitor42l.Visible = false;
            visitor42.Visible = false;
            visitor43l.Visible = false;
            visitor43.Visible = false;
            visitor44l.Visible = false;
            visitor44.Visible = false;
            visitor45l.Visible = false;
            visitor45.Visible = false;

            txtFirstName4.Enabled = true;
            txtLastName4.Enabled = true;
            txtAge4.Enabled = true;

            txtFirstName4.Text = "";
            txtLastName4.Text = "";
            txtContact4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;
        }
    }
    protected void ddlPartyType5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartyType5.SelectedItem.Text == "Member")
        {
            staff51.Visible = false;
            staff51l.Visible = false;
            staff52.Visible = false;
            staff52l.Visible = false;
            witness5.Visible = true;
            witness5l.Visible = true;
            member51l.Visible = true;
            member51.Visible = true;
            member52l.Visible = true;
            member52.Visible = true;
            member53l.Visible = true;
            member54l.Visible = true;

            visitor51l.Visible = false;
            visitor51.Visible = false;
            visitor52l.Visible = false;
            visitor52.Visible = false;
            visitor53l.Visible = false;
            visitor53.Visible = false;
            visitor54l.Visible = false;
            visitor54.Visible = false;
            visitor55l.Visible = false;
            visitor55.Visible = false;

            txtFirstName5.Enabled = false;
            txtLastName5.Enabled = false;
            txtAge5.Enabled = false;

            txtFirstName5.Text = "";
            txtLastName5.Text = "";
            txtAddress5.Text = "";
            txtMemberSince5.Text = "";
            txtContact5.Text = "";
            txtMemberNo5.Text = "";
            txtDOB5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;
            imgMember5.ImageUrl = "~/Images/white-background.png";
        }
        else if (ddlPartyType5.SelectedItem.Text == "Visitor")
        {
            staff51.Visible = false;
            staff51l.Visible = false;
            staff52.Visible = false;
            staff52l.Visible = false;
            witness5.Visible = true;
            witness5l.Visible = true;
            member51l.Visible = false;
            member51.Visible = false;
            member52l.Visible = false;
            member52.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;

            visitor51l.Visible = true;
            visitor51.Visible = true;
            visitor52l.Visible = true;
            visitor52.Visible = true;
            visitor53l.Visible = true;
            visitor53.Visible = true;
            visitor54l.Visible = true;
            visitor54.Visible = true;
            visitor55l.Visible = true;
            visitor55.Visible = true;

            txtFirstName5.Enabled = true;
            txtLastName5.Enabled = true;
            txtAge5.Enabled = true;

            txtFirstName5.Text = "";
            txtLastName5.Text = "";
            txtAddressv5.Text = "";
            txtContact5.Text = "";
            cbSignInSlip5.Text = "";
            txtSignInBy5.Text = "";
            txtDOBv5.Text = "";
            txtIDProof5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;
        }
        else if (ddlPartyType5.SelectedItem.Text == "Staff")
        {
            staff51.Visible = true;
            staff51l.Visible = true;
            staff52.Visible = true;
            staff52l.Visible = true;
            witness5.Visible = true;
            witness5l.Visible = true;
            member51l.Visible = false;
            member51.Visible = false;
            member52l.Visible = false;
            member52.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;

            visitor51l.Visible = false;
            visitor51.Visible = false;
            visitor52l.Visible = false;
            visitor52.Visible = false;
            visitor53l.Visible = false;
            visitor53.Visible = false;
            visitor54l.Visible = false;
            visitor54.Visible = false;
            visitor55l.Visible = false;
            visitor55.Visible = false;

            txtFirstName5.Enabled = true;
            txtLastName5.Enabled = true;
            txtAge5.Enabled = true;

            txtFirstName5.Text = "";
            txtLastName5.Text = "";
            txtContact5.Text = "";
            txtStaffEmpNo5.Text = "";
            txtStaffAddress5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;
        }
        else if (ddlPartyType5.SelectedItem.Text != "Select Type")
        {
            witness5.Visible = true;
            witness5l.Visible = true;
            staff51.Visible = false;
            staff51l.Visible = false;
            staff52.Visible = false;
            staff52l.Visible = false;

            member51l.Visible = false;
            member51.Visible = false;
            member52l.Visible = false;
            member52.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;

            visitor51l.Visible = false;
            visitor51.Visible = false;
            visitor52l.Visible = false;
            visitor52.Visible = false;
            visitor53l.Visible = false;
            visitor53.Visible = false;
            visitor54l.Visible = false;
            visitor54.Visible = false;
            visitor55l.Visible = false;
            visitor55.Visible = false;

            txtFirstName5.Enabled = true;
            txtLastName5.Enabled = true;
            txtAge5.Enabled = true;

            txtFirstName5.Text = "";
            txtLastName5.Text = "";
            txtContact5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;
        }
        else
        {
            staff51.Visible = false;
            staff51l.Visible = false;
            staff52.Visible = false;
            staff52l.Visible = false;
            witness5.Visible = false;
            witness5l.Visible = false;
            member51l.Visible = false;
            member51.Visible = false;
            member52l.Visible = false;
            member52.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;

            visitor51l.Visible = false;
            visitor51.Visible = false;
            visitor52l.Visible = false;
            visitor52.Visible = false;
            visitor53l.Visible = false;
            visitor53.Visible = false;
            visitor54l.Visible = false;
            visitor54.Visible = false;
            visitor55l.Visible = false;
            visitor55.Visible = false;

            txtFirstName5.Enabled = true;
            txtLastName5.Enabled = true;
            txtAge5.Enabled = true;

            txtFirstName5.Text = "";
            txtLastName5.Text = "";
            txtContact5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;
        }
    }

    // checkbox to show canvas for Human Body Form - be able add Human Body Form for Person
    protected void cbAddPerson1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAddPerson1.Checked == true)
        {
            // show the Add Person no. 2 button
            tblAddPerson2.Visible = true;
            // show the added Person form
            acpPerson1.Visible = true;
            acdPerson.SelectedIndex = 0;
            txtFirstName1.Focus();
            noOfPerson.Visible = true;
            lblNoOfPerson.Text = "1";
            noOfPerson1.Visible = true;
        }
        else
        {
            // hide the Add Person no. 2 button
            tblAddPerson2.Visible = false;
            tblAddPerson3.Visible = false;
            tblAddPerson4.Visible = false;
            tblAddPerson5.Visible = false;
            // hide the added Person form
            acpPerson1.Visible = false;
            acpPerson2.Visible = false;
            acpPerson3.Visible = false;
            acpPerson4.Visible = false;
            acpPerson5.Visible = false;
            noOfPerson.Visible = false;
            lblNoOfPerson.Text = "0";
            noOfPerson1.Visible = false;
        }
    }
    protected void btnAddPerson2_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 2 button
        tblAddPerson2.Visible = false;
        // show the added Person form
        tblAddPerson3.Visible = true;
        acpPerson2.Visible = true;
        acdPerson.SelectedIndex = 1;

        // hide the other fields (member, visitor, staff)
        staff21.Visible = false;
        staff21l.Visible = false;
        staff22.Visible = false;
        staff22l.Visible = false;
        witness2.Visible = false;
        witness2l.Visible = false;
        member21l.Visible = false;
        member21.Visible = false;
        member22l.Visible = false;
        member22.Visible = false;
        member23l.Visible = false;
        member24l.Visible = false;

        visitor21l.Visible = false;
        visitor21.Visible = false;
        visitor22l.Visible = false;
        visitor22.Visible = false;
        visitor23l.Visible = false;
        visitor23.Visible = false;
        visitor24l.Visible = false;
        visitor24.Visible = false;
        visitor25l.Visible = false;
        visitor25.Visible = false;

        txtFirstName2.Enabled = true;
        txtLastName2.Enabled = true;

        txtFirstName2.Focus();
        lblNoOfPerson.Text = "2";
    }
    protected void btnAddPerson3_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 3 button
        tblAddPerson3.Visible = false;
        // show the added Person form
        tblPerson3.Visible = true;
        tblAddPerson4.Visible = true;
        acpPerson3.Visible = true;
        acdPerson.SelectedIndex = 2;

        // hide the other fields (member, visitor, staff)
        staff31.Visible = false;
        staff31l.Visible = false;
        staff32.Visible = false;
        staff32l.Visible = false;
        witness3.Visible = false;
        witness3l.Visible = false;
        member31l.Visible = false;
        member31.Visible = false;
        member32l.Visible = false;
        member32.Visible = false;
        member33l.Visible = false;
        member34l.Visible = false;

        visitor31l.Visible = false;
        visitor31.Visible = false;
        visitor32l.Visible = false;
        visitor32.Visible = false;
        visitor33l.Visible = false;
        visitor33.Visible = false;
        visitor34l.Visible = false;
        visitor34.Visible = false;
        visitor35l.Visible = false;
        visitor35.Visible = false;

        txtFirstName3.Enabled = true;
        txtLastName3.Enabled = true;

        txtFirstName3.Focus();
        lblNoOfPerson.Text = "3";
    }
    protected void btnAddPerson4_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 4 button
        tblAddPerson4.Visible = false;
        // show the added Person form
        tblAddPerson5.Visible = true;
        acpPerson4.Visible = true;
        acdPerson.SelectedIndex = 3;

        // hide the other fields (member, visitor, staff)
        staff41.Visible = false;
        staff41l.Visible = false;
        staff42.Visible = false;
        staff42l.Visible = false;
        witness4.Visible = false;
        witness4l.Visible = false;
        member41l.Visible = false;
        member41.Visible = false;
        member42l.Visible = false;
        member42.Visible = false;
        member43l.Visible = false;
        member44l.Visible = false;

        visitor41l.Visible = false;
        visitor41.Visible = false;
        visitor42l.Visible = false;
        visitor42.Visible = false;
        visitor43l.Visible = false;
        visitor43.Visible = false;
        visitor44l.Visible = false;
        visitor44.Visible = false;
        visitor45l.Visible = false;
        visitor45.Visible = false;

        txtFirstName4.Enabled = true;
        txtLastName4.Enabled = true;

        txtFirstName4.Focus();
        lblNoOfPerson.Text = "4";
    }
    protected void btnAddPerson5_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 5 button
        tblAddPerson5.Visible = false;
        // show the added Person form
        tblDelPerson5.Visible = true;
        acpPerson5.Visible = true;
        acdPerson.SelectedIndex = 4;

        // hide the other fields (member, visitor, staff)
        staff51.Visible = false;
        staff51l.Visible = false;
        staff52.Visible = false;
        staff52l.Visible = false;
        witness5.Visible = false;
        witness5l.Visible = false;
        member51l.Visible = false;
        member51.Visible = false;
        member52l.Visible = false;
        member52.Visible = false;
        member53l.Visible = false;
        member54l.Visible = false;

        visitor51l.Visible = false;
        visitor51.Visible = false;
        visitor52l.Visible = false;
        visitor52.Visible = false;
        visitor53l.Visible = false;
        visitor53.Visible = false;
        visitor54l.Visible = false;
        visitor54.Visible = false;
        visitor55l.Visible = false;
        visitor55.Visible = false;

        txtFirstName5.Enabled = true;
        txtLastName5.Enabled = true;

        txtFirstName5.Focus();
        lblNoOfPerson.Text = "5";
    }

    // delete/hide Person form
    protected void btnDelPerson2_Click(object sender, EventArgs e)
    {
        txtFirstName2.Text = "";
        txtLastName2.Text = "";
        txtAlias2.Text = "";
        ddlPartyType2.SelectedValue = "-1";
        cbWitness2.Checked = false;
        txtMemberNo2.Text = "";
        txtMemberSince2.Text = "";
        txtContact2.Text = "";
        txtDOB2.Text = "";
        txtDOBv2.Text = "";
        cbSignInSlip2.Checked = false;
        cbCardHeld2.Checked = false;
        txtSignInBy2.Text = "";
        txtPDate2.Text = "";
        ddlPTimeH2.SelectedValue = "-1";
        ddlPTimeM2.SelectedValue = "-1";
        //ddlPTimeTC2.SelectedValue = "-1";
        txtAge2.Text = "";
        //txtWeight2.Text = "";
        ddlWeight2.SelectedValue = "";
        txtHeight2.Text = "";
        ddlGender2.SelectedValue = "-1";
        txtDistFeatures2.Text = "";
        txtInjuryDesc2.Text = "";
        txtInjuryCause2.Text = "";
        txtIncidentComm2.Text = "";
        acpPerson2.Visible = false;
        tblAddPerson2.Visible = true;
        tblAddPerson3.Visible = false;
        acdPerson.SelectedIndex = 0;
        txtFirstName1.Focus();
        lblNoOfPerson.Text = "1";
    }
    protected void btnDelPerson3_Click(object sender, EventArgs e)
    {
        txtFirstName3.Text = "";
        txtLastName3.Text = "";
        txtAlias3.Text = "";
        ddlPartyType3.SelectedValue = "-1";
        cbWitness3.Checked = false;
        txtMemberNo3.Text = "";
        txtMemberSince3.Text = "";
        txtContact3.Text = "";
        txtDOB3.Text = "";
        txtDOBv3.Text = "";
        cbSignInSlip3.Checked = false;
        cbCardHeld3.Checked = false;
        txtSignInBy3.Text = "";
        txtPDate3.Text = "";
        ddlPTimeH3.SelectedValue = "-1";
        ddlPTimeM3.SelectedValue = "-1";
        //ddlPTimeTC3.SelectedValue = "-1";
        txtAge3.Text = "";
        //txtWeight3.Text = "";
        ddlWeight3.SelectedValue = "";
        txtHeight3.Text = "";
        ddlGender3.SelectedValue = "-1";
        txtDistFeatures3.Text = "";
        txtInjuryDesc3.Text = "";
        txtInjuryCause3.Text = "";
        txtIncidentComm3.Text = "";
        acpPerson3.Visible = false;
        tblAddPerson3.Visible = true;
        tblAddPerson4.Visible = false;
        acdPerson.SelectedIndex = 1;
        txtFirstName2.Focus();
        lblNoOfPerson.Text = "2";
    }
    protected void btnDelPerson4_Click(object sender, EventArgs e)
    {
        txtFirstName4.Text = "";
        txtLastName4.Text = "";
        txtAlias4.Text = "";
        ddlPartyType4.SelectedValue = "-1";
        cbWitness4.Checked = false;
        txtMemberNo4.Text = "";
        txtMemberSince4.Text = "";
        txtContact4.Text = "";
        txtDOB4.Text = "";
        txtDOBv4.Text = "";
        cbSignInSlip4.Checked = false;
        cbCardHeld4.Checked = false;
        txtSignInBy4.Text = "";
        txtPDate4.Text = "";
        ddlPTimeH4.SelectedValue = "-1";
        ddlPTimeM4.SelectedValue = "-1";
        //ddlPTimeTC4.SelectedValue = "-1";
        txtAge4.Text = "";
        //txtWeight4.Text = "";
        ddlWeight4.SelectedValue = "";
        txtHeight4.Text = "";
        ddlGender4.SelectedValue = "-1";
        txtDistFeatures4.Text = "";
        txtInjuryDesc4.Text = "";
        txtInjuryCause4.Text = "";
        txtIncidentComm4.Text = "";
        acpPerson4.Visible = false;
        tblAddPerson4.Visible = true;
        tblAddPerson5.Visible = false;
        acdPerson.SelectedIndex = 2;
        txtFirstName3.Focus();
        lblNoOfPerson.Text = "3";
    }
    protected void btnDelPerson5_Click(object sender, EventArgs e)
    {
        txtFirstName5.Text = "";
        txtLastName5.Text = "";
        txtAlias5.Text = "";
        ddlPartyType5.SelectedValue = "-1";
        cbWitness5.Checked = false;
        txtMemberNo5.Text = "";
        txtMemberSince5.Text = "";
        txtContact5.Text = "";
        txtDOB5.Text = "";
        txtDOBv5.Text = "";
        cbSignInSlip5.Checked = false;
        cbCardHeld5.Checked = false;
        txtSignInBy5.Text = "";
        txtPDate5.Text = "";
        ddlPTimeH5.SelectedValue = "-1";
        ddlPTimeM5.SelectedValue = "-1";
        //ddlPTimeTC5.SelectedValue = "-1";
        txtAge5.Text = "";
        //txtWeight5.Text = "";
        ddlWeight5.SelectedValue = "";
        txtHeight5.Text = "";
        ddlGender5.SelectedValue = "-1";
        txtDistFeatures5.Text = "";
        txtInjuryDesc5.Text = "";
        txtInjuryCause5.Text = "";
        txtIncidentComm5.Text = "";
        acpPerson5.Visible = false;
        tblAddPerson5.Visible = true;
        tblDelPerson5.Visible = false;
        acdPerson.SelectedIndex = 3;
        txtFirstName4.Focus();
        lblNoOfPerson.Text = "4";
    }

    // display proper Age Group on Text Change
    protected void txtAge1_TextChanged(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(txtAge1.Text, out value))
        {
            if (value < 18)
            {
                ddlAgeGroup1.SelectedValue = "1";
            }
            else if (value >= 18 && value <= 25)
            {
                ddlAgeGroup1.SelectedValue = "2";
            }
            else if (value >= 26 && value <= 34)
            {
                ddlAgeGroup1.SelectedValue = "3";
            }
            else if (value >= 35 && value <= 40)
            {
                ddlAgeGroup1.SelectedValue = "4";
            }
            else if (value >= 41 && value <= 45)
            {
                ddlAgeGroup1.SelectedValue = "6";
            }
            else if (value >= 46 && value <= 50)
            {
                ddlAgeGroup1.SelectedValue = "7";
            }
            else if (value >= 51 && value <= 60)
            {
                ddlAgeGroup1.SelectedValue = "8";
            }
            else if (value >= 61)
            {
                ddlAgeGroup1.SelectedValue = "9";
            }
        }
        else
        {
            ddlAgeGroup1.SelectedValue = "5";
        }
    }
    protected void txtAge2_TextChanged(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(txtAge2.Text, out value))
        {
            if (value < 18)
            {
                ddlAgeGroup2.SelectedValue = "1";
            }
            else if (value >= 18 && value <= 25)
            {
                ddlAgeGroup2.SelectedValue = "2";
            }
            else if (value >= 26 && value <= 34)
            {
                ddlAgeGroup2.SelectedValue = "3";
            }
            else if (value >= 35 && value <= 40)
            {
                ddlAgeGroup2.SelectedValue = "4";
            }
            else if (value >= 41 && value <= 45)
            {
                ddlAgeGroup2.SelectedValue = "6";
            }
            else if (value >= 46 && value <= 50)
            {
                ddlAgeGroup2.SelectedValue = "7";
            }
            else if (value >= 51 && value <= 60)
            {
                ddlAgeGroup2.SelectedValue = "8";
            }
            else if (value >= 61)
            {
                ddlAgeGroup2.SelectedValue = "9";
            }
        }
        else
        {
            ddlAgeGroup2.SelectedValue = "5";
        }
    }
    protected void txtAge3_TextChanged(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(txtAge3.Text, out value))
        {
            if (value < 18)
            {
                ddlAgeGroup3.SelectedValue = "1";
            }
            else if (value >= 18 && value <= 25)
            {
                ddlAgeGroup3.SelectedValue = "2";
            }
            else if (value >= 26 && value <= 34)
            {
                ddlAgeGroup3.SelectedValue = "3";
            }
            else if (value >= 35 && value <= 40)
            {
                ddlAgeGroup3.SelectedValue = "4";
            }
            else if (value >= 41 && value <= 45)
            {
                ddlAgeGroup3.SelectedValue = "6";
            }
            else if (value >= 46 && value <= 50)
            {
                ddlAgeGroup3.SelectedValue = "7";
            }
            else if (value >= 51 && value <= 60)
            {
                ddlAgeGroup3.SelectedValue = "8";
            }
            else if (value >= 61)
            {
                ddlAgeGroup3.SelectedValue = "9";
            }
        }
        else
        {
            ddlAgeGroup3.SelectedValue = "5";
        }
    }
    protected void txtAge4_TextChanged(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(txtAge4.Text, out value))
        {
            if (value < 18)
            {
                ddlAgeGroup4.SelectedValue = "1";
            }
            else if (value >= 18 && value <= 25)
            {
                ddlAgeGroup4.SelectedValue = "2";
            }
            else if (value >= 26 && value <= 34)
            {
                ddlAgeGroup4.SelectedValue = "3";
            }
            else if (value >= 35 && value <= 40)
            {
                ddlAgeGroup4.SelectedValue = "4";
            }
            else if (value >= 41 && value <= 45)
            {
                ddlAgeGroup4.SelectedValue = "6";
            }
            else if (value >= 46 && value <= 50)
            {
                ddlAgeGroup4.SelectedValue = "7";
            }
            else if (value >= 51 && value <= 60)
            {
                ddlAgeGroup4.SelectedValue = "8";
            }
            else if (value >= 61)
            {
                ddlAgeGroup4.SelectedValue = "9";
            }
        }
        else
        {
            ddlAgeGroup4.SelectedValue = "5";
        }
    }
    protected void txtAge5_TextChanged(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(txtAge5.Text, out value))
        {
            if (value < 18)
            {
                ddlAgeGroup5.SelectedValue = "1";
            }
            else if (value >= 18 && value <= 25)
            {
                ddlAgeGroup5.SelectedValue = "2";
            }
            else if (value >= 26 && value <= 34)
            {
                ddlAgeGroup5.SelectedValue = "3";
            }
            else if (value >= 35 && value <= 40)
            {
                ddlAgeGroup5.SelectedValue = "4";
            }
            else if (value >= 41 && value <= 45)
            {
                ddlAgeGroup5.SelectedValue = "6";
            }
            else if (value >= 46 && value <= 50)
            {
                ddlAgeGroup5.SelectedValue = "7";
            }
            else if (value >= 51 && value <= 60)
            {
                ddlAgeGroup5.SelectedValue = "8";
            }
            else if (value >= 61)
            {
                ddlAgeGroup5.SelectedValue = "9";
            }
        }
        else
        {
            ddlAgeGroup5.SelectedValue = "5";
        }
    }

    protected void ddlAgeGroup1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge1.Text = "";
    }
    protected void ddlAgeGroup2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge2.Text = "";
    }
    protected void ddlAgeGroup3_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge3.Text = "";
    }
    protected void ddlAgeGroup4_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge4.Text = "";
    }
    protected void ddlAgeGroup5_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge5.Text = "";
    }

    // checkbox to show Camera Form - be able add Camera Form
    protected void cbCamera_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCamera.Checked == true)
        {
            // show the added Camera form
            tblCamera1.Visible = true;
            tblAddCam2.Visible = true;
        }
        else
        {
            // hide all Camera forms
            tblCamera1.Visible = false;
            tblAddCam2.Visible = false;
            tblCamera2.Visible = false;
            tblAddCam3.Visible = false;
            tblCamera3.Visible = false;
            tblAddCam4.Visible = false;
            tblCamera4.Visible = false;
            tblAddCam5.Visible = false;
            tblCamera5.Visible = false;
            tblAddCam6.Visible = false;
            tblCamera6.Visible = false;
            tblAddCam7.Visible = false;
            tblCamera7.Visible = false;
            tblDelCam7.Visible = false;
        }

    }
    protected void btnAddCam2_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 2 button
        tblAddCam2.Visible = false;
        // show the added Camera form
        tblCamera2.Visible = true;
        tblAddCam3.Visible = true;
    }
    protected void btnAddCam3_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 3 button
        tblAddCam3.Visible = false;
        // show the added Camera form
        tblCamera3.Visible = true;
        tblAddCam4.Visible = true;
    }
    protected void btnAddCam4_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 4 button
        tblAddCam4.Visible = false;
        // show the added Camera form
        tblCamera4.Visible = true;
        tblAddCam5.Visible = true;
    }
    protected void btnAddCam5_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam5.Visible = false;
        // show the added Camera form
        tblCamera5.Visible = true;
        tblAddCam6.Visible = true;
    }
    protected void btnAddCam6_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam6.Visible = false;
        // show the added Camera form
        tblCamera6.Visible = true;
        tblAddCam7.Visible = true;
    }
    protected void btnAddCam7_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam7.Visible = false;
        // show the added Camera form
        tblCamera7.Visible = true;
        tblDelCam7.Visible = true;
    }

    // delete/hide Camera form
    protected void btnDelCam2_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 2 button
        tblAddCam2.Visible = true;
        tblAddCam3.Visible = false;
        // hide the added Camera form
        tblCamera2.Visible = false;
        txtCamDesc2.Text = "";
        cbRecorded2.Checked = false;
        txtCamFilePath2.Text = "";
        txtCamSDate2.Text = "";
        //ddlCamTimeTC2.SelectedItem.Value = "-1";
        txtCamEDate2.Text = "";
        //ddlCamETimeTC2.SelectedItem.Value = "-1";
    }
    protected void btnDelCam3_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 3 button
        tblAddCam3.Visible = true;
        tblAddCam4.Visible = false;
        // hide the added Camera form
        tblCamera3.Visible = false;
        txtCamDesc3.Text = "";
        cbRecorded3.Checked = false;
        txtCamFilePath3.Text = "";
        txtCamSDate3.Text = "";
        //ddlCamTimeTC3.SelectedItem.Value = "-1";
        txtCamEDate3.Text = "";
        //ddlCamETimeTC3.SelectedItem.Value = "-1";
    }
    protected void btnDelCam4_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 4 button
        tblAddCam4.Visible = true;
        tblAddCam5.Visible = false;
        // hide the added Camera form
        tblCamera4.Visible = false;
        txtCamDesc4.Text = "";
        cbRecorded4.Checked = false;
        txtCamFilePath4.Text = "";
        txtCamSDate4.Text = "";
        //ddlCamTimeTC4.SelectedItem.Value = "-1";
        txtCamEDate4.Text = "";
        //ddlCamETimeTC4.SelectedItem.Value = "-1";
    }
    protected void btnDelCam5_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 5 button
        tblAddCam5.Visible = true;
        tblAddCam6.Visible = false;
        // hide the added Camera form
        tblCamera5.Visible = false;
        txtCamDesc5.Text = "";
        cbRecorded5.Checked = false;
        txtCamFilePath5.Text = "";
        txtCamSDate5.Text = "";
        //ddlCamTimeTC5.SelectedItem.Value = "-1";
        txtCamEDate5.Text = "";
        //ddlCamETimeTC5.SelectedItem.Value = "-1";
    }
    protected void btnDelCam6_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 6 button
        tblAddCam6.Visible = true;
        tblAddCam7.Visible = false;
        // hide the added Camera form
        tblCamera6.Visible = false;
        txtCamDesc6.Text = "";
        cbRecorded6.Checked = false;
        txtCamFilePath6.Text = "";
        txtCamSDate6.Text = "";
        //ddlCamTimeTC6.SelectedItem.Value = "-1";
        txtCamEDate6.Text = "";
        //ddlCamETimeTC6.SelectedItem.Value = "-1";
    }
    protected void btnDelCam7_Click(object sender, EventArgs e)
    {
        // show the Add Camera no. 7 button
        tblAddCam7.Visible = true;
        tblDelCam7.Visible = false;
        // hide the added Camera form
        tblCamera7.Visible = false;
        txtCamDesc7.Text = "";
        cbRecorded7.Checked = false;
        txtCamFilePath7.Text = "";
        txtCamSDate7.Text = "";
        //ddlCamTimeTC7.SelectedItem.Value = "-1";
        txtCamEDate7.Text = "";
        //ddlCamETimeTC7.SelectedItem.Value = "-1";
    }

    // list of all checkboxlist in the form - are AutoPostBack and toggles the visibility of other objects (such as textboxes)
    protected void cblWhatHappened1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in cblWhatHappened1.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    additionalDetails.Visible = true;
                    additionalDetails1.Visible = true;
                }
                else
                {
                    additionalDetails.Visible = false;
                    additionalDetails1.Visible = false;
                    txtOthers.Text = "";
                }
            }
            if (item.ToString() == "Other - Serious")
            {
                if (item.Selected)
                {
                    seriousOther.Visible = true;
                    seriousOther1.Visible = true;
                }
                else
                {
                    seriousOther.Visible = false;
                    seriousOther1.Visible = false;
                    txtOtherSerious.Text = "";
                }
            }
            if (item.ToString() == "Refused Entry")
            {
                if (item.Selected)
                {
                    refuseEntryReasons.Visible = true;
                    refuseEntryReasons1.Visible = true;
                }
                else
                {
                    refuseEntryReasons.Visible = false;
                    refuseEntryReasons1.Visible = false;
                    List_RefuseReason.ClearSelection();
                }
            }
            if (item.ToString() == "Asked to Leave")
            {
                if (item.Selected)
                {
                    askedtoLeaveReasons.Visible = true;
                    askedtoLeaveReasons1.Visible = true;
                }
                else
                {
                    askedtoLeaveReasons.Visible = false;
                    askedtoLeaveReasons1.Visible = false;
                    List_AskedToLeave.ClearSelection();
                }
            }
        }
    }
    protected void List_ActionTaken_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in List_ActionTaken.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    actionTakenOther.Visible = true;
                    actionTakenOther1.Visible = true;
                }
                else
                {
                    actionTakenOther.Visible = false;
                    actionTakenOther1.Visible = false;
                    txtActionTakenOther.Text = "";
                }
            }
        }
    }
    protected void List_Location_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in List_Location.Items)
        {
            if (item.ToString() == "Other")
            {
                if (item.Selected)
                {
                    otherLocation.Visible = true;
                    txtLocation.Visible = true;
                }
                else
                {
                    otherLocation.Visible = false;
                    txtLocation.Visible = false;
                    txtLocation.Text = "";
                }
            }
        }
    }

    // add/delete security/police info
    protected void cbPolice_CheckedChanged(object sender, EventArgs e)
    {
        if (cbPolice.Checked == true)
        {
            tdPolice1.Visible = true;
            tdPolice2.Visible = true;
            tdPolice3.Visible = true;
            tdPolice4.Visible = true;
            tdPolice5.Visible = true;
            tdPolice6.Visible = true;
        }
        else
        {
            tdPolice1.Visible = false;
            tdPolice2.Visible = false;
            tdPolice3.Visible = false;
            tdPolice4.Visible = false;
            tdPolice5.Visible = false;
            tdPolice6.Visible = false;
            txtPoliceStation.Text = "";
            txtOfficersName.Text = "";
            txtPoliceAction.Text = "";
        }
    }
    protected void cbSecurity_CheckedChanged(object sender, EventArgs e)
    {
        if (cbSecurity.Checked == true)
        {
            tdSecurity1.Visible = true;
            tdSecurity2.Visible = true;
        }
        else
        {
            tdSecurity1.Visible = false;
            tdSecurity2.Visible = false;
            txtSecurityName.Text = "";
        }
    }

    // clears all changes made
    protected void btnReset_Click(object sender, EventArgs e)
    {
        // get max version of the report template
        con.Open();
        SqlCommand version = new SqlCommand("SELECT MAX(VersionNo)" +
                         " FROM dbo.[Version]" +
                         " WHERE RCatId = 9", con);
        int maxVersion = (int)version.ExecuteScalar();

        //Reset the Player Id Global Variables
        ReportIncidentCu.PlayerId1 = "";
        ReportIncidentCu.PlayerId2 = "";
        ReportIncidentCu.PlayerId3 = "";
        ReportIncidentCu.PlayerId4 = "";
        ReportIncidentCu.PlayerId5 = "";

        // display cleared report template
        Response.Redirect("~/Reports/CU Incident Report/Create/v" + maxVersion.ToString() + "/v" + maxVersion.ToString() + ".aspx", false);
    }

    // stores data into database. Runs validateForm method to sanitise the fields before it stores it into database
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

        string WhatHappened, Location, RefuseReason = "", AskedLeaveReason = "", ActionTaken = "",
               query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_ClubUminaIncident";
        int lastRId;

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
            lastRId = 9000001;
        }
        con.Close();

        Report.LastReportId = lastRId.ToString();

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        List<String> YrStrList = new List<string>();
        // Loop through each item.
        foreach (ListItem item in cblWhatHappened1.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                YrStrList.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        WhatHappened = String.Join(",", YrStrList.ToArray());
        if (!WhatHappened.Equals(""))
        {
            WhatHappened += ",";
        }

        // if Refuse Entry option is not empty
        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        if (List_RefuseReason.SelectedValue != String.Empty)
        {
            List<String> YrStrList2 = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_RefuseReason.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList2.Add(item.Value);
                }
            }
            // Join the string together using the ; delimiter.
            RefuseReason = String.Join(",", YrStrList2.ToArray());
        }

        // if Asked To Leave option is not empty
        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        if (List_AskedToLeave.SelectedValue != String.Empty)
        {
            List<String> YrStrList3 = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_AskedToLeave.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList3.Add(item.Value);
                }
            }
            // Join the string together using the ; delimiter.
            AskedLeaveReason = String.Join(",", YrStrList3.ToArray());
        }

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        List<String> YrStrList1 = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_Location.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                YrStrList1.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        Location = String.Join(",", YrStrList1.ToArray());
        if (!Location.Equals(""))
        {
            Location += ",";
        }

        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        List<String> YrStrList4 = new List<string>();
        // Loop through each item.
        foreach (ListItem item in List_ActionTaken.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                YrStrList4.Add(item.Value);
            }
        }
        // Join the string together using the ; delimiter.
        ActionTaken = String.Join(",", YrStrList4.ToArray());
        if (!ActionTaken.Equals(""))
        {
            ActionTaken += ",";
        }

        // change the format of the entry date to timestamp format
        DateTime entry_date = DateTime.Now;

        // validate objects in the form
        int returnedValue = 0;
        if (ddlShift.SelectedItem.Value == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Shift.";
            ddlShift.Focus();
            returnedValue = 1;
        }

        if (returnedValue == 1)
        {
            alert.DisplayMessage(Report.ErrorMessage);
            Report.ErrorMessage = "";
            return;
        }

        // change the format of the shift date to timestamp format
        DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
        string shift_tDate = shift_date.ToString("yyyyMMdd");
        // separate the shift date day of week value
        string shift_DOW = shift_date.DayOfWeek.ToString();

        // get staff's id
        string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
               variable = "getStaff";
        readFiles(cmdText, variable);

        // insert data to table
        using (DataClassesDataContext dc = new DataClassesDataContext())
        {
            Report_ClubUminaIncident dm = new Report_ClubUminaIncident();
            dm.ReportId = Int32.Parse(Report.LastReportId);
            dm.RCatId = 9;
            dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
            dm.StaffName = UserCredentials.DisplayName;
            dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
            dm.ShiftDate = shift_date.Date;
            dm.ShiftDOW = shift_DOW;
            dm.EntryDate = entry_date;
            dm.Report_Table = "Report_ClubUminaIncident";
            dm.AuditVersion = 1;
            dm.ReportStat = "Awaiting Completion";
            dm.Report_Version = 1; // current version
            dm.ReadByList = "," + UserCredentials.StaffId + ",";
            dm.NoOfPerson = Int32.Parse(lblNoOfPerson.Text);
            dm.Date = txtDate1.Text;
            dm.TimeH = ddlHour.SelectedItem.Value;
            dm.TimeM = ddlMinutes.SelectedItem.Value;
            //dm.TimeTC = ddlTimeCon.SelectedItem.Value;
            dm.TxtTimeH = ddlHour.SelectedItem.Text;
            dm.TxtTimeM = ddlMinutes.SelectedItem.Text;
            //dm.TxtTimeTC = ddlTimeCon.SelectedItem.Text;
            dm.Location = Location;
            dm.LocationOther = txtLocation.Text;
            dm.ActionTaken = ActionTaken;
            dm.Details = txtDetails.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.Allegation = txtAllegation.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.IncidentHappened = WhatHappened;
            dm.ActionTakenOther = txtActionTakenOther.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.HappenedOther = txtOthers.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.HappenedSerious = txtOtherSerious.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.HappenedRefuseEntry = RefuseReason;
            dm.HappenedAskedToLeave = AskedLeaveReason;
            dm.SecurityAttend = cbSecurity.Checked;
            dm.SecurityName = txtSecurityName.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PoliceNotify = cbPolice.Checked;
            dm.PoliceAction = txtPoliceAction.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.OfficersName = txtOfficersName.Text.Replace("\n", "<br />").Replace("'", "^");
            dm.PoliceStation = txtPoliceStation.Text.Replace("\n", "<br />").Replace("'", "^");
            // Submit Person Form if visible
            if (acpPerson1.Visible == true)
            {
                dm.FirstName1 = txtFirstName1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName1 = txtLastName1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType1 = ddlPartyType1.SelectedItem.Value;
                if (ddlPartyType1.SelectedItem.Value == "1")
                {
                    dm.PlayerId1 = ReportIncidentCu.PlayerId1;
                    dm.MemberNo1 = txtMemberNo1.Text;
                    // get the member photo again to store it in the database
                    Report.MemberNumberChanged = "1";
                    string cmdQuery = SearchMember(txtMemberNo1.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto1 = memberPhoto1;
                    dm.MemberDOB1 = txtDOB1.Text;
                    dm.MemberAddress1 = txtAddress1.Text;
                    dm.CardHeld1 = cbCardHeld1.Checked;
                    dm.MemberSince1 = txtMemberSince1.Text;
                    dm.SignInSlip1 = false;
                }
                else if (ddlPartyType1.SelectedItem.Value == "3")
                {
                    dm.StaffEmpNo1 = txtStaffEmpNo1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.StaffAddress1 = txtStaffAddress1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CardHeld1 = false;
                    dm.SignInSlip1 = false;
                }
                else if (ddlPartyType1.SelectedItem.Value == "2")
                {
                    dm.CardHeld1 = false;
                    dm.SignInSlip1 = cbSignInSlip1.Checked;
                    dm.SignedInBy1 = txtSignInBy1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB1 = txtDOBv1.Text;
                    dm.VisitorAddress1 = txtAddressv1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID1 = txtIDProof1.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.CardHeld1 = false;
                    dm.SignInSlip1 = false;
                }
                dm.Witness1 = cbWitness1.Checked;
                dm.Alias1 = txtAlias1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Contact1 = txtContact1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PDate1 = txtPDate1.Text;
                dm.PTimeH1 = ddlPTimeH1.SelectedItem.Value;
                dm.PTimeM1 = ddlPTimeM1.SelectedItem.Value;
                //dm.PTimeTC1 = ddlPTimeTC1.SelectedItem.Value;
                dm.Age1 = txtAge1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.AgeGroup1 = ddlAgeGroup1.SelectedItem.Value;
                //dm.Weight1 = txtWeight1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weight1 = ddlWeight1.SelectedItem.Value;
                dm.Height1 = txtHeight1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Hair1 = txtHair1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingTop1 = txtClothingTop1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingBottom1 = txtClothingBottom1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Shoes1 = txtShoes1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weapon1 = txtWeapon1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Gender1 = ddlGender1.SelectedItem.Value;
                dm.DistFeatures1 = txtDistFeatures1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InjuryDesc1 = txtInjuryDesc1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CauseInjury1 = txtInjuryCause1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Comments1 = txtIncidentComm1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.TxtPartyType1 = ddlPartyType1.SelectedItem.Text;
                dm.TxtPTimeH1 = ddlPTimeH1.SelectedItem.Text;
                dm.TxtPTimeM1 = ddlPTimeM1.SelectedItem.Text;
                //dm.TxtPTimeTC1 = ddlPTimeTC1.SelectedItem.Text;
                dm.TxtGender1 = ddlGender1.SelectedItem.Text;
            }
            else
            {
                dm.Witness1 = false;
                dm.SignInSlip1 = false;
                dm.CardHeld1 = false;
                dm.PartyType1 = "-1";
                dm.PTimeH1 = "-1";
                dm.PTimeM1 = "-1";
                //dm.PTimeTC1 = "-1";
                dm.Gender1 = "-1";
                dm.AgeGroup1 = "-1";
            }

            if (acpPerson2.Visible == true)
            {
                dm.FirstName2 = txtFirstName2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName2 = txtLastName2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType2 = ddlPartyType2.SelectedItem.Value;
                if (ddlPartyType2.SelectedItem.Value == "1")
                {
                    dm.PlayerId2 = ReportIncidentCu.PlayerId2;
                    dm.MemberNo2 = txtMemberNo2.Text;
                    // get the member photo again to store it in the database
                    Report.MemberNumberChanged = "2";
                    string cmdQuery = SearchMember(txtMemberNo2.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto2 = memberPhoto2;
                    dm.MemberDOB2 = txtDOB2.Text;
                    dm.MemberAddress2 = txtAddress2.Text;
                    dm.CardHeld2 = cbCardHeld2.Checked;
                    dm.MemberSince2 = txtMemberSince2.Text;
                    dm.SignInSlip2 = false;
                }
                else if (ddlPartyType2.SelectedItem.Value == "3")
                {
                    dm.StaffEmpNo2 = txtStaffEmpNo2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.StaffAddress2 = txtStaffAddress2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CardHeld2 = false;
                    dm.SignInSlip2 = false;
                }
                else if (ddlPartyType2.SelectedItem.Value == "2")
                {
                    dm.CardHeld2 = false;
                    dm.SignInSlip2 = cbSignInSlip2.Checked;
                    dm.SignedInBy2 = txtSignInBy2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB2 = txtDOBv2.Text;
                    dm.VisitorAddress2 = txtAddressv2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID2 = txtIDProof2.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.CardHeld2 = false;
                    dm.SignInSlip2 = false;
                }
                dm.Witness2 = cbWitness2.Checked;
                dm.Alias2 = txtAlias2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Contact2 = txtContact2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PDate2 = txtPDate2.Text;
                dm.PTimeH2 = ddlPTimeH2.SelectedItem.Value;
                dm.PTimeM2 = ddlPTimeM2.SelectedItem.Value;
                //dm.PTimeTC2 = ddlPTimeTC2.SelectedItem.Value;
                dm.Age2 = txtAge2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.AgeGroup2 = ddlAgeGroup2.SelectedItem.Value;
                //dm.Weight2 = txtWeight2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weight2 = ddlWeight2.SelectedItem.Value;
                dm.Height2 = txtHeight2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Hair2 = txtHair2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingTop2 = txtClothingTop2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingBottom2 = txtClothingBottom2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Shoes2 = txtShoes2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weapon2 = txtWeapon2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Gender2 = ddlGender2.SelectedItem.Value;
                dm.DistFeatures2 = txtDistFeatures2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InjuryDesc2 = txtInjuryDesc2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CauseInjury2 = txtInjuryCause2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Comments2 = txtIncidentComm2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.TxtPartyType2 = ddlPartyType2.SelectedItem.Text;
                dm.TxtPTimeH2 = ddlPTimeH2.SelectedItem.Text;
                dm.TxtPTimeM2 = ddlPTimeM2.SelectedItem.Text;
                //dm.TxtPTimeTC2 = ddlPTimeTC2.SelectedItem.Text;
                dm.TxtGender2 = ddlGender2.SelectedItem.Text;
            }
            else
            {
                dm.Witness2 = false;
                dm.SignInSlip2 = false;
                dm.CardHeld2 = false;
                dm.PartyType2 = "-1";
                dm.PTimeH2 = "-1";
                dm.PTimeM2 = "-1";
                //dm.PTimeTC2 = "-1";
                dm.Gender2 = "-1";
                dm.AgeGroup2 = "-1";
            }

            if (acpPerson3.Visible == true)
            {
                dm.FirstName3 = txtFirstName3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName3 = txtLastName3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType3 = ddlPartyType3.SelectedItem.Value;
                if (ddlPartyType3.SelectedItem.Value == "1")
                {
                    dm.PlayerId3 = ReportIncidentCu.PlayerId3;
                    dm.MemberNo3 = txtMemberNo3.Text;
                    // get the member photo again to store it in the database
                    Report.MemberNumberChanged = "3";
                    string cmdQuery = SearchMember(txtMemberNo3.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto3 = memberPhoto3;
                    dm.MemberDOB3 = txtDOB3.Text;
                    dm.MemberAddress3 = txtAddress3.Text;
                    dm.CardHeld3 = cbCardHeld3.Checked;
                    dm.MemberSince3 = txtMemberSince3.Text;
                    dm.SignInSlip3 = false;
                }
                else if (ddlPartyType3.SelectedItem.Value == "3")
                {
                    dm.StaffEmpNo3 = txtStaffEmpNo3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.StaffAddress3 = txtStaffAddress3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CardHeld3 = false;
                    dm.SignInSlip3 = false;
                }
                else if (ddlPartyType3.SelectedItem.Value == "2")
                {
                    dm.CardHeld3 = false;
                    dm.SignInSlip3 = cbSignInSlip3.Checked;
                    dm.SignedInBy3 = txtSignInBy3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB3 = txtDOBv3.Text;
                    dm.VisitorAddress3 = txtAddressv3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID3 = txtIDProof3.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.CardHeld3 = false;
                    dm.SignInSlip3 = false;
                }
                dm.Witness3 = cbWitness3.Checked;
                dm.Alias3 = txtAlias3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Contact3 = txtContact3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PDate3 = txtPDate3.Text;
                dm.PTimeH3 = ddlPTimeH3.SelectedItem.Value;
                dm.PTimeM3 = ddlPTimeM3.SelectedItem.Value;
                //dm.PTimeTC3 = ddlPTimeTC3.SelectedItem.Value;
                dm.Age3 = txtAge3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.AgeGroup3 = ddlAgeGroup3.SelectedItem.Value;
                //dm.Weight3 = txtWeight3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weight3 = ddlWeight3.SelectedItem.Value;
                dm.Height3 = txtHeight3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Hair3 = txtHair3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingTop3 = txtClothingTop3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingBottom3 = txtClothingBottom3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Shoes3 = txtShoes3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weapon3 = txtWeapon3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Gender3 = ddlGender3.SelectedItem.Value;
                dm.DistFeatures3 = txtDistFeatures3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InjuryDesc3 = txtInjuryDesc3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CauseInjury3 = txtInjuryCause3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Comments3 = txtIncidentComm3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.TxtPartyType3 = ddlPartyType3.SelectedItem.Text;
                dm.TxtPTimeH3 = ddlPTimeH3.SelectedItem.Text;
                dm.TxtPTimeM3 = ddlPTimeM3.SelectedItem.Text;
                //dm.TxtPTimeTC3 = ddlPTimeTC3.SelectedItem.Text;
                dm.TxtGender3 = ddlGender3.SelectedItem.Text;
            }
            else
            {
                dm.Witness3 = false;
                dm.SignInSlip3 = false;
                dm.CardHeld3 = false;
                dm.PartyType3 = "-1";
                dm.PTimeH3 = "-1";
                dm.PTimeM3 = "-1";
                //dm.PTimeTC3 = "-1";
                dm.Gender3 = "-1";
                dm.AgeGroup3 = "-1";
            }

            if (acpPerson4.Visible == true)
            {
                dm.FirstName4 = txtFirstName4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName4 = txtLastName4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType4 = ddlPartyType4.SelectedItem.Value;
                if (ddlPartyType4.SelectedItem.Value == "1")
                {
                    dm.PlayerId4 = ReportIncidentCu.PlayerId4;
                    dm.MemberNo4 = txtMemberNo4.Text;
                    // get the member photo again to store it in the database
                    Report.MemberNumberChanged = "4";
                    string cmdQuery = SearchMember(txtMemberNo4.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto4 = memberPhoto4;
                    dm.MemberDOB4 = txtDOB4.Text;
                    dm.MemberAddress4 = txtAddress4.Text;
                    dm.CardHeld4 = cbCardHeld4.Checked;
                    dm.MemberSince4 = txtMemberSince4.Text;
                    dm.SignInSlip4 = false;
                }
                else if (ddlPartyType4.SelectedItem.Value == "3")
                {
                    dm.StaffEmpNo4 = txtStaffEmpNo4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.StaffAddress4 = txtStaffAddress4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CardHeld4 = false;
                    dm.SignInSlip4 = false;
                }
                else if (ddlPartyType4.SelectedItem.Value == "2")
                {
                    dm.CardHeld4 = false;
                    dm.SignInSlip4 = cbSignInSlip4.Checked;
                    dm.SignedInBy4 = txtSignInBy4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB4 = txtDOBv4.Text;
                    dm.VisitorAddress4 = txtAddressv4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID4 = txtIDProof4.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.CardHeld4 = false;
                    dm.SignInSlip4 = false;
                }
                dm.Witness4 = cbWitness4.Checked;
                dm.Alias4 = txtAlias4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Contact4 = txtContact4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PDate4 = txtPDate4.Text;
                dm.PTimeH4 = ddlPTimeH4.SelectedItem.Value;
                dm.PTimeM4 = ddlPTimeM4.SelectedItem.Value;
                //dm.PTimeTC4 = ddlPTimeTC4.SelectedItem.Value;
                dm.Age4 = txtAge4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.AgeGroup4 = ddlAgeGroup4.SelectedItem.Value;
                //dm.Weight4 = txtWeight4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weight4 = ddlWeight4.SelectedItem.Value;
                dm.Height4 = txtHeight4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Hair4 = txtHair4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingTop4 = txtClothingTop4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingBottom4 = txtClothingBottom4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Shoes4 = txtShoes4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weapon4 = txtWeapon4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Gender4 = ddlGender4.SelectedItem.Value;
                dm.DistFeatures4 = txtDistFeatures4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InjuryDesc4 = txtInjuryDesc4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CauseInjury4 = txtInjuryCause4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Comments4 = txtIncidentComm4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.TxtPartyType4 = ddlPartyType4.SelectedItem.Text;
                dm.TxtPTimeH4 = ddlPTimeH4.SelectedItem.Text;
                dm.TxtPTimeM4 = ddlPTimeM4.SelectedItem.Text;
                //dm.TxtPTimeTC4 = ddlPTimeTC4.SelectedItem.Text;
                dm.TxtGender4 = ddlGender4.SelectedItem.Text;
            }
            else
            {
                dm.Witness4 = false;
                dm.SignInSlip4 = false;
                dm.CardHeld4 = false;
                dm.PartyType4 = "-1";
                dm.PTimeH4 = "-1";
                dm.PTimeM4 = "-1";
                //dm.PTimeTC4 = "-1";
                dm.Gender4 = "-1";
                dm.AgeGroup4 = "-1";
            }

            if (acpPerson5.Visible == true)
            {
                dm.FirstName5 = txtFirstName5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.LastName5 = txtLastName5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PartyType5 = ddlPartyType5.SelectedItem.Value;
                if (ddlPartyType5.SelectedItem.Value == "1")
                {
                    dm.PlayerId5 = ReportIncidentCu.PlayerId5;
                    dm.MemberNo5 = txtMemberNo5.Text;
                    // get the member photo again to store it in the database
                    Report.MemberNumberChanged = "5";
                    string cmdQuery = SearchMember(txtMemberNo5.Text);
                    readFiles(cmdQuery, "MemberPhoto");
                    dm.MemberPhoto5 = memberPhoto5;
                    dm.MemberDOB5 = txtDOB5.Text;
                    dm.MemberAddress5 = txtAddress5.Text;
                    dm.CardHeld5 = cbCardHeld5.Checked;
                    dm.MemberSince5 = txtMemberSince5.Text;
                    dm.SignInSlip5 = false;
                }
                else if (ddlPartyType5.SelectedItem.Value == "3")
                {
                    dm.StaffEmpNo5 = txtStaffEmpNo5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.StaffAddress5 = txtStaffAddress5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CardHeld5 = false;
                    dm.SignInSlip5 = false;
                }
                else if (ddlPartyType5.SelectedItem.Value == "2")
                {
                    dm.CardHeld5 = false;
                    dm.SignInSlip5 = cbSignInSlip5.Checked;
                    dm.SignedInBy5 = txtSignInBy5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorDOB5 = txtDOBv5.Text;
                    dm.VisitorAddress5 = txtAddressv5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.VisitorProofID5 = txtIDProof5.Text.Replace("\n", "<br />").Replace("'", "^");
                }
                else
                {
                    dm.CardHeld5 = false;
                    dm.SignInSlip5 = false;
                }
                dm.Witness5 = cbWitness5.Checked;
                dm.Alias5 = txtAlias5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Contact5 = txtContact5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PDate5 = txtPDate5.Text;
                dm.PTimeH5 = ddlPTimeH5.SelectedItem.Value;
                dm.PTimeM5 = ddlPTimeM5.SelectedItem.Value;
                //dm.PTimeTC5 = ddlPTimeTC5.SelectedItem.Value;
                dm.Age5 = txtAge5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.AgeGroup5 = ddlAgeGroup5.SelectedItem.Value;
                //dm.Weight5 = txtWeight5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weight5 = ddlWeight5.SelectedItem.Value;
                dm.Height5 = txtHeight5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Hair5 = txtHair5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingTop5 = txtClothingTop5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.ClothingBottom5 = txtClothingBottom5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Shoes5 = txtShoes5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Weapon5 = txtWeapon5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Gender5 = ddlGender5.SelectedItem.Value;
                dm.DistFeatures5 = txtDistFeatures5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.InjuryDesc5 = txtInjuryDesc5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CauseInjury5 = txtInjuryCause5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Comments5 = txtIncidentComm5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.TxtPartyType5 = ddlPartyType5.SelectedItem.Text;
                dm.TxtPTimeH5 = ddlPTimeH5.SelectedItem.Text;
                dm.TxtPTimeM5 = ddlPTimeM5.SelectedItem.Text;
                //dm.TxtPTimeTC5 = ddlPTimeTC5.SelectedItem.Text;
                dm.TxtGender5 = ddlGender5.SelectedItem.Text;
            }
            else
            {
                dm.Witness5 = false;
                dm.SignInSlip5 = false;
                dm.CardHeld5 = false;
                dm.PartyType5 = "-1";
                dm.PTimeH5 = "-1";
                dm.PTimeM5 = "-1";
                //dm.PTimeTC5 = "-1";
                dm.Gender5 = "-1";
                dm.AgeGroup5 = "-1";
            }

            // Submit Camera Forms if visible
            if (tblCamera1.Visible == true)
            {
                dm.CamDesc1 = txtCamDesc1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate1 = txtCamSDate1.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH1 = ddlCamTimeH1.SelectedItem.Value;
                dm.CamSTimeM1 = ddlCamTimeM1.SelectedItem.Value;
                //dm.CamSTimeTC1 = ddlCamTimeTC1.SelectedItem.Value;
                dm.CamEDate1 = txtCamEDate1.Text;
                dm.CamETimeH1 = ddlCamETimeH1.SelectedItem.Value;
                dm.CamETimeM1 = ddlCamETimeM1.SelectedItem.Value;
                //dm.CamETimeTC1 = ddlCamETimeTC1.SelectedItem.Value;
                dm.CamFilePath1 = txtCamFilePath1.Text;
                dm.CamRecorded1 = cbRecorded1.Checked;
                dm.TxtCamSTimeH1 = ddlCamTimeH1.SelectedItem.Text;
                dm.TxtCamSTimeM1 = ddlCamTimeM1.SelectedItem.Text;
                //dm.TxtCamSTimeTC1 = ddlCamTimeTC1.SelectedItem.Text;
                dm.TxtCamETimeH1 = ddlCamETimeH1.SelectedItem.Text;
                dm.TxtCamETimeM1 = ddlCamETimeM1.SelectedItem.Text;
                //dm.TxtCamETimeTC1 = ddlCamETimeTC1.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded1 = false;
                dm.CamSTimeH1 = "-1";
                dm.CamSTimeM1 = "-1";
                //dm.CamSTimeTC1 = "-1";
                dm.CamETimeH1 = "-1";
                dm.CamETimeM1 = "-1";
                //dm.CamETimeTC1 = "-1";
            }
            if (tblCamera2.Visible == true)
            {
                dm.CamDesc2 = txtCamDesc2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate2 = txtCamSDate2.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH2 = ddlCamTimeH2.SelectedItem.Value;
                dm.CamSTimeM2 = ddlCamTimeM2.SelectedItem.Value;
                //dm.CamSTimeTC2 = ddlCamTimeTC2.SelectedItem.Value;
                dm.CamEDate2 = txtCamEDate2.Text;
                dm.CamETimeH2 = ddlCamETimeH2.SelectedItem.Value;
                dm.CamETimeM2 = ddlCamETimeM2.SelectedItem.Value;
                //dm.CamETimeTC2 = ddlCamETimeTC2.SelectedItem.Value;
                dm.CamFilePath2 = txtCamFilePath2.Text;
                dm.CamRecorded2 = cbRecorded2.Checked;
                dm.TxtCamSTimeH2 = ddlCamTimeH2.SelectedItem.Text;
                dm.TxtCamSTimeM2 = ddlCamTimeM2.SelectedItem.Text;
                //dm.TxtCamSTimeTC2 = ddlCamTimeTC2.SelectedItem.Text;
                dm.TxtCamETimeH2 = ddlCamETimeH2.SelectedItem.Text;
                dm.TxtCamETimeM2 = ddlCamETimeM2.SelectedItem.Text;
                //dm.TxtCamETimeTC2 = ddlCamETimeTC2.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded2 = false;
                dm.CamSTimeH2 = "-1";
                dm.CamSTimeM2 = "-1";
                //dm.CamSTimeTC2 = "-1";
                dm.CamETimeH2 = "-1";
                dm.CamETimeM2 = "-1";
                //dm.CamETimeTC2 = "-1";
            }
            if (tblCamera3.Visible == true)
            {
                dm.CamDesc3 = txtCamDesc3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate3 = txtCamSDate3.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH3 = ddlCamTimeH3.SelectedItem.Value;
                dm.CamSTimeM3 = ddlCamTimeM3.SelectedItem.Value;
                //dm.CamSTimeTC3 = ddlCamTimeTC3.SelectedItem.Value;
                dm.CamEDate3 = txtCamEDate3.Text;
                dm.CamETimeH3 = ddlCamETimeH3.SelectedItem.Value;
                dm.CamETimeM3 = ddlCamETimeM3.SelectedItem.Value;
                //dm.CamETimeTC3 = ddlCamETimeTC3.SelectedItem.Value;
                dm.CamFilePath3 = txtCamFilePath3.Text;
                dm.CamRecorded3 = cbRecorded3.Checked;
                dm.TxtCamSTimeH3 = ddlCamTimeH3.SelectedItem.Text;
                dm.TxtCamSTimeM3 = ddlCamTimeM3.SelectedItem.Text;
                //dm.TxtCamSTimeTC3 = ddlCamTimeTC3.SelectedItem.Text;
                dm.TxtCamETimeH3 = ddlCamETimeH3.SelectedItem.Text;
                dm.TxtCamETimeM3 = ddlCamETimeM3.SelectedItem.Text;
                //dm.TxtCamETimeTC3 = ddlCamETimeTC3.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded3 = false;
                dm.CamSTimeH3 = "-1";
                dm.CamSTimeM3 = "-1";
                //dm.CamSTimeTC3 = "-1";
                dm.CamETimeH3 = "-1";
                dm.CamETimeM3 = "-1";
                //dm.CamETimeTC3 = "-1";
            }
            if (tblCamera4.Visible == true)
            {
                dm.CamDesc4 = txtCamDesc4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate4 = txtCamSDate4.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH4 = ddlCamTimeH4.SelectedItem.Value;
                dm.CamSTimeM4 = ddlCamTimeM4.SelectedItem.Value;
                //dm.CamSTimeTC4 = ddlCamTimeTC4.SelectedItem.Value;
                dm.CamEDate4 = txtCamEDate4.Text;
                dm.CamETimeH4 = ddlCamETimeH4.SelectedItem.Value;
                dm.CamETimeM4 = ddlCamETimeM4.SelectedItem.Value;
                //dm.CamETimeTC4 = ddlCamETimeTC4.SelectedItem.Value;
                dm.CamFilePath4 = txtCamFilePath4.Text;
                dm.CamRecorded4 = cbRecorded4.Checked;
                dm.TxtCamSTimeH4 = ddlCamTimeH4.SelectedItem.Text;
                dm.TxtCamSTimeM4 = ddlCamTimeM4.SelectedItem.Text;
                //dm.TxtCamSTimeTC4 = ddlCamTimeTC4.SelectedItem.Text;
                dm.TxtCamETimeH4 = ddlCamETimeH4.SelectedItem.Text;
                dm.TxtCamETimeM4 = ddlCamETimeM4.SelectedItem.Text;
                //dm.TxtCamETimeTC4 = ddlCamETimeTC4.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded4 = false;
                dm.CamSTimeH4 = "-1";
                dm.CamSTimeM4 = "-1";
                //dm.CamSTimeTC4 = "-1";
                dm.CamETimeH4 = "-1";
                dm.CamETimeM4 = "-1";
                //dm.CamETimeTC4 = "-1";
            }
            if (tblCamera5.Visible == true)
            {
                dm.CamDesc5 = txtCamDesc5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate5 = txtCamSDate5.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH5 = ddlCamTimeH5.SelectedItem.Value;
                dm.CamSTimeM5 = ddlCamTimeM5.SelectedItem.Value;
                //dm.CamSTimeTC5 = ddlCamTimeTC5.SelectedItem.Value;
                dm.CamEDate5 = txtCamEDate5.Text;
                dm.CamETimeH5 = ddlCamETimeH5.SelectedItem.Value;
                dm.CamETimeM5 = ddlCamETimeM5.SelectedItem.Value;
                //dm.CamETimeTC5 = ddlCamETimeTC5.SelectedItem.Value;
                dm.CamFilePath5 = txtCamFilePath5.Text;
                dm.CamRecorded5 = cbRecorded5.Checked;
                dm.TxtCamSTimeH5 = ddlCamTimeH5.SelectedItem.Text;
                dm.TxtCamSTimeM5 = ddlCamTimeM5.SelectedItem.Text;
                //dm.TxtCamSTimeTC5 = ddlCamTimeTC5.SelectedItem.Text;
                dm.TxtCamETimeH5 = ddlCamETimeH5.SelectedItem.Text;
                dm.TxtCamETimeM5 = ddlCamETimeM5.SelectedItem.Text;
                //dm.TxtCamETimeTC5 = ddlCamETimeTC5.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded5 = false;
                dm.CamSTimeH5 = "-1";
                dm.CamSTimeM5 = "-1";
                //dm.CamSTimeTC5 = "-1";
                dm.CamETimeH5 = "-1";
                dm.CamETimeM5 = "-1";
                //dm.CamETimeTC5 = "-1";
            }
            if (tblCamera6.Visible == true)
            {
                dm.CamDesc6 = txtCamDesc6.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate6 = txtCamSDate6.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH6 = ddlCamTimeH6.SelectedItem.Value;
                dm.CamSTimeM6 = ddlCamTimeM6.SelectedItem.Value;
                //dm.CamSTimeTC6 = ddlCamTimeTC6.SelectedItem.Value;
                dm.CamEDate6 = txtCamEDate6.Text;
                dm.CamETimeH6 = ddlCamETimeH6.SelectedItem.Value;
                dm.CamETimeM6 = ddlCamETimeM6.SelectedItem.Value;
                //dm.CamETimeTC6 = ddlCamETimeTC6.SelectedItem.Value;
                dm.CamFilePath6 = txtCamFilePath6.Text;
                dm.CamRecorded6 = cbRecorded6.Checked;
                dm.TxtCamSTimeH6 = ddlCamTimeH6.SelectedItem.Text;
                dm.TxtCamSTimeM6 = ddlCamTimeM6.SelectedItem.Text;
                //dm.TxtCamSTimeTC6 = ddlCamTimeTC6.SelectedItem.Text;
                dm.TxtCamETimeH6 = ddlCamETimeH6.SelectedItem.Text;
                dm.TxtCamETimeM6 = ddlCamETimeM6.SelectedItem.Text;
                //dm.TxtCamETimeTC6 = ddlCamETimeTC6.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded6 = false;
                dm.CamSTimeH6 = "-1";
                dm.CamSTimeM6 = "-1";
                //dm.CamSTimeTC6 = "-1";
                dm.CamETimeH6 = "-1";
                dm.CamETimeM6 = "-1";
                //dm.CamETimeTC6 = "-1";
            }
            if (tblCamera7.Visible == true)
            {
                dm.CamDesc7 = txtCamDesc7.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSDate7 = txtCamSDate7.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.CamSTimeH7 = ddlCamTimeH7.SelectedItem.Value;
                dm.CamSTimeM7 = ddlCamTimeM7.SelectedItem.Value;
                //dm.CamSTimeTC7 = ddlCamTimeTC7.SelectedItem.Value;
                dm.CamEDate7 = txtCamEDate7.Text;
                dm.CamETimeH7 = ddlCamETimeH7.SelectedItem.Value;
                dm.CamETimeM7 = ddlCamETimeM7.SelectedItem.Value;
                //dm.CamETimeTC7 = ddlCamETimeTC7.SelectedItem.Value;
                dm.CamFilePath7 = txtCamFilePath7.Text;
                dm.CamRecorded7 = cbRecorded7.Checked;
                dm.TxtCamSTimeH7 = ddlCamTimeH7.SelectedItem.Text;
                dm.TxtCamSTimeM7 = ddlCamTimeM7.SelectedItem.Text;
                //dm.TxtCamSTimeTC7 = ddlCamTimeTC7.SelectedItem.Text;
                dm.TxtCamETimeH7 = ddlCamETimeH7.SelectedItem.Text;
                dm.TxtCamETimeM7 = ddlCamETimeM7.SelectedItem.Text;
                //dm.TxtCamETimeTC7 = ddlCamETimeTC7.SelectedItem.Text;
            }
            else
            {
                dm.CamRecorded7 = false;
                dm.CamSTimeH7 = "-1";
                dm.CamSTimeM7 = "-1";
                //dm.CamSTimeTC7 = "-1";
                dm.CamETimeH7 = "-1";
                dm.CamETimeM7 = "-1";
                //dm.CamETimeTC7 = "-1";
            }


            dc.Report_ClubUminaIncidents.InsertOnSubmit(dm);
            dc.SubmitChanges();
        }

        //Reset the Player Id Global Variables
        ReportIncidentCu.PlayerId1 = "";
        ReportIncidentCu.PlayerId2 = "";
        ReportIncidentCu.PlayerId3 = "";
        ReportIncidentCu.PlayerId4 = "";
        ReportIncidentCu.PlayerId5 = "";

        SearchReport.CreateReport = ""; // reset this variable to set ddlCreateReport to default value

        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('Report Submitted.'); window.location='" +
        Request.ApplicationPath + "Default.aspx';", true);
        SearchReport.SetAccordion = "1";
        SearchReport.RunOnStart = true;
        SearchReport.FromCreateReport = true;
    }

    // Once Member had a Textchanged, trigger this
    protected void txtMemberNo1_TextChanged(object sender, EventArgs e)
    {
        Report.MemberNumberChanged = "1";
        string cmdQuery = SearchMember(txtMemberNo1.Text);

        readFiles(cmdQuery, "SearchMember");
    }

    protected void txtMemberNo2_TextChanged(object sender, EventArgs e)
    {
        Report.MemberNumberChanged = "2";
        string cmdQuery = SearchMember(txtMemberNo2.Text);

        readFiles(cmdQuery, "SearchMember");
    }

    protected void txtMemberNo3_TextChanged(object sender, EventArgs e)
    {
        Report.MemberNumberChanged = "3";
        string cmdQuery = SearchMember(txtMemberNo3.Text);

        readFiles(cmdQuery, "SearchMember");
    }

    protected void txtMemberNo4_TextChanged(object sender, EventArgs e)
    {
        Report.MemberNumberChanged = "4";
        string cmdQuery = SearchMember(txtMemberNo4.Text);

        readFiles(cmdQuery, "SearchMember");
    }

    protected void txtMemberNo5_TextChanged(object sender, EventArgs e)
    {
        Report.MemberNumberChanged = "5";
        string cmdQuery = SearchMember(txtMemberNo5.Text);

        readFiles(cmdQuery, "SearchMember");
    }

    protected string SearchMember(string MemberNo)
    {
        string query = "SELECT p.PlayerId, CONVERT(INT, pmn.MembershipNumber) MemberNo, p.FirstName, p.MiddleName, p.LastName, " +
                       "CASE WHEN EXISTS(SELECT pp.Phone FROM PlayerPhone pp, PlayerMembershipNumber pmn WHERE pp.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pp.Phone IS NOT NULL) " +
                            "THEN(SELECT pp.Phone FROM PlayerPhone pp, PlayerMembershipNumber pmn WHERE pp.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pp.Preferred = 'Y') " +
                            "ELSE '' END AS Contact, CONVERT(VARCHAR, pm.DateNominated, 103) AS MemberSince, CONVERT(VARCHAR, p.Birthday, 103) as Birthday, pa.Line1 + ', ' + " +
                       "CASE WHEN EXISTS(SELECT pa.Line2 FROM PlayerAddress pa, PlayerMembershipNumber pmn WHERE pa.PlayerId = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pa.Line2 IS NOT NULL) " +
                            "THEN(SELECT pa.Line2 + ', ' FROM PlayerAddress pa, PlayerMembershipNumber pmn WHERE pa.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "') " +
                            "ELSE '' END + pa.City + ' ' + pa.ZipCode + ' ' + pa.State AS Address, p.Gender, " +
                       "CASE WHEN EXISTS(SELECT pim.PlayerImage FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "') " +
                            "THEN(SELECT pim.PlayerImage FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "' AND pim.Date = (SELECT MAX(pim.Date) FROM PlayerImage pim, PlayerMembershipNumber pmn WHERE pim.PlayerID = pmn.PlayerID AND pmn.MembershipNumber = '" + MemberNo + "')) " +
                            "ELSE NULL " +
                       "END AS PlayerImage " +
                       "FROM Player p, PlayerMembershipNumber pmn, PlayerAddress pa, PlayerMembership pm " +
                       "WHERE p.PlayerId = pmn.PlayerID AND p.PlayerId = pa.PlayerId AND p.PlayerId = pm.PlayerID AND pmn.MembershipNumber NOT LIKE '%V%' AND pmn.MembershipNumber NOT LIKE '%P%' " +
                       "AND pmn.MembershipNumber NOT LIKE '%A%' AND pmn.MembershipNumber NOT LIKE '%M%' AND pmn.MembershipNumber NOT LIKE '%S%' AND pmn.MembershipNumber = '" + MemberNo + "' " +
                       "AND pa.TypeID = 1 " +
                       "ORDER BY CONVERT(INT, pmn.MembershipNumber)";
        return query;
    }

    protected void btnUserSign_Click(object sender, EventArgs e)
    {
        if (cbUserSign.Checked == false)
        {
            alert.DisplayMessage("Please tick the checkbox to digitally sign the form.");
            cbUserSign.Focus();
            return;
        }
        else
        {
            SearchReport.CreateReportReset(); // takes off the selected report in ddlCreateReport

            string WhatHappened, Location, RefuseReason = "", AskedLeaveReason = "", ActionTaken = "",
                   query = "SELECT MAX(ReportId) AS ReportId FROM dbo.Report_ClubUminaIncident";
            int lastRId;

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
                lastRId = 9000001;
            }
            con.Close();

            Report.LastReportId = lastRId.ToString();

            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> YrStrList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in cblWhatHappened1.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList.Add(item.Value);
                }
            }
            // Join the string together using the ; delimiter.
            WhatHappened = String.Join(",", YrStrList.ToArray());
            if (!WhatHappened.Equals(""))
            {
                WhatHappened += ",";
            }

            // if Refuse Entry option is not empty
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            if (List_RefuseReason.SelectedValue != String.Empty)
            {
                List<String> YrStrList2 = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_RefuseReason.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        YrStrList2.Add(item.Value);
                    }
                }
                // Join the string together using the ; delimiter.
                RefuseReason = String.Join(",", YrStrList2.ToArray());
            }

            // if Asked To Leave option is not empty
            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            if (List_AskedToLeave.SelectedValue != String.Empty)
            {
                List<String> YrStrList3 = new List<string>();
                // Loop through each item.
                foreach (ListItem item in List_AskedToLeave.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        YrStrList3.Add(item.Value);
                    }
                }
                // Join the string together using the ; delimiter.
                AskedLeaveReason = String.Join(",", YrStrList3.ToArray());
            }

            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> YrStrList1 = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_Location.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList1.Add(item.Value);
                }
            }
            // Join the string together using the ; delimiter.
            Location = String.Join(",", YrStrList1.ToArray());
            if (!Location.Equals(""))
            {
                Location += ",";
            }

            // store in a string all the selected item in the checkboxlist
            // Create the list to store.
            List<String> YrStrList4 = new List<string>();
            // Loop through each item.
            foreach (ListItem item in List_ActionTaken.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList4.Add(item.Value);
                }
            }
            // Join the string together using the ; delimiter.
            ActionTaken = String.Join(",", YrStrList4.ToArray());
            if (!ActionTaken.Equals(""))
            {
                ActionTaken += ",";
            }

            // change the format of the entry date to timestamp format
            DateTime entry_date = DateTime.Now;

            // validate objects in the form
            int returnedValue = validateForm();
            if (ddlShift.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Shift.";
                ddlShift.Focus();
                returnedValue = 1;
            }

            if (returnedValue == 1)
            {
                HideUserSign();
                alert.DisplayMessage(Report.ErrorMessage);
                Report.ErrorMessage = "";
                return;
            }

            // change the format of the shift date to timestamp format
            DateTime shift_date = DateTime.Parse(txtDatePicker.Text);
            string shift_tDate = shift_date.ToString("yyyyMMdd");
            // separate the shift date day of week value
            string shift_DOW = shift_date.DayOfWeek.ToString();

            // get staff's id
            string cmdText = "SELECT StaffId FROM Staff WHERE Username = '" + Session["Username"] + "'",
                   variable = "getStaff";
            readFiles(cmdText, variable);

            // insert data to table
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                Report_ClubUminaIncident dm = new Report_ClubUminaIncident();
                dm.ReportId = Int32.Parse(Report.LastReportId);
                dm.RCatId = 9;
                dm.StaffId = Int32.Parse(Session["currentStaffId"].ToString());
                dm.StaffName = UserCredentials.DisplayName;
                dm.ShiftId = Int32.Parse(ddlShift.SelectedItem.Value);
                dm.ShiftDate = shift_date.Date;
                dm.ShiftDOW = shift_DOW;
                dm.EntryDate = entry_date;
                dm.Report_Table = "Report_ClubUminaIncident";
                dm.AuditVersion = 1;
                dm.ReportStat = "Awaiting Manager Sign-off";
                dm.Report_Version = 1; // current version
                dm.ReadByList = "," + UserCredentials.StaffId + ",";
                dm.NoOfPerson = Int32.Parse(lblNoOfPerson.Text);
                dm.Date = txtDate1.Text;
                dm.TimeH = ddlHour.SelectedItem.Value;
                dm.TimeM = ddlMinutes.SelectedItem.Value;
                //dm.TimeTC = ddlTimeCon.SelectedItem.Value;
                dm.TxtTimeH = ddlHour.SelectedItem.Text;
                dm.TxtTimeM = ddlMinutes.SelectedItem.Text;
                //dm.TxtTimeTC = ddlTimeCon.SelectedItem.Text;
                dm.Location = Location;
                dm.LocationOther = txtLocation.Text;
                dm.ActionTaken = ActionTaken;
                dm.Details = txtDetails.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.Allegation = txtAllegation.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.IncidentHappened = WhatHappened;
                dm.ActionTakenOther = txtActionTakenOther.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.HappenedOther = txtOthers.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.HappenedSerious = txtOtherSerious.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.HappenedRefuseEntry = RefuseReason;
                dm.HappenedAskedToLeave = AskedLeaveReason;
                dm.SecurityAttend = cbSecurity.Checked;
                dm.SecurityName = txtSecurityName.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PoliceNotify = cbPolice.Checked;
                dm.PoliceAction = txtPoliceAction.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.OfficersName = txtOfficersName.Text.Replace("\n", "<br />").Replace("'", "^");
                dm.PoliceStation = txtPoliceStation.Text.Replace("\n", "<br />").Replace("'", "^");
                // Submit Person Form if visible
                if (acpPerson1.Visible == true)
                {
                    dm.FirstName1 = txtFirstName1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.LastName1 = txtLastName1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PartyType1 = ddlPartyType1.SelectedItem.Value;
                    if (ddlPartyType1.SelectedItem.Value == "1")
                    {
                        dm.PlayerId1 = ReportIncidentCu.PlayerId1;
                        dm.MemberNo1 = txtMemberNo1.Text;
                        // get the member photo again to store it in the database
                        Report.MemberNumberChanged = "1";
                        string cmdQuery = SearchMember(txtMemberNo1.Text);
                        readFiles(cmdQuery, "MemberPhoto");
                        dm.MemberPhoto1 = memberPhoto1;
                        dm.MemberDOB1 = txtDOB1.Text;
                        dm.MemberAddress1 = txtAddress1.Text;
                        dm.CardHeld1 = cbCardHeld1.Checked;
                        dm.MemberSince1 = txtMemberSince1.Text;
                        dm.SignInSlip1 = false;
                    }
                    else if (ddlPartyType1.SelectedItem.Value == "3")
                    {
                        dm.StaffEmpNo1 = txtStaffEmpNo1.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.StaffAddress1 = txtStaffAddress1.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.CardHeld1 = false;
                        dm.SignInSlip1 = false;
                    }
                    else if (ddlPartyType1.SelectedItem.Value == "2")
                    {
                        dm.CardHeld1 = false;
                        dm.SignInSlip1 = cbSignInSlip1.Checked;
                        dm.SignedInBy1 = txtSignInBy1.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorDOB1 = txtDOBv1.Text;
                        dm.VisitorAddress1 = txtAddressv1.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorProofID1 = txtIDProof1.Text.Replace("\n", "<br />").Replace("'", "^");
                    }
                    else
                    {
                        dm.CardHeld1 = false;
                        dm.SignInSlip1 = false;
                    }
                    dm.Witness1 = cbWitness1.Checked;
                    dm.Alias1 = txtAlias1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Contact1 = txtContact1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PDate1 = txtPDate1.Text;
                    dm.PTimeH1 = ddlPTimeH1.SelectedItem.Value;
                    dm.PTimeM1 = ddlPTimeM1.SelectedItem.Value;
                    //dm.PTimeTC1 = ddlPTimeTC1.SelectedItem.Value;
                    dm.Age1 = txtAge1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.AgeGroup1 = ddlAgeGroup1.SelectedItem.Value;
                    //dm.Weight1 = txtWeight1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weight1 = ddlWeight1.SelectedItem.Value;
                    dm.Height1 = txtHeight1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Hair1 = txtHair1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingTop1 = txtClothingTop1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingBottom1 = txtClothingBottom1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Shoes1 = txtShoes1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weapon1 = txtWeapon1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Gender1 = ddlGender1.SelectedItem.Value;
                    dm.DistFeatures1 = txtDistFeatures1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.InjuryDesc1 = txtInjuryDesc1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CauseInjury1 = txtInjuryCause1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Comments1 = txtIncidentComm1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.TxtPartyType1 = ddlPartyType1.SelectedItem.Text;
                    dm.TxtPTimeH1 = ddlPTimeH1.SelectedItem.Text;
                    dm.TxtPTimeM1 = ddlPTimeM1.SelectedItem.Text;
                    //dm.TxtPTimeTC1 = ddlPTimeTC1.SelectedItem.Text;
                    dm.TxtGender1 = ddlGender1.SelectedItem.Text;
                }
                else
                {
                    dm.Witness1 = false;
                    dm.SignInSlip1 = false;
                    dm.CardHeld1 = false;
                    dm.PartyType1 = "-1";
                    dm.PTimeH1 = "-1";
                    dm.PTimeM1 = "-1";
                    //dm.PTimeTC1 = "-1";
                    dm.Gender1 = "-1";
                    dm.AgeGroup1 = "-1";
                }

                if (acpPerson2.Visible == true)
                {
                    dm.FirstName2 = txtFirstName2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.LastName2 = txtLastName2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PartyType2 = ddlPartyType2.SelectedItem.Value;
                    if (ddlPartyType2.SelectedItem.Value == "1")
                    {
                        dm.PlayerId2 = ReportIncidentCu.PlayerId2;
                        dm.MemberNo2 = txtMemberNo2.Text;
                        // get the member photo again to store it in the database
                        Report.MemberNumberChanged = "2";
                        string cmdQuery = SearchMember(txtMemberNo2.Text);
                        readFiles(cmdQuery, "MemberPhoto");
                        dm.MemberPhoto2 = memberPhoto2;
                        dm.MemberDOB2 = txtDOB2.Text;
                        dm.MemberAddress2 = txtAddress2.Text;
                        dm.CardHeld2 = cbCardHeld2.Checked;
                        dm.MemberSince2 = txtMemberSince2.Text;
                        dm.SignInSlip2 = false;
                    }
                    else if (ddlPartyType2.SelectedItem.Value == "3")
                    {
                        dm.StaffEmpNo2 = txtStaffEmpNo2.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.StaffAddress2 = txtStaffAddress2.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.CardHeld2 = false;
                        dm.SignInSlip2 = false;
                    }
                    else if (ddlPartyType2.SelectedItem.Value == "2")
                    {
                        dm.CardHeld2 = false;
                        dm.SignInSlip2 = cbSignInSlip2.Checked;
                        dm.SignedInBy2 = txtSignInBy2.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorDOB2 = txtDOBv2.Text;
                        dm.VisitorAddress2 = txtAddressv2.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorProofID2 = txtIDProof2.Text.Replace("\n", "<br />").Replace("'", "^");
                    }
                    else
                    {
                        dm.CardHeld2 = false;
                        dm.SignInSlip2 = false;
                    }
                    dm.Witness2 = cbWitness2.Checked;
                    dm.Alias2 = txtAlias2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Contact2 = txtContact2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PDate2 = txtPDate2.Text;
                    dm.PTimeH2 = ddlPTimeH2.SelectedItem.Value;
                    dm.PTimeM2 = ddlPTimeM2.SelectedItem.Value;
                    //dm.PTimeTC2 = ddlPTimeTC2.SelectedItem.Value;
                    dm.Age2 = txtAge2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.AgeGroup2 = ddlAgeGroup2.SelectedItem.Value;
                    //dm.Weight2 = txtWeight2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weight2 = ddlWeight2.SelectedItem.Value;
                    dm.Height2 = txtHeight2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Hair2 = txtHair2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingTop2 = txtClothingTop2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingBottom2 = txtClothingBottom2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Shoes2 = txtShoes2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weapon2 = txtWeapon2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Gender2 = ddlGender2.SelectedItem.Value;
                    dm.DistFeatures2 = txtDistFeatures2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.InjuryDesc2 = txtInjuryDesc2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CauseInjury2 = txtInjuryCause2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Comments2 = txtIncidentComm2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.TxtPartyType2 = ddlPartyType2.SelectedItem.Text;
                    dm.TxtPTimeH2 = ddlPTimeH2.SelectedItem.Text;
                    dm.TxtPTimeM2 = ddlPTimeM2.SelectedItem.Text;
                    //dm.TxtPTimeTC2 = ddlPTimeTC2.SelectedItem.Text;
                    dm.TxtGender2 = ddlGender2.SelectedItem.Text;
                }
                else
                {
                    dm.Witness2 = false;
                    dm.SignInSlip2 = false;
                    dm.CardHeld2 = false;
                    dm.PartyType2 = "-1";
                    dm.PTimeH2 = "-1";
                    dm.PTimeM2 = "-1";
                    //dm.PTimeTC2 = "-1";
                    dm.Gender2 = "-1";
                    dm.AgeGroup2 = "-1";
                }

                if (acpPerson3.Visible == true)
                {
                    dm.FirstName3 = txtFirstName3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.LastName3 = txtLastName3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PartyType3 = ddlPartyType3.SelectedItem.Value;
                    if (ddlPartyType3.SelectedItem.Value == "1")
                    {
                        dm.PlayerId3 = ReportIncidentCu.PlayerId3;
                        dm.MemberNo3 = txtMemberNo3.Text;
                        // get the member photo again to store it in the database
                        Report.MemberNumberChanged = "3";
                        string cmdQuery = SearchMember(txtMemberNo3.Text);
                        readFiles(cmdQuery, "MemberPhoto");
                        dm.MemberPhoto3 = memberPhoto3;
                        dm.MemberDOB3 = txtDOB3.Text;
                        dm.MemberAddress3 = txtAddress3.Text;
                        dm.CardHeld3 = cbCardHeld3.Checked;
                        dm.MemberSince3 = txtMemberSince3.Text;
                        dm.SignInSlip3 = false;
                    }
                    else if (ddlPartyType3.SelectedItem.Value == "3")
                    {
                        dm.StaffEmpNo3 = txtStaffEmpNo3.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.StaffAddress3 = txtStaffAddress3.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.CardHeld3 = false;
                        dm.SignInSlip3 = false;
                    }
                    else if (ddlPartyType3.SelectedItem.Value == "2")
                    {
                        dm.CardHeld3 = false;
                        dm.SignInSlip3 = cbSignInSlip3.Checked;
                        dm.SignedInBy3 = txtSignInBy3.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorDOB3 = txtDOBv3.Text;
                        dm.VisitorAddress3 = txtAddressv3.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorProofID3 = txtIDProof3.Text.Replace("\n", "<br />").Replace("'", "^");
                    }
                    else
                    {
                        dm.CardHeld3 = false;
                        dm.SignInSlip3 = false;
                    }
                    dm.Witness3 = cbWitness3.Checked;
                    dm.Alias3 = txtAlias3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Contact3 = txtContact3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PDate3 = txtPDate3.Text;
                    dm.PTimeH3 = ddlPTimeH3.SelectedItem.Value;
                    dm.PTimeM3 = ddlPTimeM3.SelectedItem.Value;
                    //dm.PTimeTC3 = ddlPTimeTC3.SelectedItem.Value;
                    dm.Age3 = txtAge3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.AgeGroup3 = ddlAgeGroup3.SelectedItem.Value;
                    //dm.Weight3 = txtWeight3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weight3 = ddlWeight3.SelectedItem.Value;
                    dm.Height3 = txtHeight3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Hair3 = txtHair3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingTop3 = txtClothingTop3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingBottom3 = txtClothingBottom3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Shoes3 = txtShoes3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weapon3 = txtWeapon3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Gender3 = ddlGender3.SelectedItem.Value;
                    dm.DistFeatures3 = txtDistFeatures3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.InjuryDesc3 = txtInjuryDesc3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CauseInjury3 = txtInjuryCause3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Comments3 = txtIncidentComm3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.TxtPartyType3 = ddlPartyType3.SelectedItem.Text;
                    dm.TxtPTimeH3 = ddlPTimeH3.SelectedItem.Text;
                    dm.TxtPTimeM3 = ddlPTimeM3.SelectedItem.Text;
                    //dm.TxtPTimeTC3 = ddlPTimeTC3.SelectedItem.Text;
                    dm.TxtGender3 = ddlGender3.SelectedItem.Text;
                }
                else
                {
                    dm.Witness3 = false;
                    dm.SignInSlip3 = false;
                    dm.CardHeld3 = false;
                    dm.PartyType3 = "-1";
                    dm.PTimeH3 = "-1";
                    dm.PTimeM3 = "-1";
                    //dm.PTimeTC3 = "-1";
                    dm.Gender3 = "-1";
                    dm.AgeGroup3 = "-1";
                }

                if (acpPerson4.Visible == true)
                {
                    dm.FirstName4 = txtFirstName4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.LastName4 = txtLastName4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PartyType4 = ddlPartyType4.SelectedItem.Value;
                    if (ddlPartyType4.SelectedItem.Value == "1")
                    {
                        dm.PlayerId4 = ReportIncidentCu.PlayerId4;
                        dm.MemberNo4 = txtMemberNo4.Text;
                        // get the member photo again to store it in the database
                        Report.MemberNumberChanged = "4";
                        string cmdQuery = SearchMember(txtMemberNo4.Text);
                        readFiles(cmdQuery, "MemberPhoto");
                        dm.MemberPhoto4 = memberPhoto4;
                        dm.MemberDOB4 = txtDOB4.Text;
                        dm.MemberAddress4 = txtAddress4.Text;
                        dm.CardHeld4 = cbCardHeld4.Checked;
                        dm.MemberSince4 = txtMemberSince4.Text;
                        dm.SignInSlip4 = false;
                    }
                    else if (ddlPartyType4.SelectedItem.Value == "3")
                    {
                        dm.StaffEmpNo4 = txtStaffEmpNo4.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.StaffAddress4 = txtStaffAddress4.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.CardHeld4 = false;
                        dm.SignInSlip4 = false;
                    }
                    else if (ddlPartyType4.SelectedItem.Value == "2")
                    {
                        dm.CardHeld4 = false;
                        dm.SignInSlip4 = cbSignInSlip4.Checked;
                        dm.SignedInBy4 = txtSignInBy4.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorDOB4 = txtDOBv4.Text;
                        dm.VisitorAddress4 = txtAddressv4.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorProofID4 = txtIDProof4.Text.Replace("\n", "<br />").Replace("'", "^");
                    }
                    else
                    {
                        dm.CardHeld4 = false;
                        dm.SignInSlip4 = false;
                    }
                    dm.Witness4 = cbWitness4.Checked;
                    dm.Alias4 = txtAlias4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Contact4 = txtContact4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PDate4 = txtPDate4.Text;
                    dm.PTimeH4 = ddlPTimeH4.SelectedItem.Value;
                    dm.PTimeM4 = ddlPTimeM4.SelectedItem.Value;
                    //dm.PTimeTC4 = ddlPTimeTC4.SelectedItem.Value;
                    dm.Age4 = txtAge4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.AgeGroup4 = ddlAgeGroup4.SelectedItem.Value;
                    //dm.Weight4 = txtWeight4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weight4 = ddlWeight4.SelectedItem.Value;
                    dm.Height4 = txtHeight4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Hair4 = txtHair4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingTop4 = txtClothingTop4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingBottom4 = txtClothingBottom4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Shoes4 = txtShoes4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weapon4 = txtWeapon4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Gender4 = ddlGender4.SelectedItem.Value;
                    dm.DistFeatures4 = txtDistFeatures4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.InjuryDesc4 = txtInjuryDesc4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CauseInjury4 = txtInjuryCause4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Comments4 = txtIncidentComm4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.TxtPartyType4 = ddlPartyType4.SelectedItem.Text;
                    dm.TxtPTimeH4 = ddlPTimeH4.SelectedItem.Text;
                    dm.TxtPTimeM4 = ddlPTimeM4.SelectedItem.Text;
                    //dm.TxtPTimeTC4 = ddlPTimeTC4.SelectedItem.Text;
                    dm.TxtGender4 = ddlGender4.SelectedItem.Text;
                }
                else
                {
                    dm.Witness4 = false;
                    dm.SignInSlip4 = false;
                    dm.CardHeld4 = false;
                    dm.PartyType4 = "-1";
                    dm.PTimeH4 = "-1";
                    dm.PTimeM4 = "-1";
                    //dm.PTimeTC4 = "-1";
                    dm.Gender4 = "-1";
                    dm.AgeGroup4 = "-1";
                }

                if (acpPerson5.Visible == true)
                {
                    dm.FirstName5 = txtFirstName5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.LastName5 = txtLastName5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PartyType5 = ddlPartyType5.SelectedItem.Value;
                    if (ddlPartyType5.SelectedItem.Value == "1")
                    {
                        dm.PlayerId5 = ReportIncidentCu.PlayerId5;
                        dm.MemberNo5 = txtMemberNo5.Text;
                        // get the member photo again to store it in the database
                        Report.MemberNumberChanged = "5";
                        string cmdQuery = SearchMember(txtMemberNo5.Text);
                        readFiles(cmdQuery, "MemberPhoto");
                        dm.MemberPhoto5 = memberPhoto5;
                        dm.MemberDOB5 = txtDOB5.Text;
                        dm.MemberAddress5 = txtAddress5.Text;
                        dm.CardHeld5 = cbCardHeld5.Checked;
                        dm.MemberSince5 = txtMemberSince5.Text;
                        dm.SignInSlip5 = false;
                    }
                    else if (ddlPartyType5.SelectedItem.Value == "3")
                    {
                        dm.StaffEmpNo5 = txtStaffEmpNo5.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.StaffAddress5 = txtStaffAddress5.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.CardHeld5 = false;
                        dm.SignInSlip5 = false;
                    }
                    else if (ddlPartyType5.SelectedItem.Value == "2")
                    {
                        dm.CardHeld5 = false;
                        dm.SignInSlip5 = cbSignInSlip5.Checked;
                        dm.SignedInBy5 = txtSignInBy5.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorDOB5 = txtDOBv5.Text;
                        dm.VisitorAddress5 = txtAddressv5.Text.Replace("\n", "<br />").Replace("'", "^");
                        dm.VisitorProofID5 = txtIDProof5.Text.Replace("\n", "<br />").Replace("'", "^");
                    }
                    else
                    {
                        dm.CardHeld5 = false;
                        dm.SignInSlip5 = false;
                    }
                    dm.Witness5 = cbWitness5.Checked;
                    dm.Alias5 = txtAlias5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Contact5 = txtContact5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.PDate5 = txtPDate5.Text;
                    dm.PTimeH5 = ddlPTimeH5.SelectedItem.Value;
                    dm.PTimeM5 = ddlPTimeM5.SelectedItem.Value;
                    //dm.PTimeTC5 = ddlPTimeTC5.SelectedItem.Value;
                    dm.Age5 = txtAge5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.AgeGroup5 = ddlAgeGroup5.SelectedItem.Value;
                    //dm.Weight5 = txtWeight5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weight5 = ddlWeight5.SelectedItem.Value;
                    dm.Height5 = txtHeight5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Hair5 = txtHair5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingTop5 = txtClothingTop5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.ClothingBottom5 = txtClothingBottom5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Shoes5 = txtShoes5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Weapon5 = txtWeapon5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Gender5 = ddlGender5.SelectedItem.Value;
                    dm.DistFeatures5 = txtDistFeatures5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.InjuryDesc5 = txtInjuryDesc5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CauseInjury5 = txtInjuryCause5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.Comments5 = txtIncidentComm5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.TxtPartyType5 = ddlPartyType5.SelectedItem.Text;
                    dm.TxtPTimeH5 = ddlPTimeH5.SelectedItem.Text;
                    dm.TxtPTimeM5 = ddlPTimeM5.SelectedItem.Text;
                    //dm.TxtPTimeTC5 = ddlPTimeTC5.SelectedItem.Text;
                    dm.TxtGender5 = ddlGender5.SelectedItem.Text;
                }
                else
                {
                    dm.Witness5 = false;
                    dm.SignInSlip5 = false;
                    dm.CardHeld5 = false;
                    dm.PartyType5 = "-1";
                    dm.PTimeH5 = "-1";
                    dm.PTimeM5 = "-1";
                    //dm.PTimeTC5 = "-1";
                    dm.Gender5 = "-1";
                    dm.AgeGroup5 = "-1";
                }

                // Submit Camera Forms if visible
                if (tblCamera1.Visible == true)
                {
                    dm.CamDesc1 = txtCamDesc1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate1 = txtCamSDate1.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH1 = ddlCamTimeH1.SelectedItem.Value;
                    dm.CamSTimeM1 = ddlCamTimeM1.SelectedItem.Value;
                    //dm.CamSTimeTC1 = ddlCamTimeTC1.SelectedItem.Value;
                    dm.CamEDate1 = txtCamEDate1.Text;
                    dm.CamETimeH1 = ddlCamETimeH1.SelectedItem.Value;
                    dm.CamETimeM1 = ddlCamETimeM1.SelectedItem.Value;
                    //dm.CamETimeTC1 = ddlCamETimeTC1.SelectedItem.Value;
                    dm.CamFilePath1 = txtCamFilePath1.Text;
                    dm.CamRecorded1 = cbRecorded1.Checked;
                    dm.TxtCamSTimeH1 = ddlCamTimeH1.SelectedItem.Text;
                    dm.TxtCamSTimeM1 = ddlCamTimeM1.SelectedItem.Text;
                    //dm.TxtCamSTimeTC1 = ddlCamTimeTC1.SelectedItem.Text;
                    dm.TxtCamETimeH1 = ddlCamETimeH1.SelectedItem.Text;
                    dm.TxtCamETimeM1 = ddlCamETimeM1.SelectedItem.Text;
                    //dm.TxtCamETimeTC1 = ddlCamETimeTC1.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded1 = false;
                    dm.CamSTimeH1 = "-1";
                    dm.CamSTimeM1 = "-1";
                    //dm.CamSTimeTC1 = "-1";
                    dm.CamETimeH1 = "-1";
                    dm.CamETimeM1 = "-1";
                    //dm.CamETimeTC1 = "-1";
                }
                if (tblCamera2.Visible == true)
                {
                    dm.CamDesc2 = txtCamDesc2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate2 = txtCamSDate2.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH2 = ddlCamTimeH2.SelectedItem.Value;
                    dm.CamSTimeM2 = ddlCamTimeM2.SelectedItem.Value;
                    //dm.CamSTimeTC2 = ddlCamTimeTC2.SelectedItem.Value;
                    dm.CamEDate2 = txtCamEDate2.Text;
                    dm.CamETimeH2 = ddlCamETimeH2.SelectedItem.Value;
                    dm.CamETimeM2 = ddlCamETimeM2.SelectedItem.Value;
                    //dm.CamETimeTC2 = ddlCamETimeTC2.SelectedItem.Value;
                    dm.CamFilePath2 = txtCamFilePath2.Text;
                    dm.CamRecorded2 = cbRecorded2.Checked;
                    dm.TxtCamSTimeH2 = ddlCamTimeH2.SelectedItem.Text;
                    dm.TxtCamSTimeM2 = ddlCamTimeM2.SelectedItem.Text;
                    //dm.TxtCamSTimeTC2 = ddlCamTimeTC2.SelectedItem.Text;
                    dm.TxtCamETimeH2 = ddlCamETimeH2.SelectedItem.Text;
                    dm.TxtCamETimeM2 = ddlCamETimeM2.SelectedItem.Text;
                    //dm.TxtCamETimeTC2 = ddlCamETimeTC2.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded2 = false;
                    dm.CamSTimeH2 = "-1";
                    dm.CamSTimeM2 = "-1";
                    //dm.CamSTimeTC2 = "-1";
                    dm.CamETimeH2 = "-1";
                    dm.CamETimeM2 = "-1";
                    //dm.CamETimeTC2 = "-1";
                }
                if (tblCamera3.Visible == true)
                {
                    dm.CamDesc3 = txtCamDesc3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate3 = txtCamSDate3.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH3 = ddlCamTimeH3.SelectedItem.Value;
                    dm.CamSTimeM3 = ddlCamTimeM3.SelectedItem.Value;
                    //dm.CamSTimeTC3 = ddlCamTimeTC3.SelectedItem.Value;
                    dm.CamEDate3 = txtCamEDate3.Text;
                    dm.CamETimeH3 = ddlCamETimeH3.SelectedItem.Value;
                    dm.CamETimeM3 = ddlCamETimeM3.SelectedItem.Value;
                    //dm.CamETimeTC3 = ddlCamETimeTC3.SelectedItem.Value;
                    dm.CamFilePath3 = txtCamFilePath3.Text;
                    dm.CamRecorded3 = cbRecorded3.Checked;
                    dm.TxtCamSTimeH3 = ddlCamTimeH3.SelectedItem.Text;
                    dm.TxtCamSTimeM3 = ddlCamTimeM3.SelectedItem.Text;
                    //dm.TxtCamSTimeTC3 = ddlCamTimeTC3.SelectedItem.Text;
                    dm.TxtCamETimeH3 = ddlCamETimeH3.SelectedItem.Text;
                    dm.TxtCamETimeM3 = ddlCamETimeM3.SelectedItem.Text;
                    //dm.TxtCamETimeTC3 = ddlCamETimeTC3.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded3 = false;
                    dm.CamSTimeH3 = "-1";
                    dm.CamSTimeM3 = "-1";
                    //dm.CamSTimeTC3 = "-1";
                    dm.CamETimeH3 = "-1";
                    dm.CamETimeM3 = "-1";
                    //dm.CamETimeTC3 = "-1";
                }
                if (tblCamera4.Visible == true)
                {
                    dm.CamDesc4 = txtCamDesc4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate4 = txtCamSDate4.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH4 = ddlCamTimeH4.SelectedItem.Value;
                    dm.CamSTimeM4 = ddlCamTimeM4.SelectedItem.Value;
                    //dm.CamSTimeTC4 = ddlCamTimeTC4.SelectedItem.Value;
                    dm.CamEDate4 = txtCamEDate4.Text;
                    dm.CamETimeH4 = ddlCamETimeH4.SelectedItem.Value;
                    dm.CamETimeM4 = ddlCamETimeM4.SelectedItem.Value;
                    //dm.CamETimeTC4 = ddlCamETimeTC4.SelectedItem.Value;
                    dm.CamFilePath4 = txtCamFilePath4.Text;
                    dm.CamRecorded4 = cbRecorded4.Checked;
                    dm.TxtCamSTimeH4 = ddlCamTimeH4.SelectedItem.Text;
                    dm.TxtCamSTimeM4 = ddlCamTimeM4.SelectedItem.Text;
                    //dm.TxtCamSTimeTC4 = ddlCamTimeTC4.SelectedItem.Text;
                    dm.TxtCamETimeH4 = ddlCamETimeH4.SelectedItem.Text;
                    dm.TxtCamETimeM4 = ddlCamETimeM4.SelectedItem.Text;
                    //dm.TxtCamETimeTC4 = ddlCamETimeTC4.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded4 = false;
                    dm.CamSTimeH4 = "-1";
                    dm.CamSTimeM4 = "-1";
                    //dm.CamSTimeTC4 = "-1";
                    dm.CamETimeH4 = "-1";
                    dm.CamETimeM4 = "-1";
                    //dm.CamETimeTC4 = "-1";
                }
                if (tblCamera5.Visible == true)
                {
                    dm.CamDesc5 = txtCamDesc5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate5 = txtCamSDate5.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH5 = ddlCamTimeH5.SelectedItem.Value;
                    dm.CamSTimeM5 = ddlCamTimeM5.SelectedItem.Value;
                    //dm.CamSTimeTC5 = ddlCamTimeTC5.SelectedItem.Value;
                    dm.CamEDate5 = txtCamEDate5.Text;
                    dm.CamETimeH5 = ddlCamETimeH5.SelectedItem.Value;
                    dm.CamETimeM5 = ddlCamETimeM5.SelectedItem.Value;
                    //dm.CamETimeTC5 = ddlCamETimeTC5.SelectedItem.Value;
                    dm.CamFilePath5 = txtCamFilePath5.Text;
                    dm.CamRecorded5 = cbRecorded5.Checked;
                    dm.TxtCamSTimeH5 = ddlCamTimeH5.SelectedItem.Text;
                    dm.TxtCamSTimeM5 = ddlCamTimeM5.SelectedItem.Text;
                    //dm.TxtCamSTimeTC5 = ddlCamTimeTC5.SelectedItem.Text;
                    dm.TxtCamETimeH5 = ddlCamETimeH5.SelectedItem.Text;
                    dm.TxtCamETimeM5 = ddlCamETimeM5.SelectedItem.Text;
                    //dm.TxtCamETimeTC5 = ddlCamETimeTC5.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded5 = false;
                    dm.CamSTimeH5 = "-1";
                    dm.CamSTimeM5 = "-1";
                    //dm.CamSTimeTC5 = "-1";
                    dm.CamETimeH5 = "-1";
                    dm.CamETimeM5 = "-1";
                    //dm.CamETimeTC5 = "-1";
                }
                if (tblCamera6.Visible == true)
                {
                    dm.CamDesc6 = txtCamDesc6.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate6 = txtCamSDate6.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH6 = ddlCamTimeH6.SelectedItem.Value;
                    dm.CamSTimeM6 = ddlCamTimeM6.SelectedItem.Value;
                    //dm.CamSTimeTC6 = ddlCamTimeTC6.SelectedItem.Value;
                    dm.CamEDate6 = txtCamEDate6.Text;
                    dm.CamETimeH6 = ddlCamETimeH6.SelectedItem.Value;
                    dm.CamETimeM6 = ddlCamETimeM6.SelectedItem.Value;
                    //dm.CamETimeTC6 = ddlCamETimeTC6.SelectedItem.Value;
                    dm.CamFilePath6 = txtCamFilePath6.Text;
                    dm.CamRecorded6 = cbRecorded6.Checked;
                    dm.TxtCamSTimeH6 = ddlCamTimeH6.SelectedItem.Text;
                    dm.TxtCamSTimeM6 = ddlCamTimeM6.SelectedItem.Text;
                    //dm.TxtCamSTimeTC6 = ddlCamTimeTC6.SelectedItem.Text;
                    dm.TxtCamETimeH6 = ddlCamETimeH6.SelectedItem.Text;
                    dm.TxtCamETimeM6 = ddlCamETimeM6.SelectedItem.Text;
                    //dm.TxtCamETimeTC6 = ddlCamETimeTC6.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded6 = false;
                    dm.CamSTimeH6 = "-1";
                    dm.CamSTimeM6 = "-1";
                    //dm.CamSTimeTC6 = "-1";
                    dm.CamETimeH6 = "-1";
                    dm.CamETimeM6 = "-1";
                    //dm.CamETimeTC6 = "-1";
                }
                if (tblCamera7.Visible == true)
                {
                    dm.CamDesc7 = txtCamDesc7.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSDate7 = txtCamSDate7.Text.Replace("\n", "<br />").Replace("'", "^");
                    dm.CamSTimeH7 = ddlCamTimeH7.SelectedItem.Value;
                    dm.CamSTimeM7 = ddlCamTimeM7.SelectedItem.Value;
                    //dm.CamSTimeTC7 = ddlCamTimeTC7.SelectedItem.Value;
                    dm.CamEDate7 = txtCamEDate7.Text;
                    dm.CamETimeH7 = ddlCamETimeH7.SelectedItem.Value;
                    dm.CamETimeM7 = ddlCamETimeM7.SelectedItem.Value;
                    //dm.CamETimeTC7 = ddlCamETimeTC7.SelectedItem.Value;
                    dm.CamFilePath7 = txtCamFilePath7.Text;
                    dm.CamRecorded7 = cbRecorded7.Checked;
                    dm.TxtCamSTimeH7 = ddlCamTimeH7.SelectedItem.Text;
                    dm.TxtCamSTimeM7 = ddlCamTimeM7.SelectedItem.Text;
                    //dm.TxtCamSTimeTC7 = ddlCamTimeTC7.SelectedItem.Text;
                    dm.TxtCamETimeH7 = ddlCamETimeH7.SelectedItem.Text;
                    dm.TxtCamETimeM7 = ddlCamETimeM7.SelectedItem.Text;
                    //dm.TxtCamETimeTC7 = ddlCamETimeTC7.SelectedItem.Text;
                }
                else
                {
                    dm.CamRecorded7 = false;
                    dm.CamSTimeH7 = "-1";
                    dm.CamSTimeM7 = "-1";
                    //dm.CamSTimeTC7 = "-1";
                    dm.CamETimeH7 = "-1";
                    dm.CamETimeM7 = "-1";
                    //dm.CamETimeTC7 = "-1";
                }


                dc.Report_ClubUminaIncidents.InsertOnSubmit(dm);
                dc.SubmitChanges();
            }

            //Reset the Player Id Global Variables
            ReportIncidentCu.PlayerId1 = "";
            ReportIncidentCu.PlayerId2 = "";
            ReportIncidentCu.PlayerId3 = "";
            ReportIncidentCu.PlayerId4 = "";
            ReportIncidentCu.PlayerId5 = "";

            SearchReport.CreateReport = ""; // reset this variable to set ddlCreateReport to default value

            // set the updated user signature string
            string updateUserSign = UserCredentials.DisplayName + " " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm");

            // insert staff signature
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Report_ClubUminaIncident SET StaffSign='" + updateUserSign + "' WHERE ReportId='" + Report.LastReportId + "' AND AuditVersion='1'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Report Saved.'); window.location='" +
            Request.ApplicationPath + "Default.aspx';", true);
            SearchReport.SetAccordion = "1";
            SearchReport.RunOnStart = true;
            SearchReport.FromCreateReport = true;

            HideUserSign();
        }
    }

    protected void btnCancelUserSign_Click(object sender, EventArgs e)
    {
        HideUserSign();
    }

    protected void HideUserSign()
    {
        body.Style.Add("opacity", "1");
        userSign.Visible = false;

        btnSubmit.Enabled = true;
        btnReset.Enabled = true;
        btnSign.Enabled = true;
    }

    protected void btnSign_Click(object sender, EventArgs e)
    {
        body.Style.Add("opacity", "0.15");
        userSign.Visible = true;
        cbUserSign.Checked = false;

        btnSubmit.Enabled = false;
        btnReset.Enabled = false;
        btnSign.Enabled = false;
    }
}
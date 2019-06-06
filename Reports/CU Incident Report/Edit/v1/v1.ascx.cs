using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQl Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_CU_Incident_Report_Edit_v1_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvantageDb"].ConnectionString);
    byte[] memberPhoto1 = null, memberPhoto2 = null, memberPhoto3 = null, memberPhoto4 = null, memberPhoto5 = null;
    AlertMessage alert = new AlertMessage();

    // on initial postback, reads the stored fields in the database
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Report.PopulateFields) // checks whether or not the method reads the fields from the database
        {
            List_Location.Items.Clear();
            List_AskedToLeave.Items.Clear();
            List_ActionTaken.Items.Clear();
            List_RefuseReason.Items.Clear();
            cblWhatHappened1.Items.Clear();
            ReadFields(Report.ActiveReport, "GetFields");
            Report.PopulateFields = false;
            tblHuman.Visible = false;
            section1.Visible = false;
            // validate objects in the form
            bool returnedValue = checkFields();
            if (returnedValue == true)
            {
                return;
            }
        }
    }

    // validates form, calls validateCameraForm validatePersonForm methods, error message gets displayed once update button is selected
    protected bool validateForm()
    {
        bool returnedFlag = false;
        int result;
        DateTime temp;
        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        // General Incident Report Form
        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";

            returnedFlag = true;
        }
        if (txtDatePicker.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shift Date shouldn't be empty.";

            returnedFlag = true;
        }
        if (!DateTime.TryParse(txtDatePicker.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Shifts Date entry is not in date format please select an appropriate date.";

            returnedFlag = true;
        }
        else
        {
            // compare selected date to current date
            result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDatePicker.Text).ToShortDateString()), date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                returnedFlag = true;
            }
        }

        bool returnedFlag1 = validatePersonForm();
        if (returnedFlag == true || returnedFlag1 == true)
        {
            returnedFlag = true;
        }
        bool returnedFlag2 = validateCameraForm();
        if (returnedFlag == true || returnedFlag2 == true)
        {
            returnedFlag = true;
        }
        // General Incident Report Form
        if (txtDate1.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incident Date shouldn't be empty.";

            returnedFlag = true;
        }
        if (!DateTime.TryParse(txtDate1.Text, out temp))
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incidents Date entry is not in date format please select an appropriate date.";

            returnedFlag = true;
        }
        else
        {
            DateTime date1 = DateTime.Parse(DateTime.Parse(txtDate1.Text).ToShortDateString());
            // compare selected date to current date
            result = DateTime.Compare(date1, date);
            if (result > 0)
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                returnedFlag = true;
            }
        }

        if (ddlHour.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour of the Incident.";

            returnedFlag = true;
        }
        if (ddlMinutes.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes of the Incident.";

            returnedFlag = true;
        }
        /*if (ddlTimeCon.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Time Convention of the Incident");

            returnedFlag = true;

        }*/
        if (List_Location.SelectedValue == String.Empty)
        {
            if (txtLocation.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the location in this Incident Report.";

                returnedFlag = true;
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

                            returnedFlag = true;
                        }
                    }
                }
            }
        }

        if (txtDetails.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incidents Full Details shouldn't be empty.";

            returnedFlag = true;
        }

        if (cblWhatHappened1.SelectedValue == String.Empty)
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select what happened in this Incident Report.";

            returnedFlag = true;
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

                            returnedFlag = true;
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

                            returnedFlag = true;
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

                            returnedFlag = true;
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
                            returnedFlag = true;
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

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtHair1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtClothingTop1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtClothingBottom1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtShoes1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtDistFeatures1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtWeapon1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtInjuryDesc1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 1.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 0;
                            }

                            if (txtPDate1.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date entry shouldn't be empty.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;

                            }
                            if (!DateTime.TryParse(txtPDate1.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Date entry is not in date format please select an appropriate date.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;

                            }
                            else
                            {
                                DateTime date1p = DateTime.Parse(DateTime.Parse(txtPDate1.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date1p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = true;

                                }
                            }
                            if (ddlPTimeH1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 1.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;

                            }
                            if (ddlPTimeM1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 1.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;

                            }
                        }
                        else if (acpPerson1.Visible == false)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Mandatory Fields required with this type of Incident. Please add details of Person(s) involved.";
                            returnedFlag = true;
                        }
                        if (acpPerson2.Visible == true)
                        {
                            if (txtHeight2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtHair2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtClothingTop2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtClothingBottom2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtShoes2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtDistFeatures2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;

                            }

                            if (txtWeapon2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtInjuryDesc2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 2.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 1;
                            }

                            if (txtPDate2.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date entry shouldn't be empty.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                            if (!DateTime.TryParse(txtPDate2.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Date entry is not in date format please select an appropriate date.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                            else
                            {
                                DateTime date2p = DateTime.Parse(DateTime.Parse(txtPDate2.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date2p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = true;

                                }
                            }
                            if (ddlPTimeH2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 2.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                            if (ddlPTimeM2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 2.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson3.Visible == true)
                        {
                            if (txtHeight3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtHair3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtClothingTop3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtClothingBottom3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtShoes3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtDistFeatures3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtWeapon3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtInjuryDesc3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 3.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 2;
                            }

                            if (txtPDate3.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date entry shouldn't be empty.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                            if (!DateTime.TryParse(txtPDate3.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Date entry is not in date format please select an appropriate date.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                            else
                            {
                                DateTime date3p = DateTime.Parse(DateTime.Parse(txtPDate3.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date3p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = true;

                                }
                            }
                            if (ddlPTimeH3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 3.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                            if (ddlPTimeM3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 3.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson4.Visible == true)
                        {
                            if (txtHeight4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtHair4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtClothingTop4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtClothingBottom4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtShoes4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtDistFeatures4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtWeapon4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtInjuryDesc4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 4.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 3;
                            }

                            if (txtPDate4.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date entry shouldn't be empty.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                            if (!DateTime.TryParse(txtPDate4.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Date entry is not in date format please select an appropriate date.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                            else
                            {
                                DateTime date4p = DateTime.Parse(DateTime.Parse(txtPDate4.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date4p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = true;

                                }
                            }
                            if (ddlPTimeH4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 4.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                            if (ddlPTimeM4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 4.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson5.Visible == true)
                        {
                            if (txtHeight5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Height is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtHair5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Hair is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtClothingTop5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Top is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtClothingBottom5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Clothing Bottom is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtShoes5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Shoes is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtDistFeatures5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Distinct Features is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtWeapon5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Weapon is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtInjuryDesc5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Injury Description is mandatory for Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;
                            }

                            if (txtPDate5.Text == "")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date entry shouldn't be empty.";

                                acdPerson.SelectedIndex = 4;
                                returnedFlag = true;

                            }
                            if (!DateTime.TryParse(txtPDate5.Text, out temp))
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Date entry is not in date format please select an appropriate date.";

                                acdPerson.SelectedIndex = 4;
                                returnedFlag = true;

                            }
                            else
                            {
                                DateTime date5p = DateTime.Parse(DateTime.Parse(txtPDate5.Text).ToShortDateString());
                                // compare selected date to current date
                                result = DateTime.Compare(date5p, date);
                                if (result > 0)
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = true;

                                }
                            }
                            if (ddlPTimeH5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Hour entry of Person 5.";

                                acdPerson.SelectedIndex = 4;
                                returnedFlag = true;

                            }
                            if (ddlPTimeM5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select the Minutes entry of Person 5.";

                                returnedFlag = true;
                                acdPerson.SelectedIndex = 4;

                            }
                        }
                        if (List_ActionTaken.SelectedValue == String.Empty)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Action Taken is mandatory for this Incident.";

                            returnedFlag = true;
                        }
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

                                        returnedFlag = true;
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

                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = true;
                                }

                                if (txtLastName1.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's Last Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 0;
                                    returnedFlag = true;
                                }

                                if (txtContact1.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 1.";

                                    returnedFlag = true;
                                    acdPerson.SelectedIndex = 0;
                                }
                            }

                            if (txtAge1.Text == "" && ddlAgeGroup1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 1's Age.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;
                            }

                            if (ddlGender1.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 1's Gender.";

                                acdPerson.SelectedIndex = 0;
                                returnedFlag = true;
                            }
                        }
                        else if (acpPerson1.Visible == false)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* Mandatory Fields required with this type of Incident. Please add details of Person(s) involved.";
                            returnedFlag = true;
                        }
                        if (acpPerson2.Visible == true)
                        {
                            if (ddlPartyType2.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's First Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = true;
                                }
                                if (txtLastName2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's Last Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 1;
                                    returnedFlag = true;
                                }
                                if (txtContact2.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 2.";

                                    returnedFlag = true;
                                    acdPerson.SelectedIndex = 1;
                                }
                            }

                            if (txtAge2.Text == "" && ddlAgeGroup2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 2's Age.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                            if (ddlGender2.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 2's Gender.";

                                acdPerson.SelectedIndex = 1;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson3.Visible == true)
                        {
                            if (ddlPartyType3.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's First Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = true;
                                }
                                if (txtLastName3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's Last Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 2;
                                    returnedFlag = true;
                                }
                                if (txtContact3.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 3.";

                                    returnedFlag = true;
                                    acdPerson.SelectedIndex = 2;
                                }
                            }

                            if (txtAge3.Text == "" && ddlAgeGroup3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 3's Age.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                            if (ddlGender3.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 3's Gender.";

                                acdPerson.SelectedIndex = 2;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson4.Visible == true)
                        {
                            if (ddlPartyType4.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's First Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = true;
                                }
                                if (txtLastName4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's Last Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 3;
                                    returnedFlag = true;
                                }
                                if (txtContact4.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 4.";

                                    returnedFlag = true;
                                    acdPerson.SelectedIndex = 3;
                                }
                            }

                            if (txtAge4.Text == "" && ddlAgeGroup4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 4's Age.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                            if (ddlGender4.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 4's Gender.";

                                acdPerson.SelectedIndex = 3;
                                returnedFlag = true;

                            }
                        }
                        if (acpPerson5.Visible == true)
                        {
                            if (ddlPartyType5.SelectedItem.Text != "Unknown")
                            {
                                if (txtFirstName5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's First Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = true;
                                }
                                if (txtLastName5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's Last Name shouldn't be empty.";

                                    acdPerson.SelectedIndex = 4;
                                    returnedFlag = true;
                                }
                                if (txtContact5.Text == "")
                                {
                                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Contact is mandatory for Person 5.";

                                    returnedFlag = true;
                                    acdPerson.SelectedIndex = 4;
                                }
                            }
                            if (txtAge5.Text == "" && ddlAgeGroup5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Person 5's Age.";

                                acdPerson.SelectedIndex = 4;
                                returnedFlag = true;

                            }
                            if (ddlGender5.SelectedItem.Value.ToString() == "-1")
                            {
                                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select Person 5's Gender.";

                                acdPerson.SelectedIndex = 4;
                                returnedFlag = true;

                            }
                        }
                    }
                }
            }
        }

        if (txtAllegation.Text == "")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Incidents Allegation shouldn't be empty.";

            returnedFlag = true;
        }

        // Security Officer
        if (cbSecurity.Checked == true)
        {
            if (txtSecurityName.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Security name shouldn't be empty.";

                returnedFlag = true;
            }
        }

        // Police Station
        if (cbPolice.Checked == true)
        {
            if (txtPoliceStation.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Police Station shouldn't be empty.";

                returnedFlag = true;
            }
            if (txtOfficersName.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Officer's Name shouldn't be empty.";

                returnedFlag = true;
            }
            if (txtPoliceAction.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Police's action shouldn't be empty.";

                returnedFlag = true;
            }
        }

        return returnedFlag;
    }
    protected bool validateCameraForm()
    {
        DateTime temp;
        bool returnedFlag = false;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        // Camera Forms
        if (tblCamera1.Visible == true)
        {
            if (txtCamDesc1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate1.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date1Sc = DateTime.Parse(DateTime.Parse(txtCamSDate1.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date1Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 1.";

                returnedFlag = true;

            }
            if (ddlCamTimeM1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 1.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 1.";

                returnedFlag = true;

            }*/
            if (txtCamEDate1.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate1.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 1's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {

                DateTime date1Ec = DateTime.Parse(DateTime.Parse(txtCamEDate1.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date1Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 1.";

                returnedFlag = true;

            }
            if (ddlCamETimeM1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 1.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 1.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera2.Visible == true)
        {
            if (txtCamDesc2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate2.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {

                DateTime date2Sc = DateTime.Parse(DateTime.Parse(txtCamSDate2.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date2Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 2.";

                returnedFlag = true;

            }
            if (ddlCamTimeM2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 2.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 2.";

                returnedFlag = true;

            }*/
            if (txtCamEDate2.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate2.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 2's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {

                DateTime date2Ec = DateTime.Parse(DateTime.Parse(txtCamEDate2.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date2Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 2.";

                returnedFlag = true;

            }
            if (ddlCamETimeM2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 2.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 2.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera3.Visible == true)
        {
            if (txtCamDesc3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate3.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {

                DateTime date3Sc = DateTime.Parse(DateTime.Parse(txtCamSDate3.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date3Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 3.";

                returnedFlag = true;

            }
            if (ddlCamTimeM3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 3.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 3.";

                returnedFlag = true;

            }*/
            if (txtCamEDate3.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate3.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 3's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date3Ec = DateTime.Parse(DateTime.Parse(txtCamEDate3.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date3Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 3.";

                returnedFlag = true;

            }
            if (ddlCamETimeM3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 3.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 3.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera4.Visible == true)
        {
            if (txtCamDesc4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate4.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {

                DateTime date4Sc = DateTime.Parse(DateTime.Parse(txtCamSDate4.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date4Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 4.";

                returnedFlag = true;

            }
            if (ddlCamTimeM4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 4.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 4.";

                returnedFlag = true;

            }*/
            if (txtCamEDate4.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate4.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 4's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date4Ec = DateTime.Parse(DateTime.Parse(txtCamEDate4.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date4Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 4.";

                returnedFlag = true;

            }
            if (ddlCamETimeM4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 4.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 4.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera5.Visible == true)
        {
            if (txtCamDesc5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate5.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date5Sc = DateTime.Parse(DateTime.Parse(txtCamSDate5.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date5Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 5.";

                returnedFlag = true;

            }
            if (ddlCamTimeM5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 5.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 5.";

                returnedFlag = true;

            }*/
            if (txtCamEDate5.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate5.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 5's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date5Ec = DateTime.Parse(DateTime.Parse(txtCamEDate5.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date5Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 5.";

                returnedFlag = true;

            }
            if (ddlCamETimeM5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 5.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 5.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera6.Visible == true)
        {
            if (txtCamDesc6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate6.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date6Sc = DateTime.Parse(DateTime.Parse(txtCamSDate6.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date6Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 6.";

                returnedFlag = true;

            }
            if (ddlCamTimeM6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 6.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 6.";

                returnedFlag = true;

            }*/
            if (txtCamEDate6.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate6.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 6's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date6Ec = DateTime.Parse(DateTime.Parse(txtCamEDate6.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date6Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 6.";

                returnedFlag = true;

            }
            if (ddlCamETimeM6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 6.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC6.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 6.";

                returnedFlag = true;

            }*/
        }
        if (tblCamera7.Visible == true)
        {
            if (txtCamDesc7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7 should not be empty. If there's no Camera Footage taken please enter N/A in the textbox.";

                returnedFlag = true;

            }
            if (txtCamSDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (txtCamSDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Start Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamSDate7.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date7Sc = DateTime.Parse(DateTime.Parse(txtCamSDate7.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date7Sc, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamTimeH7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 7.";

                returnedFlag = true;

            }
            if (ddlCamTimeM7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 7.";

                returnedFlag = true;

            }
            /*if (ddlCamTimeTC7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 7.";

                returnedFlag = true;

            }*/
            if (txtCamEDate7.Text == "")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's End Date shouldn't be empty.";

                returnedFlag = true;

            }
            if (!DateTime.TryParse(txtCamEDate7.Text, out temp))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Camera 7's Date entry is not in date format please select an appropriate date.";

                returnedFlag = true;

            }
            else
            {
                DateTime date7Ec = DateTime.Parse(DateTime.Parse(txtCamEDate7.Text).ToShortDateString());
                // compare selected date to current date
                result = DateTime.Compare(date7Ec, date);
                if (result > 0)
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                    returnedFlag = true;

                }
            }
            if (ddlCamETimeH7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select an Hour value for Camera 7.";

                returnedFlag = true;

            }
            if (ddlCamETimeM7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Minute value for Camera 7.";

                returnedFlag = true;

            }
            /*if (ddlCamETimeTC7.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Time Convention for Camera 7.";

                returnedFlag = true;

            }*/
        }

        return returnedFlag;
    }
    protected bool validatePersonForm()
    {
        DateTime temp;
        bool returnedFlag = false;
        int result;

        // compare date entered to current date
        DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());

        if (!Report.HasMember)
        {
            if (Report.MemberNumberChanged.Equals("1"))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member No. for Person 1.";

                acdPerson.SelectedIndex = 0;
                returnedFlag = true;
            }
            else if (Report.MemberNumberChanged.Equals("2"))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member No. for Person 2.";

                acdPerson.SelectedIndex = 1;
                returnedFlag = true;
            }
            else if (Report.MemberNumberChanged.Equals("3"))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member No. for Person 3.";

                acdPerson.SelectedIndex = 2;
                returnedFlag = true;
            }
            else if (Report.MemberNumberChanged.Equals("4"))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member No. for Person 4";

                acdPerson.SelectedIndex = 3;
                returnedFlag = true;
            }
            else if (Report.MemberNumberChanged.Equals("5"))
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Member Not Found! Please enter another Member No. for Person 5.";

                acdPerson.SelectedIndex = 4;
                returnedFlag = true;
            }
        }

        // Person 1
        if (acpPerson1.Visible == true)
        {
            if (ddlPartyType1.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 1.";

                acdPerson.SelectedIndex = 0;
                returnedFlag = true;
            }

            if (ddlPartyType1.SelectedItem.Value == "1")
            {
                if (txtMemberNo1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member No for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;
                }
                if (txtAddress1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;
                }
                if (txtDOB1.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB1.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 0;
                        returnedFlag = true;
                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB1.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 0;
                            returnedFlag = true;
                        }
                    }
                }
            }
            if (ddlPartyType1.SelectedItem.Value == "2")
            {
                if (cbSignInSlip1.Checked == true)
                {
                    if (txtSignInBy1.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in Person 1 .";

                        acdPerson.SelectedIndex = 0;
                        returnedFlag = true;
                    }
                }
                if (txtIDProof1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;
                }
                if (txtAddressv1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;
                }
                if (txtDOBv1.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv1.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 1's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 0;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv1.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 0;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType1.SelectedItem.Value == "3")
            {
                if (txtStaffEmpNo1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Staff Employee No for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;

                }
                if (txtStaffAddress1.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 1.";

                    acdPerson.SelectedIndex = 0;
                    returnedFlag = true;

                }
            }
        }
        // Person 2
        if (acpPerson2.Visible == true)
        {
            if (ddlPartyType2.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 2.";

                acdPerson.SelectedIndex = 1;
                returnedFlag = true;

            }

            if (ddlPartyType2.SelectedItem.Value == "1")
            {
                if (txtMemberNo2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member No for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
                if (txtAddress2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
                if (txtDOB2.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB2.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 1;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB2.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 1;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType2.SelectedItem.Value == "2")
            {
                if (cbSignInSlip2.Checked == true)
                {
                    if (txtSignInBy2.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in Person 2.";

                        acdPerson.SelectedIndex = 1;
                        returnedFlag = true;

                    }
                }
                if (txtIDProof2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
                if (txtAddressv2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
                if (txtDOBv2.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv2.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 2's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 1;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv2.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 1;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType2.SelectedItem.Value == "3")
            {
                if (txtStaffEmpNo2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Staff Employee No for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
                if (txtStaffAddress2.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 2.";

                    acdPerson.SelectedIndex = 1;
                    returnedFlag = true;

                }
            }
        }
        // Person 3
        if (acpPerson3.Visible == true)
        {
            if (ddlPartyType3.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 3.";

                acdPerson.SelectedIndex = 2;
                returnedFlag = true;

            }

            if (ddlPartyType3.SelectedItem.Value == "1")
            {
                if (txtMemberNo3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member No for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
                if (txtAddress3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
                if (txtDOB3.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB3.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 2;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB3.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 2;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType3.SelectedItem.Value == "2")
            {
                if (cbSignInSlip3.Checked == true)
                {
                    if (txtSignInBy3.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in Person 3 .";

                        acdPerson.SelectedIndex = 2;
                        returnedFlag = true;

                    }
                }
                if (txtIDProof3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
                if (txtAddressv3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
                if (txtDOBv3.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv3.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 3's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 2;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv3.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 2;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType3.SelectedItem.Value == "3")
            {
                if (txtStaffEmpNo3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Staff Employee No for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
                if (txtStaffAddress3.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 3.";

                    acdPerson.SelectedIndex = 2;
                    returnedFlag = true;

                }
            }
        }
        // Person 4
        if (acpPerson4.Visible == true)
        {
            if (ddlPartyType4.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 4.";

                acdPerson.SelectedIndex = 3;
                returnedFlag = true;

            }

            if (ddlPartyType4.SelectedItem.Value == "1")
            {
                if (txtMemberNo4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member No for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
                if (txtAddress4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
                if (txtDOB4.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB4.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 3;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB4.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 3;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType4.SelectedItem.Value == "2")
            {
                if (cbSignInSlip4.Checked == true)
                {
                    if (txtSignInBy4.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in Person 4 .";

                        acdPerson.SelectedIndex = 3;
                        returnedFlag = true;

                    }
                }
                if (txtIDProof4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
                if (txtAddressv4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
                if (txtDOBv4.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv4.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 4's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 3;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv4.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 3;
                            returnedFlag = true;

                        }
                    }
                }
            }
            if (ddlPartyType4.SelectedItem.Value == "3")
            {
                if (txtStaffEmpNo4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Staff Employee No for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
                if (txtStaffAddress4.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 4.";

                    acdPerson.SelectedIndex = 3;
                    returnedFlag = true;

                }
            }
        }
        // Person 5
        if (acpPerson5.Visible == true)
        {
            if (ddlPartyType5.SelectedItem.Value == "-1")
            {
                Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select one Party Type for Person 5.";

                acdPerson.SelectedIndex = 4;
                returnedFlag = true;

            }

            if (ddlPartyType5.SelectedItem.Value == "1")
            {
                if (txtMemberNo5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Member No for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
                if (txtAddress5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
                if (txtDOB5.Text != "")
                {
                    if (!DateTime.TryParse(txtDOB5.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 4;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOB5.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 4;
                            returnedFlag = true;
                        }
                    }
                }
            }
            if (ddlPartyType5.SelectedItem.Value == "2")
            {
                if (cbSignInSlip5.Checked == true)
                {
                    if (txtSignInBy5.Text == "")
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter who signed in Person 5 .";

                        acdPerson.SelectedIndex = 4;
                        returnedFlag = true;

                    }
                }
                if (txtIDProof5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Proof of Identity for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
                if (txtAddressv5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
                if (txtDOBv5.Text != "")
                {
                    if (!DateTime.TryParse(txtDOBv5.Text, out temp))
                    {
                        Report.ErrorMessage = Report.ErrorMessage + "\\n* Person 5's DOB is not in date format please select an appropriate date.";

                        acdPerson.SelectedIndex = 4;
                        returnedFlag = true;

                    }
                    else
                    {
                        // compare selected date to current date
                        result = DateTime.Compare(DateTime.Parse(DateTime.Parse(txtDOBv5.Text).ToShortDateString()), date);
                        if (result > 0)
                        {
                            Report.ErrorMessage = Report.ErrorMessage + "\\n* DATE MUST BE BEFORE CURRENT DATE.";

                            acdPerson.SelectedIndex = 4;
                            returnedFlag = true;
                        }
                    }
                }
            }
            if (ddlPartyType5.SelectedItem.Value == "3")
            {
                if (txtStaffEmpNo5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Staff Employee No for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
                if (txtStaffAddress5.Text == "")
                {
                    Report.ErrorMessage = Report.ErrorMessage + "\\n* Please enter Address for Person 5.";

                    acdPerson.SelectedIndex = 4;
                    returnedFlag = true;

                }
            }
        }

        return returnedFlag;
    }

    // reads the fields in the database
    protected void ReadFields(string sqlCommand, string method)
    {
        // read files from sql database
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        if (method.Equals("SearchMember"))
        {
            cmd = new SqlCommand(sqlCommand, con1);
        }
        else
        {
            cmd = new SqlCommand(sqlCommand, con);
        }

        try
        {
            if (method.Equals("SearchMember"))
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
                    if (method.Equals("GetFields"))
                    {
                        lblReportName.Text = rdr["ReportName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblReportId.Text = rdr["ReportId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblStaffName.Text = rdr["StaffName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        Report.SelectedStaffId = rdr["StaffId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlShift.SelectedIndex = Int32.Parse(rdr["ShiftId"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        Report.ShiftId = ddlShift.SelectedIndex.ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtDatePicker.Text = Convert.ToDateTime(rdr["ShiftDate"]).ToString("dddd, dd MMMM yyyy");
                        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString().Replace("<br />", "\n").Replace("^", "'");
                        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString().Replace("<br />", "\n").Replace("^", "'")).DayOfWeek.ToString().Replace("<br />", "\n").Replace("^", "'");
                        lblEntryDetails.Text = Convert.ToDateTime(rdr["EntryDate"]).ToString("dd/MM/yyyy HH:mm");
                        Report.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Person 1 */
                        txtFirstName1.Text = rdr["FirstName1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLastName1.Text = rdr["LastName1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtContact1.Text = rdr["Contact1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAlias1.Text = rdr["Alias1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPartyType1.SelectedIndex = Int32.Parse(rdr["PartyType1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        if (ddlPartyType1.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                        {
                            txtFirstName1.Enabled = false;
                            txtLastName1.Enabled = false;
                            txtAge1.Enabled = false;
                            txtDOB1.Enabled = false;

                            // member's fields
                            cbCardHeld1.Checked = Convert.ToBoolean(rdr["CardHeld1"]);
                            ReportIncidentCu.PlayerId1 = rdr["PlayerId1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberNo1.Text = rdr["MemberNo1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOB1.Text = rdr["MemberDOB1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddress1.Text = rdr["MemberAddress1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberSince1.Text = rdr["MemberSince1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType1.SelectedItem.Value == "2") // if person is a visitor read following objects
                        {
                            // visitor's fields
                            cbSignInSlip1.Checked = Convert.ToBoolean(rdr["SignInSlip1"]);
                            txtSignInBy1.Text = rdr["SignedInBy1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOBv1.Text = rdr["VisitorDOB1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtIDProof1.Text = rdr["VisitorProofID1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddressv1.Text = rdr["VisitorAddress1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType1.SelectedItem.Value == "3") // if person is a staff read following objects
                        {
                            // staff's fields
                            txtStaffEmpNo1.Text = rdr["StaffEmpNo1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtStaffAddress1.Text = rdr["StaffAddress1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }

                        // display label 'Number of Persons Involved' (noOfPerson) and the label of the actual number of persons involved (noPerson1)
                        noOfPerson.Visible = true;
                        lblNoOfPerson.Text = rdr["NoOfPerson"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        noOfPerson1.Visible = true;

                        txtPDate1.Text = rdr["PDate1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPTimeH1.SelectedIndex = Int32.Parse(rdr["PTimeH1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlPTimeM1.SelectedIndex = Int32.Parse(rdr["PTimeM1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlPTimeTC1.SelectedIndex = Int32.Parse(rdr["PTimeTC1"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        cbWitness1.Checked = Convert.ToBoolean(rdr["Witness1"]);
                        txtAge1.Text = rdr["Age1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlAgeGroup1.SelectedValue = rdr["AgeGroup1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        //txtWeight1.Text = rdr["Weight1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlWeight1.SelectedValue = rdr["Weight1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHeight1.Text = rdr["Height1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHair1.Text = rdr["Hair1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingTop1.Text = rdr["ClothingTop1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingBottom1.Text = rdr["ClothingBottom1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtShoes1.Text = rdr["Shoes1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWeapon1.Text = rdr["Weapon1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlGender1.SelectedIndex = Int32.Parse(rdr["Gender1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtDistFeatures1.Text = rdr["DistFeatures1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryDesc1.Text = rdr["InjuryDesc1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryCause1.Text = rdr["CauseInjury1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidentComm1.Text = rdr["Comments1"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Person 2 */
                        txtFirstName2.Text = rdr["FirstName2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLastName2.Text = rdr["LastName2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAlias2.Text = rdr["Alias2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtContact2.Text = rdr["Contact2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPartyType2.SelectedIndex = Int32.Parse(rdr["PartyType2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        if (ddlPartyType2.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                        {
                            txtFirstName2.Enabled = false;
                            txtLastName2.Enabled = false;
                            txtAge2.Enabled = false;
                            txtDOB2.Enabled = false;

                            // member's fields
                            cbCardHeld2.Checked = Convert.ToBoolean(rdr["CardHeld2"]);
                            ReportIncidentCu.PlayerId2 = rdr["PlayerId2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberNo2.Text = rdr["MemberNo2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOB2.Text = rdr["MemberDOB2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddress2.Text = rdr["MemberAddress2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberSince2.Text = rdr["MemberSince2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType2.SelectedItem.Value == "2") // if person is a visitor read following objects
                        {
                            // visitor's fields
                            cbSignInSlip2.Checked = Convert.ToBoolean(rdr["SignInSlip2"]);
                            txtSignInBy2.Text = rdr["SignedInBy2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOBv2.Text = rdr["VisitorDOB2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtIDProof2.Text = rdr["VisitorProofID2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddressv2.Text = rdr["VisitorAddress2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType2.SelectedItem.Value == "3") // if person is a staff read following objects
                        {
                            // staff's fields
                            txtStaffEmpNo2.Text = rdr["StaffEmpNo2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtStaffAddress2.Text = rdr["StaffAddress2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }

                        txtPDate2.Text = rdr["PDate2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPTimeH2.SelectedIndex = Int32.Parse(rdr["PTimeH2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlPTimeM2.SelectedIndex = Int32.Parse(rdr["PTimeM2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlPTimeTC2.SelectedIndex = Int32.Parse(rdr["PTimeTC2"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        cbWitness2.Checked = Convert.ToBoolean(rdr["Witness2"]);
                        txtAge2.Text = rdr["Age2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlAgeGroup2.SelectedValue = rdr["AgeGroup2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        //txtWeight2.Text = rdr["Weight2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlWeight2.SelectedValue = rdr["Weight2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHeight2.Text = rdr["Height2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHair2.Text = rdr["Hair2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingTop2.Text = rdr["ClothingTop2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingBottom2.Text = rdr["ClothingBottom2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtShoes2.Text = rdr["Shoes2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWeapon2.Text = rdr["Weapon2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlGender2.SelectedIndex = Int32.Parse(rdr["Gender2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtDistFeatures2.Text = rdr["DistFeatures2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryDesc2.Text = rdr["InjuryDesc2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryCause2.Text = rdr["CauseInjury2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidentComm2.Text = rdr["Comments2"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Person 3 */
                        txtFirstName3.Text = rdr["FirstName3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLastName3.Text = rdr["LastName3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAlias3.Text = rdr["Alias3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtContact3.Text = rdr["Contact3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPartyType3.SelectedIndex = Int32.Parse(rdr["PartyType3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        if (ddlPartyType3.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                        {
                            txtFirstName3.Enabled = false;
                            txtLastName3.Enabled = false;
                            txtAge3.Enabled = false;
                            txtDOB3.Enabled = false;

                            // member's fields
                            cbCardHeld3.Checked = Convert.ToBoolean(rdr["CardHeld3"]);
                            ReportIncidentCu.PlayerId3 = rdr["PlayerId3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberNo3.Text = rdr["MemberNo3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOB3.Text = rdr["MemberDOB3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddress3.Text = rdr["MemberAddress3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberSince3.Text = rdr["MemberSince3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType3.SelectedItem.Value == "2") // if person is a visitor read following objects
                        {
                            // visitor's fields
                            cbSignInSlip3.Checked = Convert.ToBoolean(rdr["SignInSlip3"]);
                            txtSignInBy3.Text = rdr["SignedInBy3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOBv3.Text = rdr["VisitorDOB3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtIDProof3.Text = rdr["VisitorProofID3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddressv3.Text = rdr["VisitorAddress3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType3.SelectedItem.Value == "3") // if person is a staff read following objects
                        {
                            // staff's fields
                            txtStaffEmpNo3.Text = rdr["StaffEmpNo3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtStaffAddress3.Text = rdr["StaffAddress3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }

                        txtPDate3.Text = rdr["PDate3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPTimeH3.SelectedIndex = Int32.Parse(rdr["PTimeH3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlPTimeM3.SelectedIndex = Int32.Parse(rdr["PTimeM3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlPTimeTC3.SelectedIndex = Int32.Parse(rdr["PTimeTC3"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        cbWitness3.Checked = Convert.ToBoolean(rdr["Witness3"]);
                        txtAge3.Text = rdr["Age3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlAgeGroup3.SelectedValue = rdr["AgeGroup3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        //txtWeight3.Text = rdr["Weight3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlWeight3.SelectedValue = rdr["Weight3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHeight3.Text = rdr["Height3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHair3.Text = rdr["Hair3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingTop3.Text = rdr["ClothingTop3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingBottom3.Text = rdr["ClothingBottom3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtShoes3.Text = rdr["Shoes3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWeapon3.Text = rdr["Weapon3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlGender3.SelectedIndex = Int32.Parse(rdr["Gender3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtDistFeatures3.Text = rdr["DistFeatures3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryDesc3.Text = rdr["InjuryDesc3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryCause3.Text = rdr["CauseInjury3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidentComm3.Text = rdr["Comments3"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Person 4 */
                        txtFirstName4.Text = rdr["FirstName4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLastName4.Text = rdr["LastName4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAlias4.Text = rdr["Alias4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtContact4.Text = rdr["Contact4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPartyType4.SelectedIndex = Int32.Parse(rdr["PartyType4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        if (ddlPartyType4.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                        {
                            txtFirstName4.Enabled = false;
                            txtLastName4.Enabled = false;
                            txtAge4.Enabled = false;
                            txtDOB4.Enabled = false;

                            // member's fields
                            cbCardHeld4.Checked = Convert.ToBoolean(rdr["CardHeld4"]);
                            ReportIncidentCu.PlayerId4 = rdr["PlayerId4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberNo4.Text = rdr["MemberNo4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOB4.Text = rdr["MemberDOB4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddress4.Text = rdr["MemberAddress4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberSince4.Text = rdr["MemberSince4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType4.SelectedItem.Value == "2") // if person is a visitor read following objects
                        {
                            // visitor's fields
                            cbSignInSlip4.Checked = Convert.ToBoolean(rdr["SignInSlip4"]);
                            txtSignInBy4.Text = rdr["SignedInBy4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOBv4.Text = rdr["VisitorDOB4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtIDProof4.Text = rdr["VisitorProofID4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddressv4.Text = rdr["VisitorAddress4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType4.SelectedItem.Value == "3") // if person is a staff read following objects
                        {
                            // staff's fields
                            txtStaffEmpNo4.Text = rdr["StaffEmpNo4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtStaffAddress4.Text = rdr["StaffAddress4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }

                        txtPDate4.Text = rdr["PDate4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPTimeH4.SelectedIndex = Int32.Parse(rdr["PTimeH4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlPTimeM4.SelectedIndex = Int32.Parse(rdr["PTimeM4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlPTimeTC4.SelectedIndex = Int32.Parse(rdr["PTimeTC4"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        cbWitness4.Checked = Convert.ToBoolean(rdr["Witness4"]);
                        txtAge4.Text = rdr["Age4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlAgeGroup4.SelectedValue = rdr["AgeGroup4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        //txtWeight4.Text = rdr["Weight4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlWeight4.SelectedValue = rdr["Weight4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHeight4.Text = rdr["Height4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHair4.Text = rdr["Hair4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingTop4.Text = rdr["ClothingTop4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingBottom4.Text = rdr["ClothingBottom4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtShoes4.Text = rdr["Shoes4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWeapon4.Text = rdr["Weapon4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlGender4.SelectedIndex = Int32.Parse(rdr["Gender4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtDistFeatures4.Text = rdr["DistFeatures4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryDesc4.Text = rdr["InjuryDesc4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryCause4.Text = rdr["CauseInjury4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidentComm4.Text = rdr["Comments4"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Person 5 */
                        txtFirstName5.Text = rdr["FirstName5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtLastName5.Text = rdr["LastName5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAlias5.Text = rdr["Alias5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtContact5.Text = rdr["Contact5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPartyType5.SelectedIndex = Int32.Parse(rdr["PartyType5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        if (ddlPartyType5.SelectedItem.Value == "1") // if person is a member, don't allow user to edit the following objects
                        {
                            txtFirstName5.Enabled = false;
                            txtLastName5.Enabled = false;
                            txtAge5.Enabled = false;
                            txtDOB5.Enabled = false;

                            // member's fields
                            cbCardHeld5.Checked = Convert.ToBoolean(rdr["CardHeld5"]);
                            ReportIncidentCu.PlayerId5 = rdr["PlayerId5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberNo5.Text = rdr["MemberNo5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOB5.Text = rdr["MemberDOB5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddress5.Text = rdr["MemberAddress5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtMemberSince5.Text = rdr["MemberSince5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType5.SelectedItem.Value == "2") // if person is a visitor read following objects
                        {
                            // visitor's fields
                            cbSignInSlip5.Checked = Convert.ToBoolean(rdr["SignInSlip5"]);
                            txtSignInBy5.Text = rdr["SignedInBy5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtDOBv5.Text = rdr["VisitorDOB5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtIDProof5.Text = rdr["VisitorProofID5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtAddressv5.Text = rdr["VisitorAddress5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        if (ddlPartyType5.SelectedItem.Value == "3") // if person is a staff read following objects
                        {
                            // staff's fields
                            txtStaffEmpNo5.Text = rdr["StaffEmpNo5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                            txtStaffAddress5.Text = rdr["StaffAddress5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }

                        txtPDate5.Text = rdr["PDate5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlPTimeH5.SelectedIndex = Int32.Parse(rdr["PTimeH5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlPTimeM5.SelectedIndex = Int32.Parse(rdr["PTimeM5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlPTimeTC5.SelectedIndex = Int32.Parse(rdr["PTimeTC5"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        cbWitness5.Checked = Convert.ToBoolean(rdr["Witness5"]);
                        txtAge5.Text = rdr["Age5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlAgeGroup5.SelectedValue = rdr["AgeGroup5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        //txtWeight5.Text = rdr["Weight5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlWeight5.SelectedValue = rdr["Weight5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHeight5.Text = rdr["Height5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtHair5.Text = rdr["Hair5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingTop5.Text = rdr["ClothingTop5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtClothingBottom5.Text = rdr["ClothingBottom5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtShoes5.Text = rdr["Shoes5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtWeapon5.Text = rdr["Weapon5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlGender5.SelectedIndex = Int32.Parse(rdr["Gender5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtDistFeatures5.Text = rdr["DistFeatures5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryDesc5.Text = rdr["InjuryDesc5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtInjuryCause5.Text = rdr["CauseInjury5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtIncidentComm5.Text = rdr["Comments5"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        txtDate1.Text = rdr["Date"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlHour.SelectedIndex = Int32.Parse(rdr["TimeH"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlMinutes.SelectedIndex = Int32.Parse(rdr["TimeM"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        // ddlTimeCon.SelectedIndex = Int32.Parse(rdr["TimeTC"].ToString().Replace("<br />", "\n").Replace("^", "'")); // Take off the AM/PM dropdownlist

                        /* Populate the Checkbox list for Incident Type and tick selected checkbox from the report */
                        string incidentType = rdr["IncidentHappened"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateIncidentList;
                        // set query to populate the incident type list
                        if (!string.IsNullOrEmpty(incidentType))
                        {
                            incidentType = incidentType.Remove(incidentType.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list
                            // order by query sets the Other value from Description field to be in the last of the the list 
                            populateIncidentList = "SELECT * FROM [dbo].[List_IncidentType] WHERE [SiteID] = 2 AND ([Active] = 1 OR [IncidentID] IN (" + incidentType + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateIncidentList = "SELECT * FROM [dbo].[List_IncidentType] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        // populate the incident type list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateIncidentList;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["IncidentId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    cblWhatHappened1.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // tick the checkbox for selected incident type
                        string[] arrWhatHappened = rdr["IncidentHappened"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in cblWhatHappened1.Items)
                        {
                            for (int i = 0; i < arrWhatHappened.Length; i++)
                            {
                                if (arrWhatHappened[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                {
                                    item.Selected = true;

                                    // display necessary rows if selected
                                    if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Other")
                                    {
                                        if (item.Selected)
                                        {
                                            additionalDetails.Visible = true;
                                            additionalDetails1.Visible = true;
                                        }
                                    }
                                    if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Other - Serious")
                                    {
                                        if (item.Selected)
                                        {
                                            seriousOther.Visible = true;
                                            seriousOther1.Visible = true;
                                        }
                                    }
                                    if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Refused Entry")
                                    {
                                        if (item.Selected)
                                        {
                                            refuseEntryReasons.Visible = true;
                                            refuseEntryReasons1.Visible = true;
                                        }
                                    }
                                    if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Asked to Leave")
                                    {
                                        if (item.Selected)
                                        {
                                            askedtoLeaveReasons.Visible = true;
                                            askedtoLeaveReasons1.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                        // check if action taken:other textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["ActionTakenOther"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            actionTakenOther.Visible = true;
                            actionTakenOther1.Visible = true;
                            txtActionTakenOther.Text = rdr["ActionTakenOther"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        // check if incident type:other textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedOther"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            additionalDetails.Visible = true;
                            additionalDetails1.Visible = true;
                            txtOthers.Text = rdr["HappenedOther"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        // check if incident type:other serious textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedSerious"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            seriousOther.Visible = true;
                            seriousOther1.Visible = true;
                            txtOtherSerious.Text = rdr["HappenedSerious"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        }
                        // populate the checkbox list for incident type:refuse entry field and tick necessary checkbox
                        string refuseEntry = rdr["HappenedRefuseEntry"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateRefuseEntry;
                        if (!string.IsNullOrEmpty(refuseEntry))
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateRefuseEntry = "SELECT * FROM [dbo].[List_RefuseReason] WHERE [SiteID] = 2 AND ([Active] = 1 OR [RefuseReasonID] IN (" + refuseEntry + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateRefuseEntry = "SELECT * FROM [dbo].[List_RefuseReason] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        // populate the refuse entry list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateRefuseEntry;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["RefuseReasonID"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    List_RefuseReason.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // if refuse entry field has value display the objects
                        if (!String.IsNullOrEmpty(rdr["HappenedRefuseEntry"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            refuseEntryReasons.Visible = true;
                            refuseEntryReasons1.Visible = true;
                            List_RefuseReason.Visible = true;

                            // tick the checkbox for selected refuse entry reasons
                            string[] arrRefuseReason = rdr["HappenedRefuseEntry"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_RefuseReason.Items)
                            {
                                for (int i = 0; i < arrRefuseReason.Length; i++)
                                {
                                    if (arrRefuseReason[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                        }
                        // populate the checkbox list for incident type:asked to leave field and tick necessary checkbox
                        string askedToLeave = rdr["HappenedAskedToLeave"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateAskedToLeave;
                        if (!string.IsNullOrEmpty(askedToLeave))
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateAskedToLeave = "SELECT * FROM [dbo].[List_AskedToLeave] WHERE [SiteID] = 2 AND ([Active] = 1 OR [AskedToLeaveID] IN (" + askedToLeave + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateAskedToLeave = "SELECT * FROM [dbo].[List_AskedToLeave] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        // populate the asked to leave list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateAskedToLeave;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["AskedToLeaveID"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    List_AskedToLeave.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // check if Asked To Leave is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedAskedToLeave"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            askedtoLeaveReasons.Visible = true;
                            askedtoLeaveReasons1.Visible = true;
                            List_AskedToLeave.Visible = true;

                            // tick the checkbox for selected asked to leave reasons
                            string[] arrAskedToLeave = rdr["HappenedAskedToLeave"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_AskedToLeave.Items)
                            {
                                for (int i = 0; i < arrAskedToLeave.Length; i++)
                                {
                                    if (arrAskedToLeave[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                        }

                        /* Populate the Checkbox list for Location and tick necessary checkbox */
                        string location = rdr["Location"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateLocationList;
                        // set query to populate the location list
                        if (!string.IsNullOrEmpty(location))
                        {
                            location = location.Remove(location.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list
                            // order by query sets the Other value from Description field to be in the last of the the list 
                            populateLocationList = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 2 AND ([Active] = 1 OR [LocationID] IN (" + location + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateLocationList = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        // populate the location list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateLocationList;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["LocationId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    List_Location.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // tick the checkbox for selected location
                        string[] arrLocation = rdr["Location"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrLocation.Length; i++)
                            {
                                if (arrLocation[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        // display location:other textbox if other is selected in location field
                        foreach (ListItem item in List_Location.Items)
                        {
                            if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Other")
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
                                }
                            }
                        }
                        txtLocation.Text = rdr["LocationOther"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        /* Camera 1 */
                        txtCamDesc1.Text = rdr["CamDesc1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded1.Checked = Convert.ToBoolean(rdr["CamRecorded1"]);
                        txtCamFilePath1.Text = rdr["CamFilePath1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate1.Text = rdr["CamSDate1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH1.SelectedIndex = Int32.Parse(rdr["CamSTimeH1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM1.SelectedIndex = Int32.Parse(rdr["CamSTimeM1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC1.SelectedIndex = Int32.Parse(rdr["CamSTimeTC1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate1.Text = rdr["CamEDate1"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH1.SelectedIndex = Int32.Parse(rdr["CamETimeH1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM1.SelectedIndex = Int32.Parse(rdr["CamETimeM1"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC1.SelectedIndex = Int32.Parse(rdr["CamETimeTC1"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 2 */
                        txtCamDesc2.Text = rdr["CamDesc2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded2.Checked = Convert.ToBoolean(rdr["CamRecorded2"]);
                        txtCamFilePath2.Text = rdr["CamFilePath2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate2.Text = rdr["CamSDate2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH2.SelectedIndex = Int32.Parse(rdr["CamSTimeH2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM2.SelectedIndex = Int32.Parse(rdr["CamSTimeM2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC2.SelectedIndex = Int32.Parse(rdr["CamSTimeTC2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate2.Text = rdr["CamEDate2"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH2.SelectedIndex = Int32.Parse(rdr["CamETimeH2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM2.SelectedIndex = Int32.Parse(rdr["CamETimeM2"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC2.SelectedIndex = Int32.Parse(rdr["CamETimeTC2"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 3 */
                        txtCamDesc3.Text = rdr["CamDesc3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded3.Checked = Convert.ToBoolean(rdr["CamRecorded3"]);
                        txtCamFilePath3.Text = rdr["CamFilePath3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate3.Text = rdr["CamSDate3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH3.SelectedIndex = Int32.Parse(rdr["CamSTimeH3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM3.SelectedIndex = Int32.Parse(rdr["CamSTimeM3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC3.SelectedIndex = Int32.Parse(rdr["CamSTimeTC3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate3.Text = rdr["CamEDate3"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH3.SelectedIndex = Int32.Parse(rdr["CamETimeH3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM3.SelectedIndex = Int32.Parse(rdr["CamETimeM3"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC3.SelectedIndex = Int32.Parse(rdr["CamETimeTC3"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 4 */
                        txtCamDesc4.Text = rdr["CamDesc4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded4.Checked = Convert.ToBoolean(rdr["CamRecorded4"]);
                        txtCamFilePath4.Text = rdr["CamFilePath4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate4.Text = rdr["CamSDate4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH4.SelectedIndex = Int32.Parse(rdr["CamSTimeH4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM4.SelectedIndex = Int32.Parse(rdr["CamSTimeM4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC4.SelectedIndex = Int32.Parse(rdr["CamSTimeTC4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate4.Text = rdr["CamEDate4"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH4.SelectedIndex = Int32.Parse(rdr["CamETimeH4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM4.SelectedIndex = Int32.Parse(rdr["CamETimeM4"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC4.SelectedIndex = Int32.Parse(rdr["CamETimeTC4"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 5 */
                        txtCamDesc5.Text = rdr["CamDesc5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded5.Checked = Convert.ToBoolean(rdr["CamRecorded5"]);
                        txtCamFilePath5.Text = rdr["CamFilePath5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate5.Text = rdr["CamSDate5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH5.SelectedIndex = Int32.Parse(rdr["CamSTimeH5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM5.SelectedIndex = Int32.Parse(rdr["CamSTimeM5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC5.SelectedIndex = Int32.Parse(rdr["CamSTimeTC5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate5.Text = rdr["CamEDate5"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH5.SelectedIndex = Int32.Parse(rdr["CamETimeH5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM5.SelectedIndex = Int32.Parse(rdr["CamETimeM5"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC5.SelectedIndex = Int32.Parse(rdr["CamETimeTC5"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 6 */
                        txtCamDesc6.Text = rdr["CamDesc6"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded6.Checked = Convert.ToBoolean(rdr["CamRecorded6"]);
                        txtCamFilePath6.Text = rdr["CamFilePath6"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate6.Text = rdr["CamSDate6"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH6.SelectedIndex = Int32.Parse(rdr["CamSTimeH6"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM6.SelectedIndex = Int32.Parse(rdr["CamSTimeM6"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC6.SelectedIndex = Int32.Parse(rdr["CamSTimeTC6"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate6.Text = rdr["CamEDate6"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH6.SelectedIndex = Int32.Parse(rdr["CamETimeH6"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM6.SelectedIndex = Int32.Parse(rdr["CamETimeM6"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC6.SelectedIndex = Int32.Parse(rdr["CamETimeTC6"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Camera 7 */
                        txtCamDesc7.Text = rdr["CamDesc7"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbRecorded7.Checked = Convert.ToBoolean(rdr["CamRecorded7"]);
                        txtCamFilePath7.Text = rdr["CamFilePath7"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtCamSDate7.Text = rdr["CamSDate7"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamTimeH7.SelectedIndex = Int32.Parse(rdr["CamSTimeH7"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamTimeM7.SelectedIndex = Int32.Parse(rdr["CamSTimeM7"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamTimeTC7.SelectedIndex = Int32.Parse(rdr["CamSTimeTC7"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        txtCamEDate7.Text = rdr["CamEDate7"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        ddlCamETimeH7.SelectedIndex = Int32.Parse(rdr["CamETimeH7"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        ddlCamETimeM7.SelectedIndex = Int32.Parse(rdr["CamETimeM7"].ToString().Replace("<br />", "\n").Replace("^", "'"));
                        //ddlCamETimeTC7.SelectedIndex = Int32.Parse(rdr["CamETimeTC7"].ToString().Replace("<br />", "\n").Replace("^", "'"));

                        /* Populate the Checkbox list for Action Taken and tick necessary checkbox */
                        string actionTaken = rdr["ActionTaken"].ToString().Replace("<br />", "\n").Replace("^", "'"), populateActionTaken;
                        // set query to populate the action taken list
                        if (!string.IsNullOrEmpty(actionTaken))
                        {
                            actionTaken = actionTaken.Remove(actionTaken.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateActionTaken = "SELECT * FROM [dbo].[List_ActionTaken] WHERE [SiteID] = 2 AND ([Active] = 1 OR [ActionID] IN (" + actionTaken + ")) ORDER BY CASE WHEN [Description] = 'None of the above' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            // order by query sets the Other value from Description field to be in the last of the the list
                            populateActionTaken = "SELECT * FROM [dbo].[List_ActionTaken] WHERE [SiteID] = 2 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'None of the above' THEN 1 ELSE 0 END, [Description]";
                        }
                        // populate the action taken list
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = populateActionTaken;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    item.Value = sdr["ActionId"].ToString().Replace("<br />", "\n").Replace("^", "'");
                                    List_ActionTaken.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // check if action taken is not empty and tick the checkbox for selected action taken
                        if (!String.IsNullOrEmpty(rdr["ActionTaken"].ToString().Replace("<br />", "\n").Replace("^", "'")))
                        {
                            string[] arrActionTaken = rdr["ActionTaken"].ToString().Replace("<br />", "\n").Replace("^", "'").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_ActionTaken.Items)
                            {
                                for (int i = 0; i < arrActionTaken.Length; i++)
                                {
                                    if (arrActionTaken[i].ToString().Replace("<br />", "\n").Replace("^", "'").Equals(item.Value))
                                    {
                                        item.Selected = true;

                                        // display necessary rows if selected
                                        if (item.ToString().Replace("<br />", "\n").Replace("^", "'") == "Other")
                                        {
                                            if (item.Selected)
                                            {
                                                actionTakenOther.Visible = true;
                                                actionTakenOther1.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        txtDetails.Text = rdr["Details"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtAllegation.Text = rdr["Allegation"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbSecurity.Checked = Convert.ToBoolean(rdr["SecurityAttend"]);
                        txtSecurityName.Text = rdr["SecurityName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        cbPolice.Checked = Convert.ToBoolean(rdr["PoliceNotify"]);
                        txtPoliceStation.Text = rdr["PoliceStation"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtOfficersName.Text = rdr["OfficersName"].ToString().Replace("<br />", "\n").Replace("^", "'");
                        txtPoliceAction.Text = rdr["PoliceAction"].ToString().Replace("<br />", "\n").Replace("^", "'");

                        // set Image labels to set whether the program shows the Image controls or not 
                        // show image Human Body Form if not empty
                        byte[] image1 = null, image2 = null, image3 = null, image4 = null, image5 = null,
                               memberPhoto1 = null, memberPhoto2 = null, memberPhoto3 = null, memberPhoto4 = null, memberPhoto5 = null;

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto1"] != null)
                            {
                                memberPhoto1 = (byte[])rdr["MemberPhoto1"];
                                ReportIncidentCu.MemberPhoto1 = memberPhoto1;
                            }
                        }
                        catch
                        {
                            memberPhoto1 = null;
                            ReportIncidentCu.MemberPhoto1 = null;
                        }
                        if (memberPhoto1 != null && memberPhoto1.Length > 0)
                        {
                            string strBase64 = Convert.ToBase64String(memberPhoto1, 0, memberPhoto1.Length);
                            imgMember1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            imgMember1.ImageUrl = "~/Images/no-image.png";
                        }

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto2"] != null)
                            {
                                memberPhoto2 = (byte[])rdr["MemberPhoto2"];
                                ReportIncidentCu.MemberPhoto2 = memberPhoto2;
                            }
                        }
                        catch
                        {
                            memberPhoto2 = null;
                            ReportIncidentCu.MemberPhoto2 = null;
                        }
                        if (memberPhoto2 != null && memberPhoto2.Length > 0)
                        {
                            string strBase64 = Convert.ToBase64String(memberPhoto2, 0, memberPhoto2.Length);
                            imgMember2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            imgMember2.ImageUrl = "~/Images/no-image.png";
                        }

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto3"] != null)
                            {
                                memberPhoto3 = (byte[])rdr["MemberPhoto3"];
                                ReportIncidentCu.MemberPhoto3 = memberPhoto3;
                            }
                        }
                        catch
                        {
                            memberPhoto3 = null;
                            ReportIncidentCu.MemberPhoto3 = null;
                        }
                        if (memberPhoto3 != null && memberPhoto3.Length > 0)
                        {
                            string strBase64 = Convert.ToBase64String(memberPhoto3, 0, memberPhoto3.Length);
                            imgMember3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            imgMember3.ImageUrl = "~/Images/no-image.png";
                        }

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto4"] != null)
                            {
                                memberPhoto4 = (byte[])rdr["MemberPhoto4"];
                                ReportIncidentCu.MemberPhoto4 = memberPhoto4;
                            }
                        }
                        catch
                        {
                            memberPhoto4 = null;
                            ReportIncidentCu.MemberPhoto4 = null;
                        }
                        if (memberPhoto4 != null && memberPhoto4.Length > 0)
                        {
                            string strBase64 = Convert.ToBase64String(memberPhoto4, 0, memberPhoto4.Length);
                            imgMember4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            imgMember4.ImageUrl = "~/Images/no-image.png";
                        }

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto5"] != null)
                            {
                                memberPhoto5 = (byte[])rdr["MemberPhoto5"];
                                ReportIncidentCu.MemberPhoto5 = memberPhoto5;
                            }
                        }
                        catch
                        {
                            memberPhoto5 = null;
                            ReportIncidentCu.MemberPhoto5 = null;
                        }
                        if (memberPhoto5 != null && memberPhoto5.Length > 0)
                        {
                            string strBase64 = Convert.ToBase64String(memberPhoto5, 0, memberPhoto5.Length);
                            imgMember5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            imgMember5.ImageUrl = "~/Images/no-image.png";
                        }

                        try // set Human Body image 1 value
                        {
                            if ((byte[])rdr["Image1"] != null)
                            {
                                image1 = (byte[])rdr["Image1"];
                                ReportIncidentCu.HumanBody1 = image1;
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image1 = null;
                            ReportIncidentCu.HumanBody1 = null;
                        }
                        try // set image 2 value
                        {
                            if ((byte[])rdr["Image2"] != null)
                            {
                                image2 = (byte[])rdr["Image2"];
                                ReportIncidentCu.HumanBody2 = image2;
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image2 = null;
                            ReportIncidentCu.HumanBody2 = null;
                        }
                        try // set image 3 value
                        {
                            if ((byte[])rdr["Image3"] != null)
                            {
                                image3 = (byte[])rdr["Image3"];
                                ReportIncidentCu.HumanBody3 = image3;
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image3 = null;
                            ReportIncidentCu.HumanBody3 = null;
                        }
                        try // set image 4 value
                        {
                            if ((byte[])rdr["Image4"] != null)
                            {
                                image4 = (byte[])rdr["Image4"];
                                ReportIncidentCu.HumanBody4 = image4;
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image4 = null;
                            ReportIncidentCu.HumanBody4 = null;
                        }
                        try // set image 5 value
                        {
                            if ((byte[])rdr["Image5"] != null)
                            {
                                image5 = (byte[])rdr["Image5"];
                                ReportIncidentCu.HumanBody5 = image5;
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image5 = null;
                            ReportIncidentCu.HumanBody5 = null;
                        }

                        if (image1 != null && image1.Length > 0)
                        {
                            lblImage1.Text = "1"; // show Image control, delete button, and tick box
                                                  // load image from database
                            string strBase64 = Convert.ToBase64String(image1, 0, image1.Length);
                            Image1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            lblImage1.Text = ""; // hide Image control, delete button, and tick box
                        }
                        if (image2 != null && image2.Length > 0)
                        {
                            lblImage2.Text = "1";
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image2, 0, image2.Length);
                            Image2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            lblImage2.Text = "";
                        }
                        if (image3 != null && image3.Length > 0)
                        {
                            lblImage3.Text = "1";
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image3, 0, image3.Length);
                            Image3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            lblImage3.Text = "";
                        }
                        if (image4 != null && image4.Length > 0)
                        {
                            lblImage4.Text = "1";
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image4, 0, image4.Length);
                            Image4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            lblImage4.Text = "";
                        }
                        if (image5 != null && image5.Length > 0)
                        {
                            lblImage5.Text = "1";
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image5, 0, image5.Length);
                            Image5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            lblImage5.Text = "";
                        }
                    }
                    if (method.Equals("SearchMember")) // Get the Member Details from IGT Advantage Database
                    {
                        if (Report.MemberNumberChanged.Equals("1"))
                        {
                            Report.HasMember = true;
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
                                string strBase64 = Convert.ToBase64String(memberPhoto1, 0, memberPhoto1.Length); // load image from database
                                imgMember1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto1 = null;
                                imgMember1.ImageUrl = "~/Images/no-image.png";
                            }

                            ReportIncidentCu.MemberPhoto1 = memberPhoto1; // set global variable to current member photo
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
                        }
                        else if (Report.MemberNumberChanged.Equals("2"))
                        {
                            Report.HasMember = true;
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
                                string strBase64 = Convert.ToBase64String(memberPhoto2, 0, memberPhoto2.Length); // load image from database
                                imgMember2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto2 = null;
                                imgMember2.ImageUrl = "~/Images/no-image.png";
                            }

                            ReportIncidentCu.MemberPhoto2 = memberPhoto2; // set global variable to current member photo
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
                        }
                        else if (Report.MemberNumberChanged.Equals("3"))
                        {
                            Report.HasMember = true;
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
                                string strBase64 = Convert.ToBase64String(memberPhoto3, 0, memberPhoto3.Length); // load image from database
                                imgMember3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto3 = null;
                                imgMember3.ImageUrl = "~/Images/no-image.png";
                            }

                            ReportIncidentCu.MemberPhoto3 = memberPhoto3; // set global variable to current member photo
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
                        }
                        else if (Report.MemberNumberChanged.Equals("4"))
                        {
                            Report.HasMember = true;
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
                                string strBase64 = Convert.ToBase64String(memberPhoto4, 0, memberPhoto4.Length); // load image from database
                                imgMember4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto4 = null;
                                imgMember4.ImageUrl = "~/Images/no-image.png";
                            }

                            ReportIncidentCu.MemberPhoto4 = memberPhoto4; // set global variable to current member photo
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
                        }
                        else if (Report.MemberNumberChanged.Equals("5"))
                        {
                            Report.HasMember = true;
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
                                string strBase64 = Convert.ToBase64String(memberPhoto5, 0, memberPhoto5.Length); // load image from database
                                imgMember5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                            }
                            catch
                            {
                                memberPhoto5 = null;
                                imgMember5.ImageUrl = "~/Images/no-image.png";
                            }

                            ReportIncidentCu.MemberPhoto5 = memberPhoto5; // set global variable to current member photo
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
                                }
                            }
                        }
                    }
                    if (method.Equals("CheckChanges")) // check if there are any changes made in the report
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
                        if (ReportIncidentCu.Date.ToString() != rdr["Date"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Date";
                        }
                        if (ReportIncidentCu.Hour.ToString() != rdr["TimeH"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TimeH";
                        }
                        if (ReportIncidentCu.Minute.ToString() != rdr["TimeM"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "TimeM";
                        }
                        /*if (ReportIncidentCu.TC.ToString() != rdr["TimeTC"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "TimeTC";
                        }*/
                        if (ReportIncidentCu.Location.ToString() != rdr["Location"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Location";
                        }
                        if (ReportIncidentCu.LocationOther.ToString() != rdr["LocationOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Location Other";
                        }
                        if (ReportIncidentCu.ActionTaken.ToString() != rdr["ActionTaken"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ActionTaken";
                        }
                        if (ReportIncidentMr.ActionTakenOther.ToString() != rdr["ActionTakenOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ActionTakenOther";
                        }
                        if (ReportIncidentCu.Details.ToString() != rdr["Details"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Details";
                        }
                        if (ReportIncidentCu.Allegation.ToString() != rdr["Allegation"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Allegation";
                        }
                        if (ReportIncidentCu.WhatHappened.ToString() != rdr["IncidentHappened"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Incident Happened";
                        }
                        if (ReportIncidentCu.HappenedOther.ToString() != rdr["HappenedOther"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Happened Other";
                        }
                        if (ReportIncidentCu.HappenedSerious.ToString() != rdr["HappenedSerious"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Happened Serious";
                        }
                        if (ReportIncidentCu.HappenedRefuseEntry.ToString() != rdr["HappenedRefuseEntry"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Happened Refuse Entry";
                        }
                        if (ReportIncidentCu.HappenedAskedLeave.ToString() != rdr["HappenedAskedToLeave"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Happened Asked To Leave";
                        }
                        if (ReportIncidentCu.SecurityAttend.ToString() != Convert.ToBoolean(rdr["SecurityAttend"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Security Attend";
                        }
                        if (ReportIncidentCu.SecurityName.ToString() != rdr["SecurityName"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Security Name";
                        }
                        if (ReportIncidentCu.PoliceNotified.ToString() != Convert.ToBoolean(rdr["PoliceNotify"]).ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Police Notify";
                        }
                        if (ReportIncidentCu.PoliceStation.ToString() != rdr["PoliceStation"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Police Station";
                        }
                        if (ReportIncidentCu.OfficersName.ToString() != rdr["OfficersName"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Officer's Name";
                        }
                        if (ReportIncidentCu.PoliceAction.ToString() != rdr["PoliceAction"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Police Action";
                        }

                        if (ReportIncidentCu.First1.ToString() != rdr["FirstName1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "F1";
                        }
                        if (ReportIncidentCu.Last1.ToString() != rdr["LastName1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "L1";
                        }
                        if (ReportIncidentCu.Alias1.ToString() != rdr["Alias1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Alias1";
                        }
                        if (ReportIncidentCu.Contact1.ToString() != rdr["Contact1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact1";
                        }
                        if (ReportIncidentCu.Type1.ToString() != rdr["PartyType1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PT1";
                        }
                        if (ReportIncidentCu.Witness1.ToString().ToLower() != Convert.ToBoolean(rdr["Witness1"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "W1";
                        }
                        if (ReportIncidentCu.Card1.ToString().ToLower() != Convert.ToBoolean(rdr["CardHeld1"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CH1";
                        }
                        if (ReportIncidentCu.Member1.ToString() != rdr["MemberNo1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MN1";
                        }
                        if (ReportIncidentCu.MDOB1.ToString() != rdr["MemberDOB1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MB1";
                        }
                        if (ReportIncidentCu.MAddress1.ToString() != rdr["MemberAddress1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAaddress1";
                        }
                        if (ReportIncidentCu.SignInSlip1.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip1"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip1";
                        }
                        if (ReportIncidentCu.SignInBy1.ToString() != rdr["SignedInBy1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy1";
                        }
                        if (ReportIncidentCu.VDOB1.ToString() != rdr["VisitorDOB1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VDOB1";
                        }
                        if (ReportIncidentCu.VProofID1.ToString() != rdr["VisitorProofID1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProof1";
                        }
                        if (ReportIncidentCu.VAddress1.ToString() != rdr["VisitorAddress1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress1";
                        }
                        if (ReportIncidentCu.StaffEmp1.ToString() != rdr["StaffEmpNo1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffEmp1";
                        }
                        if (ReportIncidentCu.StaffAddress1.ToString() != rdr["StaffAddress1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffAddress1";
                        }
                        if (ReportIncidentCu.PDate1.ToString() != rdr["PDate1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PDate1";
                        }
                        if (ReportIncidentCu.PTimeH1.ToString() != rdr["PTimeH1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeH1";
                        }
                        if (ReportIncidentCu.PTimeM1.ToString() != rdr["PTimeM1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeM1";
                        }
                        /*if (ReportIncidentCu.PTimeTC1.ToString() != rdr["PTimeTC1"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "PTimeTC1";
                        }*/
                        if (ReportIncidentCu.Age1.ToString() != rdr["Age1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Age1";
                        }
                        if (ReportIncidentCu.AgeGroup1.ToString() != rdr["AgeGroup1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AgeGroup1";
                        }
                        if (ReportIncidentCu.Height1.ToString() != rdr["Height1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Height1";
                        }
                        if (ReportIncidentCu.Weight1.ToString() != rdr["Weight1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weight1";
                        }
                        if (ReportIncidentCu.Hair1.ToString() != rdr["Hair1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Hair1";
                        }
                        if (ReportIncidentCu.ClothingTop1.ToString() != rdr["ClothingTop1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingTop1";
                        }
                        if (ReportIncidentCu.ClothingBottom1.ToString() != rdr["ClothingBottom1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingBottom1";
                        }
                        if (ReportIncidentCu.Shoes1.ToString() != rdr["Shoes1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Shoes1";
                        }
                        if (ReportIncidentCu.Weapon1.ToString() != rdr["Weapon1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weapon1";
                        }
                        if (ReportIncidentCu.Gender1.ToString() != rdr["Gender1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gender1";
                        }
                        if (ReportIncidentCu.DistFeat1.ToString() != rdr["DistFeatures1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "DistFeat1";
                        }
                        if (ReportIncidentCu.InjuryDesc1.ToString() != rdr["InjuryDesc1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InjuryDesc1";
                        }
                        if (ReportIncidentCu.InjuryCause1.ToString() != rdr["CauseInjury1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CauseInjury1";
                        }
                        if (ReportIncidentCu.InjuryComm1.ToString() != rdr["Comments1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Comments1";
                        }


                        if (ReportIncidentCu.First2.ToString() != rdr["FirstName2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "F2";
                        }
                        if (ReportIncidentCu.Last2.ToString() != rdr["LastName2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "L2";
                        }
                        if (ReportIncidentCu.Alias2.ToString() != rdr["Alias2"].ToString())
                        {
                            Report.HasChange = true; flag = 2;
                            Report.WhereChangeHappened = "Alias2";
                        }
                        if (ReportIncidentCu.Contact2.ToString() != rdr["Contact2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact2";
                        }
                        if (ReportIncidentCu.Type2.ToString() != rdr["PartyType2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PT2";
                        }
                        if (ReportIncidentCu.Witness2.ToString().ToLower() != Convert.ToBoolean(rdr["Witness2"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "W2";
                        }
                        if (ReportIncidentCu.Card2.ToString().ToLower() != Convert.ToBoolean(rdr["CardHeld2"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CH2";
                        }
                        if (ReportIncidentCu.Member2.ToString() != rdr["MemberNo2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MN2";
                        }
                        if (ReportIncidentCu.MDOB2.ToString() != rdr["MemberDOB2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MB2";
                        }
                        if (ReportIncidentCu.MAddress2.ToString() != rdr["MemberAddress2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAaddress2";
                        }
                        if (ReportIncidentCu.SignInSlip2.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip2"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip2";
                        }
                        if (ReportIncidentCu.SignInBy2.ToString() != rdr["SignedInBy2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy2";
                        }
                        if (ReportIncidentCu.VDOB2.ToString() != rdr["VisitorDOB2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VDOB2";
                        }
                        if (ReportIncidentCu.VProofID2.ToString() != rdr["VisitorProofID2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProof2";
                        }
                        if (ReportIncidentCu.VAddress2.ToString() != rdr["VisitorAddress2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress2";
                        }
                        if (ReportIncidentCu.StaffEmp2.ToString() != rdr["StaffEmpNo2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffEmp2";
                        }
                        if (ReportIncidentCu.StaffAddress2.ToString() != rdr["StaffAddress2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffAddress2";
                        }
                        if (ReportIncidentCu.PDate2.ToString() != rdr["PDate2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PDate2";
                        }
                        if (ReportIncidentCu.PTimeH2.ToString() != rdr["PTimeH2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeH2";
                        }
                        if (ReportIncidentCu.PTimeM2.ToString() != rdr["PTimeM2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeM2";
                        }
                        /*if (ReportIncidentCu.PTimeTC2.ToString() != rdr["PTimeTC2"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "PTimeTC2";
                        }*/
                        if (ReportIncidentCu.Age2.ToString() != rdr["Age2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Age2";
                        }
                        if (ReportIncidentCu.AgeGroup2.ToString() != rdr["AgeGroup2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AgeGroup2";
                        }
                        if (ReportIncidentCu.Height2.ToString() != rdr["Height2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Height2";
                        }
                        if (ReportIncidentCu.Weight2.ToString() != rdr["Weight2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weight2";
                        }
                        if (ReportIncidentCu.Hair2.ToString() != rdr["Hair2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Hair2";
                        }
                        if (ReportIncidentCu.ClothingTop2.ToString() != rdr["ClothingTop2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingTop2";
                        }
                        if (ReportIncidentCu.ClothingBottom2.ToString() != rdr["ClothingBottom2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingBottom2";
                        }
                        if (ReportIncidentCu.Shoes2.ToString() != rdr["Shoes2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Shoes2";
                        }
                        if (ReportIncidentCu.Weapon2.ToString() != rdr["Weapon2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weapon2";
                        }
                        if (ReportIncidentCu.Gender2.ToString() != rdr["Gender2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gender2";
                        }
                        if (ReportIncidentCu.DistFeat2.ToString() != rdr["DistFeatures2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "DistFeat2";
                        }
                        if (ReportIncidentCu.InjuryDesc2.ToString() != rdr["InjuryDesc2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InjuryDesc2";
                        }
                        if (ReportIncidentCu.InjuryCause2.ToString() != rdr["CauseInjury2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CauseInjury2";
                        }
                        if (ReportIncidentCu.InjuryComm2.ToString() != rdr["Comments2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Comments2";
                        }


                        if (ReportIncidentCu.First3.ToString() != rdr["FirstName3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "F3";
                        }
                        if (ReportIncidentCu.Last3.ToString() != rdr["LastName3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "L3";
                        }
                        if (ReportIncidentCu.Alias3.ToString() != rdr["Alias3"].ToString())
                        {
                            Report.HasChange = true; flag = 3;
                            Report.WhereChangeHappened = "Alias3";
                        }
                        if (ReportIncidentCu.Contact3.ToString() != rdr["Contact3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact3";
                        }
                        if (ReportIncidentCu.Type3.ToString() != rdr["PartyType3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PT3";
                        }
                        if (ReportIncidentCu.Witness3.ToString().ToLower() != Convert.ToBoolean(rdr["Witness3"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "W3";
                        }
                        if (ReportIncidentCu.Card3.ToString().ToLower() != Convert.ToBoolean(rdr["CardHeld3"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CH3";
                        }
                        if (ReportIncidentCu.Member3.ToString() != rdr["MemberNo3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MN3";
                        }
                        if (ReportIncidentCu.MDOB3.ToString() != rdr["MemberDOB3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MB3";
                        }
                        if (ReportIncidentCu.MAddress3.ToString() != rdr["MemberAddress3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAaddress3";
                        }
                        if (ReportIncidentCu.SignInSlip3.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip3"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip3";
                        }
                        if (ReportIncidentCu.SignInBy3.ToString() != rdr["SignedInBy3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy3";
                        }
                        if (ReportIncidentCu.VDOB3.ToString() != rdr["VisitorDOB3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VDOB3";
                        }
                        if (ReportIncidentCu.VProofID3.ToString() != rdr["VisitorProofID3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProof3";
                        }
                        if (ReportIncidentCu.VAddress3.ToString() != rdr["VisitorAddress3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress3";
                        }
                        if (ReportIncidentCu.StaffEmp3.ToString() != rdr["StaffEmpNo3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffEmp3";
                        }
                        if (ReportIncidentCu.StaffAddress3.ToString() != rdr["StaffAddress3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffAddress3";
                        }
                        if (ReportIncidentCu.PDate3.ToString() != rdr["PDate3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PDate3";
                        }
                        if (ReportIncidentCu.PTimeH3.ToString() != rdr["PTimeH3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeH3";
                        }
                        if (ReportIncidentCu.PTimeM3.ToString() != rdr["PTimeM3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeM3";
                        }
                        /*if (ReportIncidentCu.PTimeTC3.ToString() != rdr["PTimeTC3"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "PTimeTC3";
                        }*/
                        if (ReportIncidentCu.Age3.ToString() != rdr["Age3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Age3";
                        }
                        if (ReportIncidentCu.AgeGroup3.ToString() != rdr["AgeGroup3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AgeGroup3";
                        }
                        if (ReportIncidentCu.Height3.ToString() != rdr["Height3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Height3";
                        }
                        if (ReportIncidentCu.Weight3.ToString() != rdr["Weight3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weight3";
                        }
                        if (ReportIncidentCu.Hair3.ToString() != rdr["Hair3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Hair3";
                        }
                        if (ReportIncidentCu.ClothingTop3.ToString() != rdr["ClothingTop3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingTop3";
                        }
                        if (ReportIncidentCu.ClothingBottom3.ToString() != rdr["ClothingBottom3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingBottom3";
                        }
                        if (ReportIncidentCu.Shoes3.ToString() != rdr["Shoes3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Shoes3";
                        }
                        if (ReportIncidentCu.Weapon3.ToString() != rdr["Weapon3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weapon3";
                        }
                        if (ReportIncidentCu.Gender3.ToString() != rdr["Gender3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gender3";
                        }
                        if (ReportIncidentCu.DistFeat3.ToString() != rdr["DistFeatures3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "DistFeat3";
                        }
                        if (ReportIncidentCu.InjuryDesc3.ToString() != rdr["InjuryDesc3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InjuryDesc3";
                        }
                        if (ReportIncidentCu.InjuryCause3.ToString() != rdr["CauseInjury3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CauseInjury3";
                        }
                        if (ReportIncidentCu.InjuryComm3.ToString() != rdr["Comments3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Comments3";
                        }


                        if (ReportIncidentCu.First4.ToString() != rdr["FirstName4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "F4";
                        }
                        if (ReportIncidentCu.Last4.ToString() != rdr["LastName4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "L4";
                        }
                        if (ReportIncidentCu.Alias4.ToString() != rdr["Alias4"].ToString())
                        {
                            Report.HasChange = true; flag = 4;
                            Report.WhereChangeHappened = "Alias4";
                        }
                        if (ReportIncidentCu.Contact4.ToString() != rdr["Contact4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact4";
                        }
                        if (ReportIncidentCu.Type4.ToString() != rdr["PartyType4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PT4";
                        }
                        if (ReportIncidentCu.Witness4.ToString().ToLower() != Convert.ToBoolean(rdr["Witness4"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "W4";
                        }
                        if (ReportIncidentCu.Card4.ToString().ToLower() != Convert.ToBoolean(rdr["CardHeld4"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CH4";
                        }
                        if (ReportIncidentCu.Member4.ToString() != rdr["MemberNo4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MN4";
                        }
                        if (ReportIncidentCu.MDOB4.ToString() != rdr["MemberDOB4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MB4";
                        }
                        if (ReportIncidentCu.MAddress4.ToString() != rdr["MemberAddress4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAaddress4";
                        }
                        if (ReportIncidentCu.SignInSlip4.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip4"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip4";
                        }
                        if (ReportIncidentCu.SignInBy4.ToString() != rdr["SignedInBy4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy4";
                        }
                        if (ReportIncidentCu.VDOB4.ToString() != rdr["VisitorDOB4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VDOB4";
                        }
                        if (ReportIncidentCu.VProofID4.ToString() != rdr["VisitorProofID4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProof4";
                        }
                        if (ReportIncidentCu.VAddress4.ToString() != rdr["VisitorAddress4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress4";
                        }
                        if (ReportIncidentCu.StaffEmp4.ToString() != rdr["StaffEmpNo4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffEmp4";
                        }
                        if (ReportIncidentCu.StaffAddress4.ToString() != rdr["StaffAddress4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffAddress4";
                        }
                        if (ReportIncidentCu.PDate4.ToString() != rdr["PDate4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PDate4";
                        }
                        if (ReportIncidentCu.PTimeH4.ToString() != rdr["PTimeH4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeH4";
                        }
                        if (ReportIncidentCu.PTimeM4.ToString() != rdr["PTimeM4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeM4";
                        }
                        /*if (ReportIncidentCu.PTimeTC4.ToString() != rdr["PTimeTC4"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "PTimeTC4";
                        }*/
                        if (ReportIncidentCu.Age4.ToString() != rdr["Age4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Age4";
                        }
                        if (ReportIncidentCu.AgeGroup4.ToString() != rdr["AgeGroup4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AgeGroup4";
                        }
                        if (ReportIncidentCu.Height4.ToString() != rdr["Height4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Height4";
                        }
                        if (ReportIncidentCu.Weight4.ToString() != rdr["Weight4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weight4";
                        }
                        if (ReportIncidentCu.Hair4.ToString() != rdr["Hair4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Hair4";
                        }
                        if (ReportIncidentCu.ClothingTop4.ToString() != rdr["ClothingTop4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingTop4";
                        }
                        if (ReportIncidentCu.ClothingBottom4.ToString() != rdr["ClothingBottom4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingBottom4";
                        }
                        if (ReportIncidentCu.Shoes4.ToString() != rdr["Shoes4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Shoes4";
                        }
                        if (ReportIncidentCu.Weapon4.ToString() != rdr["Weapon4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weapon4";
                        }
                        if (ReportIncidentCu.Gender4.ToString() != rdr["Gender4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gender4";
                        }
                        if (ReportIncidentCu.DistFeat4.ToString() != rdr["DistFeatures4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "DistFeat4";
                        }
                        if (ReportIncidentCu.InjuryDesc4.ToString() != rdr["InjuryDesc4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InjuryDesc4";
                        }
                        if (ReportIncidentCu.InjuryCause4.ToString() != rdr["CauseInjury4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CauseInjury4";
                        }
                        if (ReportIncidentCu.InjuryComm4.ToString() != rdr["Comments4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Comments4";
                        }


                        if (ReportIncidentCu.First5.ToString() != rdr["FirstName5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "F5";
                        }
                        if (ReportIncidentCu.Last5.ToString() != rdr["LastName5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "L5";
                        }
                        if (ReportIncidentCu.Alias5.ToString() != rdr["Alias5"].ToString())
                        {
                            Report.HasChange = true; flag = 5;
                            Report.WhereChangeHappened = "Alias5";
                        }
                        if (ReportIncidentCu.Contact5.ToString() != rdr["Contact5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Contact5";
                        }
                        if (ReportIncidentCu.Type5.ToString() != rdr["PartyType5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PT5";
                        }
                        if (ReportIncidentCu.Witness5.ToString().ToLower() != Convert.ToBoolean(rdr["Witness5"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "W5";
                        }
                        if (ReportIncidentCu.Card5.ToString().ToLower() != Convert.ToBoolean(rdr["CardHeld5"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CH5";
                        }
                        if (ReportIncidentCu.Member5.ToString() != rdr["MemberNo5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MN5";
                        }
                        if (ReportIncidentCu.MDOB5.ToString() != rdr["MemberDOB5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MB5";
                        }
                        if (ReportIncidentCu.MAddress5.ToString() != rdr["MemberAddress5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "MAaddress5";
                        }
                        if (ReportIncidentCu.SignInSlip5.ToString().ToLower() != Convert.ToBoolean(rdr["SignInSlip5"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInSlip5";
                        }
                        if (ReportIncidentCu.SignInBy5.ToString() != rdr["SignedInBy5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "SignInBy5";
                        }
                        if (ReportIncidentCu.VDOB5.ToString() != rdr["VisitorDOB5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VDOB5";
                        }
                        if (ReportIncidentCu.VProofID5.ToString() != rdr["VisitorProofID5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VProof5";
                        }
                        if (ReportIncidentCu.VAddress5.ToString() != rdr["VisitorAddress5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "VAddress5";
                        }
                        if (ReportIncidentCu.StaffEmp5.ToString() != rdr["StaffEmpNo5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffEmp5";
                        }
                        if (ReportIncidentCu.StaffAddress5.ToString() != rdr["StaffAddress5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "StaffAddress5";
                        }
                        if (ReportIncidentCu.PDate5.ToString() != rdr["PDate5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PDate5";
                        }
                        if (ReportIncidentCu.PTimeH5.ToString() != rdr["PTimeH5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeH5";
                        }
                        if (ReportIncidentCu.PTimeM5.ToString() != rdr["PTimeM5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "PTimeM5";
                        }
                        /*if (ReportIncidentCu.PTimeTC5.ToString() != rdr["PTimeTC5"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "PTimeTC5";
                        }*/
                        if (ReportIncidentCu.Age5.ToString() != rdr["Age5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Age5";
                        }
                        if (ReportIncidentCu.AgeGroup5.ToString() != rdr["AgeGroup5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "AgeGroup5";
                        }
                        if (ReportIncidentCu.Height5.ToString() != rdr["Height5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Height5";
                        }
                        if (ReportIncidentCu.Weight5.ToString() != rdr["Weight5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weight5";
                        }
                        if (ReportIncidentCu.Hair5.ToString() != rdr["Hair5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Hair5";
                        }
                        if (ReportIncidentCu.ClothingTop5.ToString() != rdr["ClothingTop5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingTop5";
                        }
                        if (ReportIncidentCu.ClothingBottom5.ToString() != rdr["ClothingBottom5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "ClothingBottom5";
                        }
                        if (ReportIncidentCu.Shoes5.ToString() != rdr["Shoes5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Shoes5";
                        }
                        if (ReportIncidentCu.Weapon5.ToString() != rdr["Weapon5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Weapon5";
                        }
                        if (ReportIncidentCu.Gender5.ToString() != rdr["Gender5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Gender5";
                        }
                        if (ReportIncidentCu.DistFeat5.ToString() != rdr["DistFeatures5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "DistFeat5";
                        }
                        if (ReportIncidentCu.InjuryDesc5.ToString() != rdr["InjuryDesc5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "InjuryDesc5";
                        }
                        if (ReportIncidentCu.InjuryCause5.ToString() != rdr["CauseInjury5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CauseInjury5";
                        }
                        if (ReportIncidentCu.InjuryComm5.ToString() != rdr["Comments5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "Comments5";
                        }



                        if (ReportIncidentCu.CamDesc1.ToString() != rdr["CamDesc1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc1";
                        }
                        if (ReportIncidentCu.CamRec1.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded1"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded1";
                        }
                        if (ReportIncidentCu.FilePath1.ToString() != rdr["CamFilePath1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath1";
                        }
                        if (ReportIncidentCu.SDate1.ToString() != rdr["CamSDate1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate1";
                        }
                        if (ReportIncidentCu.STimeH1.ToString() != rdr["CamSTimeH1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH1";
                        }
                        if (ReportIncidentCu.STimeM1.ToString() != rdr["CamSTimeM1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM1";
                        }
                        /*if (ReportIncidentCu.STimeTC1.ToString() != rdr["CamSTimeTC1"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC1";
                        }*/
                        if (ReportIncidentCu.EDate1.ToString() != rdr["CamEDate1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate1";
                        }
                        if (ReportIncidentCu.ETimeH1.ToString() != rdr["CamETimeH1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH1";
                        }
                        if (ReportIncidentCu.ETimeM1.ToString() != rdr["CamETimeM1"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM1";
                        }
                        /*if (ReportIncidentCu.ETimeTC1.ToString() != rdr["CamETimeTC1"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC1";
                        }*/


                        if (ReportIncidentCu.CamDesc2.ToString() != rdr["CamDesc2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc2";
                        }
                        if (ReportIncidentCu.CamRec2.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded2"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded2";
                        }
                        if (ReportIncidentCu.FilePath2.ToString() != rdr["CamFilePath2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath2";
                        }
                        if (ReportIncidentCu.SDate2.ToString() != rdr["CamSDate2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate2";
                        }
                        if (ReportIncidentCu.STimeH2.ToString() != rdr["CamSTimeH2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH2";
                        }
                        if (ReportIncidentCu.STimeM2.ToString() != rdr["CamSTimeM2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM2";
                        }
                        /*if (ReportIncidentCu.STimeTC2.ToString() != rdr["CamSTimeTC2"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC2";
                        }*/
                        if (ReportIncidentCu.EDate2.ToString() != rdr["CamEDate2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate2";
                        }
                        if (ReportIncidentCu.ETimeH2.ToString() != rdr["CamETimeH2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH2";
                        }
                        if (ReportIncidentCu.ETimeM2.ToString() != rdr["CamETimeM2"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM2";
                        }
                        /*if (ReportIncidentCu.ETimeTC2.ToString() != rdr["CamETimeTC2"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC2";
                        }*/


                        if (ReportIncidentCu.CamDesc3.ToString() != rdr["CamDesc3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc3";
                        }
                        if (ReportIncidentCu.CamRec3.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded3"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded3";
                        }
                        if (ReportIncidentCu.FilePath3.ToString() != rdr["CamFilePath3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath3";
                        }
                        if (ReportIncidentCu.SDate3.ToString() != rdr["CamSDate3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate3";
                        }
                        if (ReportIncidentCu.STimeH3.ToString() != rdr["CamSTimeH3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH3";
                        }
                        if (ReportIncidentCu.STimeM3.ToString() != rdr["CamSTimeM3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM3";
                        }
                        /*if (ReportIncidentCu.STimeTC3.ToString() != rdr["CamSTimeTC3"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC3";
                        }*/
                        if (ReportIncidentCu.EDate3.ToString() != rdr["CamEDate3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate3";
                        }
                        if (ReportIncidentCu.ETimeH3.ToString() != rdr["CamETimeH3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH3";
                        }
                        if (ReportIncidentCu.ETimeM3.ToString() != rdr["CamETimeM3"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM3";
                        }
                        /*if (ReportIncidentCu.ETimeTC3.ToString() != rdr["CamETimeTC3"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC3";
                        }*/



                        if (ReportIncidentCu.CamDesc4.ToString() != rdr["CamDesc4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc4";
                        }
                        if (ReportIncidentCu.CamRec4.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded4"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded4";
                        }
                        if (ReportIncidentCu.FilePath4.ToString() != rdr["CamFilePath4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath4";
                        }
                        if (ReportIncidentCu.SDate4.ToString() != rdr["CamSDate4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate4";
                        }
                        if (ReportIncidentCu.STimeH4.ToString() != rdr["CamSTimeH4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH4";
                        }
                        if (ReportIncidentCu.STimeM4.ToString() != rdr["CamSTimeM4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM4";
                        }
                        /*if (ReportIncidentCu.STimeTC4.ToString() != rdr["CamSTimeTC4"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC4";
                        }*/
                        if (ReportIncidentCu.EDate4.ToString() != rdr["CamEDate4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate4";
                        }
                        if (ReportIncidentCu.ETimeH4.ToString() != rdr["CamETimeH4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH4";
                        }
                        if (ReportIncidentCu.ETimeM4.ToString() != rdr["CamETimeM4"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM4";
                        }
                        /*if (ReportIncidentCu.ETimeTC4.ToString() != rdr["CamETimeTC4"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC4";
                        }*/


                        if (ReportIncidentCu.CamDesc5.ToString() != rdr["CamDesc5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc5";
                        }
                        if (ReportIncidentCu.CamRec5.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded5"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded5";
                        }
                        if (ReportIncidentCu.FilePath5.ToString() != rdr["CamFilePath5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath5";
                        }
                        if (ReportIncidentCu.SDate5.ToString() != rdr["CamSDate5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate5";
                        }
                        if (ReportIncidentCu.STimeH5.ToString() != rdr["CamSTimeH5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH5";
                        }
                        if (ReportIncidentCu.STimeM5.ToString() != rdr["CamSTimeM5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM5";
                        }
                        /*if (ReportIncidentCu.STimeTC5.ToString() != rdr["CamSTimeTC5"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC5";
                        }*/
                        if (ReportIncidentCu.EDate5.ToString() != rdr["CamEDate5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate5";
                        }
                        if (ReportIncidentCu.ETimeH5.ToString() != rdr["CamETimeH5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH5";
                        }
                        if (ReportIncidentCu.ETimeM5.ToString() != rdr["CamETimeM5"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM5";
                        }
                        /*if (ReportIncidentCu.ETimeTC5.ToString() != rdr["CamETimeTC5"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC5";
                        }*/


                        if (ReportIncidentCu.CamDesc6.ToString() != rdr["CamDesc6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc6";
                        }
                        if (ReportIncidentCu.CamRec6.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded6"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded6";
                        }
                        if (ReportIncidentCu.FilePath6.ToString() != rdr["CamFilePath6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath6";
                        }
                        if (ReportIncidentCu.SDate6.ToString() != rdr["CamSDate6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate6";
                        }
                        if (ReportIncidentCu.STimeH6.ToString() != rdr["CamSTimeH6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH6";
                        }
                        if (ReportIncidentCu.STimeM6.ToString() != rdr["CamSTimeM6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM6";
                        }
                        /*if (ReportIncidentCu.STimeTC6.ToString() != rdr["CamSTimeTC6"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC6";
                        }*/
                        if (ReportIncidentCu.EDate6.ToString() != rdr["CamEDate6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate6";
                        }
                        if (ReportIncidentCu.ETimeH6.ToString() != rdr["CamETimeH6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH6";
                        }
                        if (ReportIncidentCu.ETimeM6.ToString() != rdr["CamETimeM6"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM6";
                        }
                        /*if (ReportIncidentCu.ETimeTC6.ToString() != rdr["CamETimeTC6"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC6";
                        }*/


                        if (ReportIncidentCu.CamDesc7.ToString() != rdr["CamDesc7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamDesc7";
                        }
                        if (ReportIncidentCu.CamRec7.ToString().ToLower() != Convert.ToBoolean(rdr["CamRecorded7"]).ToString().ToLower())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamRecorded7";
                        }
                        if (ReportIncidentCu.FilePath7.ToString() != rdr["CamFilePath7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamFilePath7";
                        }
                        if (ReportIncidentCu.SDate7.ToString() != rdr["CamSDate7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSDate7";
                        }
                        if (ReportIncidentCu.STimeH7.ToString() != rdr["CamSTimeH7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeH7";
                        }
                        if (ReportIncidentCu.STimeM7.ToString() != rdr["CamSTimeM7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamSTimeM7";
                        }
                        /*if (ReportIncidentCu.STimeTC7.ToString() != rdr["CamSTimeTC7"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamSTimeTC7";
                        }*/
                        if (ReportIncidentCu.EDate7.ToString() != rdr["CamEDate7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamEDate7";
                        }
                        if (ReportIncidentCu.ETimeH7.ToString() != rdr["CamETimeH7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CameETimeH7";
                        }
                        if (ReportIncidentCu.ETimeM7.ToString() != rdr["CamETimeM7"].ToString())
                        {
                            Report.HasChange = true; flag = 1;
                            Report.WhereChangeHappened = "CamETimeM7";
                        }
                        /*if (ReportIncidentCu.ETimeTC7.ToString() != rdr["CamETimeTC7"].ToString())
                        {
                            Report.HasChange = true; flag=1;
                            Report.WhereChangeHappened = "CamETimeTC7";
                        }*/
                        if (flag == 0)
                        {
                            Report.HasChange = false;
                            Report.WhereChangeHappened = "";
                        }
                        return;
                    }
                }
            }
            else // if Search Member doesn't have the member details
            {
                if (method.Equals("SearchMember"))
                {
                    Report.HasMember = false;
                    switch (Report.MemberNumberChanged) // check where the textchanged event was triggered
                    {
                        case "1":
                            ReportIncidentCu.PlayerId1 = "";
                            ReportIncidentCu.ViewPlayerId1 = "";
                            txtFirstName1.Text = "";
                            txtLastName1.Text = "";
                            txtAddress1.Text = "";
                            txtDOB1.Text = "";
                            txtMemberSince1.Text = "";
                            txtContact1.Text = "";
                            imgMember1.ImageUrl = "~/Images/white-background.png";
                            ReportIncidentCu.MemberPhoto1 = null; // set global variable to current member photo
                            ddlGender1.SelectedValue = "-1";
                            txtAge1.Text = "";
                            ddlAgeGroup1.SelectedValue = "5";
                            break;
                        case "2":
                            ReportIncidentCu.PlayerId2 = "";
                            ReportIncidentCu.ViewPlayerId2 = "";
                            txtFirstName2.Text = "";
                            txtLastName2.Text = "";
                            txtAddress2.Text = "";
                            txtDOB2.Text = "";
                            txtMemberSince2.Text = "";
                            txtContact2.Text = "";
                            imgMember2.ImageUrl = "~/Images/white-background.png";
                            ReportIncidentCu.MemberPhoto2 = null; // set global variable to current member photo
                            ddlGender2.SelectedValue = "-1";
                            txtAge2.Text = "";
                            ddlAgeGroup2.SelectedValue = "5";
                            break;
                        case "3":
                            ReportIncidentCu.PlayerId3 = "";
                            ReportIncidentCu.ViewPlayerId3 = "";
                            txtFirstName3.Text = "";
                            txtLastName3.Text = "";
                            txtAddress3.Text = "";
                            txtDOB3.Text = "";
                            txtMemberSince3.Text = "";
                            txtContact3.Text = "";
                            imgMember3.ImageUrl = "~/Images/white-background.png";
                            ReportIncidentCu.MemberPhoto3 = null; // set global variable to current member photo
                            ddlGender3.SelectedValue = "-1";
                            txtAge3.Text = "";
                            ddlAgeGroup3.SelectedValue = "5";
                            break;
                        case "4":
                            ReportIncidentCu.PlayerId4 = "";
                            ReportIncidentCu.ViewPlayerId4 = "";
                            txtFirstName4.Text = "";
                            txtLastName4.Text = "";
                            txtAddress4.Text = "";
                            txtDOB4.Text = "";
                            txtMemberSince4.Text = "";
                            txtContact4.Text = "";
                            imgMember4.ImageUrl = "~/Images/white-background.png";
                            ReportIncidentCu.MemberPhoto4 = null; // set global variable to current member photo
                            ddlGender4.SelectedValue = "-1";
                            txtAge4.Text = "";
                            ddlAgeGroup4.SelectedValue = "5";
                            break;
                        case "5":
                            ReportIncidentCu.PlayerId5 = "";
                            ReportIncidentCu.ViewPlayerId5 = "";
                            txtFirstName5.Text = "";
                            txtLastName5.Text = "";
                            txtAddress5.Text = "";
                            txtDOB5.Text = "";
                            txtMemberSince5.Text = "";
                            txtContact5.Text = "";
                            imgMember5.ImageUrl = "~/Images/white-background.png";
                            ReportIncidentCu.MemberPhoto5 = null; // set global variable to current member photo
                            ddlGender5.SelectedValue = "-1";
                            txtAge5.Text = "";
                            ddlAgeGroup5.SelectedValue = "5";
                            break;
                    }
                    alert.DisplayMessage("Member Not Found!");
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
            if (method.Equals("SearchMember"))
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
        // set the Global variables to the current fields
        setGlobalVar();
        Report.RunEditMode = true;
    }

    // stores field data in global variables
    protected void setGlobalVar()
    {
        // check whether or not we show the Image control, Delete Button and tick the checkbox in Human Body Form
        if (!String.IsNullOrEmpty(lblImage1.Text))
        {
            cbHumanBody.Checked = true;
            Image1.Visible = true;
            btnDelete1.Visible = true;
        }
        else
        {
            cbHumanBody.Checked = false;
            ReportIncidentCu.Image1 = ""; // kept, just for next version, add the image varbinary to database. But currently doesn't affect the update query
            Image1.Visible = false;
            btnDelete1.Visible = false;
        }
        if (!String.IsNullOrEmpty(lblImage2.Text))
        {
            cbHumanBody2.Checked = true;
            Image2.Visible = true;
            btnDelete2.Visible = true;
        }
        else
        {
            cbHumanBody2.Checked = false;
            ReportIncidentCu.Image2 = "";
            Image2.Visible = false;
            btnDelete2.Visible = false;
        }
        if (!String.IsNullOrEmpty(lblImage3.Text))
        {
            cbHuman3.Checked = true;
            Image3.Visible = true;
            btnDelete3.Visible = true;
        }
        else
        {
            cbHuman3.Checked = false;
            ReportIncidentCu.Image3 = "";
            Image3.Visible = false;
            btnDelete3.Visible = false;
        }
        if (!String.IsNullOrEmpty(lblImage4.Text))
        {
            cbHuman4.Checked = true;
            Image4.Visible = true;
            btnDelete4.Visible = true;
        }
        else
        {
            cbHuman4.Checked = false;
            ReportIncidentCu.Image4 = "";
            Image4.Visible = false;
            btnDelete4.Visible = false;
        }
        if (!String.IsNullOrEmpty(lblImage5.Text))
        {
            cbHuman5.Checked = true;
            Image5.Visible = true;
            btnDelete5.Visible = true;
        }
        else
        {
            cbHuman5.Checked = false;
            ReportIncidentCu.Image5 = "";
            Image5.Visible = false;
            btnDelete5.Visible = false;
        }

        Report.ShiftId = ddlShift.SelectedItem.Value;
        Report.ShiftDate = DateTime.Parse(txtDatePicker.Text).ToString();
        Report.ShiftDOW = DateTime.Parse(Report.ShiftDate.ToString()).DayOfWeek.ToString();
        ReportIncidentCu.Date = txtDate1.Text;
        ReportIncidentCu.TxtTimeH = ddlHour.SelectedItem.Text;
        ReportIncidentCu.Hour = ddlHour.SelectedItem.Value;
        ReportIncidentCu.TxtTimeM = ddlMinutes.SelectedItem.Text;
        ReportIncidentCu.Minute = ddlMinutes.SelectedItem.Value;
        //ReportIncidentCu.TxtTimeTC = ddlTimeCon.SelectedItem.Text;
        //ReportIncidentCu.TC = ddlTimeCon.SelectedItem.Value;
        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string Location;
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
        List<string> uniques4 = Location.Split(',').Distinct().ToList(); // to remove duplicate values
        Location = string.Join(",", uniques4);
        if (!Location.Equals(""))
        {
            Location += ",";
        }

        ReportIncidentCu.Location = Location;
        ReportIncidentCu.LocationOther = txtLocation.Text;
        ReportIncidentCu.LocationOther = ReportIncidentCu.LocationOther;
        ReportIncidentCu.Details = txtDetails.Text.Replace("\n", "<br />");
        ReportIncidentCu.Details = ReportIncidentCu.Details;
        ReportIncidentCu.Allegation = txtAllegation.Text.Replace("\n", "<br />");
        ReportIncidentCu.Allegation = ReportIncidentCu.Allegation;
        // store in a string all the selected item in the checkboxlist
        // Create the list to store.
        string WhatHappened, RefuseReason = "", AskedLeave = "", ActionTaken = "";
        List<String> YrStrList = new List<string>();
        List<String> YrStrList2 = new List<string>();
        List<String> YrStrList3 = new List<string>();
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
        List<string> uniques3 = ActionTaken.Split(',').Distinct().ToList(); // to remove duplicate values
        ActionTaken = string.Join(",", uniques3);
        if (!ActionTaken.Equals(""))
        {
            ActionTaken += ",";
        }

        // Loop through each item.
        foreach (ListItem item in cblWhatHappened1.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                YrStrList.Add(item.Value);
            }
        }
        // Join the string together using the ',' delimiter.
        WhatHappened = String.Join(",", YrStrList.ToArray());
        List<string> uniques = WhatHappened.Split(',').Distinct().ToList();
        WhatHappened = string.Join(",", uniques);
        if (!WhatHappened.Equals(""))
        {
            WhatHappened += ",";
        }

        // check if Refuse Entry is not empty
        if (List_RefuseReason.SelectedValue != String.Empty)
        {
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
            List<string> uniques1 = RefuseReason.Split(',').Distinct().ToList();
            RefuseReason = string.Join(",", uniques1);
        }

        // check if Asked To Leave is not empty
        if (List_AskedToLeave.SelectedValue != String.Empty)
        {
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
            AskedLeave = String.Join(",", YrStrList3.ToArray());
            List<string> uniques2 = AskedLeave.Split(',').Distinct().ToList();
            AskedLeave = string.Join(",", uniques2);
        }

        ReportIncidentCu.ActionTaken = ActionTaken;
        ReportIncidentCu.ActionTakenOther = txtActionTakenOther.Text.Replace("\n", "<br />");
        ReportIncidentCu.ActionTakenOther = ReportIncidentCu.ActionTakenOther;
        ReportIncidentCu.WhatHappened = WhatHappened;
        ReportIncidentCu.HappenedOther = txtOthers.Text.Replace("\n", "<br />");
        ReportIncidentCu.HappenedOther = ReportIncidentCu.HappenedOther;
        ReportIncidentCu.HappenedSerious = txtOtherSerious.Text.Replace("\n", "<br />");
        ReportIncidentCu.HappenedSerious = ReportIncidentCu.HappenedSerious;
        ReportIncidentCu.HappenedRefuseEntry = RefuseReason;
        ReportIncidentCu.HappenedAskedLeave = AskedLeave;
        ReportIncidentCu.SecurityAttend = cbSecurity.Checked.ToString();
        ReportIncidentCu.SecurityName = txtSecurityName.Text;
        ReportIncidentCu.SecurityName = ReportIncidentCu.SecurityName;
        ReportIncidentCu.PoliceNotified = cbPolice.Checked.ToString();
        ReportIncidentCu.PoliceAction = txtPoliceAction.Text;
        ReportIncidentCu.PoliceAction = ReportIncidentCu.PoliceAction.Replace("\n", "<br />");
        ReportIncidentCu.OfficersName = txtOfficersName.Text;
        ReportIncidentCu.OfficersName = ReportIncidentCu.OfficersName.Replace("\n", "<br />");
        ReportIncidentCu.PoliceStation = txtPoliceStation.Text;
        ReportIncidentCu.PoliceStation = ReportIncidentCu.PoliceStation.Replace("\n", "<br />");
        ReportIncidentCu.NoOfPerson = lblNoOfPerson.Text;

        if (acpPerson1.Visible == true)
        {
            ReportIncidentCu.First1 = txtFirstName1.Text;
            ReportIncidentCu.First1 = ReportIncidentCu.First1;
            ReportIncidentCu.Last1 = txtLastName1.Text;
            ReportIncidentCu.Last1 = ReportIncidentCu.Last1;
            ReportIncidentCu.Alias1 = txtAlias1.Text;
            ReportIncidentCu.Alias1 = ReportIncidentCu.Alias1;
            ReportIncidentCu.Contact1 = txtContact1.Text;
            ReportIncidentCu.Contact1 = ReportIncidentCu.Contact1;
            ReportIncidentCu.Type1 = ddlPartyType1.SelectedItem.Value;
            if (ddlPartyType1.SelectedItem.Value == "1")
            {
                ReportIncidentCu.Member1 = txtMemberNo1.Text;
                ReportIncidentCu.Member1 = ReportIncidentCu.Member1;
                ReportIncidentCu.MDOB1 = txtDOB1.Text;
                ReportIncidentCu.MemberSince1 = txtMemberSince1.Text;
                ReportIncidentCu.MAddress1 = txtAddress1.Text;
                ReportIncidentCu.MAddress1 = ReportIncidentCu.MAddress1;
                ReportIncidentCu.Card1 = cbCardHeld1.Checked.ToString();
                ReportIncidentCu.SignInSlip1 = "false";

                // empty other selections (Staff and Visitor)
                ReportIncidentCu.StaffEmp1 = "";
                ReportIncidentCu.StaffAddress1 = "";

                ReportIncidentCu.SignInBy1 = "";
                ReportIncidentCu.VDOB1 = "";
                ReportIncidentCu.VAddress1 = "";
                ReportIncidentCu.VProofID1 = "";
            }
            else if (ddlPartyType1.SelectedItem.Value == "3")
            {
                ReportIncidentCu.StaffEmp1 = txtStaffEmpNo1.Text;
                ReportIncidentCu.StaffEmp1 = ReportIncidentCu.StaffEmp1;
                ReportIncidentCu.StaffAddress1 = txtStaffAddress1.Text;
                ReportIncidentCu.StaffAddress1 = ReportIncidentCu.StaffAddress1;
                ReportIncidentCu.Card1 = "false";
                ReportIncidentCu.SignInSlip1 = "false";

                // empty other selections (Member and Visitor)
                ReportIncidentCu.Member1 = "";
                ReportIncidentCu.MDOB1 = "";
                ReportIncidentCu.MAddress1 = "";
                ReportIncidentCu.MemberSince1 = "";

                ReportIncidentCu.SignInBy1 = "";
                ReportIncidentCu.VDOB1 = "";
                ReportIncidentCu.VAddress1 = "";
                ReportIncidentCu.VProofID1 = "";
            }
            else if (ddlPartyType1.SelectedItem.Value == "2")
            {
                ReportIncidentCu.Card1 = "false";
                ReportIncidentCu.SignInSlip1 = cbSignInSlip1.Checked.ToString();
                ReportIncidentCu.SignInBy1 = txtSignInBy1.Text;
                ReportIncidentCu.SignInBy1 = ReportIncidentCu.SignInBy1;
                ReportIncidentCu.VDOB1 = txtDOBv1.Text;
                ReportIncidentCu.VAddress1 = txtAddressv1.Text;
                ReportIncidentCu.VAddress1 = ReportIncidentCu.VAddress1;
                ReportIncidentCu.VProofID1 = txtIDProof1.Text;
                ReportIncidentCu.VProofID1 = ReportIncidentCu.VProofID1;

                // empty other selections (Member and Staff)
                ReportIncidentCu.Member1 = "";
                ReportIncidentCu.MDOB1 = "";
                ReportIncidentCu.MAddress1 = "";
                ReportIncidentCu.MemberSince1 = "";

                ReportIncidentCu.StaffEmp1 = "";
                ReportIncidentCu.StaffAddress1 = "";
            }
            else
            {
                ReportIncidentCu.Card1 = "false";
                ReportIncidentCu.SignInSlip1 = "false";

                // empty other selections (Member, Staff and Visitor)
                ReportIncidentCu.Member1 = "";
                ReportIncidentCu.MDOB1 = "";
                ReportIncidentCu.MAddress1 = "";
                ReportIncidentCu.MemberSince1 = "";

                ReportIncidentCu.StaffEmp1 = "";
                ReportIncidentCu.StaffAddress1 = "";

                ReportIncidentCu.SignInBy1 = "";
                ReportIncidentCu.VDOB1 = "";
                ReportIncidentCu.VAddress1 = "";
                ReportIncidentCu.VProofID1 = "";
            }

            ReportIncidentCu.Witness1 = cbWitness1.Checked.ToString();
            ReportIncidentCu.PDate1 = txtPDate1.Text;
            ReportIncidentCu.PTimeH1 = ddlPTimeH1.SelectedItem.Value;
            ReportIncidentCu.PTimeM1 = ddlPTimeM1.SelectedItem.Value;
            //ReportIncidentCu.PTimeTC1 = ddlPTimeTC1.SelectedItem.Value;
            ReportIncidentCu.Age1 = txtAge1.Text;
            ReportIncidentCu.Age1 = ReportIncidentCu.Age1;
            ReportIncidentCu.AgeGroup1 = ddlAgeGroup1.SelectedItem.Value;
            ReportIncidentCu.AgeGroup1 = ReportIncidentCu.AgeGroup1;
            ReportIncidentCu.Height1 = txtHeight1.Text;
            ReportIncidentCu.Height1 = ReportIncidentCu.Height1;
            ReportIncidentCu.Weight1 = ddlWeight1.SelectedItem.Value;
            ReportIncidentCu.Weight1 = ReportIncidentCu.Weight1;
            ReportIncidentCu.Hair1 = txtHair1.Text;
            ReportIncidentCu.Hair1 = ReportIncidentCu.Hair1;
            ReportIncidentCu.ClothingTop1 = txtClothingTop1.Text;
            ReportIncidentCu.ClothingTop1 = ReportIncidentCu.ClothingTop1;
            ReportIncidentCu.ClothingBottom1 = txtClothingBottom1.Text;
            ReportIncidentCu.ClothingBottom1 = ReportIncidentCu.ClothingBottom1;
            ReportIncidentCu.Shoes1 = txtShoes1.Text;
            ReportIncidentCu.Shoes1 = ReportIncidentCu.Shoes1;
            ReportIncidentCu.Weapon1 = txtWeapon1.Text;
            ReportIncidentCu.Weapon1 = ReportIncidentCu.Weapon1;
            ReportIncidentCu.Gender1 = ddlGender1.SelectedItem.Value;
            ReportIncidentCu.Gender1 = ReportIncidentCu.Gender1;
            ReportIncidentCu.DistFeat1 = txtDistFeatures1.Text;
            ReportIncidentCu.DistFeat1 = ReportIncidentCu.DistFeat1.Replace("\n", "<br />");
            ReportIncidentCu.InjuryDesc1 = txtInjuryDesc1.Text;
            ReportIncidentCu.InjuryDesc1 = ReportIncidentCu.InjuryDesc1.Replace("\n", "<br />");
            ReportIncidentCu.InjuryCause1 = txtInjuryCause1.Text;
            ReportIncidentCu.InjuryCause1 = ReportIncidentCu.InjuryCause1.Replace("\n", "<br />");
            ReportIncidentCu.InjuryComm1 = txtIncidentComm1.Text;
            ReportIncidentCu.InjuryComm1 = ReportIncidentCu.InjuryComm1.Replace("\n", "<br />");
            ReportIncidentCu.TxtPartyType1 = ddlPartyType1.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeH1 = ddlPTimeH1.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeM1 = ddlPTimeM1.SelectedItem.Text;
            //ReportIncidentCu.TxtPTimeTC1 = ddlPTimeTC1.SelectedItem.Text;
            ReportIncidentCu.TxtGender1 = ddlGender1.SelectedItem.Text;
        }
        else
        {
            ReportIncidentCu.Witness1 = "false";
            ReportIncidentCu.Card1 = "false";
            ReportIncidentCu.SignInSlip1 = "false";
            ReportIncidentCu.Type1 = "-1";
            ReportIncidentCu.PTimeH1 = "-1";
            ReportIncidentCu.PTimeM1 = "-1";
            //ReportIncidentCu.PTimeTC1 = "-1";
            ReportIncidentCu.Gender1 = "-1";
            ReportIncidentCu.AgeGroup1 = "-1";
        }

        if (acpPerson2.Visible == true)
        {
            ReportIncidentCu.First2 = txtFirstName2.Text;
            ReportIncidentCu.First2 = ReportIncidentCu.First2;
            ReportIncidentCu.Last2 = txtLastName2.Text;
            ReportIncidentCu.Last2 = ReportIncidentCu.Last2;
            ReportIncidentCu.Alias2 = txtAlias2.Text;
            ReportIncidentCu.Alias2 = ReportIncidentCu.Alias2;
            ReportIncidentCu.Contact2 = txtContact2.Text;
            ReportIncidentCu.Contact2 = ReportIncidentCu.Contact2;
            ReportIncidentCu.Type2 = ddlPartyType2.SelectedItem.Value;
            if (ddlPartyType2.SelectedItem.Value == "1")
            {
                ReportIncidentCu.Member2 = txtMemberNo2.Text;
                ReportIncidentCu.Member2 = ReportIncidentCu.Member2;
                ReportIncidentCu.MDOB2 = txtDOB2.Text;
                ReportIncidentCu.MemberSince2 = txtMemberSince2.Text;
                ReportIncidentCu.MAddress2 = txtAddress2.Text;
                ReportIncidentCu.MAddress2 = ReportIncidentCu.MAddress2;
                ReportIncidentCu.Card2 = cbCardHeld2.Checked.ToString();
                ReportIncidentCu.SignInSlip2 = "false";

                // empty other selections (Staff and Visitor)
                ReportIncidentCu.StaffEmp2 = "";
                ReportIncidentCu.StaffAddress2 = "";

                ReportIncidentCu.SignInBy2 = "";
                ReportIncidentCu.VDOB2 = "";
                ReportIncidentCu.VAddress2 = "";
                ReportIncidentCu.VProofID2 = "";
            }
            else if (ddlPartyType2.SelectedItem.Value == "3")
            {
                ReportIncidentCu.StaffEmp2 = txtStaffEmpNo2.Text;
                ReportIncidentCu.StaffEmp2 = ReportIncidentCu.StaffEmp2;
                ReportIncidentCu.StaffAddress2 = txtStaffAddress2.Text;
                ReportIncidentCu.StaffAddress2 = ReportIncidentCu.StaffAddress2;
                ReportIncidentCu.Card2 = "false";
                ReportIncidentCu.SignInSlip2 = "false";

                // empty other selections (Member and Visitor)
                ReportIncidentCu.Member2 = "";
                ReportIncidentCu.MDOB2 = "";
                ReportIncidentCu.MAddress2 = "";
                ReportIncidentCu.MemberSince2 = "";

                ReportIncidentCu.SignInBy2 = "";
                ReportIncidentCu.VDOB2 = "";
                ReportIncidentCu.VAddress2 = "";
                ReportIncidentCu.VProofID2 = "";
            }
            else if (ddlPartyType2.SelectedItem.Value == "2")
            {
                ReportIncidentCu.Card2 = "false";
                ReportIncidentCu.SignInSlip2 = cbSignInSlip2.Checked.ToString();
                ReportIncidentCu.SignInBy2 = txtSignInBy2.Text;
                ReportIncidentCu.SignInBy2 = ReportIncidentCu.SignInBy2;
                ReportIncidentCu.VDOB2 = txtDOBv2.Text;
                ReportIncidentCu.VAddress2 = txtAddressv2.Text;
                ReportIncidentCu.VAddress2 = ReportIncidentCu.VAddress2;
                ReportIncidentCu.VProofID2 = txtIDProof2.Text;
                ReportIncidentCu.VProofID2 = ReportIncidentCu.VProofID2;

                // empty other selections (Member and Staff)
                ReportIncidentCu.Member2 = "";
                ReportIncidentCu.MDOB2 = "";
                ReportIncidentCu.MAddress2 = "";
                ReportIncidentCu.MemberSince2 = "";

                ReportIncidentCu.StaffEmp2 = "";
                ReportIncidentCu.StaffAddress2 = "";
            }
            else
            {
                ReportIncidentCu.Card2 = "false";
                ReportIncidentCu.SignInSlip2 = "false";

                // empty other selections (Member, Staff and Visitor)
                ReportIncidentCu.Member2 = "";
                ReportIncidentCu.MDOB2 = "";
                ReportIncidentCu.MAddress2 = "";
                ReportIncidentCu.MemberSince2 = "";

                ReportIncidentCu.StaffEmp2 = "";
                ReportIncidentCu.StaffAddress2 = "";

                ReportIncidentCu.SignInBy2 = "";
                ReportIncidentCu.VDOB2 = "";
                ReportIncidentCu.VAddress2 = "";
                ReportIncidentCu.VProofID2 = "";
            }

            ReportIncidentCu.Witness2 = cbWitness2.Checked.ToString();
            ReportIncidentCu.PDate2 = txtPDate2.Text;
            ReportIncidentCu.PTimeH2 = ddlPTimeH2.SelectedItem.Value;
            ReportIncidentCu.PTimeM2 = ddlPTimeM2.SelectedItem.Value;
            //ReportIncidentCu.PTimeTC2 = ddlPTimeTC2.SelectedItem.Value;
            ReportIncidentCu.Age2 = txtAge2.Text;
            ReportIncidentCu.Age2 = ReportIncidentCu.Age2;
            ReportIncidentCu.AgeGroup2 = ddlAgeGroup2.SelectedItem.Value;
            ReportIncidentCu.AgeGroup2 = ReportIncidentCu.AgeGroup2;
            ReportIncidentCu.Height2 = txtHeight2.Text;
            ReportIncidentCu.Height2 = ReportIncidentCu.Height2;
            ReportIncidentCu.Weight2 = ddlWeight2.SelectedItem.Value;
            ReportIncidentCu.Weight2 = ReportIncidentCu.Weight2;
            ReportIncidentCu.Hair2 = txtHair2.Text;
            ReportIncidentCu.Hair2 = ReportIncidentCu.Hair2;
            ReportIncidentCu.ClothingTop2 = txtClothingTop2.Text;
            ReportIncidentCu.ClothingTop2 = ReportIncidentCu.ClothingTop2;
            ReportIncidentCu.ClothingBottom2 = txtClothingBottom2.Text;
            ReportIncidentCu.ClothingBottom2 = ReportIncidentCu.ClothingBottom2;
            ReportIncidentCu.Shoes2 = txtShoes2.Text;
            ReportIncidentCu.Shoes2 = ReportIncidentCu.Shoes2;
            ReportIncidentCu.Weapon2 = txtWeapon2.Text;
            ReportIncidentCu.Weapon2 = ReportIncidentCu.Weapon2;
            ReportIncidentCu.Gender2 = ddlGender2.SelectedItem.Value;
            ReportIncidentCu.Gender2 = ReportIncidentCu.Gender2;
            ReportIncidentCu.DistFeat2 = txtDistFeatures2.Text;
            ReportIncidentCu.DistFeat2 = ReportIncidentCu.DistFeat2.Replace("\n", "<br />");
            ReportIncidentCu.InjuryDesc2 = txtInjuryDesc2.Text;
            ReportIncidentCu.InjuryDesc2 = ReportIncidentCu.InjuryDesc2.Replace("\n", "<br />");
            ReportIncidentCu.InjuryCause2 = txtInjuryCause2.Text;
            ReportIncidentCu.InjuryCause2 = ReportIncidentCu.InjuryCause2.Replace("\n", "<br />");
            ReportIncidentCu.InjuryComm2 = txtIncidentComm2.Text;
            ReportIncidentCu.InjuryComm2 = ReportIncidentCu.InjuryComm2.Replace("\n", "<br />");
            ReportIncidentCu.TxtPartyType2 = ddlPartyType2.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeH2 = ddlPTimeH2.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeM2 = ddlPTimeM2.SelectedItem.Text;
            //ReportIncidentCu.TxtPTimeTC2 = ddlPTimeTC2.SelectedItem.Text;
            ReportIncidentCu.TxtGender2 = ddlGender2.SelectedItem.Text;
        }
        else
        {
            ReportIncidentCu.Witness2 = "false";
            ReportIncidentCu.Card2 = "false";
            ReportIncidentCu.SignInSlip2 = "false";
            ReportIncidentCu.Type2 = "-1";
            ReportIncidentCu.PTimeH2 = "-1";
            ReportIncidentCu.PTimeM2 = "-1";
            //ReportIncidentCu.PTimeTC2 = "-1";
            ReportIncidentCu.Gender2 = "-1";
            ReportIncidentCu.AgeGroup2 = "-1";
        }
        if (acpPerson3.Visible == true)
        {
            ReportIncidentCu.First3 = txtFirstName3.Text;
            ReportIncidentCu.First3 = ReportIncidentCu.First3;
            ReportIncidentCu.Last3 = txtLastName3.Text;
            ReportIncidentCu.Last3 = ReportIncidentCu.Last3;
            ReportIncidentCu.Alias3 = txtAlias3.Text;
            ReportIncidentCu.Alias3 = ReportIncidentCu.Alias3;
            ReportIncidentCu.Contact3 = txtContact3.Text;
            ReportIncidentCu.Contact3 = ReportIncidentCu.Contact3;
            ReportIncidentCu.Type3 = ddlPartyType3.SelectedItem.Value;
            if (ddlPartyType3.SelectedItem.Value == "1")
            {
                ReportIncidentCu.Member3 = txtMemberNo3.Text;
                ReportIncidentCu.Member3 = ReportIncidentCu.Member3;
                ReportIncidentCu.MDOB3 = txtDOB3.Text;
                ReportIncidentCu.MemberSince3 = txtMemberSince3.Text;
                ReportIncidentCu.MAddress3 = txtAddress3.Text;
                ReportIncidentCu.MAddress3 = ReportIncidentCu.MAddress3;
                ReportIncidentCu.Card3 = cbCardHeld3.Checked.ToString();
                ReportIncidentCu.SignInSlip3 = "false";

                // empty other selections (Staff and Visitor)
                ReportIncidentCu.StaffEmp3 = "";
                ReportIncidentCu.StaffAddress3 = "";

                ReportIncidentCu.SignInBy3 = "";
                ReportIncidentCu.VDOB3 = "";
                ReportIncidentCu.VAddress3 = "";
                ReportIncidentCu.VProofID3 = "";
            }
            else if (ddlPartyType3.SelectedItem.Value == "3")
            {
                ReportIncidentCu.StaffEmp3 = txtStaffEmpNo3.Text;
                ReportIncidentCu.StaffEmp3 = ReportIncidentCu.StaffEmp3;
                ReportIncidentCu.StaffAddress3 = txtStaffAddress3.Text;
                ReportIncidentCu.StaffAddress3 = ReportIncidentCu.StaffAddress3;
                ReportIncidentCu.Card3 = "false";
                ReportIncidentCu.SignInSlip3 = "false";

                // empty other selections (Member and Visitor)
                ReportIncidentCu.Member3 = "";
                ReportIncidentCu.MDOB3 = "";
                ReportIncidentCu.MAddress3 = "";
                ReportIncidentCu.MemberSince3 = "";

                ReportIncidentCu.SignInBy3 = "";
                ReportIncidentCu.VDOB3 = "";
                ReportIncidentCu.VAddress3 = "";
                ReportIncidentCu.VProofID3 = "";
            }
            else if (ddlPartyType3.SelectedItem.Value == "2")
            {
                ReportIncidentCu.Card3 = "false";
                ReportIncidentCu.SignInSlip3 = cbSignInSlip3.Checked.ToString();
                ReportIncidentCu.SignInBy3 = txtSignInBy3.Text;
                ReportIncidentCu.SignInBy3 = ReportIncidentCu.SignInBy3;
                ReportIncidentCu.VDOB3 = txtDOBv3.Text;
                ReportIncidentCu.VAddress3 = txtAddressv3.Text;
                ReportIncidentCu.VAddress3 = ReportIncidentCu.VAddress3;
                ReportIncidentCu.VProofID3 = txtIDProof3.Text;
                ReportIncidentCu.VProofID3 = ReportIncidentCu.VProofID3;

                // empty other selections (Member and Staff)
                ReportIncidentCu.Member3 = "";
                ReportIncidentCu.MDOB3 = "";
                ReportIncidentCu.MAddress3 = "";
                ReportIncidentCu.MemberSince3 = "";

                ReportIncidentCu.StaffEmp3 = "";
                ReportIncidentCu.StaffAddress3 = "";
            }
            else
            {
                ReportIncidentCu.Card3 = "false";
                ReportIncidentCu.SignInSlip3 = "false";

                // empty other selections (Member, Staff and Visitor)
                ReportIncidentCu.Member3 = "";
                ReportIncidentCu.MDOB3 = "";
                ReportIncidentCu.MAddress3 = "";
                ReportIncidentCu.MemberSince3 = "";

                ReportIncidentCu.StaffEmp3 = "";
                ReportIncidentCu.StaffAddress3 = "";

                ReportIncidentCu.SignInBy3 = "";
                ReportIncidentCu.VDOB3 = "";
                ReportIncidentCu.VAddress3 = "";
                ReportIncidentCu.VProofID3 = "";
            }

            ReportIncidentCu.Witness3 = cbWitness3.Checked.ToString();
            ReportIncidentCu.PDate3 = txtPDate3.Text;
            ReportIncidentCu.PTimeH3 = ddlPTimeH3.SelectedItem.Value;
            ReportIncidentCu.PTimeM3 = ddlPTimeM3.SelectedItem.Value;
            //ReportIncidentCu.PTimeTC3 = ddlPTimeTC3.SelectedItem.Value;
            ReportIncidentCu.Age3 = txtAge3.Text;
            ReportIncidentCu.Age3 = ReportIncidentCu.Age3;
            ReportIncidentCu.AgeGroup3 = ddlAgeGroup3.SelectedItem.Value;
            ReportIncidentCu.AgeGroup3 = ReportIncidentCu.AgeGroup3;
            ReportIncidentCu.Height3 = txtHeight3.Text;
            ReportIncidentCu.Height3 = ReportIncidentCu.Height3;
            ReportIncidentCu.Weight3 = ddlWeight3.SelectedItem.Value;
            ReportIncidentCu.Weight3 = ReportIncidentCu.Weight3;
            ReportIncidentCu.Hair3 = txtHair3.Text;
            ReportIncidentCu.Hair3 = ReportIncidentCu.Hair3;
            ReportIncidentCu.ClothingTop3 = txtClothingTop3.Text;
            ReportIncidentCu.ClothingTop3 = ReportIncidentCu.ClothingTop3;
            ReportIncidentCu.ClothingBottom3 = txtClothingBottom3.Text;
            ReportIncidentCu.ClothingBottom3 = ReportIncidentCu.ClothingBottom3;
            ReportIncidentCu.Shoes3 = txtShoes3.Text;
            ReportIncidentCu.Shoes3 = ReportIncidentCu.Shoes3;
            ReportIncidentCu.Weapon3 = txtWeapon3.Text;
            ReportIncidentCu.Weapon3 = ReportIncidentCu.Weapon3;
            ReportIncidentCu.Gender3 = ddlGender3.SelectedItem.Value;
            ReportIncidentCu.Gender3 = ReportIncidentCu.Gender3;
            ReportIncidentCu.DistFeat3 = txtDistFeatures3.Text;
            ReportIncidentCu.DistFeat3 = ReportIncidentCu.DistFeat3.Replace("\n", "<br />");
            ReportIncidentCu.InjuryDesc3 = txtInjuryDesc3.Text;
            ReportIncidentCu.InjuryDesc3 = ReportIncidentCu.InjuryDesc3.Replace("\n", "<br />");
            ReportIncidentCu.InjuryCause3 = txtInjuryCause3.Text;
            ReportIncidentCu.InjuryCause3 = ReportIncidentCu.InjuryCause3.Replace("\n", "<br />");
            ReportIncidentCu.InjuryComm3 = txtIncidentComm3.Text;
            ReportIncidentCu.InjuryComm3 = ReportIncidentCu.InjuryComm3.Replace("\n", "<br />");
            ReportIncidentCu.TxtPartyType3 = ddlPartyType3.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeH3 = ddlPTimeH3.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeM3 = ddlPTimeM3.SelectedItem.Text;
            //ReportIncidentCu.TxtPTimeTC3 = ddlPTimeTC3.SelectedItem.Text;
            ReportIncidentCu.TxtGender3 = ddlGender3.SelectedItem.Text;
        }
        else
        {
            ReportIncidentCu.Witness3 = "false";
            ReportIncidentCu.Card3 = "false";
            ReportIncidentCu.SignInSlip3 = "false";
            ReportIncidentCu.Type3 = "-1";
            ReportIncidentCu.PTimeH3 = "-1";
            ReportIncidentCu.PTimeM3 = "-1";
            //ReportIncidentCu.PTimeTC3 = "-1";
            ReportIncidentCu.Gender3 = "-1";
            ReportIncidentCu.AgeGroup3 = "-1";
        }

        if (acpPerson4.Visible == true)
        {
            ReportIncidentCu.First4 = txtFirstName4.Text;
            ReportIncidentCu.First4 = ReportIncidentCu.First4;
            ReportIncidentCu.Last4 = txtLastName4.Text;
            ReportIncidentCu.Last4 = ReportIncidentCu.Last4;
            ReportIncidentCu.Alias4 = txtAlias4.Text;
            ReportIncidentCu.Alias4 = ReportIncidentCu.Alias4;
            ReportIncidentCu.Contact4 = txtContact4.Text;
            ReportIncidentCu.Contact4 = ReportIncidentCu.Contact4;
            ReportIncidentCu.Type4 = ddlPartyType4.SelectedItem.Value;
            if (ddlPartyType4.SelectedItem.Value == "1")
            {
                ReportIncidentCu.Member4 = txtMemberNo4.Text;
                ReportIncidentCu.Member4 = ReportIncidentCu.Member4;
                ReportIncidentCu.MDOB4 = txtDOB4.Text;
                ReportIncidentCu.MemberSince4 = txtMemberSince4.Text;
                ReportIncidentCu.MAddress4 = txtAddress4.Text;
                ReportIncidentCu.MAddress4 = ReportIncidentCu.MAddress4;
                ReportIncidentCu.Card4 = cbCardHeld4.Checked.ToString();
                ReportIncidentCu.SignInSlip4 = "false";

                // empty other selections (Staff and Visitor)
                ReportIncidentCu.StaffEmp4 = "";
                ReportIncidentCu.StaffAddress4 = "";

                ReportIncidentCu.SignInBy4 = "";
                ReportIncidentCu.VDOB4 = "";
                ReportIncidentCu.VAddress4 = "";
                ReportIncidentCu.VProofID4 = "";
            }
            else if (ddlPartyType4.SelectedItem.Value == "3")
            {
                ReportIncidentCu.StaffEmp4 = txtStaffEmpNo4.Text;
                ReportIncidentCu.StaffEmp4 = ReportIncidentCu.StaffEmp4;
                ReportIncidentCu.StaffAddress4 = txtStaffAddress4.Text;
                ReportIncidentCu.StaffAddress4 = ReportIncidentCu.StaffAddress4;
                ReportIncidentCu.Card4 = "false";
                ReportIncidentCu.SignInSlip4 = "false";

                // empty other selections (Member and Visitor)
                ReportIncidentCu.Member4 = "";
                ReportIncidentCu.MDOB4 = "";
                ReportIncidentCu.MAddress4 = "";
                ReportIncidentCu.MemberSince4 = "";

                ReportIncidentCu.SignInBy4 = "";
                ReportIncidentCu.VDOB4 = "";
                ReportIncidentCu.VAddress4 = "";
                ReportIncidentCu.VProofID4 = "";
            }
            else if (ddlPartyType4.SelectedItem.Value == "2")
            {
                ReportIncidentCu.Card4 = "false";
                ReportIncidentCu.SignInSlip4 = cbSignInSlip4.Checked.ToString();
                ReportIncidentCu.SignInBy4 = txtSignInBy4.Text;
                ReportIncidentCu.SignInBy4 = ReportIncidentCu.SignInBy4;
                ReportIncidentCu.VDOB4 = txtDOBv4.Text;
                ReportIncidentCu.VAddress4 = txtAddressv4.Text;
                ReportIncidentCu.VAddress4 = ReportIncidentCu.VAddress4;
                ReportIncidentCu.VProofID4 = txtIDProof4.Text;
                ReportIncidentCu.VProofID4 = ReportIncidentCu.VProofID4;

                // empty other selections (Member and Staff)
                ReportIncidentCu.Member4 = "";
                ReportIncidentCu.MDOB4 = "";
                ReportIncidentCu.MAddress4 = "";
                ReportIncidentCu.MemberSince4 = "";

                ReportIncidentCu.StaffEmp4 = "";
                ReportIncidentCu.StaffAddress4 = "";
            }
            else
            {
                ReportIncidentCu.Card4 = "false";
                ReportIncidentCu.SignInSlip4 = "false";

                // empty other selections (Member, Staff and Visitor)
                ReportIncidentCu.Member4 = "";
                ReportIncidentCu.MDOB4 = "";
                ReportIncidentCu.MAddress4 = "";
                ReportIncidentCu.MemberSince4 = "";

                ReportIncidentCu.StaffEmp4 = "";
                ReportIncidentCu.StaffAddress4 = "";

                ReportIncidentCu.SignInBy4 = "";
                ReportIncidentCu.VDOB4 = "";
                ReportIncidentCu.VAddress4 = "";
                ReportIncidentCu.VProofID4 = "";
            }

            ReportIncidentCu.Witness4 = cbWitness4.Checked.ToString();
            ReportIncidentCu.PDate4 = txtPDate4.Text;
            ReportIncidentCu.PTimeH4 = ddlPTimeH4.SelectedItem.Value;
            ReportIncidentCu.PTimeM4 = ddlPTimeM4.SelectedItem.Value;
            //ReportIncidentCu.PTimeTC4 = ddlPTimeTC4.SelectedItem.Value;
            ReportIncidentCu.Age4 = txtAge4.Text;
            ReportIncidentCu.Age4 = ReportIncidentCu.Age4;
            ReportIncidentCu.AgeGroup4 = ddlAgeGroup4.SelectedItem.Value;
            ReportIncidentCu.AgeGroup4 = ReportIncidentCu.AgeGroup4;
            ReportIncidentCu.Height4 = txtHeight4.Text;
            ReportIncidentCu.Height4 = ReportIncidentCu.Height4;
            ReportIncidentCu.Weight4 = ddlWeight4.SelectedItem.Value;
            ReportIncidentCu.Weight4 = ReportIncidentCu.Weight4;
            ReportIncidentCu.Hair4 = txtHair4.Text;
            ReportIncidentCu.Hair4 = ReportIncidentCu.Hair4;
            ReportIncidentCu.ClothingTop4 = txtClothingTop4.Text;
            ReportIncidentCu.ClothingTop4 = ReportIncidentCu.ClothingTop4;
            ReportIncidentCu.ClothingBottom4 = txtClothingBottom4.Text;
            ReportIncidentCu.ClothingBottom4 = ReportIncidentCu.ClothingBottom4;
            ReportIncidentCu.Shoes4 = txtShoes4.Text;
            ReportIncidentCu.Shoes4 = ReportIncidentCu.Shoes4;
            ReportIncidentCu.Weapon4 = txtWeapon4.Text;
            ReportIncidentCu.Weapon4 = ReportIncidentCu.Weapon4;
            ReportIncidentCu.Gender4 = ddlGender4.SelectedItem.Value;
            ReportIncidentCu.Gender4 = ReportIncidentCu.Gender4;
            ReportIncidentCu.DistFeat4 = txtDistFeatures4.Text;
            ReportIncidentCu.DistFeat4 = ReportIncidentCu.DistFeat4.Replace("\n", "<br />");
            ReportIncidentCu.InjuryDesc4 = txtInjuryDesc4.Text;
            ReportIncidentCu.InjuryDesc4 = ReportIncidentCu.InjuryDesc4.Replace("\n", "<br />");
            ReportIncidentCu.InjuryCause4 = txtInjuryCause4.Text;
            ReportIncidentCu.InjuryCause4 = ReportIncidentCu.InjuryCause4.Replace("\n", "<br />");
            ReportIncidentCu.InjuryComm4 = txtIncidentComm4.Text;
            ReportIncidentCu.InjuryComm4 = ReportIncidentCu.InjuryComm4.Replace("\n", "<br />");
            ReportIncidentCu.TxtPartyType4 = ddlPartyType4.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeH4 = ddlPTimeH4.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeM4 = ddlPTimeM4.SelectedItem.Text;
            //ReportIncidentCu.TxtPTimeTC4 = ddlPTimeTC4.SelectedItem.Text;
            ReportIncidentCu.TxtGender4 = ddlGender4.SelectedItem.Text;
        }
        else
        {
            ReportIncidentCu.Witness4 = "false";
            ReportIncidentCu.Card4 = "false";
            ReportIncidentCu.SignInSlip4 = "false";
            ReportIncidentCu.Type4 = "-1";
            ReportIncidentCu.PTimeH4 = "-1";
            ReportIncidentCu.PTimeM4 = "-1";
            //ReportIncidentCu.PTimeTC4 = "-1";
            ReportIncidentCu.Gender4 = "-1";
            ReportIncidentCu.AgeGroup4 = "-1";
        }

        if (acpPerson5.Visible == true)
        {
            ReportIncidentCu.First5 = txtFirstName5.Text;
            ReportIncidentCu.First5 = ReportIncidentCu.First5;
            ReportIncidentCu.Last5 = txtLastName5.Text;
            ReportIncidentCu.Last5 = ReportIncidentCu.Last5;
            ReportIncidentCu.Alias5 = txtAlias5.Text;
            ReportIncidentCu.Alias5 = ReportIncidentCu.Alias5;
            ReportIncidentCu.Contact5 = txtContact5.Text;
            ReportIncidentCu.Contact5 = ReportIncidentCu.Contact5;
            ReportIncidentCu.Type5 = ddlPartyType5.SelectedItem.Value;
            if (ddlPartyType5.SelectedItem.Value == "1")
            {
                ReportIncidentCu.Member5 = txtMemberNo5.Text;
                ReportIncidentCu.Member5 = ReportIncidentCu.Member5;
                ReportIncidentCu.MDOB5 = txtDOB5.Text;
                ReportIncidentCu.MemberSince5 = txtMemberSince5.Text;
                ReportIncidentCu.MAddress5 = txtAddress5.Text;
                ReportIncidentCu.MAddress5 = ReportIncidentCu.MAddress5;
                ReportIncidentCu.Card5 = cbCardHeld5.Checked.ToString();
                ReportIncidentCu.SignInSlip5 = "false";

                // empty other selections (Staff and Visitor)
                ReportIncidentCu.StaffEmp5 = "";
                ReportIncidentCu.StaffAddress5 = "";

                ReportIncidentCu.SignInBy5 = "";
                ReportIncidentCu.VDOB5 = "";
                ReportIncidentCu.VAddress5 = "";
                ReportIncidentCu.VProofID5 = "";
            }
            else if (ddlPartyType5.SelectedItem.Value == "3")
            {
                ReportIncidentCu.StaffEmp5 = txtStaffEmpNo5.Text;
                ReportIncidentCu.StaffEmp5 = ReportIncidentCu.StaffEmp5;
                ReportIncidentCu.StaffAddress5 = txtStaffAddress5.Text;
                ReportIncidentCu.StaffAddress5 = ReportIncidentCu.StaffAddress5;
                ReportIncidentCu.Card5 = "false";
                ReportIncidentCu.SignInSlip5 = "false";

                // empty other selections (Member and Visitor)
                ReportIncidentCu.Member5 = "";
                ReportIncidentCu.MDOB5 = "";
                ReportIncidentCu.MAddress5 = "";
                ReportIncidentCu.MemberSince5 = "";

                ReportIncidentCu.SignInBy5 = "";
                ReportIncidentCu.VDOB5 = "";
                ReportIncidentCu.VAddress5 = "";
                ReportIncidentCu.VProofID5 = "";
            }
            else if (ddlPartyType5.SelectedItem.Value == "2")
            {
                ReportIncidentCu.Card5 = "false";
                ReportIncidentCu.SignInSlip5 = cbSignInSlip5.Checked.ToString();
                ReportIncidentCu.SignInBy5 = txtSignInBy5.Text;
                ReportIncidentCu.SignInBy5 = ReportIncidentCu.SignInBy5;
                ReportIncidentCu.VDOB5 = txtDOBv5.Text;
                ReportIncidentCu.VAddress5 = txtAddressv5.Text;
                ReportIncidentCu.VAddress5 = ReportIncidentCu.VAddress5;
                ReportIncidentCu.VProofID5 = txtIDProof5.Text;
                ReportIncidentCu.VProofID5 = ReportIncidentCu.VProofID5;

                // empty other selections (Member and Staff)
                ReportIncidentCu.Member5 = "";
                ReportIncidentCu.MDOB5 = "";
                ReportIncidentCu.MAddress5 = "";
                ReportIncidentCu.MemberSince5 = "";

                ReportIncidentCu.StaffEmp5 = "";
                ReportIncidentCu.StaffAddress5 = "";
            }
            else
            {
                ReportIncidentCu.Card5 = "false";
                ReportIncidentCu.SignInSlip5 = "false";

                // empty other selections (Member, Staff and Visitor)
                ReportIncidentCu.Member5 = "";
                ReportIncidentCu.MDOB5 = "";
                ReportIncidentCu.MAddress5 = "";
                ReportIncidentCu.MemberSince5 = "";

                ReportIncidentCu.StaffEmp5 = "";
                ReportIncidentCu.StaffAddress5 = "";

                ReportIncidentCu.SignInBy5 = "";
                ReportIncidentCu.VDOB5 = "";
                ReportIncidentCu.VAddress5 = "";
                ReportIncidentCu.VProofID5 = "";
            }

            ReportIncidentCu.Witness5 = cbWitness5.Checked.ToString();
            ReportIncidentCu.PDate5 = txtPDate5.Text;
            ReportIncidentCu.PTimeH5 = ddlPTimeH5.SelectedItem.Value;
            ReportIncidentCu.PTimeM5 = ddlPTimeM5.SelectedItem.Value;
            //ReportIncidentCu.PTimeTC5 = ddlPTimeTC5.SelectedItem.Value;
            ReportIncidentCu.Age5 = txtAge5.Text;
            ReportIncidentCu.Age5 = ReportIncidentCu.Age5;
            ReportIncidentCu.AgeGroup5 = ddlAgeGroup5.SelectedItem.Value;
            ReportIncidentCu.AgeGroup5 = ReportIncidentCu.AgeGroup5;
            ReportIncidentCu.Height5 = txtHeight5.Text;
            ReportIncidentCu.Height5 = ReportIncidentCu.Height5;
            ReportIncidentCu.Weight5 = ddlWeight5.SelectedItem.Value;
            ReportIncidentCu.Weight5 = ReportIncidentCu.Weight5;
            ReportIncidentCu.Hair5 = txtHair5.Text;
            ReportIncidentCu.Hair5 = ReportIncidentCu.Hair5;
            ReportIncidentCu.ClothingTop5 = txtClothingTop5.Text;
            ReportIncidentCu.ClothingTop5 = ReportIncidentCu.ClothingTop5;
            ReportIncidentCu.ClothingBottom5 = txtClothingBottom5.Text;
            ReportIncidentCu.ClothingBottom5 = ReportIncidentCu.ClothingBottom5;
            ReportIncidentCu.Shoes5 = txtShoes5.Text;
            ReportIncidentCu.Shoes5 = ReportIncidentCu.Shoes5;
            ReportIncidentCu.Weapon5 = txtWeapon5.Text;
            ReportIncidentCu.Weapon5 = ReportIncidentCu.Weapon5;
            ReportIncidentCu.Gender5 = ddlGender5.SelectedItem.Value;
            ReportIncidentCu.Gender5 = ReportIncidentCu.Gender5;
            ReportIncidentCu.DistFeat5 = txtDistFeatures5.Text;
            ReportIncidentCu.DistFeat5 = ReportIncidentCu.DistFeat5.Replace("\n", "<br />");
            ReportIncidentCu.InjuryDesc5 = txtInjuryDesc5.Text;
            ReportIncidentCu.InjuryDesc5 = ReportIncidentCu.InjuryDesc5.Replace("\n", "<br />");
            ReportIncidentCu.InjuryCause5 = txtInjuryCause5.Text;
            ReportIncidentCu.InjuryCause5 = ReportIncidentCu.InjuryCause5.Replace("\n", "<br />");
            ReportIncidentCu.InjuryComm5 = txtIncidentComm5.Text;
            ReportIncidentCu.InjuryComm5 = ReportIncidentCu.InjuryComm5.Replace("\n", "<br />");
            ReportIncidentCu.TxtPartyType5 = ddlPartyType5.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeH5 = ddlPTimeH5.SelectedItem.Text;
            ReportIncidentCu.TxtPTimeM5 = ddlPTimeM5.SelectedItem.Text;
            //ReportIncidentCu.TxtPTimeTC5 = ddlPTimeTC5.SelectedItem.Text;
            ReportIncidentCu.TxtGender5 = ddlGender5.SelectedItem.Text;
        }
        else
        {
            ReportIncidentCu.Witness5 = "false";
            ReportIncidentCu.Card5 = "false";
            ReportIncidentCu.SignInSlip5 = "false";
            ReportIncidentCu.Type5 = "-1";
            ReportIncidentCu.PTimeH5 = "-1";
            ReportIncidentCu.PTimeM5 = "-1";
            //ReportIncidentCu.PTimeTC5 = "-1";
            ReportIncidentCu.Gender5 = "-1";
            ReportIncidentCu.AgeGroup5 = "-1";
        }

        /* Camera 1 */
        ReportIncidentCu.CamDesc1 = txtCamDesc1.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc1 = ReportIncidentCu.CamDesc1;
        ReportIncidentCu.SDate1 = txtCamSDate1.Text;
        ReportIncidentCu.STimeH1 = ddlCamTimeH1.SelectedItem.Value;
        ReportIncidentCu.STimeM1 = ddlCamTimeM1.SelectedItem.Value;
        //ReportIncidentCu.STimeTC1 = ddlCamTimeTC1.SelectedItem.Value;
        ReportIncidentCu.EDate1 = txtCamEDate1.Text;
        ReportIncidentCu.ETimeH1 = ddlCamETimeH1.SelectedItem.Value;
        ReportIncidentCu.ETimeM1 = ddlCamETimeM1.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC1 = ddlCamETimeTC1.SelectedItem.Value;
        ReportIncidentCu.FilePath1 = txtCamFilePath1.Text;
        ReportIncidentCu.FilePath1 = ReportIncidentCu.FilePath1;
        ReportIncidentCu.CamRec1 = cbRecorded1.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH1 = ddlCamTimeH1.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM1 = ddlCamTimeM1.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC1 = ddlCamTimeTC1.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH1 = ddlCamETimeH1.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM1 = ddlCamETimeM1.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC1 = ddlCamETimeTC1.SelectedItem.Text;

        /* Camera 2 */
        ReportIncidentCu.CamDesc2 = txtCamDesc2.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc2 = ReportIncidentCu.CamDesc2;
        ReportIncidentCu.SDate2 = txtCamSDate2.Text;
        ReportIncidentCu.STimeH2 = ddlCamTimeH2.SelectedItem.Value;
        ReportIncidentCu.STimeM2 = ddlCamTimeM2.SelectedItem.Value;
        //ReportIncidentCu.STimeTC2 = ddlCamTimeTC2.SelectedItem.Value;
        ReportIncidentCu.EDate2 = txtCamEDate2.Text;
        ReportIncidentCu.ETimeH2 = ddlCamETimeH2.SelectedItem.Value;
        ReportIncidentCu.ETimeM2 = ddlCamETimeM2.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC2 = ddlCamETimeTC2.SelectedItem.Value;
        ReportIncidentCu.FilePath2 = txtCamFilePath2.Text;
        ReportIncidentCu.FilePath2 = ReportIncidentCu.FilePath2;
        ReportIncidentCu.CamRec2 = cbRecorded2.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH2 = ddlCamTimeH2.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM2 = ddlCamTimeM2.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC2 = ddlCamTimeTC2.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH2 = ddlCamETimeH2.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM2 = ddlCamETimeM2.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC2 = ddlCamETimeTC2.SelectedItem.Text;

        /* Camera 3 */
        ReportIncidentCu.CamDesc3 = txtCamDesc3.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc3 = ReportIncidentCu.CamDesc3;
        ReportIncidentCu.SDate3 = txtCamSDate3.Text;
        ReportIncidentCu.STimeH3 = ddlCamTimeH3.SelectedItem.Value;
        ReportIncidentCu.STimeM3 = ddlCamTimeM3.SelectedItem.Value;
        //ReportIncidentCu.STimeTC3 = ddlCamTimeTC3.SelectedItem.Value;
        ReportIncidentCu.EDate3 = txtCamEDate3.Text;
        ReportIncidentCu.ETimeH3 = ddlCamETimeH3.SelectedItem.Value;
        ReportIncidentCu.ETimeM3 = ddlCamETimeM3.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC3 = ddlCamETimeTC3.SelectedItem.Value;
        ReportIncidentCu.FilePath3 = txtCamFilePath3.Text;
        ReportIncidentCu.FilePath3 = ReportIncidentCu.FilePath3;
        ReportIncidentCu.CamRec3 = cbRecorded3.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH3 = ddlCamTimeH3.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM3 = ddlCamTimeM3.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC3 = ddlCamTimeTC3.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH3 = ddlCamETimeH3.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM3 = ddlCamETimeM3.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC3 = ddlCamETimeTC3.SelectedItem.Text;

        /* Camera 4 */
        ReportIncidentCu.CamDesc4 = txtCamDesc4.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc4 = ReportIncidentCu.CamDesc4;
        ReportIncidentCu.SDate4 = txtCamSDate4.Text;
        ReportIncidentCu.STimeH4 = ddlCamTimeH4.SelectedItem.Value;
        ReportIncidentCu.STimeM4 = ddlCamTimeM4.SelectedItem.Value;
        //ReportIncidentCu.STimeTC4 = ddlCamTimeTC4.SelectedItem.Value;
        ReportIncidentCu.EDate4 = txtCamEDate4.Text;
        ReportIncidentCu.ETimeH4 = ddlCamETimeH4.SelectedItem.Value;
        ReportIncidentCu.ETimeM4 = ddlCamETimeM4.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC4 = ddlCamETimeTC4.SelectedItem.Value;
        ReportIncidentCu.FilePath4 = txtCamFilePath4.Text;
        ReportIncidentCu.FilePath4 = ReportIncidentCu.FilePath4;
        ReportIncidentCu.CamRec4 = cbRecorded4.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH4 = ddlCamTimeH4.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM4 = ddlCamTimeM4.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC4 = ddlCamTimeTC4.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH4 = ddlCamETimeH4.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM4 = ddlCamETimeM4.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC4 = ddlCamETimeTC4.SelectedItem.Text;

        /* Camera 5 */
        ReportIncidentCu.CamDesc5 = txtCamDesc5.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc5 = ReportIncidentCu.CamDesc5;
        ReportIncidentCu.SDate5 = txtCamSDate5.Text;
        ReportIncidentCu.STimeH5 = ddlCamTimeH5.SelectedItem.Value;
        ReportIncidentCu.STimeM5 = ddlCamTimeM5.SelectedItem.Value;
        //ReportIncidentCu.STimeTC5 = ddlCamTimeTC5.SelectedItem.Value;
        ReportIncidentCu.EDate5 = txtCamEDate5.Text;
        ReportIncidentCu.ETimeH5 = ddlCamETimeH5.SelectedItem.Value;
        ReportIncidentCu.ETimeM5 = ddlCamETimeM5.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC5 = ddlCamETimeTC5.SelectedItem.Value;
        ReportIncidentCu.FilePath5 = txtCamFilePath5.Text;
        ReportIncidentCu.FilePath5 = ReportIncidentCu.FilePath5;
        ReportIncidentCu.CamRec5 = cbRecorded5.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH5 = ddlCamTimeH5.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM5 = ddlCamTimeM5.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC5 = ddlCamTimeTC5.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH5 = ddlCamETimeH5.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM5 = ddlCamETimeM5.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC5 = ddlCamETimeTC5.SelectedItem.Text;

        /* Camera 6 */
        ReportIncidentCu.CamDesc6 = txtCamDesc6.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc6 = ReportIncidentCu.CamDesc6;
        ReportIncidentCu.SDate6 = txtCamSDate6.Text;
        ReportIncidentCu.STimeH6 = ddlCamTimeH6.SelectedItem.Value;
        ReportIncidentCu.STimeM6 = ddlCamTimeM6.SelectedItem.Value;
        //ReportIncidentCu.STimeTC6 = ddlCamTimeTC6.SelectedItem.Value;
        ReportIncidentCu.EDate6 = txtCamEDate6.Text;
        ReportIncidentCu.ETimeH6 = ddlCamETimeH6.SelectedItem.Value;
        ReportIncidentCu.ETimeM6 = ddlCamETimeM6.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC6 = ddlCamETimeTC6.SelectedItem.Value;
        ReportIncidentCu.FilePath6 = txtCamFilePath6.Text;
        ReportIncidentCu.FilePath6 = ReportIncidentCu.FilePath6;
        ReportIncidentCu.CamRec6 = cbRecorded6.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH6 = ddlCamTimeH6.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM6 = ddlCamTimeM6.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC6 = ddlCamTimeTC6.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH6 = ddlCamETimeH6.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM6 = ddlCamETimeM6.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC6 = ddlCamETimeTC6.SelectedItem.Text;

        /* Camera 7 */
        ReportIncidentCu.CamDesc7 = txtCamDesc7.Text.Replace("\n", "<br />");
        ReportIncidentCu.CamDesc7 = ReportIncidentCu.CamDesc7;
        ReportIncidentCu.SDate7 = txtCamSDate7.Text;
        ReportIncidentCu.STimeH7 = ddlCamTimeH7.SelectedItem.Value;
        ReportIncidentCu.STimeM7 = ddlCamTimeM7.SelectedItem.Value;
        //ReportIncidentCu.STimeTC7 = ddlCamTimeTC7.SelectedItem.Value;
        ReportIncidentCu.EDate7 = txtCamEDate7.Text;
        ReportIncidentCu.ETimeH7 = ddlCamETimeH7.SelectedItem.Value;
        ReportIncidentCu.ETimeM7 = ddlCamETimeM7.SelectedItem.Value;
        //ReportIncidentCu.ETimeTC7 = ddlCamETimeTC7.SelectedItem.Value;
        ReportIncidentCu.FilePath7 = txtCamFilePath7.Text;
        ReportIncidentCu.FilePath7 = ReportIncidentCu.FilePath7;
        ReportIncidentCu.CamRec7 = cbRecorded7.Checked.ToString();
        ReportIncidentCu.TxtCamSTimeH7 = ddlCamTimeH7.SelectedItem.Text;
        ReportIncidentCu.TxtCamSTimeM7 = ddlCamTimeM7.SelectedItem.Text;
        //ReportIncidentCu.TxtCamSTimeTC7 = ddlCamTimeTC7.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeH7 = ddlCamETimeH7.SelectedItem.Text;
        ReportIncidentCu.TxtCamETimeM7 = ddlCamETimeM7.SelectedItem.Text;
        //ReportIncidentCu.TxtCamETimeTC7 = ddlCamETimeTC7.SelectedItem.Text;

        // by default set the extra Camera tables hidden
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc1))
        {
            tblCamera1.Visible = false;
            tblAddCam2.Visible = false;
            cbCamera.Checked = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc2))
            {
                cbCamera.Checked = true;
                tblCamera1.Visible = true;
                tblAddCam2.Visible = true;
            }
            else
            {
                cbCamera.Checked = true;
                tblAddCam2.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc2))
        {
            tblCamera2.Visible = false;
            tblAddCam3.Visible = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc3))
            {
                tblCamera2.Visible = true;
                tblAddCam3.Visible = true;
            }
            else
            {
                tblAddCam3.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc3))
        {
            tblCamera3.Visible = false;
            tblAddCam4.Visible = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc4))
            {
                tblCamera3.Visible = true;
                tblAddCam4.Visible = true;
            }
            else
            {
                tblAddCam4.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc4))
        {
            tblCamera4.Visible = false;
            tblAddCam5.Visible = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc5))
            {
                tblCamera4.Visible = true;
                tblAddCam5.Visible = true;
            }
            else
            {
                tblAddCam5.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc5))
        {
            tblCamera5.Visible = false;
            tblAddCam6.Visible = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc6))
            {
                tblCamera5.Visible = true;
                tblAddCam6.Visible = true;
            }
            else
            {
                tblAddCam6.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc6))
        {
            tblCamera6.Visible = false;
            tblAddCam7.Visible = false;
        }
        else
        {
            if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc7))
            {
                tblCamera6.Visible = true;
                tblAddCam7.Visible = true;
            }
            else
            {
                tblAddCam7.Visible = false;
            }
        }
        if (String.IsNullOrEmpty(ReportIncidentCu.CamDesc7))
        {
            tblCamera7.Visible = false;
            tblDelCam7.Visible = false;
        }

        // by default set the Person tables are hidden
        if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 1 && String.IsNullOrEmpty(ReportIncidentCu.Member1))
        {
            acpPerson1.Visible = false;
            tblAddPerson2.Visible = false;
            cbAddPerson1.Checked = false;
        }
        else
        {
            if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 2 && String.IsNullOrEmpty(ReportIncidentCu.Member2))
            {
                tblAddPerson2.Visible = true;
            }
            else
            {
                tblAddPerson2.Visible = false;
            }
            cbAddPerson1.Checked = true;
        }
        if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 2 && String.IsNullOrEmpty(ReportIncidentCu.Member2))
        {
            acpPerson2.Visible = false;
            tblAddPerson3.Visible = false;
        }
        else
        {
            if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 3 && String.IsNullOrEmpty(ReportIncidentCu.Member3))
            {
                tblAddPerson3.Visible = true;
            }
            else
            {
                cbAddPerson1.Checked = true;
                tblAddPerson3.Visible = false;
            }
        }
        if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 3 && String.IsNullOrEmpty(ReportIncidentCu.Member3))
        {
            acpPerson3.Visible = false;
            tblAddPerson4.Visible = false;
        }
        else
        {
            if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 4 && String.IsNullOrEmpty(ReportIncidentCu.Member4))
            {
                tblAddPerson4.Visible = true;
            }
            else
            {
                tblAddPerson4.Visible = false;
            }
        }
        if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 4 && String.IsNullOrEmpty(ReportIncidentCu.Member4))
        {
            acpPerson4.Visible = false;
            tblAddPerson5.Visible = false;
        }
        else
        {
            if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 5 && String.IsNullOrEmpty(ReportIncidentCu.Member5))
            {
                tblAddPerson5.Visible = true;
            }
            else
            {
                tblAddPerson5.Visible = false;
            }
        }
        if (Int32.Parse(ReportIncidentCu.NoOfPerson) < 5 && String.IsNullOrEmpty(ReportIncidentCu.Member5))
        {
            acpPerson5.Visible = false;
            tblDelPerson5.Visible = false;
        }
        if (cbSecurity.Checked == false)
        {
            // Hide Security Details by Default
            tdSecurity1.Visible = false;
            tdSecurity2.Visible = false;
        }

        if (cbPolice.Checked == false)
        {
            // Hide Police Details by Default
            tdPolice1.Visible = false;
            tdPolice2.Visible = false;
            tdPolice3.Visible = false;
            tdPolice4.Visible = false;
            tdPolice5.Visible = false;
            tdPolice6.Visible = false;
        }

        // show/hide objects depending on which party type is selected
        if (ReportIncidentCu.Type1 == "1")
        {
            staff11l.Visible = false;
            staff11.Visible = false;
            staff12l.Visible = false;
            staff12.Visible = false;
            witness1l.Visible = true;
            witness1.Visible = true;
            member11l.Visible = true;
            member12l.Visible = true;
            member13l.Visible = true;
            member14l.Visible = true;
            member15l.Visible = true;
            member11.Visible = true;
            member12.Visible = true;
            member13.Visible = true;
            member14.Visible = true;
            member15.Visible = true;

            visitor11l.Visible = false;
            visitor12l.Visible = false;
            visitor13l.Visible = false;
            visitor14l.Visible = false;
            visitor15l.Visible = false;
            visitor11.Visible = false;
            visitor12.Visible = false;
            visitor13.Visible = false;
            visitor14.Visible = false;
            visitor15.Visible = false;
        }
        else if (ReportIncidentCu.Type1 == "2")
        {
            staff11l.Visible = false;
            staff12l.Visible = false;
            witness1l.Visible = true;
            member11l.Visible = false;
            member12l.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;
            staff11.Visible = false;
            staff12.Visible = false;
            witness1.Visible = true;
            member11.Visible = false;
            member12.Visible = false;
            member13.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

            visitor11l.Visible = true;
            visitor12l.Visible = true;
            visitor13l.Visible = true;
            visitor14l.Visible = true;
            visitor15l.Visible = true;
            visitor11.Visible = true;
            visitor12.Visible = true;
            visitor13.Visible = true;
            visitor14.Visible = true;
            visitor15.Visible = true;
        }
        else if (ReportIncidentCu.Type1 == "3")
        {
            staff11l.Visible = true;
            staff12l.Visible = true;
            witness1l.Visible = true;
            member11l.Visible = false;
            member12l.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;
            staff11.Visible = true;
            staff12.Visible = true;
            witness1.Visible = true;
            member11.Visible = false;
            member12.Visible = false;
            member13.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

            visitor11l.Visible = false;
            visitor12l.Visible = false;
            visitor13l.Visible = false;
            visitor14l.Visible = false;
            visitor15l.Visible = false;
            visitor11.Visible = false;
            visitor12.Visible = false;
            visitor13.Visible = false;
            visitor14.Visible = false;
            visitor15.Visible = false;
        }
        else if (ReportIncidentCu.Type1 == "4" || ReportIncidentCu.Type1 == "5" || ReportIncidentCu.Type1 == "6" || ReportIncidentCu.Type1 == "7")
        {
            witness1.Visible = true;
            witness1l.Visible = true;
        }
        else
        {
            staff11l.Visible = false;
            staff12l.Visible = false;
            witness1l.Visible = false;
            member11l.Visible = false;
            member12l.Visible = false;
            member13l.Visible = false;
            member14l.Visible = false;
            staff11.Visible = false;
            staff12.Visible = false;
            witness1.Visible = false;
            member11.Visible = false;
            member12.Visible = false;
            member13.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

            visitor11l.Visible = false;
            visitor12l.Visible = false;
            visitor13l.Visible = false;
            visitor14l.Visible = false;
            visitor15l.Visible = false;
            visitor11.Visible = false;
            visitor12.Visible = false;
            visitor13.Visible = false;
            visitor14.Visible = false;
            visitor15.Visible = false;
        }
        if (ReportIncidentCu.Type2 == "1")
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
            member23.Visible = true;
            member24l.Visible = true;
            member24.Visible = true;
            member25.Visible = true;
            member25l.Visible = true;

            //member two image
            //member25.Visible = true;
            //member25l.Visible = true;

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
        }
        else if (ReportIncidentCu.Type2 == "2")
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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
        }
        else if (ReportIncidentCu.Type2 == "3")
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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
        }
        else if (ReportIncidentCu.Type2 == "4" || ReportIncidentCu.Type2 == "5" || ReportIncidentCu.Type2 == "6" || ReportIncidentCu.Type2 == "7")
        {
            witness2.Visible = true;
            witness2l.Visible = true;
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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
        }
        if (ReportIncidentCu.Type3 == "1")
        {
            staff31l.Visible = false;
            staff31.Visible = false;
            staff32l.Visible = false;
            staff32.Visible = false;
            witness3l.Visible = true;
            witness3.Visible = true;
            member31l.Visible = true;
            member32l.Visible = true;
            member33l.Visible = true;
            member34l.Visible = true;
            member31.Visible = true;
            member32.Visible = true;
            member33.Visible = true;
            member34.Visible = true;
            member35.Visible = true;
            member35l.Visible = true;

            visitor31l.Visible = false;
            visitor32l.Visible = false;
            visitor33l.Visible = false;
            visitor34l.Visible = false;
            visitor35l.Visible = false;
            visitor31.Visible = false;
            visitor32.Visible = false;
            visitor33.Visible = false;
            visitor34.Visible = false;
            visitor35.Visible = false;
        }
        else if (ReportIncidentCu.Type3 == "2")
        {
            staff31l.Visible = false;
            staff32l.Visible = false;
            witness3l.Visible = true;
            member31l.Visible = false;
            member32l.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;
            staff31.Visible = false;
            staff32.Visible = false;
            witness3.Visible = true;
            member31.Visible = false;
            member32.Visible = false;
            member33.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

            visitor31l.Visible = true;
            visitor32l.Visible = true;
            visitor33l.Visible = true;
            visitor34l.Visible = true;
            visitor35l.Visible = true;
            visitor31.Visible = true;
            visitor32.Visible = true;
            visitor33.Visible = true;
            visitor34.Visible = true;
            visitor35.Visible = true;
        }
        else if (ReportIncidentCu.Type3 == "3")
        {
            staff31l.Visible = true;
            staff32l.Visible = true;
            witness3l.Visible = true;
            member31l.Visible = false;
            member32l.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;
            staff31.Visible = true;
            staff32.Visible = true;
            witness3.Visible = true;
            member31.Visible = false;
            member32.Visible = false;
            member33.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

            visitor31l.Visible = false;
            visitor32l.Visible = false;
            visitor33l.Visible = false;
            visitor34l.Visible = false;
            visitor35l.Visible = false;
            visitor31.Visible = false;
            visitor32.Visible = false;
            visitor33.Visible = false;
            visitor34.Visible = false;
            visitor35.Visible = false;
        }
        else if (ReportIncidentCu.Type3 == "4" || ReportIncidentCu.Type3 == "5" || ReportIncidentCu.Type3 == "6" || ReportIncidentCu.Type3 == "7")
        {
            witness3.Visible = true;
            witness3l.Visible = true;
        }
        else
        {
            staff31l.Visible = false;
            staff32l.Visible = false;
            witness3l.Visible = false;
            member31l.Visible = false;
            member32l.Visible = false;
            member33l.Visible = false;
            member34l.Visible = false;
            staff31.Visible = false;
            staff32.Visible = false;
            witness3.Visible = false;
            member31.Visible = false;
            member32.Visible = false;
            member33.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

            visitor31l.Visible = false;
            visitor32l.Visible = false;
            visitor33l.Visible = false;
            visitor34l.Visible = false;
            visitor35l.Visible = false;
            visitor31.Visible = false;
            visitor32.Visible = false;
            visitor33.Visible = false;
            visitor34.Visible = false;
            visitor35.Visible = false;
        }
        if (ReportIncidentCu.Type4 == "1")
        {
            staff41l.Visible = false;
            staff41.Visible = false;
            staff42l.Visible = false;
            staff42.Visible = false;
            witness4l.Visible = true;
            witness4.Visible = true;
            member41l.Visible = true;
            member42l.Visible = true;
            member43l.Visible = true;
            member44l.Visible = true;
            member41.Visible = true;
            member42.Visible = true;
            member43.Visible = true;
            member44.Visible = true;
            member45.Visible = true;
            member45l.Visible = true;

            visitor41l.Visible = false;
            visitor42l.Visible = false;
            visitor43l.Visible = false;
            visitor44l.Visible = false;
            visitor45l.Visible = false;
            visitor41.Visible = false;
            visitor42.Visible = false;
            visitor43.Visible = false;
            visitor44.Visible = false;
            visitor45.Visible = false;
        }
        else if (ReportIncidentCu.Type4 == "2")
        {
            staff41l.Visible = false;
            staff42l.Visible = false;
            witness4l.Visible = true;
            member41l.Visible = false;
            member42l.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;
            staff41.Visible = false;
            staff42.Visible = false;
            witness4.Visible = true;
            member41.Visible = false;
            member42.Visible = false;
            member43.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

            visitor41l.Visible = true;
            visitor42l.Visible = true;
            visitor43l.Visible = true;
            visitor44l.Visible = true;
            visitor45l.Visible = true;
            visitor41.Visible = true;
            visitor42.Visible = true;
            visitor43.Visible = true;
            visitor44.Visible = true;
            visitor45.Visible = true;
        }
        else if (ReportIncidentCu.Type4 == "3")
        {
            staff41l.Visible = true;
            staff42l.Visible = true;
            witness4l.Visible = true;
            member41l.Visible = false;
            member42l.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;
            staff41.Visible = true;
            staff42.Visible = true;
            witness4.Visible = true;
            member41.Visible = false;
            member42.Visible = false;
            member43.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

            visitor41l.Visible = false;
            visitor42l.Visible = false;
            visitor43l.Visible = false;
            visitor44l.Visible = false;
            visitor45l.Visible = false;
            visitor41.Visible = false;
            visitor42.Visible = false;
            visitor43.Visible = false;
            visitor44.Visible = false;
            visitor45.Visible = false;
        }
        else if (ReportIncidentCu.Type4 == "4" || ReportIncidentCu.Type4 == "5" || ReportIncidentCu.Type4 == "6" || ReportIncidentCu.Type4 == "7")
        {
            witness4.Visible = true;
            witness4l.Visible = true;
        }
        else
        {
            staff41l.Visible = false;
            staff42l.Visible = false;
            witness4l.Visible = false;
            member41l.Visible = false;
            member42l.Visible = false;
            member43l.Visible = false;
            member44l.Visible = false;
            staff41.Visible = false;
            staff42.Visible = false;
            witness4.Visible = false;
            member41.Visible = false;
            member42.Visible = false;
            member43.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

            visitor41l.Visible = false;
            visitor42l.Visible = false;
            visitor43l.Visible = false;
            visitor44l.Visible = false;
            visitor45l.Visible = false;
            visitor41.Visible = false;
            visitor42.Visible = false;
            visitor43.Visible = false;
            visitor44.Visible = false;
            visitor45.Visible = false;
        }
        if (ReportIncidentCu.Type5 == "1")
        {
            staff51l.Visible = false;
            staff51.Visible = false;
            staff52l.Visible = false;
            staff52.Visible = false;
            witness5l.Visible = true;
            witness5.Visible = true;
            member51l.Visible = true;
            member52l.Visible = true;
            member53l.Visible = true;
            member54l.Visible = true;
            member51.Visible = true;
            member52.Visible = true;
            member53.Visible = true;
            member54.Visible = true;
            member55.Visible = true;
            member55l.Visible = true;

            visitor51l.Visible = false;
            visitor52l.Visible = false;
            visitor53l.Visible = false;
            visitor54l.Visible = false;
            visitor55l.Visible = false;
            visitor51.Visible = false;
            visitor52.Visible = false;
            visitor53.Visible = false;
            visitor54.Visible = false;
            visitor55.Visible = false;
        }
        else if (ReportIncidentCu.Type5 == "2")
        {
            staff51l.Visible = false;
            staff52l.Visible = false;
            witness5l.Visible = true;
            member51l.Visible = false;
            member52l.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;
            staff51.Visible = false;
            staff52.Visible = false;
            witness5.Visible = true;
            member51.Visible = false;
            member52.Visible = false;
            member53.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

            visitor51l.Visible = true;
            visitor52l.Visible = true;
            visitor53l.Visible = true;
            visitor54l.Visible = true;
            visitor55l.Visible = true;
            visitor51.Visible = true;
            visitor52.Visible = true;
            visitor53.Visible = true;
            visitor54.Visible = true;
            visitor55.Visible = true;
        }
        else if (ReportIncidentCu.Type5 == "3")
        {
            staff51l.Visible = true;
            staff52l.Visible = true;
            witness5l.Visible = true;
            member51l.Visible = false;
            member52l.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;
            staff51.Visible = true;
            staff52.Visible = true;
            witness5.Visible = true;
            member51.Visible = false;
            member52.Visible = false;
            member53.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

            visitor51l.Visible = false;
            visitor52l.Visible = false;
            visitor53l.Visible = false;
            visitor54l.Visible = false;
            visitor55l.Visible = false;
            visitor51.Visible = false;
            visitor52.Visible = false;
            visitor53.Visible = false;
            visitor54.Visible = false;
            visitor55.Visible = false;
        }
        else if (ReportIncidentCu.Type5 == "4" || ReportIncidentCu.Type5 == "5" || ReportIncidentCu.Type5 == "6" || ReportIncidentCu.Type5 == "7")
        {
            witness5.Visible = true;
            witness5l.Visible = true;
        }
        else
        {
            staff51l.Visible = false;
            staff52l.Visible = false;
            witness5l.Visible = false;
            member51l.Visible = false;
            member52l.Visible = false;
            member53l.Visible = false;
            member54l.Visible = false;
            staff51.Visible = false;
            staff52.Visible = false;
            witness5.Visible = false;
            member51.Visible = false;
            member52.Visible = false;
            member53.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

            visitor51l.Visible = false;
            visitor52l.Visible = false;
            visitor53l.Visible = false;
            visitor54l.Visible = false;
            visitor55l.Visible = false;
            visitor51.Visible = false;
            visitor52.Visible = false;
            visitor53.Visible = false;
            visitor54.Visible = false;
            visitor55.Visible = false;
        }

        if (Report.Status != "Awaiting Completion")
        {
            ReadFields(Report.ActiveReport, "CheckChanges");
        }
    }

    // stores the error message on a global variable
    protected void showAlert(string message)
    {
        message = "alert(\"" + message + "\");";
        //ReportIncidentCu.LastErrorMsg = message;
        // hide Human Body form
        tblHuman.Visible = false;
        section1.Visible = false;
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
            member13.Visible = true;
            member14l.Visible = true;
            member14.Visible = true;
            member15.Visible = true;
            member15l.Visible = true;

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

            ReportIncidentCu.SignInSlip1 = "false";
            ReportIncidentCu.SignInBy1 = "";
            ReportIncidentCu.VDOB1 = "";
            ReportIncidentCu.VProofID1 = "";
            ReportIncidentCu.VAddress1 = "";

            ReportIncidentCu.StaffEmp1 = "";
            ReportIncidentCu.StaffAddress1 = "";
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
            member13.Visible = false;
            member14l.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

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

            ReportIncidentCu.Card1 = "false";
            ReportIncidentCu.Member1 = "";
            ReportIncidentCu.MDOB1 = "";
            ReportIncidentCu.MemberSince1 = "";
            ReportIncidentCu.MAddress1 = "";

            ReportIncidentCu.StaffEmp1 = "";
            ReportIncidentCu.StaffAddress1 = "";
            ReportIncidentCu.MemberPhoto1 = null;
            Report.MemberNumberChanged = "";
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
            member13.Visible = false;
            member14l.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

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

            ReportIncidentCu.Card1 = "false";
            ReportIncidentCu.Member1 = "";
            ReportIncidentCu.MDOB1 = "";
            ReportIncidentCu.MemberSince1 = "";
            ReportIncidentCu.MAddress1 = "";

            ReportIncidentCu.SignInSlip1 = "false";
            ReportIncidentCu.SignInBy1 = "";
            ReportIncidentCu.VDOB1 = "";
            ReportIncidentCu.VProofID1 = "";
            ReportIncidentCu.VAddress1 = "";
            ReportIncidentCu.MemberPhoto1 = null;
            Report.MemberNumberChanged = "";
        }
        else
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
            member13.Visible = false;
            member14l.Visible = false;
            member14.Visible = false;
            member15.Visible = false;
            member15l.Visible = false;

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
            txtContact1.Text = "";
            txtFirstName1.Text = "";
            txtLastName1.Text = "";


            txtAge1.Text = "";
            ddlAgeGroup1.SelectedIndex = -1;

            ReportIncidentCu.Card1 = "false";
            ReportIncidentCu.Member1 = "";
            ReportIncidentCu.MDOB1 = "";
            ReportIncidentCu.MemberSince1 = "";
            ReportIncidentCu.MAddress1 = "";

            ReportIncidentCu.SignInSlip1 = "false";
            ReportIncidentCu.SignInBy1 = "";
            ReportIncidentCu.VDOB1 = "";
            ReportIncidentCu.VProofID1 = "";
            ReportIncidentCu.VAddress1 = "";

            ReportIncidentCu.StaffEmp1 = "";
            ReportIncidentCu.StaffAddress1 = "";
            ReportIncidentCu.MemberPhoto1 = null;
            Report.MemberNumberChanged = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 0;
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
            member23.Visible = true;
            member24l.Visible = true;
            member24.Visible = true;
            member25.Visible = true;
            member25l.Visible = true;

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

            ReportIncidentCu.SignInSlip2 = "false";
            ReportIncidentCu.SignInBy2 = "";
            ReportIncidentCu.VDOB2 = "";
            ReportIncidentCu.VProofID2 = "";
            ReportIncidentCu.VAddress2 = "";

            ReportIncidentCu.StaffEmp2 = "";
            ReportIncidentCu.StaffAddress2 = "";
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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

            ReportIncidentCu.Card2 = "false";
            ReportIncidentCu.Member2 = "";
            ReportIncidentCu.MDOB2 = "";
            ReportIncidentCu.MemberSince2 = "";
            ReportIncidentCu.MAddress2 = "";

            ReportIncidentCu.StaffEmp2 = "";
            ReportIncidentCu.StaffAddress2 = "";
            ReportIncidentCu.MemberPhoto2 = null;
            Report.MemberNumberChanged = "";
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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

            ReportIncidentCu.Card2 = "false";
            ReportIncidentCu.Member2 = "";
            ReportIncidentCu.MDOB2 = "";
            ReportIncidentCu.MemberSince2 = "";
            ReportIncidentCu.MAddress2 = "";

            ReportIncidentCu.SignInSlip2 = "false";
            ReportIncidentCu.SignInBy2 = "";
            ReportIncidentCu.VDOB2 = "";
            ReportIncidentCu.VProofID2 = "";
            ReportIncidentCu.VAddress2 = "";
            ReportIncidentCu.MemberPhoto2 = null;
            Report.MemberNumberChanged = "";
        }
        else
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
            member23.Visible = false;
            member24l.Visible = false;
            member24.Visible = false;
            member25.Visible = false;
            member25l.Visible = false;

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

            ReportIncidentCu.Card2 = "false";
            ReportIncidentCu.Member2 = "";
            ReportIncidentCu.MDOB2 = "";
            ReportIncidentCu.MemberSince2 = "";
            ReportIncidentCu.MAddress2 = "";

            ReportIncidentCu.SignInSlip2 = "false";
            ReportIncidentCu.SignInBy2 = "";
            ReportIncidentCu.VDOB2 = "";
            ReportIncidentCu.VProofID2 = "";
            ReportIncidentCu.VAddress2 = "";

            ReportIncidentCu.StaffEmp2 = "";
            ReportIncidentCu.StaffAddress2 = "";
            ReportIncidentCu.MemberPhoto2 = null;
            Report.MemberNumberChanged = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 1;
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
            member33.Visible = true;
            member34l.Visible = true;
            member34.Visible = true;
            member35.Visible = true;
            member35l.Visible = true;

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

            ReportIncidentCu.SignInSlip3 = "false";
            ReportIncidentCu.SignInBy3 = "";
            ReportIncidentCu.VDOB3 = "";
            ReportIncidentCu.VProofID3 = "";
            ReportIncidentCu.VAddress3 = "";

            ReportIncidentCu.StaffEmp3 = "";
            ReportIncidentCu.StaffAddress3 = "";
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
            member33.Visible = false;
            member34l.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

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

            ReportIncidentCu.Card3 = "false";
            ReportIncidentCu.Member3 = "";
            ReportIncidentCu.MDOB3 = "";
            ReportIncidentCu.MemberSince3 = "";
            ReportIncidentCu.MAddress3 = "";

            ReportIncidentCu.StaffEmp3 = "";
            ReportIncidentCu.StaffAddress3 = "";
            ReportIncidentCu.MemberPhoto3 = null;
            Report.MemberNumberChanged = "";
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
            member33.Visible = false;
            member34l.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

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
            txtStaffEmpNo3.Text = "";
            txtStaffAddress3.Text = "";
            txtContact3.Text = "";
            txtAge3.Text = "";
            ddlAgeGroup3.SelectedIndex = -1;

            ReportIncidentCu.Card3 = "false";
            ReportIncidentCu.Member3 = "";
            ReportIncidentCu.MDOB3 = "";
            ReportIncidentCu.MemberSince3 = "";
            ReportIncidentCu.MAddress3 = "";

            ReportIncidentCu.SignInSlip3 = "false";
            ReportIncidentCu.SignInBy3 = "";
            ReportIncidentCu.VDOB3 = "";
            ReportIncidentCu.VProofID3 = "";
            ReportIncidentCu.VAddress3 = "";
            ReportIncidentCu.MemberPhoto3 = null;
            Report.MemberNumberChanged = "";
        }
        else
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
            member33.Visible = false;
            member34l.Visible = false;
            member34.Visible = false;
            member35.Visible = false;
            member35l.Visible = false;

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

            ReportIncidentCu.Card3 = "false";
            ReportIncidentCu.Member3 = "";
            ReportIncidentCu.MDOB3 = "";
            ReportIncidentCu.MemberSince3 = "";
            ReportIncidentCu.MAddress3 = "";

            ReportIncidentCu.SignInSlip3 = "false";
            ReportIncidentCu.SignInBy3 = "";
            ReportIncidentCu.VDOB3 = "";
            ReportIncidentCu.VProofID3 = "";
            ReportIncidentCu.VAddress3 = "";

            ReportIncidentCu.StaffEmp3 = "";
            ReportIncidentCu.StaffAddress3 = "";
            ReportIncidentCu.MemberPhoto3 = null;
            Report.MemberNumberChanged = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 2;
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
            member43.Visible = true;
            member44l.Visible = true;
            member44.Visible = true;
            member45.Visible = true;
            member45l.Visible = true;

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
            txtMemberNo4.Text = "";
            txtMemberSince4.Text = "";
            txtContact4.Text = "";
            txtDOB4.Text = "";
            txtAge4.Text = "";
            ddlAgeGroup4.SelectedIndex = -1;

            ReportIncidentCu.SignInSlip4 = "false";
            ReportIncidentCu.SignInBy4 = "";
            ReportIncidentCu.VDOB4 = "";
            ReportIncidentCu.VProofID4 = "";
            ReportIncidentCu.VAddress4 = "";

            ReportIncidentCu.StaffEmp4 = "";
            ReportIncidentCu.StaffAddress4 = "";
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
            member43.Visible = false;
            member44l.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

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

            ReportIncidentCu.Card4 = "false";
            ReportIncidentCu.Member4 = "";
            ReportIncidentCu.MDOB4 = "";
            ReportIncidentCu.MemberSince4 = "";
            ReportIncidentCu.MAddress4 = "";

            ReportIncidentCu.StaffEmp4 = "";
            ReportIncidentCu.StaffAddress4 = "";
            ReportIncidentCu.MemberPhoto4 = null;
            Report.MemberNumberChanged = "";
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
            member43.Visible = false;
            member44l.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

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

            ReportIncidentCu.Card4 = "false";
            ReportIncidentCu.Member4 = "";
            ReportIncidentCu.MDOB4 = "";
            ReportIncidentCu.MemberSince4 = "";
            ReportIncidentCu.MAddress4 = "";

            ReportIncidentCu.SignInSlip4 = "false";
            ReportIncidentCu.SignInBy4 = "";
            ReportIncidentCu.VDOB4 = "";
            ReportIncidentCu.VProofID4 = "";
            ReportIncidentCu.VAddress4 = "";
            ReportIncidentCu.MemberPhoto4 = null;
            Report.MemberNumberChanged = "";
        }
        else
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
            member43.Visible = false;
            member44l.Visible = false;
            member44.Visible = false;
            member45.Visible = false;
            member45l.Visible = false;

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

            ReportIncidentCu.Card4 = "false";
            ReportIncidentCu.Member4 = "";
            ReportIncidentCu.MDOB4 = "";
            ReportIncidentCu.MemberSince4 = "";
            ReportIncidentCu.MAddress4 = "";

            ReportIncidentCu.SignInSlip4 = "false";
            ReportIncidentCu.SignInBy4 = "";
            ReportIncidentCu.VDOB4 = "";
            ReportIncidentCu.VProofID4 = "";
            ReportIncidentCu.VAddress4 = "";

            ReportIncidentCu.StaffEmp4 = "";
            ReportIncidentCu.StaffAddress4 = "";
            ReportIncidentCu.MemberPhoto4 = null;
            Report.MemberNumberChanged = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 3;
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
            member53.Visible = true;
            member54l.Visible = true;
            member54.Visible = true;
            member55.Visible = true;
            member55l.Visible = true;

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
            txtMemberNo5.Text = "";
            txtMemberSince5.Text = "";
            txtContact5.Text = "";
            txtDOB5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;

            ReportIncidentCu.SignInSlip5 = "false";
            ReportIncidentCu.SignInBy5 = "";
            ReportIncidentCu.VDOB5 = "";
            ReportIncidentCu.VProofID5 = "";
            ReportIncidentCu.VAddress5 = "";

            ReportIncidentCu.StaffEmp5 = "";
            ReportIncidentCu.StaffAddress5 = "";
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
            member53.Visible = false;
            member54l.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

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

            ReportIncidentCu.Card5 = "false";
            ReportIncidentCu.Member5 = "";
            ReportIncidentCu.MDOB5 = "";
            ReportIncidentCu.MemberSince5 = "";
            ReportIncidentCu.MAddress5 = "";

            ReportIncidentCu.StaffEmp5 = "";
            ReportIncidentCu.StaffAddress5 = "";
            ReportIncidentCu.MemberPhoto5 = null;
            Report.MemberNumberChanged = "";
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
            member53.Visible = false;
            member54l.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

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
            txtStaffEmpNo5.Text = "";
            txtStaffAddress5.Text = "";
            txtContact5.Text = "";
            txtAge5.Text = "";
            ddlAgeGroup5.SelectedIndex = -1;

            ReportIncidentCu.Card5 = "false";
            ReportIncidentCu.Member5 = "";
            ReportIncidentCu.MDOB5 = "";
            ReportIncidentCu.MemberSince5 = "";
            ReportIncidentCu.MAddress5 = "";

            ReportIncidentCu.SignInSlip5 = "false";
            ReportIncidentCu.SignInBy5 = "";
            ReportIncidentCu.VDOB5 = "";
            ReportIncidentCu.VProofID5 = "";
            ReportIncidentCu.VAddress5 = "";
            ReportIncidentCu.MemberPhoto5 = null;
            Report.MemberNumberChanged = "";
        }
        else
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
            member53.Visible = false;
            member54l.Visible = false;
            member54.Visible = false;
            member55.Visible = false;
            member55l.Visible = false;

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

            ReportIncidentCu.Card5 = "false";
            ReportIncidentCu.Member5 = "";
            ReportIncidentCu.MDOB5 = "";
            ReportIncidentCu.MemberSince5 = "";
            ReportIncidentCu.MAddress5 = "";

            ReportIncidentCu.SignInSlip5 = "false";
            ReportIncidentCu.SignInBy5 = "";
            ReportIncidentCu.VDOB5 = "";
            ReportIncidentCu.VProofID5 = "";
            ReportIncidentCu.VAddress5 = "";

            ReportIncidentCu.StaffEmp5 = "";
            ReportIncidentCu.StaffAddress5 = "";
            ReportIncidentCu.MemberPhoto5 = null;
            Report.MemberNumberChanged = "";
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 4;
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
            // validate objects in the form
            bool returnedValue = checkFields();
            if (returnedValue == true)
            {
                return;
            }
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

            // delete all contents in Person 1 Form
            string personNo = "P1";
            ReportIncidentCu.First1 = "";
            ReportIncidentCu.Last1 = "";
            ReportIncidentCu.Alias1 = "";
            ReportIncidentCu.Contact1 = "";
            ReportIncidentCu.Type1 = "-1";
            ReportIncidentCu.TxtPartyType1 = "Select Type";
            ReportIncidentCu.Witness1 = "false";

            ReportIncidentCu.Card1 = "false";
            ReportIncidentCu.Member1 = "";
            ReportIncidentCu.MDOB1 = "";
            ReportIncidentCu.MAddress1 = "";
            ReportIncidentCu.MemberSince1 = "";

            ReportIncidentCu.SignInSlip1 = "false";
            ReportIncidentCu.SignInBy1 = "";
            ReportIncidentCu.VDOB1 = "";
            ReportIncidentCu.VProofID1 = "";
            ReportIncidentCu.VAddress1 = "";

            ReportIncidentCu.StaffEmp1 = "";
            ReportIncidentCu.StaffAddress1 = "";

            ReportIncidentCu.PDate1 = "";
            ReportIncidentCu.TxtPTimeH1 = "Select Hour";
            ReportIncidentCu.PTimeH1 = "-1";
            ReportIncidentCu.TxtPTimeM1 = "Select Hour";
            ReportIncidentCu.PTimeM1 = "-1";
            ReportIncidentCu.Age1 = "";
            ReportIncidentCu.AgeGroup1 = "-1";
            ReportIncidentCu.Weight1 = "";
            ReportIncidentCu.Height1 = "";
            ReportIncidentCu.Hair1 = "";
            ReportIncidentCu.ClothingTop1 = "";
            ReportIncidentCu.ClothingBottom1 = "";
            ReportIncidentCu.Shoes1 = "";
            ReportIncidentCu.Weapon1 = "";
            ReportIncidentCu.TxtGender1 = "Select Gender";
            ReportIncidentCu.Gender1 = "-1";
            ReportIncidentCu.DistFeat1 = "";
            ReportIncidentCu.InjuryDesc1 = "";
            ReportIncidentCu.InjuryCause1 = "";
            ReportIncidentCu.InjuryComm1 = "";
            ReportIncidentCu.PlayerId1 = "";
            ReportIncidentCu.MemberPhoto1 = null;

            ReportIncidentCu.First2 = "";
            ReportIncidentCu.Last2 = "";
            ReportIncidentCu.Contact2 = "";
            ReportIncidentCu.Type2 = "-1";
            ReportIncidentCu.TxtPartyType2 = "Select Type";
            ReportIncidentCu.Witness2 = "false";

            ReportIncidentCu.Card2 = "false";
            ReportIncidentCu.Member2 = "";
            ReportIncidentCu.MDOB2 = "";
            ReportIncidentCu.MAddress2 = "";
            ReportIncidentCu.MemberSince2 = "";

            ReportIncidentCu.SignInSlip2 = "false";
            ReportIncidentCu.SignInBy2 = "";
            ReportIncidentCu.VDOB2 = "";
            ReportIncidentCu.VProofID2 = "";
            ReportIncidentCu.VAddress2 = "";

            ReportIncidentCu.StaffEmp2 = "";
            ReportIncidentCu.StaffAddress2 = "";

            ReportIncidentCu.PDate2 = "";
            ReportIncidentCu.TxtPTimeH2 = "Select Hour";
            ReportIncidentCu.PTimeH2 = "-1";
            ReportIncidentCu.TxtPTimeM2 = "Select Hour";
            ReportIncidentCu.PTimeM2 = "-1";
            ReportIncidentCu.Age2 = "";
            ReportIncidentCu.AgeGroup2 = "-1";
            ReportIncidentCu.Weight2 = "";
            ReportIncidentCu.Height2 = "";
            ReportIncidentCu.Hair2 = "";
            ReportIncidentCu.ClothingTop2 = "";
            ReportIncidentCu.ClothingBottom2 = "";
            ReportIncidentCu.Shoes2 = "";
            ReportIncidentCu.Weapon2 = "";
            ReportIncidentCu.TxtGender2 = "Select Gender";
            ReportIncidentCu.Gender2 = "-1";
            ReportIncidentCu.DistFeat2 = "";
            ReportIncidentCu.InjuryDesc2 = "";
            ReportIncidentCu.InjuryCause2 = "";
            ReportIncidentCu.InjuryComm2 = "";
            ReportIncidentCu.PlayerId2 = "";
            ReportIncidentCu.MemberPhoto2 = null;

            ReportIncidentCu.First3 = "";
            ReportIncidentCu.Last3 = "";
            ReportIncidentCu.Contact3 = "";
            ReportIncidentCu.Type3 = "-1";
            ReportIncidentCu.TxtPartyType3 = "Select Type";
            ReportIncidentCu.Witness3 = "false";

            ReportIncidentCu.Card3 = "false";
            ReportIncidentCu.Member3 = "";
            ReportIncidentCu.MDOB3 = "";
            ReportIncidentCu.MAddress3 = "";
            ReportIncidentCu.MemberSince3 = "";

            ReportIncidentCu.SignInSlip3 = "false";
            ReportIncidentCu.SignInBy3 = "";
            ReportIncidentCu.VDOB3 = "";
            ReportIncidentCu.VProofID3 = "";
            ReportIncidentCu.VAddress3 = "";

            ReportIncidentCu.StaffEmp3 = "";
            ReportIncidentCu.StaffAddress3 = "";

            ReportIncidentCu.PDate3 = "";
            ReportIncidentCu.TxtPTimeH3 = "Select Hour";
            ReportIncidentCu.PTimeH3 = "-1";
            ReportIncidentCu.TxtPTimeM3 = "Select Hour";
            ReportIncidentCu.PTimeM3 = "-1";
            ReportIncidentCu.Age3 = "";
            ReportIncidentCu.AgeGroup3 = "-1";
            ReportIncidentCu.Weight3 = "";
            ReportIncidentCu.Height3 = "";
            ReportIncidentCu.Hair3 = "";
            ReportIncidentCu.ClothingTop3 = "";
            ReportIncidentCu.ClothingBottom3 = "";
            ReportIncidentCu.Shoes3 = "";
            ReportIncidentCu.Weapon3 = "";
            ReportIncidentCu.TxtGender3 = "Select Gender";
            ReportIncidentCu.Gender3 = "-1";
            ReportIncidentCu.DistFeat3 = "";
            ReportIncidentCu.InjuryDesc3 = "";
            ReportIncidentCu.InjuryCause3 = "";
            ReportIncidentCu.InjuryComm3 = "";
            ReportIncidentCu.PlayerId3 = "";
            ReportIncidentCu.MemberPhoto3 = null;

            ReportIncidentCu.First4 = "";
            ReportIncidentCu.Last4 = "";
            ReportIncidentCu.Contact4 = "";
            ReportIncidentCu.Type4 = "-1";
            ReportIncidentCu.TxtPartyType4 = "Select Type";
            ReportIncidentCu.Witness4 = "false";

            ReportIncidentCu.Card4 = "false";
            ReportIncidentCu.Member4 = "";
            ReportIncidentCu.MDOB4 = "";
            ReportIncidentCu.MAddress4 = "";
            ReportIncidentCu.MemberSince4 = "";

            ReportIncidentCu.SignInSlip4 = "false";
            ReportIncidentCu.SignInBy4 = "";
            ReportIncidentCu.VDOB4 = "";
            ReportIncidentCu.VProofID4 = "";
            ReportIncidentCu.VAddress4 = "";

            ReportIncidentCu.StaffEmp4 = "";
            ReportIncidentCu.StaffAddress4 = "";

            ReportIncidentCu.PDate4 = "";
            ReportIncidentCu.TxtPTimeH4 = "Select Hour";
            ReportIncidentCu.PTimeH4 = "-1";
            ReportIncidentCu.TxtPTimeM4 = "Select Hour";
            ReportIncidentCu.PTimeM4 = "-1";
            ReportIncidentCu.Age4 = "";
            ReportIncidentCu.AgeGroup4 = "-1";
            ReportIncidentCu.Weight4 = "";
            ReportIncidentCu.Height4 = "";
            ReportIncidentCu.Hair4 = "";
            ReportIncidentCu.ClothingTop4 = "";
            ReportIncidentCu.ClothingBottom4 = "";
            ReportIncidentCu.Shoes4 = "";
            ReportIncidentCu.Weapon4 = "";
            ReportIncidentCu.TxtGender4 = "Select Gender";
            ReportIncidentCu.Gender4 = "-1";
            ReportIncidentCu.DistFeat4 = "";
            ReportIncidentCu.InjuryDesc4 = "";
            ReportIncidentCu.InjuryCause4 = "";
            ReportIncidentCu.InjuryComm4 = "";
            ReportIncidentCu.PlayerId4 = "";
            ReportIncidentCu.MemberPhoto4 = null;

            ReportIncidentCu.First5 = "";
            ReportIncidentCu.Last5 = "";
            ReportIncidentCu.Contact5 = "";
            ReportIncidentCu.Type5 = "-1";
            ReportIncidentCu.TxtPartyType5 = "Select Type";
            ReportIncidentCu.Witness5 = "false";

            ReportIncidentCu.Card5 = "false";
            ReportIncidentCu.Member5 = "";
            ReportIncidentCu.MDOB5 = "";
            ReportIncidentCu.MAddress5 = "";
            ReportIncidentCu.MemberSince5 = "";

            ReportIncidentCu.SignInSlip5 = "false";
            ReportIncidentCu.SignInBy5 = "";
            ReportIncidentCu.VDOB5 = "";
            ReportIncidentCu.VProofID5 = "";
            ReportIncidentCu.VAddress5 = "";

            ReportIncidentCu.StaffEmp5 = "";
            ReportIncidentCu.StaffAddress5 = "";

            ReportIncidentCu.PDate5 = "";
            ReportIncidentCu.TxtPTimeH5 = "Select Hour";
            ReportIncidentCu.PTimeH5 = "-1";
            ReportIncidentCu.TxtPTimeM5 = "Select Hour";
            ReportIncidentCu.PTimeM5 = "-1";
            ReportIncidentCu.Age5 = "";
            ReportIncidentCu.AgeGroup5 = "-1";
            ReportIncidentCu.Weight5 = "";
            ReportIncidentCu.Height5 = "";
            ReportIncidentCu.Hair5 = "";
            ReportIncidentCu.ClothingTop5 = "";
            ReportIncidentCu.ClothingBottom5 = "";
            ReportIncidentCu.Shoes5 = "";
            ReportIncidentCu.Weapon5 = "";
            ReportIncidentCu.TxtGender5 = "Select Gender";
            ReportIncidentCu.Gender5 = "-1";
            ReportIncidentCu.DistFeat5 = "";
            ReportIncidentCu.InjuryDesc5 = "";
            ReportIncidentCu.InjuryCause5 = "";
            ReportIncidentCu.InjuryComm5 = "";
            ReportIncidentCu.PlayerId5 = "";
            ReportIncidentCu.MemberPhoto5 = null;

            // Add global variables to update Age, Hair, Clothing, etc.

            noOfPerson.Visible = false;
            lblNoOfPerson.Text = "0";
            noOfPerson1.Visible = false;

            // validate objects in the form
            bool returnedValue = deleteHumanBodyForm(personNo);
            if (returnedValue == true)
            {
                return;
            }
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
        // hide Human Body form
        tblHuman.Visible = false;
        section1.Visible = false;
        txtFirstName2.Focus();
        lblNoOfPerson.Text = "2";
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // hide Human Body form
        tblHuman.Visible = false;
        section1.Visible = false;
        txtFirstName3.Focus();
        lblNoOfPerson.Text = "3";
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddPerson4_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 4 button
        tblAddPerson4.Visible = false;
        // show the added Person form
        tblAddPerson5.Visible = true;
        acpPerson4.Visible = true;
        acdPerson.SelectedIndex = 3;
        // hide Human Body form
        tblHuman.Visible = false;
        section1.Visible = false;
        txtFirstName4.Focus();
        lblNoOfPerson.Text = "4";
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddPerson5_Click(object sender, EventArgs e)
    {
        // hide the Add Person no. 5 button
        tblAddPerson5.Visible = false;
        // show the added Person form
        tblDelPerson5.Visible = true;
        acpPerson5.Visible = true;
        acdPerson.SelectedIndex = 4;
        // hide Human Body form
        tblHuman.Visible = false;
        section1.Visible = false;
        txtFirstName5.Focus();
        lblNoOfPerson.Text = "5";
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // delete/hide Person form
    protected void btnDelPerson2_Click(object sender, EventArgs e)
    {
        string personNo = "P2";
        ReportIncidentCu.First2 = "";
        ReportIncidentCu.Last2 = "";
        ReportIncidentCu.Alias2 = "";
        ReportIncidentCu.Contact2 = "";
        ReportIncidentCu.Type2 = "-1";
        ReportIncidentCu.TxtPartyType2 = "Select Type";
        ReportIncidentCu.Witness2 = "false";

        ReportIncidentCu.Card2 = "false";
        ReportIncidentCu.Member2 = "";
        ReportIncidentCu.MDOB2 = "";
        ReportIncidentCu.MAddress2 = "";
        ReportIncidentCu.MemberSince2 = "";

        ReportIncidentCu.SignInSlip2 = "false";
        ReportIncidentCu.SignInBy2 = "";
        ReportIncidentCu.VDOB2 = "";
        ReportIncidentCu.VProofID2 = "";
        ReportIncidentCu.VAddress2 = "";

        ReportIncidentCu.StaffEmp2 = "";
        ReportIncidentCu.StaffAddress2 = "";

        ReportIncidentCu.PDate2 = "";
        ReportIncidentCu.TxtPTimeH2 = "Select Hour";
        ReportIncidentCu.PTimeH2 = "-1";
        ReportIncidentCu.TxtPTimeM2 = "Select Hour";
        ReportIncidentCu.PTimeM2 = "-1";
        ReportIncidentCu.Age2 = "";
        ReportIncidentCu.AgeGroup2 = "-1";
        ReportIncidentCu.Weight2 = "";
        ReportIncidentCu.Height2 = "";
        ReportIncidentCu.Hair2 = "";
        ReportIncidentCu.ClothingTop2 = "";
        ReportIncidentCu.ClothingBottom2 = "";
        ReportIncidentCu.Shoes2 = "";
        ReportIncidentCu.Weapon2 = "";
        ReportIncidentCu.TxtGender2 = "Select Gender";
        ReportIncidentCu.Gender2 = "-1";
        ReportIncidentCu.DistFeat2 = "";
        ReportIncidentCu.InjuryDesc2 = "";
        ReportIncidentCu.InjuryCause2 = "";
        ReportIncidentCu.InjuryComm2 = "";
        ReportIncidentCu.PlayerId2 = "";
        ReportIncidentCu.MemberPhoto2 = null;

        acpPerson2.Visible = false;
        tblAddPerson2.Visible = true;
        tblAddPerson3.Visible = false;
        acdPerson.SelectedIndex = 0;
        txtFirstName1.Focus();
        lblNoOfPerson.Text = "1";
        // validate objects in the form
        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelPerson3_Click(object sender, EventArgs e)
    {
        string personNo = "P3";
        ReportIncidentCu.First3 = "";
        ReportIncidentCu.Last3 = "";
        ReportIncidentCu.Alias3 = "";
        ReportIncidentCu.Contact3 = "";
        ReportIncidentCu.Type3 = "-1";
        ReportIncidentCu.TxtPartyType3 = "Select Type";
        ReportIncidentCu.Witness3 = "false";

        ReportIncidentCu.Card3 = "false";
        ReportIncidentCu.Member3 = "";
        ReportIncidentCu.MDOB3 = "";
        ReportIncidentCu.MAddress3 = "";
        ReportIncidentCu.MemberSince3 = "";

        ReportIncidentCu.SignInSlip3 = "false";
        ReportIncidentCu.SignInBy3 = "";
        ReportIncidentCu.VDOB3 = "";
        ReportIncidentCu.VProofID3 = "";
        ReportIncidentCu.VAddress3 = "";

        ReportIncidentCu.StaffEmp3 = "";
        ReportIncidentCu.StaffAddress3 = "";

        ReportIncidentCu.PDate3 = "";
        ReportIncidentCu.TxtPTimeH3 = "Select Hour";
        ReportIncidentCu.PTimeH3 = "-1";
        ReportIncidentCu.TxtPTimeM3 = "Select Hour";
        ReportIncidentCu.PTimeM3 = "-1";
        ReportIncidentCu.Age3 = "";
        ReportIncidentCu.AgeGroup3 = "-1";
        ReportIncidentCu.Weight3 = "";
        ReportIncidentCu.Height3 = "";
        ReportIncidentCu.Hair3 = "";
        ReportIncidentCu.ClothingTop3 = "";
        ReportIncidentCu.ClothingBottom3 = "";
        ReportIncidentCu.Shoes3 = "";
        ReportIncidentCu.Weapon3 = "";
        ReportIncidentCu.TxtGender3 = "Select Gender";
        ReportIncidentCu.Gender3 = "-1";
        ReportIncidentCu.DistFeat3 = "";
        ReportIncidentCu.InjuryDesc3 = "";
        ReportIncidentCu.InjuryCause3 = "";
        ReportIncidentCu.InjuryComm3 = "";
        ReportIncidentCu.PlayerId3 = "";
        ReportIncidentCu.MemberPhoto3 = null;

        acpPerson3.Visible = false;
        tblAddPerson3.Visible = true;
        tblAddPerson4.Visible = false;
        acdPerson.SelectedIndex = 1;
        txtFirstName2.Focus();
        lblNoOfPerson.Text = "2";
        // validate objects in the form
        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelPerson4_Click(object sender, EventArgs e)
    {
        string personNo = "P4";
        ReportIncidentCu.First4 = "";
        ReportIncidentCu.Last4 = "";
        ReportIncidentCu.Alias4 = "";
        ReportIncidentCu.Contact4 = "";
        ReportIncidentCu.Type4 = "-1";
        ReportIncidentCu.TxtPartyType4 = "Select Type";
        ReportIncidentCu.Witness4 = "false";

        ReportIncidentCu.Card4 = "false";
        ReportIncidentCu.Member4 = "";
        ReportIncidentCu.MDOB4 = "";
        ReportIncidentCu.MAddress4 = "";
        ReportIncidentCu.MemberSince4 = "";

        ReportIncidentCu.SignInSlip4 = "false";
        ReportIncidentCu.SignInBy4 = "";
        ReportIncidentCu.VDOB4 = "";
        ReportIncidentCu.VProofID4 = "";
        ReportIncidentCu.VAddress4 = "";

        ReportIncidentCu.StaffEmp4 = "";
        ReportIncidentCu.StaffAddress4 = "";

        ReportIncidentCu.PDate4 = "";
        ReportIncidentCu.TxtPTimeH4 = "Select Hour";
        ReportIncidentCu.PTimeH4 = "-1";
        ReportIncidentCu.TxtPTimeM4 = "Select Hour";
        ReportIncidentCu.PTimeM4 = "-1";
        ReportIncidentCu.Age4 = "";
        ReportIncidentCu.AgeGroup4 = "-1";
        ReportIncidentCu.Weight4 = "";
        ReportIncidentCu.Height4 = "";
        ReportIncidentCu.Hair4 = "";
        ReportIncidentCu.ClothingTop4 = "";
        ReportIncidentCu.ClothingBottom4 = "";
        ReportIncidentCu.Shoes4 = "";
        ReportIncidentCu.Weapon4 = "";
        ReportIncidentCu.TxtGender4 = "Select Gender";
        ReportIncidentCu.Gender4 = "-1";
        ReportIncidentCu.DistFeat4 = "";
        ReportIncidentCu.InjuryDesc4 = "";
        ReportIncidentCu.InjuryCause4 = "";
        ReportIncidentCu.InjuryComm4 = "";
        ReportIncidentCu.PlayerId4 = "";
        ReportIncidentCu.MemberPhoto4 = null;

        acpPerson4.Visible = false;
        tblAddPerson4.Visible = true;
        tblAddPerson5.Visible = false;
        acdPerson.SelectedIndex = 2;
        txtFirstName3.Focus();
        lblNoOfPerson.Text = "3";
        // validate objects in the form
        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelPerson5_Click(object sender, EventArgs e)
    {
        string personNo = "P5";
        ReportIncidentCu.First5 = "";
        ReportIncidentCu.Last5 = "";
        ReportIncidentCu.Alias5 = "";
        ReportIncidentCu.Contact5 = "";
        ReportIncidentCu.Type5 = "-1";
        ReportIncidentCu.TxtPartyType5 = "Select Type";
        ReportIncidentCu.Witness5 = "false";

        ReportIncidentCu.Card5 = "false";
        ReportIncidentCu.Member5 = "";
        ReportIncidentCu.MDOB5 = "";
        ReportIncidentCu.MAddress5 = "";
        ReportIncidentCu.MemberSince5 = "";

        ReportIncidentCu.SignInSlip5 = "false";
        ReportIncidentCu.SignInBy5 = "";
        ReportIncidentCu.VDOB5 = "";
        ReportIncidentCu.VProofID5 = "";
        ReportIncidentCu.VAddress5 = "";

        ReportIncidentCu.StaffEmp5 = "";
        ReportIncidentCu.StaffAddress5 = "";

        ReportIncidentCu.PDate5 = "";
        ReportIncidentCu.TxtPTimeH5 = "Select Hour";
        ReportIncidentCu.PTimeH5 = "-1";
        ReportIncidentCu.TxtPTimeM5 = "Select Hour";
        ReportIncidentCu.PTimeM5 = "-1";
        ReportIncidentCu.Age5 = "";
        ReportIncidentCu.AgeGroup5 = "-1";
        ReportIncidentCu.Weight5 = "";
        ReportIncidentCu.Height5 = "";
        ReportIncidentCu.Hair5 = "";
        ReportIncidentCu.ClothingTop5 = "";
        ReportIncidentCu.ClothingBottom5 = "";
        ReportIncidentCu.Shoes5 = "";
        ReportIncidentCu.Weapon5 = "";
        ReportIncidentCu.TxtGender5 = "Select Gender";
        ReportIncidentCu.Gender5 = "-1";
        ReportIncidentCu.DistFeat5 = "";
        ReportIncidentCu.InjuryDesc5 = "";
        ReportIncidentCu.InjuryCause5 = "";
        ReportIncidentCu.InjuryComm5 = "";
        ReportIncidentCu.PlayerId5 = "";
        ReportIncidentCu.MemberPhoto5 = null;

        acpPerson5.Visible = false;
        tblAddPerson5.Visible = true;
        tblDelPerson5.Visible = false;
        acdPerson.SelectedIndex = 3;
        txtFirstName4.Focus();
        lblNoOfPerson.Text = "4";
        // validate objects in the form
        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 0;
        txtAge1.Focus();
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 1;
        txtAge2.Focus();
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 2;
        txtAge3.Focus();
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 3;
        txtAge4.Focus();
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
        acdPerson.SelectedIndex = 4;
        txtAge5.Focus();
    }

    protected void ddlAgeGroup1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge1.Text = "";
        acdPerson.SelectedIndex = 0;
        txtAge1.Focus();
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void ddlAgeGroup2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge2.Text = "";
        acdPerson.SelectedIndex = 1;
        txtAge2.Focus();
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void ddlAgeGroup3_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge3.Text = "";
        acdPerson.SelectedIndex = 2;
        txtAge3.Focus();
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void ddlAgeGroup4_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge4.Text = "";
        acdPerson.SelectedIndex = 3;
        txtAge4.Focus();
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void ddlAgeGroup5_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAge5.Text = "";
        acdPerson.SelectedIndex = 4;
        txtAge5.Focus();
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    // delete stored Human Body Images from Person
    protected void btnDelete1_Click(object sender, EventArgs e)
    {
        string personNo = "P1";

        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        string personNo = "P2";

        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelete3_Click(object sender, EventArgs e)
    {
        string personNo = "P3";

        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelete4_Click(object sender, EventArgs e)
    {
        string personNo = "P4";

        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnDelete5_Click(object sender, EventArgs e)
    {
        string personNo = "P5";

        bool returnedValue = deleteHumanBodyForm(personNo);
        if (returnedValue == true)
        {
            return;
        }
    }

    // generic delete method for Human Body Forms
    protected bool deleteHumanBodyForm(string personNo)
    {
        // check if the report status is 'Report Completed'
        // toggle the global variable _deleteHumanImage flag if it's true
        // store the personNo in a delimited string ';'
        // proceed to btnUpdate_Click event in Default.aspx.cs 

        //var uri = new Uri("file://MR-WEB01/ReportImages/RId" + ReportSystem.getId + "_" + personNo + "_AV" + ReportSystem.getAuditVersion + ".jpeg", UriKind.Absolute);
        //if (File.Exists(uri.LocalPath))
        //{
        //    File.Delete(uri.LocalPath);
        //}

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return returnedValue;
        }

        if (personNo.Equals("P1"))
        {
            cbHumanBody.Checked = false;
            Image1.Visible = false;
            btnDelete1.Visible = false;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE Report_ClubUminaIncident SET Image1=NULL WHERE ReportId='" + Report.Id + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            acdPerson.SelectedIndex = 0;
            ReportIncidentCu.HumanBody1 = null;
        }
        if (personNo.Equals("P2"))
        {
            cbHumanBody2.Checked = false;
            Image2.Visible = false;
            btnDelete2.Visible = false;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE Report_ClubUminaIncident SET Image2=NULL WHERE ReportId='" + Report.Id + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            acdPerson.SelectedIndex = 1;
            ReportIncidentCu.HumanBody2 = null;
        }
        if (personNo.Equals("P3"))
        {
            cbHuman3.Checked = false;
            Image3.Visible = false;
            btnDelete3.Visible = false;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE Report_ClubUminaIncident SET Image3=NULL WHERE ReportId='" + Report.Id + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            acdPerson.SelectedIndex = 2;
            ReportIncidentCu.HumanBody3 = null;
        }
        if (personNo.Equals("P4"))
        {
            cbHuman4.Checked = false;
            Image4.Visible = false;
            btnDelete4.Visible = false;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE Report_ClubUminaIncident SET Image4=NULL WHERE ReportId='" + Report.Id + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            acdPerson.SelectedIndex = 3;
            ReportIncidentCu.HumanBody4 = null;
        }
        if (personNo.Equals("P5"))
        {
            cbHuman5.Checked = false;
            Image5.Visible = false;
            btnDelete5.Visible = false;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE Report_ClubUminaIncident SET Image5=NULL WHERE ReportId='" + Report.Id + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            acdPerson.SelectedIndex = 4;
            ReportIncidentCu.HumanBody5 = null;
        }
        // if report is report completed. Flag that there were changes made
        if (Report.Status == "Report Completed")
        {
            Report.HasImageChange = true;
        }
        return returnedValue;
    }

    // displays whether or not to tick the Human Body checkbox and sets the current accordion selected (also runs cbHumanBodyForm method)
    protected void cbHumanBody_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHumanBody.Checked == true)
        {
            Report.SelectedAcp = "0";
        }
        else
        {
            Report.SelectedAcp = "-1";
        }
        cbHumanBodyForm();
    }
    protected void cbHumanBody2_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHumanBody2.Checked == true)
        {
            Report.SelectedAcp = "1";
        }
        else
        {
            Report.SelectedAcp = "-1";
        }
        cbHumanBodyForm();
    }
    protected void cbHuman3_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHuman3.Checked == true)
        {
            Report.SelectedAcp = "2";
        }
        else
        {
            Report.SelectedAcp = "-1";
        }
        cbHumanBodyForm();
    }
    protected void cbHuman4_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHuman4.Checked == true)
        {
            Report.SelectedAcp = "3";
        }
        else
        {
            Report.SelectedAcp = "-1";
        }
        cbHumanBodyForm();
    }
    protected void cbHuman5_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHuman5.Checked == true)
        {
            Report.SelectedAcp = "4";
        }
        else
        {
            Report.SelectedAcp = "-1";
        }
        cbHumanBodyForm();
    }

    // toggles the canvas and section (for Human Body Form), Image object and delete button (if an image is stored) 
    protected void cbHumanBodyForm()
    {
        if (Report.SelectedAcp == "0")
        {
            // show Human Body form
            tblHuman.Visible = true;
            section1.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "init", "init('Image')", true);
            acdPerson.SelectedIndex = 0;
        }
        else if (Report.SelectedAcp == "1")
        {
            // show Human Body form
            tblHuman.Visible = true;
            section1.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "init", "init('Image')", true);
            acdPerson.SelectedIndex = 1;
        }
        else
       if (Report.SelectedAcp == "2")
        {
            // show Human Body form
            tblHuman.Visible = true;
            section1.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "init", "init('Image')", true);
            acdPerson.SelectedIndex = 2;
        }
        else
       if (Report.SelectedAcp == "3")
        {
            // show Human Body form
            tblHuman.Visible = true;
            section1.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "init", "init('Image')", true);
            acdPerson.SelectedIndex = 3;
        }
        else
       if (Report.SelectedAcp == "4")
        {
            // show Human Body form
            tblHuman.Visible = true;
            section1.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "init", "init('Image')", true);
            acdPerson.SelectedIndex = 4;
        }
        else
        {
            // hide Human Body form
            tblHuman.Visible = false;
            section1.Visible = false;
        }

        Report.RunEditMode = true;
        setGlobalVar();
        if (Report.SelectedAcp == "0")
        {
            cbHumanBody.Checked = true;
            btnDelete1.Visible = false;
            Image1.Visible = false;
        }
        if (Report.SelectedAcp == "1")
        {
            cbHumanBody2.Checked = true;
            btnDelete2.Visible = false;
            Image2.Visible = false;
        }
        if (Report.SelectedAcp == "2")
        {
            cbHuman3.Checked = true;
            btnDelete3.Visible = false;
            Image3.Visible = false;
        }
        if (Report.SelectedAcp == "3")
        {
            cbHuman4.Checked = true;
            btnDelete4.Visible = false;
            Image4.Visible = false;
        }
        if (Report.SelectedAcp == "4")
        {
            cbHuman5.Checked = true;
            btnDelete5.Visible = false;
            Image5.Visible = false;
        }
    }

    // checkbox to show Camera Form - be able add Camera Form
    protected void cbCamera_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCamera.Checked == true)
        {
            // show the added Camera form
            tblCamera1.Visible = true;
            tblAddCam2.Visible = true;
            txtCamDesc1.Text = "Camera No. ";
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
            txtCamDesc1.Text = "";
            cbRecorded1.Checked = false;
            txtCamFilePath1.Text = "";
            txtCamSDate1.Text = "";
            txtCamEDate1.Text = "";
        }

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam2_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 2 button
        tblAddCam2.Visible = false;
        // show the added Camera form
        tblCamera2.Visible = true;
        txtCamDesc2.Text = "Camera No. ";
        tblAddCam3.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam3_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 3 button
        tblAddCam3.Visible = false;
        // show the added Camera form
        tblCamera3.Visible = true;
        txtCamDesc3.Text = "Camera No. ";
        tblAddCam4.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam4_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 4 button
        tblAddCam4.Visible = false;
        // show the added Camera form
        tblCamera4.Visible = true;
        txtCamDesc4.Text = "Camera No. ";
        tblAddCam5.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam5_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam5.Visible = false;
        // show the added Camera form
        tblCamera5.Visible = true;
        txtCamDesc5.Text = "Camera No. ";
        tblAddCam6.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam6_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam6.Visible = false;
        // show the added Camera form
        tblCamera6.Visible = true;
        txtCamDesc6.Text = "Camera No. ";
        tblAddCam7.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void btnAddCam7_Click(object sender, EventArgs e)
    {
        // hide the Add Camera no. 5 button
        tblAddCam7.Visible = false;
        // show the added Camera form
        tblCamera7.Visible = true;
        txtCamDesc7.Text = "Camera No. ";
        tblDelCam7.Visible = true;
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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
                    txtOthers.Focus();
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
                    txtOtherSerious.Focus();
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
                    List_RefuseReason.Focus();
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
                    List_AskedToLeave.Focus();
                }
                else
                {
                    askedtoLeaveReasons.Visible = false;
                    askedtoLeaveReasons1.Visible = false;
                    List_AskedToLeave.ClearSelection();
                }
            }
        }
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
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
                    txtActionTakenOther.Focus();
                }
                else
                {
                    actionTakenOther.Visible = false;
                    actionTakenOther1.Visible = false;
                    txtActionTakenOther.Text = "";
                }
            }
        }

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // add/delete security/police info
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
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
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // generic text, selectedindex, check changed events
    protected void TextChanged_TextChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // generic text, selectedindex, check changed events
    protected void MemberNo_TextChanged(object sender, EventArgs e)
    {
        TextBox txtBox = sender as TextBox;
        string cmdQuery;
        switch (txtBox.ID)
        {
            case "txtMemberNo1":
                Report.MemberNumberChanged = "1";
                cmdQuery = SearchMember(txtMemberNo1.Text);
                ReadFields(cmdQuery, "SearchMember");
                acdPerson.SelectedIndex = 0;
                break;
            case "txtMemberNo2":
                Report.MemberNumberChanged = "2";
                cmdQuery = SearchMember(txtMemberNo2.Text);
                ReadFields(cmdQuery, "SearchMember");
                acdPerson.SelectedIndex = 1;
                break;
            case "txtMemberNo3":
                Report.MemberNumberChanged = "3";
                cmdQuery = SearchMember(txtMemberNo3.Text);
                ReadFields(cmdQuery, "SearchMember");
                acdPerson.SelectedIndex = 2;
                break;
            case "txtMemberNo4":
                Report.MemberNumberChanged = "4";
                cmdQuery = SearchMember(txtMemberNo4.Text);
                ReadFields(cmdQuery, "SearchMember");
                acdPerson.SelectedIndex = 3;
                break;
            case "txtMemberNo5":
                Report.MemberNumberChanged = "5";
                cmdQuery = SearchMember(txtMemberNo5.Text);
                ReadFields(cmdQuery, "SearchMember");
                acdPerson.SelectedIndex = 4;
                break;
        }

        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
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

    protected void SelectedIndexChanged_SelectedIndexChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }
    protected void CheckChanged_CheckedChanged(object sender, EventArgs e)
    {
        // validate objects in the form
        bool returnedValue = checkFields();
        if (returnedValue == true)
        {
            return;
        }
    }

    // runs validateForm method and sets global variables
    protected bool checkFields()
    {
        Report.ErrorMessage = ""; // stores the last known error message
        bool returnedValue = false;

        if (ddlShift.SelectedItem.Value.ToString() == "-1")
        {
            Report.ErrorMessage = Report.ErrorMessage + "\\n* Please select a Shift.";
            ddlShift.Focus();
            returnedValue = true;
        }

        // sets Returned Flag to either 1 or 2 (with / without error) and reloads editButton from Default.aspx
        if (returnedValue == true)
        {
            Report.HasErrorMessage = true; // does not trigger update query in Default because of the error
            return returnedValue;
        }
        else
        {
            Report.HasErrorMessage = false; // allows the update query to run (no errors)
            Report.ErrorMessage = ""; // stores the last known error message
        }

        bool returnedValue1 = validateForm();
        // sets Returned Flag to either 1 or 2 (with / without error) and reloads editButton from Default.aspx
        if (returnedValue1 == true)
        {
            Report.HasErrorMessage1 = true; // does not trigger update query in Default because of the error
        }
        else
        {
            Report.HasErrorMessage1 = false; // allows the update query to run (no errors)
            Report.ErrorMessage = ""; // stores the last known error message
        }
        Report.RunEditMode = true; // reloads editButton method from Default.aspx
        setGlobalVar(); // stores the objects data in a global variable

        return returnedValue;
    }
}
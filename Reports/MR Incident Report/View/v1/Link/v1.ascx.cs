using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MR_Incident_Report_View_v1_Link_v1 : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Report.LinkedTable.Contains("Incident"))
        {
            //if (Report.SelectedStaffId == UserCredentials.StaffId || UserCredentials.GroupsQuery.Contains("Supervisor") || UserCredentials.GroupsQuery.Contains("Duty Manager") || UserCredentials.GroupsQuery.Contains("Senior Manager") || UserCredentials.GroupsQuery.Contains("Override") && Report.LinkedTable.Contains("Incident")) // if it is a member of Duty Manager display the Incident Report
            //{
            //    incidentReport.Visible = true;
            //    readFiles(Report.LinkedReport, "getFields");
            //}
            //else
            //{
            //    incidentReport.Visible = false;
            //}
        }
        else
        {
            incidentReport.Visible = true;
            readFiles(Report.LinkedReport, "getFields");
        }

        if (UserCredentials.Role.Equals("MR Reception") || UserCredentials.Role.Equals("CU Reception"))
        {
            lblIncidentNo.Text = "Incident No. " + Session["LinkRId"];
            sdsRecommendation_Allegation.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_Allegation] WHERE ReportId=" + 0;
            sdsRecommendation_DisciplinaryAction.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_DisciplinaryAction] WHERE ReportId=" + 0;
            sdsRecommendation_Judiciary.SelectCommand = "SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [Recommendation_Judiciary] WHERE ReportId=" + Session["LinkRId"];
        }
        else
        {
            lblIncidentNo.Text = "Incident No. " + Session["LinkRId"];
            sdsRecommendation_Allegation.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_Allegation] WHERE ReportId=" + Session["LinkRId"];
            sdsRecommendation_DisciplinaryAction.SelectCommand = "SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_DisciplinaryAction] WHERE ReportId=" + Session["LinkRId"];
            sdsRecommendation_Judiciary.SelectCommand = "SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [Recommendation_Judiciary] WHERE ReportId=" + Session["LinkRId"];
        }
    }

    public string ProcessMyDataItem(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return " ";
        }
        else
        {
            myValue = Convert.ToDateTime(myValue).ToString("dddd, dd MMMM yyyy");
        }
        return myValue.ToString();
    }

    public string ProcessDate(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return "";
        }
        else
        {
            myValue = Convert.ToDateTime(myValue).ToString("dd/MM/yyyy");
        }
        return myValue.ToString();
    }

    public Boolean ProcessCheckBox(object myValue)
    {
        if (String.IsNullOrEmpty(myValue.ToString()))
        {
            return false;
        }
        return Convert.ToBoolean(myValue);
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
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
                        // display proper Age Group
                        switch (rdr["AgeGroup1"].ToString())
                        {
                            case "-1":
                                lblAgeGroup1.Text = "";
                                break;
                            case "1":
                                lblAgeGroup1.Text = "Under 18";
                                break;
                            case "2":
                                lblAgeGroup1.Text = "18-25";
                                break;
                            case "3":
                                lblAgeGroup1.Text = "26-34";
                                break;
                            case "4":
                                lblAgeGroup1.Text = "35-40";
                                break;
                            case "6":
                                lblAgeGroup1.Text = "41-45";
                                break;
                            case "7":
                                lblAgeGroup1.Text = "46-50";
                                break;
                            case "8":
                                lblAgeGroup1.Text = "51-60";
                                break;
                            case "9":
                                lblAgeGroup1.Text = "61+";
                                break;
                            case "5":
                                lblAgeGroup1.Text = "N/A";
                                break;
                        }
                        switch (rdr["AgeGroup2"].ToString())
                        {
                            case "-1":
                                lblAgeGroup2.Text = "";
                                break;
                            case "1":
                                lblAgeGroup2.Text = "Under 18";
                                break;
                            case "2":
                                lblAgeGroup2.Text = "18-25";
                                break;
                            case "3":
                                lblAgeGroup2.Text = "26-34";
                                break;
                            case "4":
                                lblAgeGroup2.Text = "35-40";
                                break;
                            case "6":
                                lblAgeGroup2.Text = "41-45";
                                break;
                            case "7":
                                lblAgeGroup2.Text = "46-50";
                                break;
                            case "8":
                                lblAgeGroup2.Text = "51-60";
                                break;
                            case "9":
                                lblAgeGroup2.Text = "61+";
                                break;
                            case "5":
                                lblAgeGroup2.Text = "N/A";
                                break;
                        }
                        switch (rdr["AgeGroup3"].ToString())
                        {
                            case "-1":
                                lblAgeGroup3.Text = "";
                                break;
                            case "1":
                                lblAgeGroup3.Text = "Under 18";
                                break;
                            case "2":
                                lblAgeGroup3.Text = "18-25";
                                break;
                            case "3":
                                lblAgeGroup3.Text = "26-34";
                                break;
                            case "4":
                                lblAgeGroup3.Text = "35-40";
                                break;
                            case "6":
                                lblAgeGroup3.Text = "41-45";
                                break;
                            case "7":
                                lblAgeGroup3.Text = "46-50";
                                break;
                            case "8":
                                lblAgeGroup3.Text = "51-60";
                                break;
                            case "9":
                                lblAgeGroup3.Text = "61+";
                                break;
                            case "5":
                                lblAgeGroup3.Text = "N/A";
                                break;
                        }
                        switch (rdr["AgeGroup4"].ToString())
                        {
                            case "-1":
                                lblAgeGroup4.Text = "";
                                break;
                            case "1":
                                lblAgeGroup4.Text = "Under 18";
                                break;
                            case "2":
                                lblAgeGroup4.Text = "18-25";
                                break;
                            case "3":
                                lblAgeGroup4.Text = "26-34";
                                break;
                            case "4":
                                lblAgeGroup4.Text = "35-40";
                                break;
                            case "6":
                                lblAgeGroup4.Text = "41-45";
                                break;
                            case "7":
                                lblAgeGroup4.Text = "46-50";
                                break;
                            case "8":
                                lblAgeGroup4.Text = "51-60";
                                break;
                            case "9":
                                lblAgeGroup4.Text = "61+";
                                break;
                            case "5":
                                lblAgeGroup4.Text = "N/A";
                                break;
                        }
                        switch (rdr["AgeGroup5"].ToString())
                        {
                            case "-1":
                                lblAgeGroup5.Text = "";
                                break;
                            case "1":
                                lblAgeGroup5.Text = "Under 18";
                                break;
                            case "2":
                                lblAgeGroup5.Text = "18-25";
                                break;
                            case "3":
                                lblAgeGroup5.Text = "26-34";
                                break;
                            case "4":
                                lblAgeGroup5.Text = "35-40";
                                break;
                            case "6":
                                lblAgeGroup5.Text = "41-45";
                                break;
                            case "7":
                                lblAgeGroup5.Text = "46-50";
                                break;
                            case "8":
                                lblAgeGroup5.Text = "51-60";
                                break;
                            case "9":
                                lblAgeGroup5.Text = "61+";
                                break;
                            case "5":
                                lblAgeGroup5.Text = "N/A";
                                break;
                        }

                        // populate player ids
                        if (!String.IsNullOrEmpty(rdr["PlayerId1"].ToString()))
                        {
                            ReportIncidentMr.ViewPlayerId1 = rdr["PlayerId1"].ToString();
                        }
                        if (!String.IsNullOrEmpty(rdr["PlayerId2"].ToString()))
                        {
                            ReportIncidentMr.ViewPlayerId2 = rdr["PlayerId2"].ToString();
                        }
                        if (!String.IsNullOrEmpty(rdr["PlayerId3"].ToString()))
                        {
                            ReportIncidentMr.ViewPlayerId3 = rdr["PlayerId3"].ToString();
                        }
                        if (!String.IsNullOrEmpty(rdr["PlayerId4"].ToString()))
                        {
                            ReportIncidentMr.ViewPlayerId4 = rdr["PlayerId4"].ToString();
                        }
                        if (!String.IsNullOrEmpty(rdr["PlayerId5"].ToString()))
                        {
                            ReportIncidentMr.ViewPlayerId5 = rdr["PlayerId5"].ToString();
                        }

                        // Populate the Checkbox for Incident Type and tick necessary checkbox
                        string actionTakenVariable = rdr["ActionTaken"].ToString(), cmdQuery3;

                        if (!string.IsNullOrEmpty(actionTakenVariable))
                        {
                            actionTakenVariable = actionTakenVariable.Remove(actionTakenVariable.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list

                            cmdQuery3 = "SELECT * FROM [dbo].[List_ActionTaken] WHERE [SiteID] = 1 AND ([Active] = 1 OR [ActionID] IN (" + actionTakenVariable + ")) ORDER BY CASE WHEN [Description] = 'None of the above' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            cmdQuery3 = "SELECT * FROM [dbo].[List_ActionTaken] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'None of the above' THEN 1 ELSE 0 END, [Description]";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery3;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["ActionId"].ToString();
                                    List_ActionTaken.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check if Action Taken is not empty
                        if (!String.IsNullOrEmpty(rdr["ActionTaken"].ToString()))
                        {
                            string[] arrActionTaken = rdr["ActionTaken"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_ActionTaken.Items)
                            {
                                for (int i = 0; i < arrActionTaken.Length; i++)
                                {
                                    if (arrActionTaken[i].ToString().Equals(item.Value))
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                        }

                        // check if Other Location Textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["LocationOther"].ToString()))
                        {
                            otherLocation.Visible = true;
                        }

                        // Populate the Checkbox for Incident Type and tick necessary checkbox
                        string refuseEntryVariable = rdr["HappenedRefuseEntry"].ToString(), cmdQuery4;

                        if (!string.IsNullOrEmpty(refuseEntryVariable))
                        {
                            cmdQuery4 = "SELECT * FROM [dbo].[List_RefuseReason] WHERE [SiteID] = 1 AND ([Active] = 1 OR [RefuseReasonID] IN (" + refuseEntryVariable + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            cmdQuery4 = "SELECT * FROM [dbo].[List_RefuseReason] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery4;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["RefuseReasonID"].ToString();
                                    List_RefuseReason.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        // check if Refuse Entry is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedRefuseEntry"].ToString()))
                        {
                            refuseEntryReasons.Visible = true;
                            refuseEntryReasons1.Visible = true;
                            List_RefuseReason.Visible = true;
                            string[] arrRefuseReason = rdr["HappenedRefuseEntry"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_RefuseReason.Items)
                            {
                                for (int i = 0; i < arrRefuseReason.Length; i++)
                                {
                                    if (arrRefuseReason[i].ToString().Equals(item.Value))
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                        }

                        // check if Other Happened Textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedOther"].ToString()))
                        {
                            additionalDetails.Visible = true;
                            additionalDetails1.Visible = true;
                        }

                        // check if Other - Action Taken is not empty
                        if (!String.IsNullOrEmpty(rdr["ActionTakenOther"].ToString()))
                        {
                            actionTakenOther.Visible = true;
                            actionTakenOther1.Visible = true;
                        }

                        // check if Other Serious Textbox is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedSerious"].ToString()))
                        {
                            otherSerious.Visible = true;
                            otherSerious1.Visible = true;
                        }

                        // Populate the Checkbox for Incident Type and tick necessary checkbox
                        string askedToLeaveVariable = rdr["HappenedAskedToLeave"].ToString(), cmdQuery5;

                        if (!string.IsNullOrEmpty(askedToLeaveVariable))
                        {
                            cmdQuery5 = "SELECT * FROM [dbo].[List_AskedToLeave] WHERE [SiteID] = 1 AND ([Active] = 1 OR [AskedToLeaveID] IN (" + askedToLeaveVariable + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            cmdQuery5 = "SELECT * FROM [dbo].[List_AskedToLeave] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery5;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["AskedToLeaveID"].ToString();
                                    List_AskedToLeave.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }
                        // check if Asked To Leave is not empty
                        if (!String.IsNullOrEmpty(rdr["HappenedAskedToLeave"].ToString()))
                        {
                            askedtoLeaveReasons.Visible = true;
                            askedtoLeaveReasons1.Visible = true;
                            List_AskedToLeave.Visible = true;
                            string[] arrAskedToLeave = rdr["HappenedAskedToLeave"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (ListItem item in List_AskedToLeave.Items)
                            {
                                for (int i = 0; i < arrAskedToLeave.Length; i++)
                                {
                                    if (arrAskedToLeave[i].ToString().Equals(item.Value))
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                        }

                        // show image Human Body Form if not empty
                        byte[] image1 = null,
                               image2 = null,
                               image3 = null,
                               image4 = null,
                               image5 = null,
                               memberPhoto1 = null,
                               memberPhoto2 = null,
                               memberPhoto3 = null,
                               memberPhoto4 = null,
                               memberPhoto5 = null;

                        try // set Member Photo
                        {
                            if ((byte[])rdr["MemberPhoto1"] != null)
                            {
                                memberPhoto1 = (byte[])rdr["MemberPhoto1"];
                            }
                        }
                        catch
                        {
                            memberPhoto1 = null;
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
                            }
                        }
                        catch
                        {
                            memberPhoto2 = null;
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
                            }
                        }
                        catch
                        {
                            memberPhoto3 = null;
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
                            }
                        }
                        catch
                        {
                            memberPhoto4 = null;
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
                            }
                        }
                        catch
                        {
                            memberPhoto5 = null;
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
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image1 = null;
                        }
                        try // set image 2 value
                        {
                            if ((byte[])rdr["Image2"] != null)
                            {
                                image2 = (byte[])rdr["Image2"];
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image2 = null;
                        }
                        try // set image 3 value
                        {
                            if ((byte[])rdr["Image3"] != null)
                            {
                                image3 = (byte[])rdr["Image3"];
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image3 = null;
                        }
                        try // set image 4 value
                        {
                            if ((byte[])rdr["Image4"] != null)
                            {
                                image4 = (byte[])rdr["Image4"];
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image4 = null;
                        }
                        try // set image 5 value
                        {
                            if ((byte[])rdr["Image5"] != null)
                            {
                                image5 = (byte[])rdr["Image5"];
                            }
                        }
                        catch // if it is empty set it to null
                        {
                            image5 = null;
                        }

                        if (image1 != null && image1.Length > 0)
                        {
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image1, 0, image1.Length);
                            Image1.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            image1l.Visible = false;
                            Image1.Visible = false;
                        }
                        if (image2 != null && image2.Length > 0)
                        {
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image2, 0, image2.Length);
                            Image2.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            image2l.Visible = false;
                            Image2.Visible = false;
                        }
                        if (image3 != null && image3.Length > 0)
                        {
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image3, 0, image3.Length);
                            Image3.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            image3l.Visible = false;
                            Image3.Visible = false;
                        }
                        if (image4 != null && image4.Length > 0)
                        {
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image4, 0, image4.Length);
                            Image4.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            image4l.Visible = false;
                            Image4.Visible = false;
                        }
                        if (image5 != null && image5.Length > 0)
                        {
                            // load image from database
                            string strBase64 = Convert.ToBase64String(image5, 0, image5.Length);
                            Image5.ImageUrl = "data:image/jpeg;base64," + strBase64;
                        }
                        else
                        {
                            image5l.Visible = false;
                            Image5.Visible = false;
                        }
                        // hide fields if empty
                        if (String.IsNullOrEmpty(rdr["Height1"].ToString()))
                        {
                            height1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight1"].ToString()))
                        {
                            weight1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Hair1"].ToString()))
                        {
                            hair1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingTop1"].ToString()))
                        {
                            clothingTop1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingBottom1"].ToString()))
                        {
                            clothingBottom1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Shoes1"].ToString()))
                        {
                            shoes1.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Weight1"].ToString()) && String.IsNullOrEmpty(rdr["Height1"].ToString()) && String.IsNullOrEmpty(rdr["Hair1"].ToString()) && String.IsNullOrEmpty(rdr["ClothingTop1"].ToString()) &&
                            String.IsNullOrEmpty(rdr["ClothingBottom1"].ToString()) && String.IsNullOrEmpty(rdr["Shoes1"].ToString()) && String.IsNullOrEmpty(rdr["Weapon1"].ToString()))
                        {
                            physical1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight2"].ToString()) && String.IsNullOrEmpty(rdr["Height2"].ToString()) && String.IsNullOrEmpty(rdr["Hair2"].ToString()) && String.IsNullOrEmpty(rdr["ClothingTop2"].ToString()) &&
                            String.IsNullOrEmpty(rdr["ClothingBottom2"].ToString()) && String.IsNullOrEmpty(rdr["Shoes2"].ToString()) && String.IsNullOrEmpty(rdr["Weapon2"].ToString()))
                        {
                            physical2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight3"].ToString()) && String.IsNullOrEmpty(rdr["Height3"].ToString()) && String.IsNullOrEmpty(rdr["Hair3"].ToString()) && String.IsNullOrEmpty(rdr["ClothingTop3"].ToString()) &&
                            String.IsNullOrEmpty(rdr["ClothingBottom3"].ToString()) && String.IsNullOrEmpty(rdr["Shoes3"].ToString()) && String.IsNullOrEmpty(rdr["Weapon3"].ToString()))
                        {
                            physical3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight4"].ToString()) && String.IsNullOrEmpty(rdr["Height4"].ToString()) && String.IsNullOrEmpty(rdr["Hair4"].ToString()) && String.IsNullOrEmpty(rdr["ClothingTop4"].ToString()) &&
                            String.IsNullOrEmpty(rdr["ClothingBottom4"].ToString()) && String.IsNullOrEmpty(rdr["Shoes4"].ToString()) && String.IsNullOrEmpty(rdr["Weapon4"].ToString()))
                        {
                            physical4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight5"].ToString()) && String.IsNullOrEmpty(rdr["Height5"].ToString()) && String.IsNullOrEmpty(rdr["Hair5"].ToString()) && String.IsNullOrEmpty(rdr["ClothingTop5"].ToString()) &&
                            String.IsNullOrEmpty(rdr["ClothingBottom5"].ToString()) && String.IsNullOrEmpty(rdr["Shoes5"].ToString()) && String.IsNullOrEmpty(rdr["Weapon5"].ToString()))
                        {
                            physical5.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["PDate1"].ToString()) || rdr["TxtPTimeH1"].ToString().Equals("Select Hour") || rdr["TxtPTimeM1"].ToString().Equals("Select Minute"))
                        {
                            p1DateEntryl.Visible = false;
                            p1DateEntry.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["PDate2"].ToString()) || rdr["TxtPTimeH2"].ToString().Equals("Select Hour") || rdr["TxtPTimeM2"].ToString().Equals("Select Minute"))
                        {
                            p2DateEntryl.Visible = false;
                            p2DateEntry.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["PDate3"].ToString()) || rdr["TxtPTimeH3"].ToString().Equals("Select Hour") || rdr["TxtPTimeM3"].ToString().Equals("Select Minute"))
                        {
                            p3DateEntryl.Visible = false;
                            p3DateEntry.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["PDate4"].ToString()) || rdr["TxtPTimeH4"].ToString().Equals("Select Hour") || rdr["TxtPTimeM4"].ToString().Equals("Select Minute"))
                        {
                            p4DateEntryl.Visible = false;
                            p4DateEntry.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["PDate5"].ToString()) || rdr["TxtPTimeH5"].ToString().Equals("Select Hour") || rdr["TxtPTimeM5"].ToString().Equals("Select Minute"))
                        {
                            p5DateEntryl.Visible = false;
                            p5DateEntry.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Weapon1"].ToString()))
                        {
                            weapon1.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Height2"].ToString()))
                        {
                            height2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight2"].ToString()))
                        {
                            weight2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Hair2"].ToString()))
                        {
                            hair2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingTop2"].ToString()))
                        {
                            clothingTop2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingBottom2"].ToString()))
                        {
                            clothingBottom2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Shoes2"].ToString()))
                        {
                            shoes2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weapon2"].ToString()))
                        {
                            weapon2.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Height3"].ToString()))
                        {
                            height3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight3"].ToString()))
                        {
                            weight3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Hair3"].ToString()))
                        {
                            hair3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingTop3"].ToString()))
                        {
                            clothingTop3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingBottom3"].ToString()))
                        {
                            clothingBottom3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Shoes3"].ToString()))
                        {
                            shoes3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weapon3"].ToString()))
                        {
                            weapon3.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Height4"].ToString()))
                        {
                            height4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight4"].ToString()))
                        {
                            weight4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Hair4"].ToString()))
                        {
                            hair4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingTop4"].ToString()))
                        {
                            clothingTop4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingBottom4"].ToString()))
                        {
                            clothingBottom4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Shoes4"].ToString()))
                        {
                            shoes4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weapon4"].ToString()))
                        {
                            weapon4.Visible = false;
                        }

                        if (String.IsNullOrEmpty(rdr["Height5"].ToString()))
                        {
                            height5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weight5"].ToString()))
                        {
                            weight5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Hair5"].ToString()))
                        {
                            hair5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingTop5"].ToString()))
                        {
                            clothingTop5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["ClothingBottom5"].ToString()))
                        {
                            clothingBottom5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Shoes5"].ToString()))
                        {
                            shoes5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Weapon5"].ToString()))
                        {
                            weapon5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["DistFeatures1"].ToString()))
                        {
                            dist1l.Visible = false;
                            dist1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["DistFeatures2"].ToString()))
                        {
                            dist2l.Visible = false;
                            dist2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["DistFeatures3"].ToString()))
                        {
                            dist3l.Visible = false;
                            dist3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["DistFeatures4"].ToString()))
                        {
                            dist4l.Visible = false;
                            dist4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["DistFeatures5"].ToString()))
                        {
                            dist5l.Visible = false;
                            dist5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["InjuryDesc1"].ToString()))
                        {
                            injdesc1l.Visible = false;
                            injdesc1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["InjuryDesc2"].ToString()))
                        {
                            injdesc2l.Visible = false;
                            injdesc2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["InjuryDesc3"].ToString()))
                        {
                            injdesc3l.Visible = false;
                            injdesc3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["InjuryDesc4"].ToString()))
                        {
                            injdesc4l.Visible = false;
                            injdesc4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["InjuryDesc5"].ToString()))
                        {
                            injdesc5l.Visible = false;
                            injdesc5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CauseInjury1"].ToString()))
                        {
                            causeinj1l.Visible = false;
                            causeinj1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CauseInjury2"].ToString()))
                        {
                            causeinj2l.Visible = false;
                            causeinj2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CauseInjury3"].ToString()))
                        {
                            causeinj3l.Visible = false;
                            causeinj3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CauseInjury4"].ToString()))
                        {
                            causeinj4l.Visible = false;
                            causeinj4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CauseInjury5"].ToString()))
                        {
                            causeinj5l.Visible = false;
                            causeinj5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Comments1"].ToString()))
                        {
                            inccom1l.Visible = false;
                            inccom1.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Comments2"].ToString()))
                        {
                            inccom2l.Visible = false;
                            inccom2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Comments3"].ToString()))
                        {
                            inccom3l.Visible = false;
                            inccom3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Comments4"].ToString()))
                        {
                            inccom4l.Visible = false;
                            inccom4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["Comments5"].ToString()))
                        {
                            inccom5l.Visible = false;
                            inccom5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc1"].ToString()))
                        {
                            tblCam1.Visible = false;
                        }
                        else
                        {
                            cbCameraFootage.Checked = true;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc2"].ToString()))
                        {
                            tblCam2.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc3"].ToString()))
                        {
                            tblCam3.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc4"].ToString()))
                        {
                            tblCam4.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc5"].ToString()))
                        {
                            tblCam5.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc6"].ToString()))
                        {
                            tblCam6.Visible = false;
                        }
                        if (String.IsNullOrEmpty(rdr["CamDesc7"].ToString()))
                        {
                            tblCam7.Visible = false;
                        }
                        if (Int32.Parse(rdr["NoOfPerson"].ToString()) < 1)
                        {
                            tblPerson1.Visible = false;
                        }
                        if (Int32.Parse(rdr["NoOfPerson"].ToString()) < 2)
                        {
                            tblPerson2.Visible = false;
                        }
                        if (Int32.Parse(rdr["NoOfPerson"].ToString()) < 3)
                        {
                            tblPerson3.Visible = false;
                        }
                        if (Int32.Parse(rdr["NoOfPerson"].ToString()) < 4)
                        {
                            tblPerson4.Visible = false;
                        }
                        if (Int32.Parse(rdr["NoOfPerson"].ToString()) < 5)
                        {
                            tblPerson5.Visible = false;
                        }
                        if (rdr["PartyType1"].ToString() == "1")
                        {
                            staff11l.Visible = false;
                            staff12l.Visible = false;
                            witness1l.Visible = true;
                            member11l.Visible = true;
                            member12l.Visible = true;
                            member13l.Visible = true;
                            member14l.Visible = true;

                            visitor11l.Visible = false;
                            visitor12l.Visible = false;
                            visitor13l.Visible = false;
                            visitor14l.Visible = false;
                            visitor15l.Visible = false;
                        }
                        else if (rdr["PartyType1"].ToString() == "2")
                        {
                            staff11l.Visible = false;
                            staff12l.Visible = false;
                            witness1l.Visible = true;
                            member11l.Visible = false;
                            member12l.Visible = false;
                            member13l.Visible = false;
                            member14l.Visible = false;

                            visitor11l.Visible = true;
                            visitor12l.Visible = true;
                            visitor13l.Visible = true;
                            visitor14l.Visible = true;
                            visitor15l.Visible = true;
                        }
                        else if (rdr["PartyType1"].ToString() == "3")
                        {
                            staff11l.Visible = true;
                            staff12l.Visible = true;
                            witness1l.Visible = true;
                            member11l.Visible = false;
                            member12l.Visible = false;
                            member13l.Visible = false;
                            member14l.Visible = false;

                            visitor11l.Visible = false;
                            visitor12l.Visible = false;
                            visitor13l.Visible = false;
                            visitor14l.Visible = false;
                            visitor15l.Visible = false;
                        }
                        else if (rdr["PartyType1"].ToString() == "4" || rdr["PartyType1"].ToString() == "5" || rdr["PartyType1"].ToString() == "6" || rdr["PartyType1"].ToString() == "7")
                        {
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

                            visitor11l.Visible = false;
                            visitor12l.Visible = false;
                            visitor13l.Visible = false;
                            visitor14l.Visible = false;
                            visitor15l.Visible = false;
                        }
                        if (rdr["PartyType2"].ToString() == "1")
                        {
                            staff21l.Visible = false;
                            staff22l.Visible = false;
                            witness2l.Visible = true;
                            member21l.Visible = true;
                            member22l.Visible = true;
                            member23l.Visible = true;
                            member24l.Visible = true;

                            visitor21l.Visible = false;
                            visitor22l.Visible = false;
                            visitor23l.Visible = false;
                            visitor24l.Visible = false;
                            visitor25l.Visible = false;
                        }
                        else if (rdr["PartyType2"].ToString() == "2")
                        {
                            staff21l.Visible = false;
                            staff22l.Visible = false;
                            witness2l.Visible = true;
                            member21l.Visible = false;
                            member22l.Visible = false;
                            member23l.Visible = false;
                            member24l.Visible = false;

                            visitor21l.Visible = true;
                            visitor22l.Visible = true;
                            visitor23l.Visible = true;
                            visitor24l.Visible = true;
                            visitor25l.Visible = true;
                        }
                        else if (rdr["PartyType2"].ToString() == "3")
                        {
                            staff21l.Visible = true;
                            staff22l.Visible = true;
                            witness2l.Visible = true;
                            member21l.Visible = false;
                            member22l.Visible = false;
                            member23l.Visible = false;
                            member24l.Visible = false;

                            visitor21l.Visible = false;
                            visitor22l.Visible = false;
                            visitor23l.Visible = false;
                            visitor24l.Visible = false;
                            visitor25l.Visible = false;
                        }
                        else if (rdr["PartyType2"].ToString() == "4" || rdr["PartyType2"].ToString() == "5" || rdr["PartyType2"].ToString() == "6" || rdr["PartyType2"].ToString() == "7")
                        {
                            witness2l.Visible = true;
                        }
                        else
                        {
                            staff21l.Visible = false;
                            staff22l.Visible = false;
                            witness2l.Visible = false;
                            member21l.Visible = false;
                            member22l.Visible = false;
                            member23l.Visible = false;
                            member24l.Visible = false;

                            visitor21l.Visible = false;
                            visitor22l.Visible = false;
                            visitor23l.Visible = false;
                            visitor24l.Visible = false;
                            visitor25l.Visible = false;
                        }
                        if (rdr["PartyType3"].ToString() == "1")
                        {
                            staff31l.Visible = false;
                            staff32l.Visible = false;
                            witness3l.Visible = true;
                            member31l.Visible = true;
                            member32l.Visible = true;
                            member33l.Visible = true;
                            member34l.Visible = true;

                            visitor31l.Visible = false;
                            visitor32l.Visible = false;
                            visitor33l.Visible = false;
                            visitor34l.Visible = false;
                            visitor35l.Visible = false;
                        }
                        else if (rdr["PartyType3"].ToString() == "2")
                        {
                            staff31l.Visible = false;
                            staff32l.Visible = false;
                            witness3l.Visible = true;
                            member31l.Visible = false;
                            member32l.Visible = false;
                            member33l.Visible = false;
                            member34l.Visible = false;

                            visitor31l.Visible = true;
                            visitor32l.Visible = true;
                            visitor33l.Visible = true;
                            visitor34l.Visible = true;
                            visitor35l.Visible = true;
                        }
                        else if (rdr["PartyType3"].ToString() == "3")
                        {
                            staff31l.Visible = true;
                            staff32l.Visible = true;
                            witness3l.Visible = true;
                            member31l.Visible = false;
                            member32l.Visible = false;
                            member33l.Visible = false;
                            member34l.Visible = false;

                            visitor31l.Visible = false;
                            visitor32l.Visible = false;
                            visitor33l.Visible = false;
                            visitor34l.Visible = false;
                            visitor35l.Visible = false;
                        }
                        else if (rdr["PartyType3"].ToString() == "4" || rdr["PartyType3"].ToString() == "5" || rdr["PartyType3"].ToString() == "6" || rdr["PartyType3"].ToString() == "7")
                        {
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

                            visitor31l.Visible = false;
                            visitor32l.Visible = false;
                            visitor33l.Visible = false;
                            visitor34l.Visible = false;
                            visitor35l.Visible = false;
                        }
                        if (rdr["PartyType4"].ToString() == "1")
                        {
                            staff41l.Visible = false;
                            staff42l.Visible = false;
                            witness4l.Visible = true;
                            member41l.Visible = true;
                            member42l.Visible = true;
                            member43l.Visible = true;
                            member44l.Visible = true;

                            visitor41l.Visible = false;
                            visitor42l.Visible = false;
                            visitor43l.Visible = false;
                            visitor44l.Visible = false;
                            visitor45l.Visible = false;
                        }
                        else if (rdr["PartyType4"].ToString() == "2")
                        {
                            staff41l.Visible = false;
                            staff42l.Visible = false;
                            witness4l.Visible = true;
                            member41l.Visible = false;
                            member42l.Visible = false;
                            member43l.Visible = false;
                            member44l.Visible = false;

                            visitor41l.Visible = true;
                            visitor42l.Visible = true;
                            visitor43l.Visible = true;
                            visitor44l.Visible = true;
                            visitor45l.Visible = true;
                        }
                        else if (rdr["PartyType4"].ToString() == "3")
                        {
                            staff41l.Visible = true;
                            staff42l.Visible = true;
                            witness4l.Visible = true;
                            member41l.Visible = false;
                            member42l.Visible = false;
                            member43l.Visible = false;
                            member44l.Visible = false;

                            visitor41l.Visible = false;
                            visitor42l.Visible = false;
                            visitor43l.Visible = false;
                            visitor44l.Visible = false;
                            visitor45l.Visible = false;
                        }
                        else if (rdr["PartyType4"].ToString() == "4" || rdr["PartyType4"].ToString() == "5" || rdr["PartyType4"].ToString() == "6" || rdr["PartyType4"].ToString() == "7")
                        {
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

                            visitor41l.Visible = false;
                            visitor42l.Visible = false;
                            visitor43l.Visible = false;
                            visitor44l.Visible = false;
                            visitor45l.Visible = false;
                        }
                        if (rdr["PartyType5"].ToString() == "1")
                        {
                            staff51l.Visible = false;
                            staff52l.Visible = false;
                            witness5l.Visible = true;
                            member51l.Visible = true;
                            member52l.Visible = true;
                            member53l.Visible = true;
                            member54l.Visible = true;

                            visitor51l.Visible = false;
                            visitor52l.Visible = false;
                            visitor53l.Visible = false;
                            visitor54l.Visible = false;
                            visitor55l.Visible = false;
                        }
                        else if (rdr["PartyType5"].ToString() == "2")
                        {
                            staff51l.Visible = false;
                            staff52l.Visible = false;
                            witness5l.Visible = true;
                            member51l.Visible = false;
                            member52l.Visible = false;
                            member53l.Visible = false;
                            member54l.Visible = false;

                            visitor51l.Visible = true;
                            visitor52l.Visible = true;
                            visitor53l.Visible = true;
                            visitor54l.Visible = true;
                            visitor55l.Visible = true;
                        }
                        else if (rdr["PartyType5"].ToString() == "3")
                        {
                            staff51l.Visible = true;
                            staff52l.Visible = true;
                            witness5l.Visible = true;
                            member51l.Visible = false;
                            member52l.Visible = false;
                            member53l.Visible = false;
                            member54l.Visible = false;

                            visitor51l.Visible = false;
                            visitor52l.Visible = false;
                            visitor53l.Visible = false;
                            visitor54l.Visible = false;
                            visitor55l.Visible = false;
                        }
                        else if (rdr["PartyType5"].ToString() == "4" || rdr["PartyType5"].ToString() == "5" || rdr["PartyType5"].ToString() == "6" || rdr["PartyType5"].ToString() == "7")
                        {
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

                            visitor51l.Visible = false;
                            visitor52l.Visible = false;
                            visitor53l.Visible = false;
                            visitor54l.Visible = false;
                            visitor55l.Visible = false;
                        }

                        if (Convert.ToBoolean(rdr["SecurityAttend"]) == false)
                        {
                            // Hide Security Details by Default
                            tdSecurity1.Visible = false;
                        }

                        if (Convert.ToBoolean(rdr["PoliceNotify"]) == false)
                        {
                            // Hide Police Details by Default
                            tdPolice1.Visible = false;
                            tdPolice2.Visible = false;
                            tdPolice3.Visible = false;
                        }

                        // Populate the Checkbox for Incident Type and tick necessary checkbox
                        string incidentVariable = rdr["IncidentHappened"].ToString(), cmdQuery1;

                        if (!string.IsNullOrEmpty(incidentVariable))
                        {
                            incidentVariable = incidentVariable.Remove(incidentVariable.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list

                            cmdQuery1 = "SELECT * FROM [dbo].[List_IncidentType] WHERE [SiteID] = 1 AND ([Active] = 1 OR [IncidentID] IN (" + incidentVariable + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            cmdQuery1 = "SELECT * FROM [dbo].[List_IncidentType] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery1;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["IncidentId"].ToString();
                                    cblWhatHappened1.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        string[] arrWhatHappened = rdr["IncidentHappened"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in cblWhatHappened1.Items)
                        {
                            for (int i = 0; i < arrWhatHappened.Length; i++)
                            {
                                if (arrWhatHappened[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        // Populate the Checkbox for Location and tick necessary checkbox
                        string locationVariable = rdr["Location"].ToString(), cmdQuery2;

                        if (!string.IsNullOrEmpty(locationVariable))
                        {
                            locationVariable = locationVariable.Remove(locationVariable.Length - 1); // take off the ','. creates exceptions in passing the values to the dropdown list

                            cmdQuery2 = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 1 AND ([Active] = 1 OR [LocationID] IN (" + locationVariable + ")) ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }
                        else
                        {
                            cmdQuery2 = "SELECT * FROM [dbo].[List_Location] WHERE [SiteID] = 1 AND [Active] = 1 ORDER BY CASE WHEN [Description] = 'Other' THEN 1 ELSE 0 END, [Description]";
                        }

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = cmdQuery2;
                            command.Connection = connection;
                            connection.Open();
                            using (SqlDataReader sdr = command.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Description"].ToString();
                                    item.Value = sdr["LocationId"].ToString();
                                    List_Location.Items.Add(item);
                                }
                            }
                            connection.Close();
                        }

                        string[] arrLocation = rdr["Location"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem item in List_Location.Items)
                        {
                            for (int i = 0; i < arrLocation.Length; i++)
                            {
                                if (arrLocation[i].ToString().Equals(item.Value))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        // adjust the spacing with the witness, height, gender, and weight fields
                        if (height1.Visible == false && weight1.Visible == false)
                        {
                            if (hair1.Visible == false && clothingTop1.Visible == false)
                            {
                                tdPartyType1.Style.Add("width", "510px");
                            }
                            else
                            {
                                tdPartyType1.Style.Add("width", "510px");
                            }
                        }
                        else if (height1.Visible == true && weight1.Visible == true)
                        {
                            tdPartyType1.Style.Add("width", "310px");
                            witness1l.Style.Add("width", "200px");
                        }

                        if (height2.Visible == false && weight2.Visible == false)
                        {
                            if (hair2.Visible == false && clothingTop2.Visible == false)
                            {
                                tdPartyType2.Style.Add("width", "510px");
                            }
                            else
                            {
                                tdPartyType2.Style.Add("width", "510px");
                            }
                        }
                        else if (height2.Visible == true && weight2.Visible == true)
                        {
                            tdPartyType2.Style.Add("width", "310px");
                            witness2l.Style.Add("width", "200px");
                        }

                        if (height3.Visible == false && weight3.Visible == false)
                        {
                            if (hair3.Visible == false && clothingTop3.Visible == false)
                            {
                                tdPartyType3.Style.Add("width", "510px");
                            }
                            else
                            {
                                tdPartyType3.Style.Add("width", "510px");
                            }
                        }
                        else if (height3.Visible == true && weight3.Visible == true)
                        {
                            tdPartyType3.Style.Add("width", "310px");
                            witness3l.Style.Add("width", "200px");
                        }

                        if (height4.Visible == false && weight4.Visible == false)
                        {
                            if (hair4.Visible == false && clothingTop4.Visible == false)
                            {
                                tdPartyType4.Style.Add("width", "510px");
                            }
                            else
                            {
                                tdPartyType4.Style.Add("width", "510px");
                            }
                        }
                        else if (height4.Visible == true && weight4.Visible == true)
                        {
                            tdPartyType4.Style.Add("width", "310px");
                            witness4l.Style.Add("width", "200px");
                        }

                        if (height5.Visible == false && weight5.Visible == false)
                        {
                            if (hair5.Visible == false && clothingTop5.Visible == false)
                            {
                                tdPartyType5.Style.Add("width", "510px");
                            }
                            else
                            {
                                tdPartyType5.Style.Add("width", "510px");
                            }
                        }
                        else if (height5.Visible == true && weight5.Visible == true)
                        {
                            tdPartyType5.Style.Add("width", "310px");
                            witness5l.Style.Add("width", "200px");
                        }

                        if (Convert.ToBoolean(rdr["SignInSlip1"]) == false)
                        {
                            visitor12l.Visible = false;
                        }
                        if (Convert.ToBoolean(rdr["SignInSlip2"]) == false)
                        {
                            visitor22l.Visible = false;
                        }
                        if (Convert.ToBoolean(rdr["SignInSlip3"]) == false)
                        {
                            visitor32l.Visible = false;
                        }
                        if (Convert.ToBoolean(rdr["SignInSlip4"]) == false)
                        {
                            visitor42l.Visible = false;
                        }
                        if (Convert.ToBoolean(rdr["SignInSlip5"]) == false)
                        {
                            visitor52l.Visible = false;
                        }
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

    protected void sdsRecommendation_Allegation_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@ReportId"].Value = Session["LinkRId"];
    } // Used for setting the Select Parameter
      // Disciplinary Action
    protected void sdsRecommendation_DisciplinaryAction_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@ReportId"].Value = Session["LinkRId"];
    } // Used for setting the Select Parameter
      // Judiciary Committee/Board Decision
    protected void sdsRecommendation_Judiciary_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@ReportId"].Value = Session["LinkRId"];
    } // Used for setting the Select Parameter
}
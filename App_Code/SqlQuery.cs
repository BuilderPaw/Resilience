using System;
using System.Collections.Generic;
using System.Data; // Command Type
using System.Data.SqlClient; // SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI; // Display Message

/// <summary>
/// Pases through SQL Connection Query to retrieving data
/// </summary>
public class SqlQuery
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();

    public SqlQuery()
    {

    }

    //public string[] RetrieveData(string sqlQuery, string data)
    //{
    //    string[] returnData = new string[12];

    //    // read files from sql database
    //    SqlDataReader rdr = null;
    //    SqlCommand cmd = new SqlCommand(sqlQuery, con);

    //    // set appropriate stored procedure (either Proc_KeywordSearchAllReports - any report other than Incidents
    //    if (sqlQuery.Equals("Proc_KeywordSearchAllReports"))
    //    {
    //        cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeOut"]);
    //        string keyword = SearchReport.Keyword.ToString().Replace("+", " ");
    //        cmd.CommandType = CommandType.StoredProcedure; // runs stored procedure Proc_KeywordSearchAllReports
    //        cmd.Parameters.Add("SearchStr", SqlDbType.VarChar).Value = keyword;
    //    }

    //    // Proc_KeywordSearchIncidentReports - Incidents ONLY)
    //    if (sqlQuery.Equals("Proc_KeywordSearchIncidentReports"))
    //    {
    //        cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeOut"]);
    //        string keyword = SearchReport.Keyword.Replace("+", " ");
    //        cmd.CommandType = CommandType.StoredProcedure; // runs stored procedure Proc_KeywordSearchIncidentReports
    //        cmd.Parameters.Add("SearchStr", SqlDbType.VarChar).Value = keyword;
    //        cmd.Parameters.Add("MemNo", SqlDbType.VarChar).Value = SearchReport.MemberNo;
    //        cmd.Parameters.Add("Location", SqlDbType.VarChar).Value = SearchReport.Location;
    //        cmd.Parameters.Add("WhatHappened", SqlDbType.VarChar).Value = SearchReport.WhatHappened;
    //        cmd.Parameters.Add("ActionTaken", SqlDbType.VarChar).Value = SearchReport.ActionTaken;
    //        cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = SearchReport.FirstName;
    //        cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = SearchReport.LastName;
    //        cmd.Parameters.Add("Alias", SqlDbType.VarChar).Value = SearchReport.Alias;
    //    }

    //    // List all reports related to selected Player Id
    //    if (sqlQuery.Equals("Proc_ListPriorIncidents"))
    //    {
    //        string playerId = "";
    //        switch (SearchReport.ListPlayerIdIncidents)
    //        {
    //            case "mr1":
    //                playerId = ReportIncidentMr.ViewPlayerId1;
    //                break;
    //            case "mr2":
    //                playerId = ReportIncidentMr.ViewPlayerId2;
    //                break;
    //            case "mr3":
    //                playerId = ReportIncidentMr.ViewPlayerId3;
    //                break;
    //            case "mr4":
    //                playerId = ReportIncidentMr.ViewPlayerId4;
    //                break;
    //            case "mr5":
    //                playerId = ReportIncidentMr.ViewPlayerId5;
    //                break;
    //            case "cu1":
    //                playerId = ReportIncidentCu.ViewPlayerId1;
    //                break;
    //            case "cu2":
    //                playerId = ReportIncidentCu.ViewPlayerId2;
    //                break;
    //            case "cu3":
    //                playerId = ReportIncidentCu.ViewPlayerId3;
    //                break;
    //            case "cu4":
    //                playerId = ReportIncidentCu.ViewPlayerId4;
    //                break;
    //            case "cu5":
    //                playerId = ReportIncidentCu.ViewPlayerId5;
    //                break;
    //        }
    //        cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeOut"]);
    //        cmd.CommandType = CommandType.StoredProcedure; // runs stored procedure Proc_ListPriorIncidents
    //        cmd.Parameters.Add("PlayerId", SqlDbType.VarChar).Value = playerId;
    //    }

    //    try
    //    {
    //        con.Open();
    //        rdr = cmd.ExecuteReader();

    //        if (rdr.HasRows)
    //        {
    //            while (rdr.Read())
    //            {
    //                if (data.Equals("UpdateStaffSign")) // script written to revert Update mistake
    //                {
    //                    Report.EntryDate = rdr["ModifyDate"].ToString();
    //                    Report.SelectedStaffName = rdr["StaffName"].ToString();
    //                }
    //                if (data.Equals("SearchKeyword"))
    //                {
    //                    // get table name and report id, save it as a string together with the sql query (adding a union) and make it look like the view from MRSLDB
    //                    // send the Table Name and Report ID to ReportSystem static class to create the query for searching the keyword
    //                    SearchReport.GlobalSearchId += rdr["ReportID"].ToString() + ", ";
    //                }
    //                if (data.Equals("CheckStaffExist"))
    //                {
    //                    con1.Open(); // check whether or not the active name stored in the database is correct
    //                    SqlCommand checkExist = new SqlCommand("SELECT Name FROM [StaffName] WHERE [StaffId] = '" + rdr["StaffId"].ToString() + "' AND [Active] = 1", con1);
    //                    string staffName = (string)checkExist.ExecuteScalar();
    //                    con1.Close();

    //                    try
    //                    {
    //                        // store the Staff Id current Club Umina Manager to be used in ManagerSignQuery method in Report.cs and ManagerSignNotification method in Default.aspx.cs
    //                        con1.Open();
    //                        SqlCommand cuManager = new SqlCommand("SELECT StaffId FROM [Staff] WHERE GroupNames LIKE '%CUReportsClubManager%'", con1);
    //                        Report.ClubManagerUmina = cuManager.ExecuteScalar().ToString();
    //                        con1.Close();
    //                    }
    //                    catch { }

    //                    if (UserCredentials.DisplayName.Equals(staffName)) // if staff is up-to-date, continue
    //                    {                     
    //                        UserCredentials.StaffId = rdr["StaffId"].ToString();
    //                        UserCredentials.StaffNameId = rdr["StaffNameId"].ToString();

    //                        UpdateStaffRoleAndPass();
    //                    }
    //                    else // if user has a different name in the Active Directory to the Database
    //                    {
    //                        con1.Open();
    //                        SqlCommand updateActiveName = new SqlCommand("UPDATE [StaffName] SET [Active]=0 WHERE Name='" + staffName + "'", con1); // update StaffName table and set Active field to false for this staff name
    //                        updateActiveName.ExecuteNonQuery();
    //                        con1.Close();

    //                        con1.Open();
    //                        SqlCommand checkNameExist = new SqlCommand("SELECT COUNT(*) FROM [StaffName] WHERE [Name] = '" + UserCredentials.DisplayName + "'", con1); // check if the name given already exist in the database
    //                        int exist = (int)checkNameExist.ExecuteScalar();
    //                        con1.Close();

    //                        if (exist > 0) // the name is already in the database, change the Active field to the right StaffNameId
    //                        {
    //                            con1.Open();
    //                            SqlCommand cmd3 = new SqlCommand("Update [StaffName] SET [Active]=1 WHERE Name='" + UserCredentials.DisplayName + "'", con1);
    //                            cmd3.ExecuteNonQuery();
    //                            con1.Close();

    //                            con1.Open();
    //                            SqlCommand checkExist3 = new SqlCommand("SELECT [StaffNameId] FROM [StaffName] WHERE [Name] = '" + UserCredentials.DisplayName + "' AND [ACTIVE]=1 ", con1);
    //                            int staffNameId = (int)checkExist3.ExecuteScalar();
    //                            con1.Close();

    //                            con1.Open();
    //                            SqlCommand cmd4 = new SqlCommand("Update [Staff] SET [StaffNameId]='" + staffNameId + "' WHERE StaffId='" + rdr["StaffId"].ToString() + "'", con1);
    //                            cmd4.ExecuteNonQuery();
    //                            con1.Close();

    //                            UserCredentials.StaffId = rdr["StaffId"].ToString();
    //                            UserCredentials.StaffNameId = staffNameId.ToString();
    //                            UserCredentials.Role = rdr["StaffGroup"].ToString();

    //                            UpdateStaffRoleAndPass();
    //                        }
    //                        else // Name does not exist in the database, create a new StaffNameId and make it active
    //                        {
    //                            using (DataClassesDataContext dc = new DataClassesDataContext()) // add new staff name
    //                            {
    //                                StaffName dm = new StaffName();
    //                                dm.StaffId = Int32.Parse(rdr["StaffId"].ToString());
    //                                dm.Name = UserCredentials.DisplayName;
    //                                dm.Active = true;
    //                                dc.StaffNames.InsertOnSubmit(dm);
    //                                dc.SubmitChanges();
    //                            }

    //                            con1.Open();
    //                            SqlCommand checkExist4 = new SqlCommand("SELECT [StaffNameId] FROM [StaffName] WHERE [StaffId] = '" + rdr["StaffId"].ToString() + "' AND [Active] = 1", con1);
    //                            int staffNameId = (int)checkExist4.ExecuteScalar();
    //                            con1.Close();

    //                            con1.Open();
    //                            SqlCommand cmd5 = new SqlCommand("Update [Staff] SET [StaffNameId]='" + staffNameId + "' WHERE StaffId='" + rdr["StaffId"].ToString() + "'", con1);
    //                            cmd5.ExecuteNonQuery();
    //                            con1.Close();

    //                            UserCredentials.StaffId = rdr["StaffId"].ToString();
    //                            UserCredentials.StaffNameId = staffNameId.ToString();
    //                            UserCredentials.Role = rdr["StaffGroup"].ToString();
    //                        }
    //                    }

    //                    break; // the query only needs to run once, this stops it from looping a few times
    //                }
    //                if (data.Equals("HasReport")) // used for previous and next report selected
    //                {
    //                    Report.Id = rdr["ReportId"].ToString();                     // set the selected ReportId
    //                    Report.Table = rdr["Report_Table"].ToString();              // set the selected Report_Table
    //                    try // if report is from a Report Table                     // set the selected Report_Version
    //                    {
    //                        Report.Version = rdr["Report_Version"].ToString();
    //                    }
    //                    catch // if report is from ActionRequired Table 
    //                    {
    //                        Report.Version = rdr["Version"].ToString();
    //                    }
    //                    Report.RowNumber = rdr["RowNum"].ToString();                // set the selected Row Number
    //                    Report.AuditVersion = rdr["AuditVersion"].ToString();       // set the selected Audit Version
    //                    Report.Status = rdr["ReportStat"].ToString();               // set the status of the selected report
    //                    Report.Name = rdr["ReportName"].ToString();                 // set the selected ReportName
    //                    try // if the report is written by the logged in user       // set the Staff ID selected in the report
    //                    {
    //                        Report.SelectedStaffId = rdr["StaffAuthor"].ToString();
    //                    }
    //                    catch // else someone else have written the report
    //                    {
    //                        Report.SelectedStaffId = rdr["StaffId"].ToString();
    //                    }
    //                    Report.SelectedStaffName = rdr["StaffName"].ToString();     // set the Staff selected in the report
    //                    Report.HasReport = true;
    //                }
    //                if (data.Equals("ManagerSignOffRequired")) // check if report requires manager sign-off
    //                {
    //                    Report.ManagerSignOffRequired = (bool)rdr["ManagerSignOffRequired"];
    //                }
    //                if (data.Equals("ReadList")) // get the list of users who read the report selected
    //                {
    //                    Report.ReadList = rdr["ReadBy"].ToString();
    //                    Report.ReadListStaffId = rdr["ReadByList"].ToString();
    //                }
    //                if (data.Equals("Comment")) // get the list of comments entered in the report selected
    //                {
    //                    Report.Comment = rdr["Comments"].ToString();
    //                }
    //                if (data.Equals("HasManagerSign")) // check if report has already been signed by a manager
    //                {
    //                    if (string.IsNullOrEmpty(rdr["ManagerSign"].ToString())) // if there is no manager sign in the selected report
    //                    {
    //                        Report.HasManagerSign = false;
    //                    }else // a manager has already signed the report
    //                    {
    //                        Report.HasManagerSign = true;
    //                    }
    //                }
    //                if (data.Equals("HasUserSign")) // check if report has already been signed by the user
    //                {
    //                    if (string.IsNullOrEmpty(rdr["StaffSign"].ToString())) // user hasn't signed the selected report
    //                    {
    //                        Report.HasUserSign = false;
    //                    }
    //                    else // user has already signed the report
    //                    {
    //                        Report.HasUserSign = true;
    //                    }
    //                }
    //                if (data.Equals("HasPendingAction"))
    //                {
    //                    if (Convert.ToBoolean(rdr["Completed"].ToString()) == false)
    //                    {
    //                        Report.HasPendingAction = true;
    //                    }
    //                }
    //                if (data.Equals("CheckUsername")) // get report owner's username
    //                {
    //                    returnData[0] = rdr["Username"].ToString();
    //                }
    //            }
    //        }
    //        else // if there is no data to read
    //        {
    //            if (data.Equals("HasReport")) // used for previous and next report selected
    //            {
    //                Report.HasReport = false;
    //                alert.DisplayMessage("End of list.");
    //            }
    //            if (data.Equals("ReadList")) // if no one has read the report yet
    //            {
    //                Report.ReadList = "";
    //                Report.ReadListStaffId = "";
    //            }
    //            if (data.Equals("Comment")) // if no one has entered a comment on the report
    //            {
    //                Report.Comment = "";
    //            }
    //            if (data.Equals("CheckStaffExist"))
    //            {
    //                string staffRole = ""; // at any case, update the staff group details of the user (just in case there was a promotion that had happened)
    //                if (UserCredentials.Groups.Contains("MRReportsSeniorManagers"))
    //                {
    //                    staffRole = "MR Senior Managers";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsDutyManagers"))
    //                {
    //                    staffRole = "MR Duty Managers";
    //                }
    //                else if (UserCredentials.Groups.Contains("CUReportsDutyManagers"))
    //                {
    //                    staffRole = "CU Duty Managers";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsSupervisors"))
    //                {
    //                    staffRole = "MR Supervisors";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsFunctionSupervisor"))
    //                {
    //                    staffRole = "MR Function Supervisor";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsReceptionSupervisor"))
    //                {
    //                    staffRole = "MR Reception Supervisor";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsReception"))
    //                {
    //                    staffRole = "MR Reception";
    //                }
    //                else if (UserCredentials.Groups.Contains("CUReportsReception"))
    //                {
    //                    staffRole = "CU Reception";
    //                }
    //                else if (UserCredentials.Groups.Contains("MRReportsIncident"))
    //                {
    //                    staffRole = "MR Contractor";
    //                }

    //                // get the last Staff Name ID stored in the database
    //                con1.Open();
    //                SqlCommand checkExist = new SqlCommand("SELECT MAX(StaffNameId) FROM [StaffName]", con1);
    //                int staffNameId = (int)checkExist.ExecuteScalar();
    //                con1.Close();

    //                // store staffNameId as the next available variable
    //                staffNameId += 1;
    //                UserCredentials.StaffNameId = staffNameId.ToString();

    //                // add the staff if not registered
    //                using (DataClassesDataContext dc = new DataClassesDataContext())
    //                {
    //                    Staff dm = new Staff();
    //                    dm.Username = UserCredentials.Username;
    //                    dm.StaffGroup = staffRole;
    //                    dm.StaffNameId = staffNameId;
    //                    dm.Active = true;
    //                    dc.Staffs.InsertOnSubmit(dm);
    //                    dc.SubmitChanges();
    //                }

    //                // get the Staff ID of the created staff
    //                con1.Open();
    //                SqlCommand checkExist1 = new SqlCommand("SELECT MAX(StaffId) FROM [Staff] WHERE [StaffNameId] = '" + staffNameId + "'", con1);
    //                int staffId = (int)checkExist1.ExecuteScalar();
    //                con1.Close();

    //                // add new staff name
    //                using (DataClassesDataContext dc = new DataClassesDataContext())
    //                {
    //                    StaffName dm = new StaffName();
    //                    dm.StaffId = staffId;
    //                    dm.Name = UserCredentials.DisplayName;
    //                    dm.Active = true;
    //                    dc.StaffNames.InsertOnSubmit(dm);
    //                    dc.SubmitChanges();
    //                }
    //            }
    //            if (data.Equals("HasPendingAction"))
    //            {
    //                Report.HasPendingAction = false;
    //            }
    //            if (data.Equals("CheckUsername"))
    //            {
    //                Report.WrongUsername = true;
    //            }
    //        }
    //    }
    //    catch (Exception er)
    //    {
    //        alert.DisplayMessage(er.Message);
    //    }
    //    finally
    //    {
    //        if (rdr != null)
    //        {
    //            rdr.Close();
    //        }
    //        if (con != null)
    //        {
    //            con.Close();
    //        }
    //    }
    //    return returnData;
    //}

    private void UpdateStaffRoleAndPass()
    {
        string staffRole = ""; // at any case, update the staff group details of the user (just in case there was a promotion that had happened)
        if (UserCredentials.Groups.Contains("MRReportsSeniorManagers"))
        {
            staffRole = "MR Senior Managers";
        }
        else if (UserCredentials.Groups.Contains("MRReportsDutyManagers"))
        {
            staffRole = "MR Duty Managers";
        }
        else if (UserCredentials.Groups.Contains("CUReportsDutyManagers"))
        {
            staffRole = "CU Duty Managers";
        }
        else if (UserCredentials.Groups.Contains("MRReportsSupervisors"))
        {
            staffRole = "MR Supervisors";
        }
        else if (UserCredentials.Groups.Contains("MRReportsFunctionSupervisor"))
        {
            staffRole = "MR Function Supervisor";
        }
        else if (UserCredentials.Groups.Contains("MRReportsReceptionSupervisor"))
        {
            staffRole = "MR Reception Supervisor";
        }
        else if (UserCredentials.Groups.Contains("MRReportsReception"))
        {
            staffRole = "MR Reception";
        }
        else if (UserCredentials.Groups.Contains("CUReportsReception"))
        {
            staffRole = "CU Reception";
        }
        else if (UserCredentials.Groups.Contains("MRReportsIncident"))
        {
            staffRole = "MR Contractor";
        }

        con1.Open(); // Update Staff Role in the database
        SqlCommand updateRole = new SqlCommand("UPDATE [Staff] SET [StaffGroup]='" + staffRole + "' WHERE StaffId=" + UserCredentials.StaffId, con1);
        updateRole.ExecuteNonQuery();
        con1.Close();

        // update group names
        con1.Open(); // Update Staff Role in the database
        SqlCommand updateGroups = new SqlCommand("UPDATE [Staff] SET [GroupNames]='" + UserCredentials.Groups + "' WHERE StaffId=" + UserCredentials.StaffId, con1);
        updateGroups.ExecuteNonQuery();
        con1.Close();

        UserCredentials.Role = staffRole;
    }
}
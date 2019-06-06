using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for Searching Report
/// </summary>
public class SearchReport
{
    public SearchReport()
    {

    }

    public string Search(int report, int dateGroup, string staffId, int status, string keyword, string listPlayerIdIncidents)
    {        
        Keyword = keyword;

        string reportStatus = "";
        switch (status) // set status for writing the select query
        {
            case 2:
                reportStatus = "%Completion%";
                break;
            case 3:
                reportStatus = "%Manager%";
                break;
            case 4:
                reportStatus = "%Further%";
                break;
            case 5:
                reportStatus = "%Completed%";
                break;
        }

        DateTime date1 = DateTime.Now.Date, date2 = DateTime.Now.Date; // used to hold Date Group values
        switch (dateGroup) // set the date being filtered
        {
            case 2:
                date2 = DateTime.Now.Date.AddDays(-1);  // reports from yesterday
                break;
            case 3:
                date2 = DateTime.Now.Date.AddDays(-7);  // reports from last seven days
                break;
            case 4:
                date2 = DateTime.Now.Date.AddDays(-14);  // reports from last 14 days
                break;
            case 5:
                date2 = DateTime.Now.Date.AddDays(-30);  // reports from last month
                break;
            case 6:
                date2 = DateTime.Now.Date.AddDays(-365);  // reports from last year
                break;
            case 7:
                date2 = DateTime.Parse(StartDate);
                date1 = DateTime.Parse(EndDate);
                break;
        }

        string reportType = "";
        switch (report) // set the report type being filtered (take note that any changes from the group will create an error - MRReportsDutyManager)
        {
            case 2:
                reportType = "MR Incident Report";
                break;
            case 3:
                reportType = "MR Duty Managers";
                break;
            case 4:
                reportType = "MR Supervisors";
                break;
            case 5:
                reportType = "MR Function Supervisor";
                break;
            case 6:
                reportType = "MR Reception Supervisor";
                break;
            case 7:
                reportType = "MR Reception";
                break;
            case 8:
                reportType = "CU Duty Managers";
                break;
            case 9:
                reportType = "CU Reception";
                break;
            case 10:
                reportType = "CU Incident Report";
                break;
        }

        // check if user has entered a keyword to be filtered
        bool hasKeyword = true;
        if (keyword.Equals("0") || keyword.Equals("")) // check whether the keyword filter is empty
        {
            hasKeyword = false; // keyword filter is empty
        }

        // check if staff has filter
        bool hasStaffFilter = true;
        if (ArchivedStaff)
        {
            if (string.IsNullOrEmpty(staffId))
            {
                staffId = "SELECT StaffId FROM Staff WHERE Active=0";
            }
        }
        else if (string.IsNullOrEmpty(staffId)) // if there is no staff filter selected, populate staff list
        {
            staffId = "SELECT StaffId FROM Staff";
            hasStaffFilter = false;
        }

        // check if selected staff filter is the user logged in
        bool isAuthor = true;
        if (!staffId.Equals(UserCredentials.StaffId))
        {
            isAuthor = false;
        }

        string selectQuery = "",
               startQuery = "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], [RowNum]" +
                            " FROM [View_Reports] WHERE [ReportName] ",
               startQuery1= "SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table], [Report_Version], [ReportStat], [AuditVersion], ROW_NUMBER() OVER(ORDER BY ShiftDate DESC, ShiftId DESC) RowNum" +
                            " FROM [View_Reports] WHERE ReportName ",
               reportIdQuery = "", dateQuery = "", statusQuery = "", unreadQuery = "", reportQuery = "", authorQuery = "", cuQuery = "", mrQuery = "",
               endQuery = "ORDER BY ShiftDate DESC, ShiftId DESC, RowNum";

        if (report == 1) // no report type filter
        {
            reportQuery = "IN ('" + UserCredentials.GroupsQuery + "') AND ";
        }
        else // has report type filter
        {
            reportQuery = "= '" + reportType + "' AND ";
        }

        if (string.IsNullOrWhiteSpace(ReportId))
        {
            reportIdQuery = " ";
        }
        else
        {
            reportIdQuery = "ReportId =" + ReportId + " AND ";
        }

        if(dateGroup != 1) // has date filter
        {
            dateQuery = "ShiftDate BETWEEN '" + date2.ToString("yyyy-MM-dd") + "' AND '" + date1.ToString("yyyy-MM-dd") + "' AND ";
        }
        else // no date filter
        {
            dateQuery = " ";
        }

        if (MROnly)
        {
            mrQuery = "[ReportName] LIKE '%MR%' AND ";
        }
        else
        {
            mrQuery = "";
        }

        if (CUOnly)
        {
            cuQuery = "[ReportName] LIKE '%CU%' AND ";
        }
        else
        {
            cuQuery = "";
        }

        if (status != 1) // has status filter
        {
            statusQuery = "[ReportStat] LIKE '" + reportStatus + "' AND ";
        }
        else // no status filter
        {
            statusQuery = " ";
        }

        if (!hasStaffFilter) // if staff filter is empty
        {
            authorQuery = "([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off' OR ([ReportStat] = 'Awaiting Completion' AND [StaffId] = '" + UserCredentials.StaffId + "')) ";
        }
        else // has a staff filter
        {
            if (isAuthor)  // The user selected his ownself
            {
                authorQuery = "([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off' OR ([ReportStat] = 'Awaiting Completion' AND [StaffId] = '" + UserCredentials.StaffId + "')) AND StaffId IN (" + staffId + ") ";
            }
            else //  // staff other than the user
            {
                authorQuery = "([ReportStat] = 'Report Completed' OR [ReportStat] = 'Further Action Required' OR [ReportStat] = 'Awaiting Manager Sign-off') AND StaffId IN (" + staffId + ") ";
            }
        }

        if(UnreadList && string.IsNullOrEmpty(ListPlayerIdIncidents)) // unread tickbox has been checked
        {
            unreadQuery = "AND ([ReadByList] NOT LIKE '%," + UserCredentials.StaffId + ",%' OR [ReadByList] IS NULL) AND ([ManagerSignId] NOT LIKE '%" + UserCredentials.StaffId + ",%' OR [ManagerSignId] IS NULL) ";
        }
        else // no unread list filter
        {
            unreadQuery = " ";
        }


        if (!hasKeyword && (WhatHappened.Equals("0") || string.IsNullOrEmpty(WhatHappened)) && (Location.Equals("0") || string.IsNullOrEmpty(Location))
            && (ActionTaken.Equals("0") || string.IsNullOrEmpty(ActionTaken)) && (MemberNo.Equals("0") || string.IsNullOrEmpty(MemberNo))
            && (FirstName.Equals("0") || string.IsNullOrEmpty(FirstName)) && (LastName.Equals("0") || string.IsNullOrEmpty(LastName))
            && (Alias.Equals("0") || string.IsNullOrEmpty(Alias))) // if Keyword and advanced filters are empty
        {
            selectQuery = startQuery + reportQuery + reportIdQuery + dateQuery + mrQuery + cuQuery + statusQuery + authorQuery + unreadQuery + endQuery;
        }
        else // keyword filter and advanced filter has been entered
        {
            // run stored procedures
            SqlQuery sqlQuery = new SqlQuery();
            //if (!string.IsNullOrEmpty(listPlayerIdIncidents)) // run all the list of incidents for the selected player id
            //{
            //    sqlQuery.RetrieveData("Proc_ListPriorIncidents", "SearchKeyword");
            //}
            //else // no player id is selected, filter via keyword and report filters
            //{
            //    // set appropriate stored procedure (either Proc_KeywordSearchAllReports - any report other than Incidents ; Proc_KeywordSearchIncidentReports - Incidents ONLY)
            //    if (reportType.Contains("Incident"))
            //    {
            //        sqlQuery.RetrieveData("Proc_KeywordSearchIncidentReports", "SearchKeyword");
            //    }
            //    else
            //    {
            //        sqlQuery.RetrieveData("Proc_KeywordSearchAllReports", "SearchKeyword");
            //    }
            //}

            if (GlobalSearchId.Equals("")) // if no data retrieved, display an error message
            {
                return selectQuery;
            }

            // take off the extra ', ' in Global Search Ids Variable
            int strLength = GlobalSearchId.Length;
            GlobalSearchId = GlobalSearchId.Remove(strLength - 2, 2);

            string keywordQuery = "AND [ReportId] IN (" + GlobalSearchId + ") ";
            GlobalSearchId = ""; // to avoid this variable from getting appended
            ListPlayerIdIncidents = ""; // reset this variable to be reused again in searching incident reports related to player id selected

            selectQuery = startQuery1 + reportQuery + reportIdQuery + dateQuery + mrQuery + cuQuery + statusQuery + authorQuery + keywordQuery + unreadQuery + endQuery;
        }
        return selectQuery;
    }

    public static string SetAccordion
    {
        get
        {
            if (HttpContext.Current.Session["SRSetAccordion"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRSetAccordion"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRSetAccordion"] = value;
        }
    }

    public static string WhatHappened
    {
        get
        {
            if (HttpContext.Current.Session["SRWhatHappened"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRWhatHappened"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRWhatHappened"] = value;
        }
    }

    public static string Location
    {
        get
        {
            if (HttpContext.Current.Session["SRLocation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRLocation"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRLocation"] = value;
        }
    }

    public static string MemberNo
    {
        get
        {
            if (HttpContext.Current.Session["SRMemberNo"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRMemberNo"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRMemberNo"] = value;
        }
    }

    public static string ActionTaken
    {
        get
        {
            if (HttpContext.Current.Session["SRActionTaken"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRActionTaken"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRActionTaken"] = value;
        }
    }

    public static string FirstName
    {
        get
        {
            if (HttpContext.Current.Session["SRFirstName"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["SRFirstName"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRFirstName"] = value;
        }
    }

    public static string LastName
    {
        get
        {
            if (HttpContext.Current.Session["SRLastName"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["SRLastName"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRLastName"] = value;
        }
    }

    public static string Alias
    {
        get
        {
            if (HttpContext.Current.Session["SRAlias"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["SRAlias"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRAlias"] = value;
        }
    }

    public static string StartDate
    {
        get
        {
            if (HttpContext.Current.Session["SRStartDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRStartDate"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRStartDate"] = value;
        }
    }

    public static string EndDate
    {
        get
        {
            if (HttpContext.Current.Session["SREndDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SREndDate"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SREndDate"] = value;
        }
    }

    public static string Keyword
    {
        get
        {
            if (HttpContext.Current.Session["SRKeyword"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRKeyword"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRKeyword"] = value;
        }
    }

    public static string ReportId
    {
        get
        {
            if (HttpContext.Current.Session["SRReportId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRReportId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRReportId"] = value;
        }
    }

    public static string GlobalSearchId
    {
        get
        {
            if (HttpContext.Current.Session["SRGlobalSearchId"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRGlobalSearchId"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRGlobalSearchId"] = value;
        }
    }

    public static bool UnreadList
    {
        get
        {
            if (HttpContext.Current.Session["SRUnreadList"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRUnreadList"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRUnreadList"] = value;
        }
    }

    public static bool CUOnly
    {
        get
        {
            if (HttpContext.Current.Session["SRCUOnly"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRCUOnly"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRCUOnly"] = value;
        }
    }

    public static bool MROnly
    {
        get
        {
            if (HttpContext.Current.Session["SRMROnly"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRMROnly"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRMROnly"] = value;
        }
    }

    public static bool ArchivedStaff
    {
        get
        {
            if (HttpContext.Current.Session["SRArchivedStaff"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRArchivedStaff"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRArchivedStaff"] = value;
        }
    }

    public static string CreateReport // set the dropdownlist Create Report the current report the user is creating
    {
        get
        {
            if (HttpContext.Current.Session["RCreateReport"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RCreateReport"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["RCreateReport"] = value;
        }
    }

    public static void CreateReportReset() // reset this after submitting a report or when user clicks logo button
    { // takes off the selected report in ddlCreateReport
        CreateReport = "";
    }

    public static void ResetNavigation() // reset any filter the user has selected
    { 
        CreateReportReset(); // takes off the selected report in ddlCreateReport
        UnreadList = true; // ticks this checkbox just in case it's been unticked
        Report.SortReset(); // reset sort static properties
    }

    public static string ListPlayerIdIncidents
    {
        get
        {
            if (HttpContext.Current.Session["SRListPlayerIdIncidents"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["SRListPlayerIdIncidents"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["SRListPlayerIdIncidents"] = value;
        }
    }

    public static bool RunOnStart
    {
        get
        {
            if (HttpContext.Current.Session["SRRunOnStart"] == null)
            {
                return true;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRRunOnStart"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRRunOnStart"] = value;
        }
    }

    public static bool FromCreateReport // check whether or not postback came from Creating a Report
    {
        get
        {
            if (HttpContext.Current.Session["SRCreateReport"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["SRCreateReport"];
            }
        }
        set
        {
            HttpContext.Current.Session["SRCreateReport"] = value;
        }
    }
}
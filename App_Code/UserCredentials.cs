using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for User Credentials
/// </summary>
public class UserCredentials
{
    public UserCredentials()
    {

    }

    public int[] ListReports() // populate into an int array a list of all reports available to the user
    {
        string[] group = UserCredentials.Groups.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
        int j = 0;
        int[] reportList = new int[12];

        for (int i = 0; i < group.Length; i++)
        {
            if (group[i].ToString().Equals("MRReportsDutyManagers"))
            {
                reportList[j] = 1; // assign this number in the array value and increment variable 'j' to add the next value of report available to user
                j++;
            }
            else if (group[i].ToString().Equals("MRReportsSupervisors"))
            {
                reportList[j] = 2;
                j++;
            }
            else if (group[i].ToString().Equals("MRReportsFunctionSupervisor"))
            {
                reportList[j] = 3;
                j++;
            }
            else if (group[i].ToString().Equals("MRReportsReceptionSupervisor"))
            {
                reportList[j] = 4;
                j++;
            }
            else if (group[i].ToString().Equals("MRReportsReception"))
            {
                reportList[j] = 5;
                j++;
            }
            else if (group[i].ToString().Equals("CUReportsDutyManagers"))
            {
                reportList[j] = 6;
                j++;
            }
            else if (group[i].ToString().Equals("CUReportsReception"))
            {
                reportList[j] = 7;
                j++;
            }
            else if (group[i].ToString().Equals("MRReportsIncident"))
            {
                reportList[j] = 8;
                j++;
            }
        }
        return reportList;
    }

    public static string Groups
    {
        get
        {
            if (HttpContext.Current.Session["UCGroups"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["UCGroups"].ToString();
            }
        }
        set
        { /// =GODISGOOD=
            HttpContext.Current.Session["UCGroups"] = value;
        }
    }

    public static string GroupsQuery
    {
        get
        {
            string groupsQuery = HttpContext.Current.Session["UCGroups"].ToString(); // variable for groups without pipe character and is used for SQL query

            if (groupsQuery.Contains("MRReportsSeniorManagers|"))
            {
                groupsQuery = "CU Reception Supervisors', 'MR Reception Supervisor', 'MR Function Supervisor', 'CU Supervisors', 'CU Reception', 'CU Duty Managers', 'MR Users', 'MR Supervisors', 'MR Reception', 'MR Duty Managers', 'MR Incident Report', 'MR Allegation', 'MR Senior Managers', 'CU Incident Report";
            }
            else
            {
                groupsQuery = groupsQuery.Replace("|", ", "); // change the pipe to a comma character
                groupsQuery = groupsQuery.Replace("Reports", " "); // change string "Reports" to a space
                groupsQuery = groupsQuery.Replace("ReceptionSupervisor", "Reception Supervisor"); // add spaces to report
                groupsQuery = groupsQuery.Replace("FunctionSupervisor", "Function Supervisor");
                groupsQuery = groupsQuery.Replace("DutyManager", "Duty Manager");
                groupsQuery = groupsQuery.Replace("CU Reception", "'CU Reception'"); // add a '' to all reports to make it compatible for the sql query to run 
                groupsQuery = groupsQuery.Replace("MR Reception", "'MR Reception'");
                groupsQuery = groupsQuery.Replace("MR Incident", "'MR Incident Report'");
                groupsQuery = groupsQuery.Replace("'CU Reception' Supervisors", "'CU Reception Supervisors'");
                groupsQuery = groupsQuery.Replace("'MR Reception' Supervisor", "'MR Reception Supervisor'");
                groupsQuery = groupsQuery.Replace("'CU Reception'", "'CU Reception', 'CU Incident Report'"); // add a '' to all reports to make it compatible for the sql query to run 
                groupsQuery = groupsQuery.Replace("'MR Reception'", "'MR Reception', 'MR Incident Report'");
                groupsQuery = groupsQuery.Replace("MR Function Supervisor", "'MR Function Supervisor'");
                groupsQuery = groupsQuery.Replace("CU Supervisors", "'CU Supervisors'");
                groupsQuery = groupsQuery.Replace("MR Override","'MR Override'");
                groupsQuery = groupsQuery.Replace("CU Duty Managers", "'CU Duty Managers', 'CU Incident Report'");
                groupsQuery = groupsQuery.Replace("MR Users", "'MR Users'");
                groupsQuery = groupsQuery.Replace("MR Allegation", "'MR Allegation'");
                groupsQuery = groupsQuery.Replace("MR Operations", "'MR Operations'");
                groupsQuery = groupsQuery.Replace("CU ClubManager", "'CU Club Manager'");
                groupsQuery = groupsQuery.Replace("MR Supervisors", "'MR Supervisors', 'MR Incident Report'");
                groupsQuery = groupsQuery.Replace("MR Duty Managers", "'MR Duty Managers', 'MR Incident Report'");
                groupsQuery = groupsQuery.Replace("MR SeniorManagers", "'MR Senior Managers'"); // if user is a Senior Manager create an If/Else statement to replace 'MR Duty Managers', 'MR Incident Report' to just 'MR Duty Managers' and add 'MR Incident Report' after 'MR Senior Managers'
                groupsQuery = groupsQuery.Remove(0, 1);
                int strLength = groupsQuery.Length;
                groupsQuery = groupsQuery.Remove(strLength - 3, 3); // delete the "', " string at the end of the string variable
            }

            return groupsQuery;
        }
    }

    public static string DisplayName
    {
        get
        {
            if (HttpContext.Current.Session["UCDisplayName"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["UCDisplayName"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["UCDisplayName"] = value;
        }
    }

    public static string Username
    {
        get
        {
            if (HttpContext.Current.Session["UCUsername"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["UCUsername"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["UCUsername"] = value;
        }
    }


    public static string Role
    {
        get
        {
            if (HttpContext.Current.Session["UCRole"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["UCRole"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["UCRole"] = value;
        }
    }

    public static int StaffId // StaffID in Staff table
    {
        get
        {
            if (HttpContext.Current.Session["UCStaffId"] == null)
            {
                return 0;
            }
            else
            {
                return (int)HttpContext.Current.Session["UCStaffId"];
            }
        }
        set
        {
            HttpContext.Current.Session["UCStaffId"] = value;
        }
    }

    public static int StaffNameId // StaffNameID in StaffName table
    {
        get
        {
            if (HttpContext.Current.Session["UCStaffNameId"] == null)
            {
                return 0;
            }
            else
            {
                return (int)HttpContext.Current.Session["UCStaffNameId"];
            }
        }
        set
        {
            HttpContext.Current.Session["UCStaffNameId"] = value;
        }
    }

    public static string Password
    {
        get
        {
            if (HttpContext.Current.Session["UCPassword"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["UCPassword"].ToString();
            }
        }
        set
        {
            HttpContext.Current.Session["UCPassword"] = value;
        }
    }

    public static int BillManager
    {
        get
        {
            if (HttpContext.Current.Session["UCBillManager"] == null)
            {
                return 0;
            }
            else
            {
                return (int)HttpContext.Current.Session["UCBillManager"];
            }
        }
        set
        {
            HttpContext.Current.Session["UCBillManager"] = value;
        }
    }

    public static bool BillManagerFiltered
    {
        get
        {
            if (HttpContext.Current.Session["UCBillManagerFiltered"] == null)
            {
                return false;
            }
            else
            {
                return (bool)HttpContext.Current.Session["UCBillManagerFiltered"];
            }
        }
        set
        {
            HttpContext.Current.Session["UCBillManagerFiltered"] = value;
        }
    }
}
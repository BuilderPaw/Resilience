using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportFunctionSupervisorMr
/// </summary>
public class ReportFunctionSupervisorMr
{
    public ReportFunctionSupervisorMr()
    {

    }

    // MR FunctionSupervisor Report Version 1
    public static string FunctionName
    {
        get
        {
            if (HttpContext.Current.Session["RFSMFunctionName"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMFunctionName"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMFunctionName"] = value;
        }
    }
    public static string NoOfGuests
    {
        get
        {
            if (HttpContext.Current.Session["RFSMNoOfGuests"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMNoOfGuests"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMNoOfGuests"] = value;
        }
    }
    public static string Setup
    {
        get
        {
            if (HttpContext.Current.Session["RFSMSetup"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMSetup"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMSetup"] = value;
        }
    }
    public static string MenuFeed
    {
        get
        {
            if (HttpContext.Current.Session["RFSMMenuFeed"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMMenuFeed"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMMenuFeed"] = value;
        }
    }
    public static string BarFeed
    {
        get
        {
            if (HttpContext.Current.Session["RFSMBarFeed"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMBarFeed"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMBarFeed"] = value;
        }
    }
    public static string StaffIss
    {
        get
        {
            if (HttpContext.Current.Session["RFSMStaffIss"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMStaffIss"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMStaffIss"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RFSMGenComm"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RFSMGenComm"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RFSMGenComm"] = value;
        }
    }
}
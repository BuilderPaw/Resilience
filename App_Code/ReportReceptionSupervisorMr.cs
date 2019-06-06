using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportReceptionSupervisorMr
/// </summary>
public class ReportReceptionSupervisorMr
{
    public ReportReceptionSupervisorMr()
    {

    }

    public static string SignIn
    {
        get
        {
            if (HttpContext.Current.Session["RRSMSignIn"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRSMSignIn"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRSMSignIn"] = value;
        }
    }
    public static string Refusals
    {
        get
        {
            if (HttpContext.Current.Session["RRSMRefusals"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRSMRefusals"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRSMRefusals"] = value;
        }
    }
    public static string Events
    {
        get
        {
            if (HttpContext.Current.Session["RRSMEvents"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRSMEvents"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRSMEvents"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RRSMGenComm"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRSMGenComm"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRSMGenComm"] = value;
        }
    }
}
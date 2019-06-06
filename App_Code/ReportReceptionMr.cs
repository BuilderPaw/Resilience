using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for MR Reception Reports
/// </summary>
public class ReportReceptionMr
{
    public ReportReceptionMr()
    {

    }

    public static string SignIn
    {
        get
        {
            if (HttpContext.Current.Session["RRMSignIn"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRMSignIn"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRMSignIn"] = value;
        }
    }
    public static string Refusals
    {
        get
        {
            if (HttpContext.Current.Session["RRMRefusals"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRMRefusals"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRMRefusals"] = value;
        }
    }
    public static string Events
    {
        get
        {
            if (HttpContext.Current.Session["RRMEvents"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRMEvents"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRMEvents"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RRMGenComm"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRMGenComm"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRMGenComm"] = value;
        }
    }
}
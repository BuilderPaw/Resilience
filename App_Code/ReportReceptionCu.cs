using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportReceptionCu
/// </summary>
public class ReportReceptionCu
{
    public ReportReceptionCu()
    {

    }

    public static string SignIn
    {
        get
        {
            if (HttpContext.Current.Session["RRCSignIn"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRCSignIn"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRCSignIn"] = value;
        }
    }
    public static string Refusals
    {
        get
        {
            if (HttpContext.Current.Session["RRCRefusals"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRCRefusals"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRCRefusals"] = value;
        }
    }
    public static string Events
    {
        get
        {
            if (HttpContext.Current.Session["RRCEvents"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRCEvents"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRCEvents"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RRCGenComm"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RRCGenComm"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RRCGenComm"] = value;
        }
    }
}
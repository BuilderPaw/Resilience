using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportSupervisorMr
/// </summary>
public class ReportSupervisorMr
{
    public ReportSupervisorMr()
    {

    }

    // MR Supervisor Report Version 1
    public static string SignInSlip
    {
        get
        {
            if (HttpContext.Current.Session["RSMSignInSlip"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMSignInSlip"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMSignInSlip"] = value;
        }
    }
    public static string Reception
    {
        get
        {
            if (HttpContext.Current.Session["RSMReception"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMReception"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMReception"] = value;
        }
    }
    public static string Gaming
    {
        get
        {
            if (HttpContext.Current.Session["RSMGaming"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMGaming"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMGaming"] = value;
        }
    }
    public static string Bar
    {
        get
        {
            if (HttpContext.Current.Session["RSMBar"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMBar"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMBar"] = value;
        }
    }
    public static string TabKeno
    {
        get
        {
            if (HttpContext.Current.Session["RSMTabKeno"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMTabKeno"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMTabKeno"] = value;
        }
    }
    public static string HouseKeeping
    {
        get
        {
            if (HttpContext.Current.Session["RSMHouseKeeping"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMHouseKeeping"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMHouseKeeping"] = value;
        }
    }
    public static string Bistro
    {
        get
        {
            if (HttpContext.Current.Session["RSMBistro"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMBistro"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMBistro"] = value;
        }
    }
    public static string FoodHygiene
    {
        get
        {
            if (HttpContext.Current.Session["RSMFoodHygiene"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMFoodHygiene"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMFoodHygiene"] = value;
        }
    }
    public static string Events
    {
        get
        {
            if (HttpContext.Current.Session["RSMEvents"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMEvents"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMEvents"] = value;
        }
    }
    public static string CustomerService
    {
        get
        {
            if (HttpContext.Current.Session["RSMCustomerService"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMCustomerService"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMCustomerService"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RSMGeneralComments"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMGeneralComments"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMGeneralComments"] = value;
        }
    }
    public static string LuckyRewards
    {
        get
        {
            if (HttpContext.Current.Session["RSMLuckyRewards"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMLuckyRewards"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMLuckyRewards"] = value;
        }
    }
    public static string RSA
    {
        get
        {
            if (HttpContext.Current.Session["RSMRSA"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMRSA"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMRSA"] = value;
        }
    }
    public static string AMLCTF
    {
        get
        {
            if (HttpContext.Current.Session["RSMAMLCTF"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RSMAMLCTF"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RSMAMLCTF"] = value;
        }
    }
}
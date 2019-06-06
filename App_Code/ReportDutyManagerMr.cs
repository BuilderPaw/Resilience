using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for MR Duty Manager Reports
/// </summary>
public class ReportDutyManagerMr
{
    public ReportDutyManagerMr()
    {

    }

    // MR Duty Manager Report Version 1
    public static string Sup
    {
        get
        {
            if (HttpContext.Current.Session["RDMMSupervisors"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMSupervisors"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMSupervisors"] = value;
        }
    }
    public static string Whs
    {
        get
        {
            if (HttpContext.Current.Session["RDMMWhs"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMWhs"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMWhs"] = value;
        }
    }
    public static string Cost
    {
        get
        {
            if (HttpContext.Current.Session["RDMMCost"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMCost"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMCost"] = value;
        }
    }
    public static string ClubPres
    {
        get
        {
            if (HttpContext.Current.Session["RDMMClubPres"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMClubPres"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMClubPres"] = value;
        }
    }
    public static string ClubMain
    {
        get
        {
            if (HttpContext.Current.Session["RDMMClubMain"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMClubMain"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMClubMain"] = value;
        }
    }
    public static string Absent
    {
        get
        {
            if (HttpContext.Current.Session["RDMMAbsenteeism"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMAbsenteeism"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMAbsenteeism"] = value;
        }
    }
    public static string StaffIssues
    {
        get
        {
            if (HttpContext.Current.Session["RDMMStaffIssues"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMStaffIssues"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMStaffIssues"] = value;
        }
    }
    public static string Gaming
    {
        get
        {
            if (HttpContext.Current.Session["RDMMGaming"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMGaming"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMGaming"] = value;
        }
    }
    public static string KeySec
    {
        get
        {
            if (HttpContext.Current.Session["RDMMKeySec"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMKeySec"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMKeySec"] = value;
        }
    }
    public static string Cameras
    {
        get
        {
            if (HttpContext.Current.Session["RDMMCameras"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMCameras"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMCameras"] = value;
        }
    }
    public static string GenComm
    {
        get
        {
            if (HttpContext.Current.Session["RDMMGeneralComms"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMGeneralComms"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMGeneralComms"] = value;
        }
    }
    public static string LuckyRewards
    {
        get
        {
            if (HttpContext.Current.Session["RDMMLuckyRewards"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMLuckyRewards"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMLuckyRewards"] = value;
        }
    }
    public static string Compliance
    {
        get
        {
            if (HttpContext.Current.Session["RDMMCompliance"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RDMMCompliance"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RDMMCompliance"] = value;
        }
    }
}
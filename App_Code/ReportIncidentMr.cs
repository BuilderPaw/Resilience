using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for MR Incident Reports
/// </summary>
public class ReportIncidentMr
{
    public ReportIncidentMr()
    {

    }

    public static string MemberSince1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince1"] = value;
        }
    }
    public static string MemberSince2
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince2"] = value;
        }
    }
    public static string MemberSince3
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince3"] = value;
        }
    }
    public static string MemberSince4
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince4"] = value;
        }
    }
    public static string MemberSince5
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberSince5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMemberSince5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberSince5"] = value;
        }
    }

    public static string ViewPlayerId1
    {
        get
        {
            if (HttpContext.Current.Session["RIMViewPlayerId1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMViewPlayerId1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMViewPlayerId1"] = value;
        }
    }

    public static string ViewPlayerId2
    {
        get
        {
            if (HttpContext.Current.Session["RIMViewPlayerId2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMViewPlayerId2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMViewPlayerId2"] = value;
        }
    }

    public static string ViewPlayerId3
    {
        get
        {
            if (HttpContext.Current.Session["RIMViewPlayerId3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMViewPlayerId3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMViewPlayerId3"] = value;
        }
    }

    public static string ViewPlayerId4
    {
        get
        {
            if (HttpContext.Current.Session["RIMViewPlayerId4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMViewPlayerId4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMViewPlayerId4"] = value;
        }
    }

    public static string ViewPlayerId5
    {
        get
        {
            if (HttpContext.Current.Session["RIMViewPlayerId5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMViewPlayerId5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMViewPlayerId5"] = value;
        }
    }

    public static string PlayerId1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPlayerId1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPlayerId1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPlayerId1"] = value;
        }
    }

    public static string PlayerId2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPlayerId2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPlayerId2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPlayerId2"] = value;
        }
    }

    public static string PlayerId3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPlayerId3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPlayerId3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPlayerId3"] = value;
        }
    }

    public static string PlayerId4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPlayerId4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPlayerId4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPlayerId4"] = value;
        }
    }

    public static string PlayerId5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPlayerId5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPlayerId5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPlayerId5"] = value;
        }
    }

    public static byte[] HumanBody1
    {
        get
        {
            if (HttpContext.Current.Session["RIMHumanBody1"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMHumanBody1"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHumanBody1"] = value;
        }
    }

    public static byte[] HumanBody2
    {
        get
        {
            if (HttpContext.Current.Session["RIMHumanBody2"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMHumanBody2"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHumanBody2"] = value;
        }
    }

    public static byte[] HumanBody3
    {
        get
        {
            if (HttpContext.Current.Session["RIMHumanBody3"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMHumanBody3"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHumanBody3"] = value;
        }
    }

    public static byte[] HumanBody4
    {
        get
        {
            if (HttpContext.Current.Session["RIMHumanBody4"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMHumanBody4"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHumanBody4"] = value;
        }
    }

    public static byte[] HumanBody5
    {
        get
        {
            if (HttpContext.Current.Session["RIMHumanBody5"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMHumanBody5"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHumanBody5"] = value;
        }
    }

    public static string Image1
    {
        get
        {
            if (HttpContext.Current.Session["RIMImage1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMImage1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMImage1"] = value;
        }
    }
    public static string Image2
    {
        get
        {
            if (HttpContext.Current.Session["RIMImage2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMImage2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMImage2"] = value;
        }
    }
    public static string Image3
    {
        get
        {
            if (HttpContext.Current.Session["RIMImage3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMImage3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMImage3"] = value;
        }
    }
    public static string Image4
    {
        get
        {
            if (HttpContext.Current.Session["RIMImage4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMImage4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMImage4"] = value;
        }
    }
    public static string Image5
    {
        get
        {
            if (HttpContext.Current.Session["RIMImage5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMImage5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMImage5"] = value;
        }
    }

    public static string LastErrorMsg
    {
        get
        {
            if (HttpContext.Current.Session["RIMLastErrorMsg"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RIMLastErrorMsg"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLastErrorMsg"] = value;
        }
    }

    public static string TxtTimeH
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtTimeH"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtTimeH"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtTimeH"] = value;
        }
    }
    public static string TxtTimeM
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtTimeM"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtTimeM"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtTimeM"] = value;
        }
    }
    public static string TxtTimeTC
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtTimeTC"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtTimeTC"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtTimeTC"] = value;
        }
    }
    public static string TxtCamSTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH1"] = value;
        }
    }
    public static string TxtCamSTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM1"] = value;
        }
    }
    public static string TxtCamSTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC1"] = value;
        }
    }
    public static string TxtCamETimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH1"] = value;
        }
    }
    public static string TxtCamETimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM1"] = value;
        }
    }
    public static string TxtCamETimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC1"] = value;
        }
    }
    public static string TxtCamSTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH2"] = value;
        }
    }
    public static string TxtCamSTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM2"] = value;
        }
    }
    public static string TxtCamSTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC2"] = value;
        }
    }
    public static string TxtCamETimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH2"] = value;
        }
    }
    public static string TxtCamETimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM2"] = value;
        }
    }
    public static string TxtCamETimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC2"] = value;
        }
    }
    public static string TxtCamSTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH3"] = value;
        }
    }
    public static string TxtCamSTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM3"] = value;
        }
    }
    public static string TxtCamSTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC3"] = value;
        }
    }
    public static string TxtCamETimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH3"] = value;
        }
    }
    public static string TxtCamETimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM3"] = value;
        }
    }
    public static string TxtCamETimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC3"] = value;
        }
    }
    public static string TxtCamSTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH4"] = value;
        }
    }
    public static string TxtCamSTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM4"] = value;
        }
    }
    public static string TxtCamSTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC4"] = value;
        }
    }
    public static string TxtCamETimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH4"] = value;
        }
    }
    public static string TxtCamETimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM4"] = value;
        }
    }
    public static string TxtCamETimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC4"] = value;
        }
    }
    public static string TxtCamSTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH5"] = value;
        }
    }
    public static string TxtCamSTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM5"] = value;
        }
    }
    public static string TxtCamSTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC5"] = value;
        }
    }
    public static string TxtCamETimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH5"] = value;
        }
    }
    public static string TxtCamETimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM5"] = value;
        }
    }
    public static string TxtCamETimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC5"] = value;
        }
    }
    public static string TxtCamSTimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH6"] = value;
        }
    }
    public static string TxtCamSTimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM6"] = value;
        }
    }
    public static string TxtCamSTimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC6"] = value;
        }
    }
    public static string TxtCamETimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH6"] = value;
        }
    }
    public static string TxtCamETimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM6"] = value;
        }
    }
    public static string TxtCamETimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC6"] = value;
        }
    }
    public static string TxtCamSTimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeH7"] = value;
        }
    }
    public static string TxtCamSTimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeM7"] = value;
        }
    }
    public static string TxtCamSTimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamSTimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamSTimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamSTimeTC7"] = value;
        }
    }
    public static string TxtCamETimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeH7"] = value;
        }
    }
    public static string TxtCamETimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeM7"] = value;
        }
    }
    public static string TxtCamETimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtCamETimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtCamETimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtCamETimeTC7"] = value;
        }
    }
    public static string NoOfPerson
    {
        get
        {
            if (HttpContext.Current.Session["RIMNoOfPerson"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RIMNoOfPerson"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMNoOfPerson"] = value;
        }
    }
    public static string TxtPartyType1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPartyType1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPartyType1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPartyType1"] = value;
        }
    }
    public static string TxtPTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeH1"] = value;
        }
    }
    public static string TxtPTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeM1"] = value;
        }
    }
    public static string TxtPTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeTC1"] = value;
        }
    }
    public static string TxtGender1
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtGender1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtGender1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtGender1"] = value;
        }
    }
    public static string TxtPartyType2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPartyType2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPartyType2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPartyType2"] = value;
        }
    }
    public static string TxtPTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeH2"] = value;
        }
    }
    public static string TxtPTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeM2"] = value;
        }
    }
    public static string TxtPTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeTC2"] = value;
        }
    }
    public static string TxtGender2
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtGender2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtGender2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtGender2"] = value;
        }
    }
    public static string TxtPartyType3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPartyType3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPartyType3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPartyType3"] = value;
        }
    }
    public static string TxtPTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeH3"] = value;
        }
    }
    public static string TxtPTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeM3"] = value;
        }
    }
    public static string TxtPTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeTC3"] = value;
        }
    }
    public static string TxtGender3
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtGender3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtGender3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtGender3"] = value;
        }
    }
    public static string TxtPartyType4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPartyType4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPartyType4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPartyType4"] = value;
        }
    }
    public static string TxtPTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeH4"] = value;
        }
    }
    public static string TxtPTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeM4"] = value;
        }
    }
    public static string TxtPTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeTC4"] = value;
        }
    }
    public static string TxtGender4
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtGender4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtGender4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtGender4"] = value;
        }
    }
    public static string TxtPartyType5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPartyType5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPartyType5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPartyType5"] = value;
        }
    }
    public static string TxtPTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeH5"] = value;
        }
    }
    public static string TxtPTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtPTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeM5"] = value;
        }
    }
    public static string TxtPTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtPTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtPTimeTC5"] = value;
        }
    }
    public static string TxtGender5
    {
        get
        {
            if (HttpContext.Current.Session["RIMTxtGender5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTxtGender5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTxtGender5"] = value;
        }
    }

    public static string StaffEmp1
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffEmp1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffEmp1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffEmp1"] = value;
        }
    }
    public static string StaffEmp2
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffEmp2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffEmp2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffEmp2"] = value;
        }
    }
    public static string StaffEmp3
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffEmp3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffEmp3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffEmp3"] = value;
        }
    }
    public static string StaffEmp4
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffEmp4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffEmp4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffEmp4"] = value;
        }
    }
    public static string StaffEmp5
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffEmp5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffEmp5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffEmp5"] = value;
        }
    }
    public static string ActionTakenOther
    {
        get
        {
            if (HttpContext.Current.Session["RIMActionTakenOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMActionTakenOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMActionTakenOther"] = value;
        }
    }
    public static string HappenedOther
    {
        get
        {
            if (HttpContext.Current.Session["RIMHappenedOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHappenedOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHappenedOther"] = value;
        }
    }
    public static string HappenedSerious
    {
        get
        {
            if (HttpContext.Current.Session["RIMHappenedSerious"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHappenedSerious"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHappenedSerious"] = value;
        }
    }
    public static string HappenedRefuseEntry
    {
        get
        {
            if (HttpContext.Current.Session["RIMHappenedRefuseEntry"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHappenedRefuseEntry"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHappenedRefuseEntry"] = value;
        }
    }
    public static string HappenedAskedLeave
    {
        get
        {
            if (HttpContext.Current.Session["RIMHappenedAskedLeave"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHappenedAskedLeave"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHappenedAskedLeave"] = value;
        }
    }
    public static string Allegation
    {
        get
        {
            if (HttpContext.Current.Session["RIMAllegation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAllegation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAllegation"] = value;
        }
    }
    public static string VDOB1
    {
        get
        {
            if (HttpContext.Current.Session["RIMVDOB1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVDOB1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVDOB1"] = value;
        }
    }
    public static string MDOB1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMDOB1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMDOB1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMDOB1"] = value;
        }
    }
    public static string VAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RIMVAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVAddress1"] = value;
        }
    }
    public static string MAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMAddress1"] = value;
        }
    }
    public static string VProofID1
    {
        get
        {
            if (HttpContext.Current.Session["RIMVProofID1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVProofID1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVProofID1"] = value;
        }
    }
    public static string StaffAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffAddress1"] = value;
        }
    }
    public static string VDOB2
    {
        get
        {
            if (HttpContext.Current.Session["RIMVDOB2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVDOB2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVDOB2"] = value;
        }
    }
    public static string MDOB2
    {
        get
        {
            if (HttpContext.Current.Session["RIMMDOB2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMDOB2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMDOB2"] = value;
        }
    }
    public static string VAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RIMVAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVAddress2"] = value;
        }
    }
    public static string MAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RIMMAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMAddress2"] = value;
        }
    }
    public static string VProofID2
    {
        get
        {
            if (HttpContext.Current.Session["RIMVProofID2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVProofID2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVProofID2"] = value;
        }
    }
    public static string StaffAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffAddress2"] = value;
        }
    }
    public static string VDOB3
    {
        get
        {
            if (HttpContext.Current.Session["RIMVDOB3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVDOB3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVDOB3"] = value;
        }
    }
    public static string MDOB3
    {
        get
        {
            if (HttpContext.Current.Session["RIMMDOB3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMDOB3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMDOB3"] = value;
        }
    }
    public static string VAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RIMVAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVAddress3"] = value;
        }
    }
    public static string MAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RIMMAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMAddress3"] = value;
        }
    }
    public static string VProofID3
    {
        get
        {
            if (HttpContext.Current.Session["RIMVProofID3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVProofID3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVProofID3"] = value;
        }
    }
    public static string StaffAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffAddress3"] = value;
        }
    }
    public static string VDOB4
    {
        get
        {
            if (HttpContext.Current.Session["RIMVDOB4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVDOB4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVDOB4"] = value;
        }
    }
    public static string MDOB4
    {
        get
        {
            if (HttpContext.Current.Session["RIMMDOB4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMDOB4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMDOB4"] = value;
        }
    }
    public static string VAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RIMVAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVAddress4"] = value;
        }
    }
    public static string MAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RIMMAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMAddress4"] = value;
        }
    }
    public static string VProofID4
    {
        get
        {
            if (HttpContext.Current.Session["RIMVProofID4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVProofID4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVProofID4"] = value;
        }
    }
    public static string StaffAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffAddress4"] = value;
        }
    }
    public static string VDOB5
    {
        get
        {
            if (HttpContext.Current.Session["RIMVDOB5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVDOB5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVDOB5"] = value;
        }
    }
    public static string MDOB5
    {
        get
        {
            if (HttpContext.Current.Session["RIMMDOB5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMDOB5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMDOB5"] = value;
        }
    }
    public static string VAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RIMVAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVAddress5"] = value;
        }
    }
    public static string MAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RIMMAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMAddress5"] = value;
        }
    }
    public static string VProofID5
    {
        get
        {
            if (HttpContext.Current.Session["RIMVProofID5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMVProofID5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMVProofID5"] = value;
        }
    }
    public static string StaffAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RIMStaffAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMStaffAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMStaffAddress5"] = value;
        }
    }
    public static string First1
    {
        get
        {
            if (HttpContext.Current.Session["RIMFirst1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFirst1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFirst1"] = value;
        }
    }
    public static string Last1
    {
        get
        {
            if (HttpContext.Current.Session["RIMLast1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLast1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLast1"] = value;
        }
    }
    public static string Contact1
    {
        get
        {
            if (HttpContext.Current.Session["RIMContact1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMContact1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMContact1"] = value;
        }
    }
    public static string Type1
    {
        get
        {
            if (HttpContext.Current.Session["RIMType1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMType1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMType1"] = value;
        }
    }
    public static string Witness1
    {
        get
        {
            if (HttpContext.Current.Session["RIMWitness1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWitness1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWitness1"] = value;
        }
    }
    public static string Member1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMember1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMember1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMember1"] = value;
        }
    }
    public static string SignInSlip1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInSlip1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInSlip1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInSlip1"] = value;
        }
    }
    public static string PDate1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPDate1"] = value;
        }
    }
    public static string Card1
    {
        get
        {
            if (HttpContext.Current.Session["RIMCard1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCard1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCard1"] = value;
        }
    }
    public static string SignInBy1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInBy1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInBy1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInBy1"] = value;
        }
    }
    public static string PTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeH1"] = value;
        }
    }
    public static string PTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeM1"] = value;
        }
    }
    public static string PTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeTC1"] = value;
        }
    }
    public static string Age1
    {
        get
        {
            if (HttpContext.Current.Session["RIMAge1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAge1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAge1"] = value;
        }
    }
    public static string AgeGroup1
    {
        get
        {
            if (HttpContext.Current.Session["RIMAgeGroup1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAgeGroup1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAgeGroup1"] = value;
        }
    }
    public static string Weight1
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeight1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeight1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeight1"] = value;
        }
    }
    public static string Height1
    {
        get
        {
            if (HttpContext.Current.Session["RIMHeight1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHeight1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHeight1"] = value;
        }
    }
    public static string Hair1
    {
        get
        {
            if (HttpContext.Current.Session["RIMHair1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHair1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHair1"] = value;
        }
    }
    public static string ClothingTop1
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingTop1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingTop1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingTop1"] = value;
        }
    }
    public static string ClothingBottom1
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingBottom1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingBottom1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingBottom1"] = value;
        }
    }
    public static string Shoes1
    {
        get
        {
            if (HttpContext.Current.Session["RIMShoes1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMShoes1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMShoes1"] = value;
        }
    }
    public static string Weapon1
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeapon1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeapon1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeapon1"] = value;
        }
    }
    public static string Gender1
    {
        get
        {
            if (HttpContext.Current.Session["RIMGender1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMGender1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMGender1"] = value;
        }
    }
    public static string DistFeat1
    {
        get
        {
            if (HttpContext.Current.Session["RIMDistFeat1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDistFeat1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDistFeat1"] = value;
        }
    }
    public static string InjuryDesc1
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryDesc1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryDesc1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryDesc1"] = value;
        }
    }
    public static string InjuryCause1
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryCause1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryCause1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryCause1"] = value;
        }
    }
    public static string InjuryComm1
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryComm1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryComm1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryComm1"] = value;
        }
    }
    public static string First2
    {
        get
        {
            if (HttpContext.Current.Session["RIMFirst2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFirst2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFirst2"] = value;
        }
    }
    public static string Last2
    {
        get
        {
            if (HttpContext.Current.Session["RIMLast2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLast2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLast2"] = value;
        }
    }
    public static string Contact2
    {
        get
        {
            if (HttpContext.Current.Session["RIMContact2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMContact2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMContact2"] = value;
        }
    }
    public static string Type2
    {
        get
        {
            if (HttpContext.Current.Session["RIMType2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMType2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMType2"] = value;
        }
    }
    public static string Witness2
    {
        get
        {
            if (HttpContext.Current.Session["RIMWitness2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWitness2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWitness2"] = value;
        }
    }
    public static string Member2
    {
        get
        {
            if (HttpContext.Current.Session["RIMMember2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMember2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMember2"] = value;
        }
    }
    public static string SignInSlip2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInSlip2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInSlip2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInSlip2"] = value;
        }
    }
    public static string PDate2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPDate2"] = value;
        }
    }
    public static string Card2
    {
        get
        {
            if (HttpContext.Current.Session["RIMCard2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCard2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCard2"] = value;
        }
    }
    public static string SignInBy2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInBy2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInBy2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInBy2"] = value;
        }
    }
    public static string PTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeH2"] = value;
        }
    }
    public static string PTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeM2"] = value;
        }
    }
    public static string PTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeTC2"] = value;
        }
    }
    public static string Age2
    {
        get
        {
            if (HttpContext.Current.Session["RIMAge2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAge2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAge2"] = value;
        }
    }
    public static string AgeGroup2
    {
        get
        {
            if (HttpContext.Current.Session["RIMAgeGroup2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAgeGroup2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAgeGroup2"] = value;
        }
    }
    public static string Weight2
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeight2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeight2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeight2"] = value;
        }
    }
    public static string Height2
    {
        get
        {
            if (HttpContext.Current.Session["RIMHeight2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHeight2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHeight2"] = value;
        }
    }
    public static string Hair2
    {
        get
        {
            if (HttpContext.Current.Session["RIMHair2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHair2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHair2"] = value;
        }
    }
    public static string ClothingTop2
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingTop2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingTop2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingTop2"] = value;
        }
    }
    public static string ClothingBottom2
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingBottom2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingBottom2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingBottom2"] = value;
        }
    }
    public static string Shoes2
    {
        get
        {
            if (HttpContext.Current.Session["RIMShoes2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMShoes2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMShoes2"] = value;
        }
    }
    public static string Weapon2
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeapon2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeapon2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeapon2"] = value;
        }
    }
    public static string Gender2
    {
        get
        {
            if (HttpContext.Current.Session["RIMGender2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMGender2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMGender2"] = value;
        }
    }
    public static string DistFeat2
    {
        get
        {
            if (HttpContext.Current.Session["RIMDistFeat2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDistFeat2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDistFeat2"] = value;
        }
    }
    public static string InjuryDesc2
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryDesc2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryDesc2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryDesc2"] = value;
        }
    }
    public static string InjuryCause2
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryCause2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryCause2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryCause2"] = value;
        }
    }
    public static string InjuryComm2
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryComm2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryComm2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryComm2"] = value;
        }
    }
    public static string First3
    {
        get
        {
            if (HttpContext.Current.Session["RIMFirst3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFirst3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFirst3"] = value;
        }
    }
    public static string Last3
    {
        get
        {
            if (HttpContext.Current.Session["RIMLast3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLast3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLast3"] = value;
        }
    }
    public static string Contact3
    {
        get
        {
            if (HttpContext.Current.Session["RIMContact3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMContact3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMContact3"] = value;
        }
    }
    public static string Type3
    {
        get
        {
            if (HttpContext.Current.Session["RIMType3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMType3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMType3"] = value;
        }
    }
    public static string Witness3
    {
        get
        {
            if (HttpContext.Current.Session["RIMWitness3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWitness3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWitness3"] = value;
        }
    }
    public static string Member3
    {
        get
        {
            if (HttpContext.Current.Session["RIMMember3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMember3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMember3"] = value;
        }
    }
    public static string SignInSlip3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInSlip3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInSlip3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInSlip3"] = value;
        }
    }
    public static string PDate3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPDate3"] = value;
        }
    }
    public static string Card3
    {
        get
        {
            if (HttpContext.Current.Session["RIMCard3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCard3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCard3"] = value;
        }
    }
    public static string SignInBy3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInBy3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInBy3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInBy3"] = value;
        }
    }
    public static string PTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeH3"] = value;
        }
    }
    public static string PTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeM3"] = value;
        }
    }
    public static string PTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeTC3"] = value;
        }
    }
    public static string Age3
    {
        get
        {
            if (HttpContext.Current.Session["RIMAge3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAge3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAge3"] = value;
        }
    }
    public static string AgeGroup3
    {
        get
        {
            if (HttpContext.Current.Session["RIMAgeGroup3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAgeGroup3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAgeGroup3"] = value;
        }
    }
    public static string Weight3
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeight3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeight3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeight3"] = value;
        }
    }
    public static string Height3
    {
        get
        {
            if (HttpContext.Current.Session["RIMHeight3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHeight3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHeight3"] = value;
        }
    }
    public static string Hair3
    {
        get
        {
            if (HttpContext.Current.Session["RIMHair3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHair3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHair3"] = value;
        }
    }
    public static string ClothingTop3
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingTop3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingTop3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingTop3"] = value;
        }
    }
    public static string ClothingBottom3
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingBottom3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingBottom3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingBottom3"] = value;
        }
    }
    public static string Shoes3
    {
        get
        {
            if (HttpContext.Current.Session["RIMShoes3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMShoes3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMShoes3"] = value;
        }
    }
    public static string Weapon3
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeapon3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeapon3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeapon3"] = value;
        }
    }
    public static string Gender3
    {
        get
        {
            if (HttpContext.Current.Session["RIMGender3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMGender3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMGender3"] = value;
        }
    }
    public static string DistFeat3
    {
        get
        {
            if (HttpContext.Current.Session["RIMDistFeat3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDistFeat3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDistFeat3"] = value;
        }
    }
    public static string InjuryDesc3
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryDesc3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryDesc3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryDesc3"] = value;
        }
    }
    public static string InjuryCause3
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryCause3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryCause3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryCause3"] = value;
        }
    }
    public static string InjuryComm3
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryComm3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryComm3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryComm3"] = value;
        }
    }
    public static string First4
    {
        get
        {
            if (HttpContext.Current.Session["RIMFirst4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFirst4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFirst4"] = value;
        }
    }
    public static string Last4
    {
        get
        {
            if (HttpContext.Current.Session["RIMLast4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLast4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLast4"] = value;
        }
    }
    public static string Contact4
    {
        get
        {
            if (HttpContext.Current.Session["RIMContact4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMContact4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMContact4"] = value;
        }
    }
    public static string Type4
    {
        get
        {
            if (HttpContext.Current.Session["RIMType4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMType4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMType4"] = value;
        }
    }
    public static string Witness4
    {
        get
        {
            if (HttpContext.Current.Session["RIMWitness4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWitness4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWitness4"] = value;
        }
    }
    public static string Member4
    {
        get
        {
            if (HttpContext.Current.Session["RIMMember4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMember4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMember4"] = value;
        }
    }
    public static string SignInSlip4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInSlip4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInSlip4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInSlip4"] = value;
        }
    }
    public static string PDate4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPDate4"] = value;
        }
    }
    public static string Card4
    {
        get
        {
            if (HttpContext.Current.Session["RIMCard4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCard4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCard4"] = value;
        }
    }
    public static string SignInBy4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInBy4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInBy4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInBy4"] = value;
        }
    }
    public static string PTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeH4"] = value;
        }
    }
    public static string PTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeM4"] = value;
        }
    }
    public static string PTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeTC4"] = value;
        }
    }
    public static string Age4
    {
        get
        {
            if (HttpContext.Current.Session["RIMAge4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAge4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAge4"] = value;
        }
    }
    public static string AgeGroup4
    {
        get
        {
            if (HttpContext.Current.Session["RIMAgeGroup4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAgeGroup4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAgeGroup4"] = value;
        }
    }
    public static string Weight4
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeight4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeight4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeight4"] = value;
        }
    }
    public static string Height4
    {
        get
        {
            if (HttpContext.Current.Session["RIMHeight4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHeight4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHeight4"] = value;
        }
    }
    public static string Hair4
    {
        get
        {
            if (HttpContext.Current.Session["RIMHair4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHair4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHair4"] = value;
        }
    }
    public static string ClothingTop4
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingTop4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingTop4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingTop4"] = value;
        }
    }
    public static string ClothingBottom4
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingBottom4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingBottom4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingBottom4"] = value;
        }
    }
    public static string Shoes4
    {
        get
        {
            if (HttpContext.Current.Session["RIMShoes4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMShoes4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMShoes4"] = value;
        }
    }
    public static string Weapon4
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeapon4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeapon4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeapon4"] = value;
        }
    }
    public static string Gender4
    {
        get
        {
            if (HttpContext.Current.Session["RIMGender4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMGender4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMGender4"] = value;
        }
    }
    public static string DistFeat4
    {
        get
        {
            if (HttpContext.Current.Session["RIMDistFeat4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDistFeat4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDistFeat4"] = value;
        }
    }
    public static string InjuryDesc4
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryDesc4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryDesc4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryDesc4"] = value;
        }
    }
    public static string InjuryCause4
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryCause4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryCause4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryCause4"] = value;
        }
    }
    public static string InjuryComm4
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryComm4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryComm4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryComm4"] = value;
        }
    }
    public static string First5
    {
        get
        {
            if (HttpContext.Current.Session["RIMFirst5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFirst5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFirst5"] = value;
        }
    }
    public static string Last5
    {
        get
        {
            if (HttpContext.Current.Session["RIMLast5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLast5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLast5"] = value;
        }
    }
    public static string Contact5
    {
        get
        {
            if (HttpContext.Current.Session["RIMContact5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMContact5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMContact5"] = value;
        }
    }
    public static string Type5
    {
        get
        {
            if (HttpContext.Current.Session["RIMType5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMType5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMType5"] = value;
        }
    }
    public static string Witness5
    {
        get
        {
            if (HttpContext.Current.Session["RIMWitness5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWitness5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWitness5"] = value;
        }
    }
    public static string Member5
    {
        get
        {
            if (HttpContext.Current.Session["RIMMember5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMember5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMember5"] = value;
        }
    }
    public static string SignInSlip5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInSlip5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInSlip5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInSlip5"] = value;
        }
    }
    public static string PDate5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPDate5"] = value;
        }
    }
    public static string Card5
    {
        get
        {
            if (HttpContext.Current.Session["RIMCard5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCard5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCard5"] = value;
        }
    }
    public static string SignInBy5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSignInBy5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSignInBy5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSignInBy5"] = value;
        }
    }
    public static string PTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeH5"] = value;
        }
    }
    public static string PTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeM5"] = value;
        }
    }
    public static string PTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMPTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPTimeTC5"] = value;
        }
    }
    public static string Age5
    {
        get
        {
            if (HttpContext.Current.Session["RIMAge5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAge5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAge5"] = value;
        }
    }
    public static string AgeGroup5
    {
        get
        {
            if (HttpContext.Current.Session["RIMAgeGroup5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAgeGroup5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAgeGroup5"] = value;
        }
    }
    public static string Weight5
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeight5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeight5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeight5"] = value;
        }
    }
    public static string Height5
    {
        get
        {
            if (HttpContext.Current.Session["RIMHeight5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHeight5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHeight5"] = value;
        }
    }
    public static string Hair5
    {
        get
        {
            if (HttpContext.Current.Session["RIMHair5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHair5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHair5"] = value;
        }
    }
    public static string ClothingTop5
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingTop5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingTop5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingTop5"] = value;
        }
    }
    public static string ClothingBottom5
    {
        get
        {
            if (HttpContext.Current.Session["RIMClothingBottom5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMClothingBottom5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMClothingBottom5"] = value;
        }
    }
    public static string Shoes5
    {
        get
        {
            if (HttpContext.Current.Session["RIMShoes5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMShoes5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMShoes5"] = value;
        }
    }
    public static string Weapon5
    {
        get
        {
            if (HttpContext.Current.Session["RIMWeapon5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWeapon5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWeapon5"] = value;
        }
    }
    public static string Gender5
    {
        get
        {
            if (HttpContext.Current.Session["RIMGender5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMGender5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMGender5"] = value;
        }
    }
    public static string DistFeat5
    {
        get
        {
            if (HttpContext.Current.Session["RIMDistFeat5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDistFeat5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDistFeat5"] = value;
        }
    }
    public static string InjuryDesc5
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryDesc5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryDesc5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryDesc5"] = value;
        }
    }
    public static string InjuryCause5
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryCause5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryCause5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryCause5"] = value;
        }
    }
    public static string InjuryComm5
    {
        get
        {
            if (HttpContext.Current.Session["RIMInjuryComm5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMInjuryComm5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMInjuryComm5"] = value;
        }
    }
    public static string Date
    {
        get
        {
            if (HttpContext.Current.Session["RIMDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDate"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDate"] = value;
        }
    }
    public static string Hour
    {
        get
        {
            if (HttpContext.Current.Session["RIMHour"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMHour"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMHour"] = value;
        }
    }
    public static string Minute
    {
        get
        {
            if (HttpContext.Current.Session["RIMMinute"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMMinute"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMinute"] = value;
        }
    }
    public static string TC
    {
        get
        {
            if (HttpContext.Current.Session["RIMTC"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMTC"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMTC"] = value;
        }
    }
    public static string Location
    {
        get
        {
            if (HttpContext.Current.Session["RIMLocation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLocation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLocation"] = value;
        }
    }
    public static string LocationOther
    {
        get
        {
            if (HttpContext.Current.Session["RIMLocationOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMLocationOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMLocationOther"] = value;
        }
    }
    public static string CamDesc1
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc1"] = value;
        }
    }
    public static string CamRec1
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec1"] = value;
        }
    }
    public static string FilePath1
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath1"] = value;
        }
    }
    public static string SDate1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate1"] = value;
        }
    }
    public static string STimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH1"] = value;
        }
    }
    public static string STimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM1"] = value;
        }
    }
    public static string STimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC1"] = value;
        }
    }
    public static string EDate1
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate1"] = value;
        }
    }
    public static string ETimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH1"] = value;
        }
    }
    public static string ETimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM1"] = value;
        }
    }
    public static string ETimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC1"] = value;
        }
    }
    public static string CamDesc2
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc2"] = value;
        }
    }
    public static string CamRec2
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec2"] = value;
        }
    }
    public static string FilePath2
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath2"] = value;
        }
    }
    public static string SDate2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate2"] = value;
        }
    }
    public static string STimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH2"] = value;
        }
    }
    public static string STimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM2"] = value;
        }
    }
    public static string STimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC2"] = value;
        }
    }
    public static string EDate2
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate2"] = value;
        }
    }
    public static string ETimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH2"] = value;
        }
    }
    public static string ETimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM2"] = value;
        }
    }
    public static string ETimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC2"] = value;
        }
    }
    public static string CamDesc3
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc3"] = value;
        }
    }
    public static string CamRec3
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec3"] = value;
        }
    }
    public static string FilePath3
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath3"] = value;
        }
    }
    public static string SDate3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate3"] = value;
        }
    }
    public static string STimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH3"] = value;
        }
    }
    public static string STimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM3"] = value;
        }
    }
    public static string STimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC3"] = value;
        }
    }
    public static string EDate3
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate3"] = value;
        }
    }
    public static string ETimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH3"] = value;
        }
    }
    public static string ETimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM3"] = value;
        }
    }
    public static string ETimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC3"] = value;
        }
    }
    public static string CamDesc4
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc4"] = value;
        }
    }
    public static string CamRec4
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec4"] = value;
        }
    }
    public static string FilePath4
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath4"] = value;
        }
    }
    public static string SDate4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate4"] = value;
        }
    }
    public static string STimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH4"] = value;
        }
    }
    public static string STimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM4"] = value;
        }
    }
    public static string STimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC4"] = value;
        }
    }
    public static string EDate4
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate4"] = value;
        }
    }
    public static string ETimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH4"] = value;
        }
    }
    public static string ETimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM4"] = value;
        }
    }
    public static string ETimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC4"] = value;
        }
    }
    public static string CamDesc5
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc5"] = value;
        }
    }
    public static string CamRec5
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec5"] = value;
        }
    }
    public static string FilePath5
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath5"] = value;
        }
    }
    public static string SDate5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate5"] = value;
        }
    }
    public static string STimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH5"] = value;
        }
    }
    public static string STimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM5"] = value;
        }
    }
    public static string STimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC5"] = value;
        }
    }
    public static string EDate5
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate5"] = value;
        }
    }
    public static string ETimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH5"] = value;
        }
    }
    public static string ETimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM5"] = value;
        }
    }
    public static string ETimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC5"] = value;
        }
    }
    public static string CamDesc6
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc6"] = value;
        }
    }
    public static string CamRec6
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec6"] = value;
        }
    }
    public static string FilePath6
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath6"] = value;
        }
    }
    public static string SDate6
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate6"] = value;
        }
    }
    public static string STimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH6"] = value;
        }
    }
    public static string STimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM6"] = value;
        }
    }
    public static string STimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC6"] = value;
        }
    }
    public static string EDate6
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate6"] = value;
        }
    }
    public static string ETimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH6"] = value;
        }
    }
    public static string ETimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM6"] = value;
        }
    }
    public static string ETimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC6"] = value;
        }
    }
    public static string CamDesc7
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamDesc7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamDesc7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamDesc7"] = value;
        }
    }
    public static string CamRec7
    {
        get
        {
            if (HttpContext.Current.Session["RIMCamRec7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMCamRec7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMCamRec7"] = value;
        }
    }
    public static string FilePath7
    {
        get
        {
            if (HttpContext.Current.Session["RIMFilePath7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMFilePath7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMFilePath7"] = value;
        }
    }
    public static string SDate7
    {
        get
        {
            if (HttpContext.Current.Session["RIMSDate7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSDate7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSDate7"] = value;
        }
    }
    public static string STimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeH7"] = value;
        }
    }
    public static string STimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeM7"] = value;
        }
    }
    public static string STimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RIMSTimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSTimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSTimeTC7"] = value;
        }
    }
    public static string EDate7
    {
        get
        {
            if (HttpContext.Current.Session["RIMEDate7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMEDate7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMEDate7"] = value;
        }
    }
    public static string ETimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeH7"] = value;
        }
    }
    public static string ETimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeM7"] = value;
        }
    }
    public static string ETimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RIMETimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMETimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMETimeTC7"] = value;
        }
    }
    public static string WhatHappened
    {
        get
        {
            if (HttpContext.Current.Session["RIMWhatHappened"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMWhatHappened"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMWhatHappened"] = value;
        }
    }
    public static string ActionTaken
    {
        get
        {
            if (HttpContext.Current.Session["RIMActionTaken"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMActionTaken"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMActionTaken"] = value;
        }
    }
    public static string Details
    {
        get
        {
            if (HttpContext.Current.Session["RIMDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMDetails"] = value;
        }
    }
    public static string SecurityAttend
    {
        get
        {
            if (HttpContext.Current.Session["RIMSecurityAttend"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSecurityAttend"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSecurityAttend"] = value;
        }
    }
    public static string SecurityName
    {
        get
        {
            if (HttpContext.Current.Session["RIMSecurityName"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMSecurityName"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMSecurityName"] = value;
        }
    }
    public static string PoliceNotified
    {
        get
        {
            if (HttpContext.Current.Session["RIMPoliceNotified"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPoliceNotified"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPoliceNotified"] = value;
        }
    }
    public static string PoliceStation
    {
        get
        {
            if (HttpContext.Current.Session["RIMPoliceStation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPoliceStation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPoliceStation"] = value;
        }
    }
    public static string OfficersName
    {

        get
        {
            if (HttpContext.Current.Session["RIMOfficersName"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMOfficersName"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMOfficersName"] = value;
        }
    }
    public static string PoliceAction
    {
        get
        {
            if (HttpContext.Current.Session["RIMPoliceAction"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMPoliceAction"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMPoliceAction"] = value;
        }
    }

    public static byte[] MemberPhoto1
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberPhoto1"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMMemberPhoto1"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberPhoto1"] = value;
        }
    }

    public static byte[] MemberPhoto2
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberPhoto2"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMMemberPhoto2"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberPhoto2"] = value;
        }
    }

    public static byte[] MemberPhoto3
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberPhoto3"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMMemberPhoto3"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberPhoto3"] = value;
        }
    }

    public static byte[] MemberPhoto4
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberPhoto4"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMMemberPhoto4"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberPhoto4"] = value;
        }
    }

    public static byte[] MemberPhoto5
    {
        get
        {
            if (HttpContext.Current.Session["RIMMemberPhoto5"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RIMMemberPhoto5"];
            }
        }
        set
        {
            HttpContext.Current.Session["RIMMemberPhoto5"] = value;
        }
    }
    public static string Alias1
    {
        get
        {
            if (HttpContext.Current.Session["RIMAlias1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAlias1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAlias1"] = value;
        }
    }
    public static string Alias2
    {
        get
        {
            if (HttpContext.Current.Session["RIMAlias2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAlias2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAlias2"] = value;
        }
    }
    public static string Alias3
    {
        get
        {
            if (HttpContext.Current.Session["RIMAlias3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAlias3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAlias3"] = value;
        }
    }
    public static string Alias4
    {
        get
        {
            if (HttpContext.Current.Session["RIMAlias4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAlias4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAlias4"] = value;
        }
    }
    public static string Alias5
    {
        get
        {
            if (HttpContext.Current.Session["RIMAlias5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RIMAlias5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RIMAlias5"] = value;
        }
    }
}
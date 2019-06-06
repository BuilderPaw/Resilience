using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Static Properties for CU Incident Reports
/// </summary>
public class ReportIncidentCu
{
    public ReportIncidentCu()
    {

    }

    public static string MemberSince1
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberSince1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMemberSince1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberSince1"] = value;
        }
    }
    public static string MemberSince2
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberSince2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMemberSince2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberSince2"] = value;
        }
    }
    public static string MemberSince3
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberSince3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMemberSince3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberSince3"] = value;
        }
    }
    public static string MemberSince4
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberSince4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMemberSince4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberSince4"] = value;
        }
    }
    public static string MemberSince5
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberSince5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMemberSince5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberSince5"] = value;
        }
    }

    public static string ViewPlayerId1
    {
        get
        {
            if (HttpContext.Current.Session["RICViewPlayerId1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICViewPlayerId1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICViewPlayerId1"] = value;
        }
    }

    public static string ViewPlayerId2
    {
        get
        {
            if (HttpContext.Current.Session["RICViewPlayerId2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICViewPlayerId2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICViewPlayerId2"] = value;
        }
    }

    public static string ViewPlayerId3
    {
        get
        {
            if (HttpContext.Current.Session["RICViewPlayerId3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICViewPlayerId3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICViewPlayerId3"] = value;
        }
    }

    public static string ViewPlayerId4
    {
        get
        {
            if (HttpContext.Current.Session["RICViewPlayerId4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICViewPlayerId4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICViewPlayerId4"] = value;
        }
    }

    public static string ViewPlayerId5
    {
        get
        {
            if (HttpContext.Current.Session["RICViewPlayerId5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICViewPlayerId5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICViewPlayerId5"] = value;
        }
    }

    public static string PlayerId1
    {
        get
        {
            if (HttpContext.Current.Session["RICPlayerId1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPlayerId1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPlayerId1"] = value;
        }
    }

    public static string PlayerId2
    {
        get
        {
            if (HttpContext.Current.Session["RICPlayerId2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPlayerId2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPlayerId2"] = value;
        }
    }

    public static string PlayerId3
    {
        get
        {
            if (HttpContext.Current.Session["RICPlayerId3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPlayerId3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPlayerId3"] = value;
        }
    }

    public static string PlayerId4
    {
        get
        {
            if (HttpContext.Current.Session["RICPlayerId4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPlayerId4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPlayerId4"] = value;
        }
    }

    public static string PlayerId5
    {
        get
        {
            if (HttpContext.Current.Session["RICPlayerId5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPlayerId5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPlayerId5"] = value;
        }
    }

    public static byte[] HumanBody1
    {
        get
        {
            if (HttpContext.Current.Session["RICHumanBody1"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICHumanBody1"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICHumanBody1"] = value;
        }
    }

    public static byte[] HumanBody2
    {
        get
        {
            if (HttpContext.Current.Session["RICHumanBody2"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICHumanBody2"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICHumanBody2"] = value;
        }
    }

    public static byte[] HumanBody3
    {
        get
        {
            if (HttpContext.Current.Session["RICHumanBody3"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICHumanBody3"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICHumanBody3"] = value;
        }
    }

    public static byte[] HumanBody4
    {
        get
        {
            if (HttpContext.Current.Session["RICHumanBody4"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICHumanBody4"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICHumanBody4"] = value;
        }
    }

    public static byte[] HumanBody5
    {
        get
        {
            if (HttpContext.Current.Session["RICHumanBody5"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICHumanBody5"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICHumanBody5"] = value;
        }
    }


    public static string Image1
    {
        get
        {
            if (HttpContext.Current.Session["RICImage1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICImage1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICImage1"] = value;
        }
    }
    public static string Image2
    {
        get
        {
            if (HttpContext.Current.Session["RICImage2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICImage2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICImage2"] = value;
        }
    }
    public static string Image3
    {
        get
        {
            if (HttpContext.Current.Session["RICImage3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICImage3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICImage3"] = value;
        }
    }
    public static string Image4
    {
        get
        {
            if (HttpContext.Current.Session["RICImage4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICImage4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICImage4"] = value;
        }
    }
    public static string Image5
    {
        get
        {
            if (HttpContext.Current.Session["RICImage5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICImage5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICImage5"] = value;
        }
    }

    public static string LastErrorMsg
    {
        get
        {
            if (HttpContext.Current.Session["RICLastErrorMsg"] == null)
            {
                return " ";
            }
            else
            {
                return HttpContext.Current.Session["RICLastErrorMsg"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLastErrorMsg"] = value;
        }
    }

    public static string TxtTimeH
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtTimeH"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtTimeH"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtTimeH"] = value;
        }
    }
    public static string TxtTimeM
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtTimeM"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtTimeM"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtTimeM"] = value;
        }
    }
    public static string TxtTimeTC
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtTimeTC"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtTimeTC"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtTimeTC"] = value;
        }
    }
    public static string TxtCamSTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH1"] = value;
        }
    }
    public static string TxtCamSTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM1"] = value;
        }
    }
    public static string TxtCamSTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC1"] = value;
        }
    }
    public static string TxtCamETimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH1"] = value;
        }
    }
    public static string TxtCamETimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM1"] = value;
        }
    }
    public static string TxtCamETimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC1"] = value;
        }
    }
    public static string TxtCamSTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH2"] = value;
        }
    }
    public static string TxtCamSTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM2"] = value;
        }
    }
    public static string TxtCamSTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC2"] = value;
        }
    }
    public static string TxtCamETimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH2"] = value;
        }
    }
    public static string TxtCamETimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM2"] = value;
        }
    }
    public static string TxtCamETimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC2"] = value;
        }
    }
    public static string TxtCamSTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH3"] = value;
        }
    }
    public static string TxtCamSTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM3"] = value;
        }
    }
    public static string TxtCamSTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC3"] = value;
        }
    }
    public static string TxtCamETimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH3"] = value;
        }
    }
    public static string TxtCamETimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM3"] = value;
        }
    }
    public static string TxtCamETimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC3"] = value;
        }
    }
    public static string TxtCamSTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH4"] = value;
        }
    }
    public static string TxtCamSTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM4"] = value;
        }
    }
    public static string TxtCamSTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC4"] = value;
        }
    }
    public static string TxtCamETimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH4"] = value;
        }
    }
    public static string TxtCamETimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM4"] = value;
        }
    }
    public static string TxtCamETimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC4"] = value;
        }
    }
    public static string TxtCamSTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH5"] = value;
        }
    }
    public static string TxtCamSTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM5"] = value;
        }
    }
    public static string TxtCamSTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC5"] = value;
        }
    }
    public static string TxtCamETimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH5"] = value;
        }
    }
    public static string TxtCamETimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM5"] = value;
        }
    }
    public static string TxtCamETimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC5"] = value;
        }
    }
    public static string TxtCamSTimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH6"] = value;
        }
    }
    public static string TxtCamSTimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM6"] = value;
        }
    }
    public static string TxtCamSTimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC6"] = value;
        }
    }
    public static string TxtCamETimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH6"] = value;
        }
    }
    public static string TxtCamETimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM6"] = value;
        }
    }
    public static string TxtCamETimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC6"] = value;
        }
    }
    public static string TxtCamSTimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeH7"] = value;
        }
    }
    public static string TxtCamSTimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeM7"] = value;
        }
    }
    public static string TxtCamSTimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamSTimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamSTimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamSTimeTC7"] = value;
        }
    }
    public static string TxtCamETimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeH7"] = value;
        }
    }
    public static string TxtCamETimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeM7"] = value;
        }
    }
    public static string TxtCamETimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtCamETimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtCamETimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtCamETimeTC7"] = value;
        }
    }
    public static string NoOfPerson
    {
        get
        {
            if (HttpContext.Current.Session["RICNoOfPerson"] == null)
            {
                return "0";
            }
            else
            {
                return HttpContext.Current.Session["RICNoOfPerson"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICNoOfPerson"] = value;
        }
    }
    public static string TxtPartyType1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPartyType1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPartyType1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPartyType1"] = value;
        }
    }
    public static string TxtPTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeH1"] = value;
        }
    }
    public static string TxtPTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeM1"] = value;
        }
    }
    public static string TxtPTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeTC1"] = value;
        }
    }
    public static string TxtGender1
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtGender1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtGender1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtGender1"] = value;
        }
    }
    public static string TxtPartyType2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPartyType2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPartyType2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPartyType2"] = value;
        }
    }
    public static string TxtPTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeH2"] = value;
        }
    }
    public static string TxtPTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeM2"] = value;
        }
    }
    public static string TxtPTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeTC2"] = value;
        }
    }
    public static string TxtGender2
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtGender2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtGender2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtGender2"] = value;
        }
    }
    public static string TxtPartyType3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPartyType3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPartyType3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPartyType3"] = value;
        }
    }
    public static string TxtPTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeH3"] = value;
        }
    }
    public static string TxtPTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeM3"] = value;
        }
    }
    public static string TxtPTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeTC3"] = value;
        }
    }
    public static string TxtGender3
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtGender3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtGender3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtGender3"] = value;
        }
    }
    public static string TxtPartyType4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPartyType4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPartyType4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPartyType4"] = value;
        }
    }
    public static string TxtPTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeH4"] = value;
        }
    }
    public static string TxtPTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeM4"] = value;
        }
    }
    public static string TxtPTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeTC4"] = value;
        }
    }
    public static string TxtGender4
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtGender4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtGender4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtGender4"] = value;
        }
    }
    public static string TxtPartyType5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPartyType5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPartyType5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPartyType5"] = value;
        }
    }
    public static string TxtPTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeH5"] = value;
        }
    }
    public static string TxtPTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtPTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeM5"] = value;
        }
    }
    public static string TxtPTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtPTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtPTimeTC5"] = value;
        }
    }
    public static string TxtGender5
    {
        get
        {
            if (HttpContext.Current.Session["RICTxtGender5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTxtGender5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTxtGender5"] = value;
        }
    }

    public static string StaffEmp1
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffEmp1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffEmp1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffEmp1"] = value;
        }
    }
    public static string StaffEmp2
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffEmp2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffEmp2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffEmp2"] = value;
        }
    }
    public static string StaffEmp3
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffEmp3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffEmp3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffEmp3"] = value;
        }
    }
    public static string StaffEmp4
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffEmp4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffEmp4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffEmp4"] = value;
        }
    }
    public static string StaffEmp5
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffEmp5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffEmp5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffEmp5"] = value;
        }
    }
    public static string ActionTakenOther
    {
        get
        {
            if (HttpContext.Current.Session["RICActionTakenOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICActionTakenOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICActionTakenOther"] = value;
        }
    }
    public static string HappenedOther
    {
        get
        {
            if (HttpContext.Current.Session["RICHappenedOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHappenedOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHappenedOther"] = value;
        }
    }
    public static string HappenedSerious
    {
        get
        {
            if (HttpContext.Current.Session["RICHappenedSerious"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHappenedSerious"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHappenedSerious"] = value;
        }
    }
    public static string HappenedRefuseEntry
    {
        get
        {
            if (HttpContext.Current.Session["RICHappenedRefuseEntry"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHappenedRefuseEntry"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHappenedRefuseEntry"] = value;
        }
    }
    public static string HappenedAskedLeave
    {
        get
        {
            if (HttpContext.Current.Session["RICHappenedAskedLeave"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHappenedAskedLeave"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHappenedAskedLeave"] = value;
        }
    }
    public static string Allegation
    {
        get
        {
            if (HttpContext.Current.Session["RICAllegation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAllegation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAllegation"] = value;
        }
    }
    public static string VDOB1
    {
        get
        {
            if (HttpContext.Current.Session["RICVDOB1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVDOB1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVDOB1"] = value;
        }
    }
    public static string MDOB1
    {
        get
        {
            if (HttpContext.Current.Session["RICMDOB1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMDOB1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMDOB1"] = value;
        }
    }
    public static string VAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RICVAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVAddress1"] = value;
        }
    }
    public static string MAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RICMAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMAddress1"] = value;
        }
    }
    public static string VProofID1
    {
        get
        {
            if (HttpContext.Current.Session["RICVProofID1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVProofID1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVProofID1"] = value;
        }
    }
    public static string StaffAddress1
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffAddress1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffAddress1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffAddress1"] = value;
        }
    }
    public static string VDOB2
    {
        get
        {
            if (HttpContext.Current.Session["RICVDOB2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVDOB2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVDOB2"] = value;
        }
    }
    public static string MDOB2
    {
        get
        {
            if (HttpContext.Current.Session["RICMDOB2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMDOB2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMDOB2"] = value;
        }
    }
    public static string VAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RICVAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVAddress2"] = value;
        }
    }
    public static string MAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RICMAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMAddress2"] = value;
        }
    }
    public static string VProofID2
    {
        get
        {
            if (HttpContext.Current.Session["RICVProofID2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVProofID2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVProofID2"] = value;
        }
    }
    public static string StaffAddress2
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffAddress2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffAddress2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffAddress2"] = value;
        }
    }
    public static string VDOB3
    {
        get
        {
            if (HttpContext.Current.Session["RICVDOB3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVDOB3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVDOB3"] = value;
        }
    }
    public static string MDOB3
    {
        get
        {
            if (HttpContext.Current.Session["RICMDOB3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMDOB3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMDOB3"] = value;
        }
    }
    public static string VAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RICVAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVAddress3"] = value;
        }
    }
    public static string MAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RICMAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMAddress3"] = value;
        }
    }
    public static string VProofID3
    {
        get
        {
            if (HttpContext.Current.Session["RICVProofID3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVProofID3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVProofID3"] = value;
        }
    }
    public static string StaffAddress3
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffAddress3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffAddress3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffAddress3"] = value;
        }
    }
    public static string VDOB4
    {
        get
        {
            if (HttpContext.Current.Session["RICVDOB4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVDOB4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVDOB4"] = value;
        }
    }
    public static string MDOB4
    {
        get
        {
            if (HttpContext.Current.Session["RICMDOB4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMDOB4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMDOB4"] = value;
        }
    }
    public static string VAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RICVAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVAddress4"] = value;
        }
    }
    public static string MAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RICMAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMAddress4"] = value;
        }
    }
    public static string VProofID4
    {
        get
        {
            if (HttpContext.Current.Session["RICVProofID4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVProofID4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVProofID4"] = value;
        }
    }
    public static string StaffAddress4
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffAddress4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffAddress4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffAddress4"] = value;
        }
    }
    public static string VDOB5
    {
        get
        {
            if (HttpContext.Current.Session["RICVDOB5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVDOB5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVDOB5"] = value;
        }
    }
    public static string MDOB5
    {
        get
        {
            if (HttpContext.Current.Session["RICMDOB5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMDOB5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMDOB5"] = value;
        }
    }
    public static string VAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RICVAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVAddress5"] = value;
        }
    }
    public static string MAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RICMAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMAddress5"] = value;
        }
    }
    public static string VProofID5
    {
        get
        {
            if (HttpContext.Current.Session["RICVProofID5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICVProofID5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICVProofID5"] = value;
        }
    }
    public static string StaffAddress5
    {
        get
        {
            if (HttpContext.Current.Session["RICStaffAddress5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICStaffAddress5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICStaffAddress5"] = value;
        }
    }
    public static string First1
    {
        get
        {
            if (HttpContext.Current.Session["RICFirst1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFirst1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFirst1"] = value;
        }
    }
    public static string Last1
    {
        get
        {
            if (HttpContext.Current.Session["RICLast1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLast1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLast1"] = value;
        }
    }
    public static string Contact1
    {
        get
        {
            if (HttpContext.Current.Session["RICContact1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICContact1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICContact1"] = value;
        }
    }
    public static string Type1
    {
        get
        {
            if (HttpContext.Current.Session["RICType1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICType1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICType1"] = value;
        }
    }
    public static string Witness1
    {
        get
        {
            if (HttpContext.Current.Session["RICWitness1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWitness1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWitness1"] = value;
        }
    }
    public static string Member1
    {
        get
        {
            if (HttpContext.Current.Session["RICMember1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMember1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMember1"] = value;
        }
    }
    public static string SignInSlip1
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInSlip1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInSlip1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInSlip1"] = value;
        }
    }
    public static string PDate1
    {
        get
        {
            if (HttpContext.Current.Session["RICPDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPDate1"] = value;
        }
    }
    public static string Card1
    {
        get
        {
            if (HttpContext.Current.Session["RICCard1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCard1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCard1"] = value;
        }
    }
    public static string SignInBy1
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInBy1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInBy1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInBy1"] = value;
        }
    }
    public static string PTimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeH1"] = value;
        }
    }
    public static string PTimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeM1"] = value;
        }
    }
    public static string PTimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeTC1"] = value;
        }
    }
    public static string Age1
    {
        get
        {
            if (HttpContext.Current.Session["RICAge1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAge1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAge1"] = value;
        }
    }
    public static string AgeGroup1
    {
        get
        {
            if (HttpContext.Current.Session["RICAgeGroup1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAgeGroup1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAgeGroup1"] = value;
        }
    }
    public static string Weight1
    {
        get
        {
            if (HttpContext.Current.Session["RICWeight1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeight1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeight1"] = value;
        }
    }
    public static string Height1
    {
        get
        {
            if (HttpContext.Current.Session["RICHeight1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHeight1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHeight1"] = value;
        }
    }
    public static string Hair1
    {
        get
        {
            if (HttpContext.Current.Session["RICHair1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHair1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHair1"] = value;
        }
    }
    public static string ClothingTop1
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingTop1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingTop1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingTop1"] = value;
        }
    }
    public static string ClothingBottom1
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingBottom1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingBottom1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingBottom1"] = value;
        }
    }
    public static string Shoes1
    {
        get
        {
            if (HttpContext.Current.Session["RICShoes1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICShoes1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICShoes1"] = value;
        }
    }
    public static string Weapon1
    {
        get
        {
            if (HttpContext.Current.Session["RICWeapon1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeapon1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeapon1"] = value;
        }
    }
    public static string Gender1
    {
        get
        {
            if (HttpContext.Current.Session["RICGender1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICGender1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICGender1"] = value;
        }
    }
    public static string DistFeat1
    {
        get
        {
            if (HttpContext.Current.Session["RICDistFeat1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDistFeat1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDistFeat1"] = value;
        }
    }
    public static string InjuryDesc1
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryDesc1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryDesc1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryDesc1"] = value;
        }
    }
    public static string InjuryCause1
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryCause1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryCause1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryCause1"] = value;
        }
    }
    public static string InjuryComm1
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryComm1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryComm1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryComm1"] = value;
        }
    }
    public static string First2
    {
        get
        {
            if (HttpContext.Current.Session["RICFirst2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFirst2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFirst2"] = value;
        }
    }
    public static string Last2
    {
        get
        {
            if (HttpContext.Current.Session["RICLast2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLast2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLast2"] = value;
        }
    }
    public static string Contact2
    {
        get
        {
            if (HttpContext.Current.Session["RICContact2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICContact2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICContact2"] = value;
        }
    }
    public static string Type2
    {
        get
        {
            if (HttpContext.Current.Session["RICType2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICType2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICType2"] = value;
        }
    }
    public static string Witness2
    {
        get
        {
            if (HttpContext.Current.Session["RICWitness2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWitness2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWitness2"] = value;
        }
    }
    public static string Member2
    {
        get
        {
            if (HttpContext.Current.Session["RICMember2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMember2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMember2"] = value;
        }
    }
    public static string SignInSlip2
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInSlip2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInSlip2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInSlip2"] = value;
        }
    }
    public static string PDate2
    {
        get
        {
            if (HttpContext.Current.Session["RICPDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPDate2"] = value;
        }
    }
    public static string Card2
    {
        get
        {
            if (HttpContext.Current.Session["RICCard2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCard2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCard2"] = value;
        }
    }
    public static string SignInBy2
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInBy2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInBy2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInBy2"] = value;
        }
    }
    public static string PTimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeH2"] = value;
        }
    }
    public static string PTimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeM2"] = value;
        }
    }
    public static string PTimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeTC2"] = value;
        }
    }
    public static string Age2
    {
        get
        {
            if (HttpContext.Current.Session["RICAge2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAge2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAge2"] = value;
        }
    }
    public static string AgeGroup2
    {
        get
        {
            if (HttpContext.Current.Session["RICAgeGroup2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAgeGroup2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAgeGroup2"] = value;
        }
    }
    public static string Weight2
    {
        get
        {
            if (HttpContext.Current.Session["RICWeight2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeight2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeight2"] = value;
        }
    }
    public static string Height2
    {
        get
        {
            if (HttpContext.Current.Session["RICHeight2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHeight2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHeight2"] = value;
        }
    }
    public static string Hair2
    {
        get
        {
            if (HttpContext.Current.Session["RICHair2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHair2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHair2"] = value;
        }
    }
    public static string ClothingTop2
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingTop2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingTop2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingTop2"] = value;
        }
    }
    public static string ClothingBottom2
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingBottom2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingBottom2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingBottom2"] = value;
        }
    }
    public static string Shoes2
    {
        get
        {
            if (HttpContext.Current.Session["RICShoes2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICShoes2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICShoes2"] = value;
        }
    }
    public static string Weapon2
    {
        get
        {
            if (HttpContext.Current.Session["RICWeapon2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeapon2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeapon2"] = value;
        }
    }
    public static string Gender2
    {
        get
        {
            if (HttpContext.Current.Session["RICGender2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICGender2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICGender2"] = value;
        }
    }
    public static string DistFeat2
    {
        get
        {
            if (HttpContext.Current.Session["RICDistFeat2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDistFeat2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDistFeat2"] = value;
        }
    }
    public static string InjuryDesc2
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryDesc2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryDesc2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryDesc2"] = value;
        }
    }
    public static string InjuryCause2
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryCause2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryCause2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryCause2"] = value;
        }
    }
    public static string InjuryComm2
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryComm2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryComm2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryComm2"] = value;
        }
    }
    public static string First3
    {
        get
        {
            if (HttpContext.Current.Session["RICFirst3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFirst3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFirst3"] = value;
        }
    }
    public static string Last3
    {
        get
        {
            if (HttpContext.Current.Session["RICLast3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLast3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLast3"] = value;
        }
    }
    public static string Contact3
    {
        get
        {
            if (HttpContext.Current.Session["RICContact3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICContact3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICContact3"] = value;
        }
    }
    public static string Type3
    {
        get
        {
            if (HttpContext.Current.Session["RICType3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICType3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICType3"] = value;
        }
    }
    public static string Witness3
    {
        get
        {
            if (HttpContext.Current.Session["RICWitness3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWitness3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWitness3"] = value;
        }
    }
    public static string Member3
    {
        get
        {
            if (HttpContext.Current.Session["RICMember3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMember3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMember3"] = value;
        }
    }
    public static string SignInSlip3
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInSlip3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInSlip3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInSlip3"] = value;
        }
    }
    public static string PDate3
    {
        get
        {
            if (HttpContext.Current.Session["RICPDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPDate3"] = value;
        }
    }
    public static string Card3
    {
        get
        {
            if (HttpContext.Current.Session["RICCard3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCard3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCard3"] = value;
        }
    }
    public static string SignInBy3
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInBy3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInBy3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInBy3"] = value;
        }
    }
    public static string PTimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeH3"] = value;
        }
    }
    public static string PTimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeM3"] = value;
        }
    }
    public static string PTimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeTC3"] = value;
        }
    }
    public static string Age3
    {
        get
        {
            if (HttpContext.Current.Session["RICAge3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAge3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAge3"] = value;
        }
    }
    public static string AgeGroup3
    {
        get
        {
            if (HttpContext.Current.Session["RICAgeGroup3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAgeGroup3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAgeGroup3"] = value;
        }
    }
    public static string Weight3
    {
        get
        {
            if (HttpContext.Current.Session["RICWeight3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeight3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeight3"] = value;
        }
    }
    public static string Height3
    {
        get
        {
            if (HttpContext.Current.Session["RICHeight3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHeight3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHeight3"] = value;
        }
    }
    public static string Hair3
    {
        get
        {
            if (HttpContext.Current.Session["RICHair3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHair3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHair3"] = value;
        }
    }
    public static string ClothingTop3
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingTop3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingTop3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingTop3"] = value;
        }
    }
    public static string ClothingBottom3
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingBottom3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingBottom3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingBottom3"] = value;
        }
    }
    public static string Shoes3
    {
        get
        {
            if (HttpContext.Current.Session["RICShoes3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICShoes3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICShoes3"] = value;
        }
    }
    public static string Weapon3
    {
        get
        {
            if (HttpContext.Current.Session["RICWeapon3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeapon3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeapon3"] = value;
        }
    }
    public static string Gender3
    {
        get
        {
            if (HttpContext.Current.Session["RICGender3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICGender3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICGender3"] = value;
        }
    }
    public static string DistFeat3
    {
        get
        {
            if (HttpContext.Current.Session["RICDistFeat3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDistFeat3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDistFeat3"] = value;
        }
    }
    public static string InjuryDesc3
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryDesc3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryDesc3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryDesc3"] = value;
        }
    }
    public static string InjuryCause3
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryCause3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryCause3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryCause3"] = value;
        }
    }
    public static string InjuryComm3
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryComm3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryComm3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryComm3"] = value;
        }
    }
    public static string First4
    {
        get
        {
            if (HttpContext.Current.Session["RICFirst4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFirst4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFirst4"] = value;
        }
    }
    public static string Last4
    {
        get
        {
            if (HttpContext.Current.Session["RICLast4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLast4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLast4"] = value;
        }
    }
    public static string Contact4
    {
        get
        {
            if (HttpContext.Current.Session["RICContact4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICContact4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICContact4"] = value;
        }
    }
    public static string Type4
    {
        get
        {
            if (HttpContext.Current.Session["RICType4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICType4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICType4"] = value;
        }
    }
    public static string Witness4
    {
        get
        {
            if (HttpContext.Current.Session["RICWitness4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWitness4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWitness4"] = value;
        }
    }
    public static string Member4
    {
        get
        {
            if (HttpContext.Current.Session["RICMember4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMember4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMember4"] = value;
        }
    }
    public static string SignInSlip4
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInSlip4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInSlip4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInSlip4"] = value;
        }
    }
    public static string PDate4
    {
        get
        {
            if (HttpContext.Current.Session["RICPDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPDate4"] = value;
        }
    }
    public static string Card4
    {
        get
        {
            if (HttpContext.Current.Session["RICCard4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCard4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCard4"] = value;
        }
    }
    public static string SignInBy4
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInBy4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInBy4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInBy4"] = value;
        }
    }
    public static string PTimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeH4"] = value;
        }
    }
    public static string PTimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeM4"] = value;
        }
    }
    public static string PTimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeTC4"] = value;
        }
    }
    public static string Age4
    {
        get
        {
            if (HttpContext.Current.Session["RICAge4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAge4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAge4"] = value;
        }
    }
    public static string AgeGroup4
    {
        get
        {
            if (HttpContext.Current.Session["RICAgeGroup4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAgeGroup4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAgeGroup4"] = value;
        }
    }
    public static string Weight4
    {
        get
        {
            if (HttpContext.Current.Session["RICWeight4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeight4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeight4"] = value;
        }
    }
    public static string Height4
    {
        get
        {
            if (HttpContext.Current.Session["RICHeight4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHeight4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHeight4"] = value;
        }
    }
    public static string Hair4
    {
        get
        {
            if (HttpContext.Current.Session["RICHair4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHair4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHair4"] = value;
        }
    }
    public static string ClothingTop4
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingTop4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingTop4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingTop4"] = value;
        }
    }
    public static string ClothingBottom4
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingBottom4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingBottom4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingBottom4"] = value;
        }
    }
    public static string Shoes4
    {
        get
        {
            if (HttpContext.Current.Session["RICShoes4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICShoes4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICShoes4"] = value;
        }
    }
    public static string Weapon4
    {
        get
        {
            if (HttpContext.Current.Session["RICWeapon4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeapon4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeapon4"] = value;
        }
    }
    public static string Gender4
    {
        get
        {
            if (HttpContext.Current.Session["RICGender4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICGender4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICGender4"] = value;
        }
    }
    public static string DistFeat4
    {
        get
        {
            if (HttpContext.Current.Session["RICDistFeat4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDistFeat4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDistFeat4"] = value;
        }
    }
    public static string InjuryDesc4
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryDesc4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryDesc4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryDesc4"] = value;
        }
    }
    public static string InjuryCause4
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryCause4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryCause4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryCause4"] = value;
        }
    }
    public static string InjuryComm4
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryComm4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryComm4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryComm4"] = value;
        }
    }
    public static string First5
    {
        get
        {
            if (HttpContext.Current.Session["RICFirst5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFirst5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFirst5"] = value;
        }
    }
    public static string Last5
    {
        get
        {
            if (HttpContext.Current.Session["RICLast5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLast5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLast5"] = value;
        }
    }
    public static string Contact5
    {
        get
        {
            if (HttpContext.Current.Session["RICContact5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICContact5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICContact5"] = value;
        }
    }
    public static string Type5
    {
        get
        {
            if (HttpContext.Current.Session["RICType5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICType5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICType5"] = value;
        }
    }
    public static string Witness5
    {
        get
        {
            if (HttpContext.Current.Session["RICWitness5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWitness5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWitness5"] = value;
        }
    }
    public static string Member5
    {
        get
        {
            if (HttpContext.Current.Session["RICMember5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMember5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMember5"] = value;
        }
    }
    public static string SignInSlip5
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInSlip5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInSlip5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInSlip5"] = value;
        }
    }
    public static string PDate5
    {
        get
        {
            if (HttpContext.Current.Session["RICPDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPDate5"] = value;
        }
    }
    public static string Card5
    {
        get
        {
            if (HttpContext.Current.Session["RICCard5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCard5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCard5"] = value;
        }
    }
    public static string SignInBy5
    {
        get
        {
            if (HttpContext.Current.Session["RICSignInBy5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSignInBy5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSignInBy5"] = value;
        }
    }
    public static string PTimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeH5"] = value;
        }
    }
    public static string PTimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeM5"] = value;
        }
    }
    public static string PTimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICPTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPTimeTC5"] = value;
        }
    }
    public static string Age5
    {
        get
        {
            if (HttpContext.Current.Session["RICAge5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAge5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAge5"] = value;
        }
    }
    public static string AgeGroup5
    {
        get
        {
            if (HttpContext.Current.Session["RICAgeGroup5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAgeGroup5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAgeGroup5"] = value;
        }
    }
    public static string Weight5
    {
        get
        {
            if (HttpContext.Current.Session["RICWeight5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeight5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeight5"] = value;
        }
    }
    public static string Height5
    {
        get
        {
            if (HttpContext.Current.Session["RICHeight5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHeight5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHeight5"] = value;
        }
    }
    public static string Hair5
    {
        get
        {
            if (HttpContext.Current.Session["RICHair5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHair5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHair5"] = value;
        }
    }
    public static string ClothingTop5
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingTop5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingTop5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingTop5"] = value;
        }
    }
    public static string ClothingBottom5
    {
        get
        {
            if (HttpContext.Current.Session["RICClothingBottom5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICClothingBottom5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICClothingBottom5"] = value;
        }
    }
    public static string Shoes5
    {
        get
        {
            if (HttpContext.Current.Session["RICShoes5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICShoes5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICShoes5"] = value;
        }
    }
    public static string Weapon5
    {
        get
        {
            if (HttpContext.Current.Session["RICWeapon5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWeapon5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWeapon5"] = value;
        }
    }
    public static string Gender5
    {
        get
        {
            if (HttpContext.Current.Session["RICGender5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICGender5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICGender5"] = value;
        }
    }
    public static string DistFeat5
    {
        get
        {
            if (HttpContext.Current.Session["RICDistFeat5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDistFeat5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDistFeat5"] = value;
        }
    }
    public static string InjuryDesc5
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryDesc5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryDesc5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryDesc5"] = value;
        }
    }
    public static string InjuryCause5
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryCause5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryCause5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryCause5"] = value;
        }
    }
    public static string InjuryComm5
    {
        get
        {
            if (HttpContext.Current.Session["RICInjuryComm5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICInjuryComm5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICInjuryComm5"] = value;
        }
    }
    public static string Date
    {
        get
        {
            if (HttpContext.Current.Session["RICDate"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDate"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDate"] = value;
        }
    }
    public static string Hour
    {
        get
        {
            if (HttpContext.Current.Session["RICHour"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICHour"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICHour"] = value;
        }
    }
    public static string Minute
    {
        get
        {
            if (HttpContext.Current.Session["RICMinute"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICMinute"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICMinute"] = value;
        }
    }
    public static string TC
    {
        get
        {
            if (HttpContext.Current.Session["RICTC"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICTC"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICTC"] = value;
        }
    }
    public static string Location
    {
        get
        {
            if (HttpContext.Current.Session["RICLocation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLocation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLocation"] = value;
        }
    }
    public static string LocationOther
    {
        get
        {
            if (HttpContext.Current.Session["RICLocationOther"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICLocationOther"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICLocationOther"] = value;
        }
    }
    public static string CamDesc1
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc1"] = value;
        }
    }
    public static string CamRec1
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec1"] = value;
        }
    }
    public static string FilePath1
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath1"] = value;
        }
    }
    public static string SDate1
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate1"] = value;
        }
    }
    public static string STimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH1"] = value;
        }
    }
    public static string STimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM1"] = value;
        }
    }
    public static string STimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC1"] = value;
        }
    }
    public static string EDate1
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate1"] = value;
        }
    }
    public static string ETimeH1
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH1"] = value;
        }
    }
    public static string ETimeM1
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM1"] = value;
        }
    }
    public static string ETimeTC1
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC1"] = value;
        }
    }
    public static string CamDesc2
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc2"] = value;
        }
    }
    public static string CamRec2
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec2"] = value;
        }
    }
    public static string FilePath2
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath2"] = value;
        }
    }
    public static string SDate2
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate2"] = value;
        }
    }
    public static string STimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH2"] = value;
        }
    }
    public static string STimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM2"] = value;
        }
    }
    public static string STimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC2"] = value;
        }
    }
    public static string EDate2
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate2"] = value;
        }
    }
    public static string ETimeH2
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH2"] = value;
        }
    }
    public static string ETimeM2
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM2"] = value;
        }
    }
    public static string ETimeTC2
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC2"] = value;
        }
    }
    public static string CamDesc3
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc3"] = value;
        }
    }
    public static string CamRec3
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec3"] = value;
        }
    }
    public static string FilePath3
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath3"] = value;
        }
    }
    public static string SDate3
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate3"] = value;
        }
    }
    public static string STimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH3"] = value;
        }
    }
    public static string STimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM3"] = value;
        }
    }
    public static string STimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC3"] = value;
        }
    }
    public static string EDate3
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate3"] = value;
        }
    }
    public static string ETimeH3
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH3"] = value;
        }
    }
    public static string ETimeM3
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM3"] = value;
        }
    }
    public static string ETimeTC3
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC3"] = value;
        }
    }
    public static string CamDesc4
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc4"] = value;
        }
    }
    public static string CamRec4
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec4"] = value;
        }
    }
    public static string FilePath4
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath4"] = value;
        }
    }
    public static string SDate4
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate4"] = value;
        }
    }
    public static string STimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH4"] = value;
        }
    }
    public static string STimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM4"] = value;
        }
    }
    public static string STimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC4"] = value;
        }
    }
    public static string EDate4
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate4"] = value;
        }
    }
    public static string ETimeH4
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH4"] = value;
        }
    }
    public static string ETimeM4
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM4"] = value;
        }
    }
    public static string ETimeTC4
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC4"] = value;
        }
    }
    public static string CamDesc5
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc5"] = value;
        }
    }
    public static string CamRec5
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec5"] = value;
        }
    }
    public static string FilePath5
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath5"] = value;
        }
    }
    public static string SDate5
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate5"] = value;
        }
    }
    public static string STimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH5"] = value;
        }
    }
    public static string STimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM5"] = value;
        }
    }
    public static string STimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC5"] = value;
        }
    }
    public static string EDate5
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate5"] = value;
        }
    }
    public static string ETimeH5
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH5"] = value;
        }
    }
    public static string ETimeM5
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM5"] = value;
        }
    }
    public static string ETimeTC5
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC5"] = value;
        }
    }
    public static string CamDesc6
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc6"] = value;
        }
    }
    public static string CamRec6
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec6"] = value;
        }
    }
    public static string FilePath6
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath6"] = value;
        }
    }
    public static string SDate6
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate6"] = value;
        }
    }
    public static string STimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH6"] = value;
        }
    }
    public static string STimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM6"] = value;
        }
    }
    public static string STimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC6"] = value;
        }
    }
    public static string EDate6
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate6"] = value;
        }
    }
    public static string ETimeH6
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH6"] = value;
        }
    }
    public static string ETimeM6
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM6"] = value;
        }
    }
    public static string ETimeTC6
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC6"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC6"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC6"] = value;
        }
    }
    public static string CamDesc7
    {
        get
        {
            if (HttpContext.Current.Session["RICCamDesc7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamDesc7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamDesc7"] = value;
        }
    }
    public static string CamRec7
    {
        get
        {
            if (HttpContext.Current.Session["RICCamRec7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICCamRec7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICCamRec7"] = value;
        }
    }
    public static string FilePath7
    {
        get
        {
            if (HttpContext.Current.Session["RICFilePath7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICFilePath7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICFilePath7"] = value;
        }
    }
    public static string SDate7
    {
        get
        {
            if (HttpContext.Current.Session["RICSDate7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSDate7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSDate7"] = value;
        }
    }
    public static string STimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeH7"] = value;
        }
    }
    public static string STimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeM7"] = value;
        }
    }
    public static string STimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RICSTimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSTimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSTimeTC7"] = value;
        }
    }
    public static string EDate7
    {
        get
        {
            if (HttpContext.Current.Session["RICEDate7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICEDate7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICEDate7"] = value;
        }
    }
    public static string ETimeH7
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeH7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeH7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeH7"] = value;
        }
    }
    public static string ETimeM7
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeM7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeM7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeM7"] = value;
        }
    }
    public static string ETimeTC7
    {
        get
        {
            if (HttpContext.Current.Session["RICETimeTC7"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICETimeTC7"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICETimeTC7"] = value;
        }
    }
    public static string WhatHappened
    {
        get
        {
            if (HttpContext.Current.Session["RICWhatHappened"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICWhatHappened"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICWhatHappened"] = value;
        }
    }
    public static string ActionTaken
    {
        get
        {
            if (HttpContext.Current.Session["RICActionTaken"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICActionTaken"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICActionTaken"] = value;
        }
    }
    public static string Details
    {
        get
        {
            if (HttpContext.Current.Session["RICDetails"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICDetails"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICDetails"] = value;
        }
    }
    public static string SecurityAttend
    {
        get
        {
            if (HttpContext.Current.Session["RICSecurityAttend"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSecurityAttend"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSecurityAttend"] = value;
        }
    }
    public static string SecurityName
    {
        get
        {
            if (HttpContext.Current.Session["RICSecurityName"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICSecurityName"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICSecurityName"] = value;
        }
    }
    public static string PoliceNotified
    {
        get
        {
            if (HttpContext.Current.Session["RICPoliceNotified"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPoliceNotified"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPoliceNotified"] = value;
        }
    }
    public static string PoliceStation
    {
        get
        {
            if (HttpContext.Current.Session["RICPoliceStation"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPoliceStation"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPoliceStation"] = value;
        }
    }
    public static string OfficersName
    {

        get
        {
            if (HttpContext.Current.Session["RICOfficersName"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICOfficersName"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICOfficersName"] = value;
        }
    }
    public static string PoliceAction
    {
        get
        {
            if (HttpContext.Current.Session["RICPoliceAction"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICPoliceAction"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICPoliceAction"] = value;
        }
    }

    public static byte[] MemberPhoto1
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberPhoto1"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICMemberPhoto1"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberPhoto1"] = value;
        }
    }

    public static byte[] MemberPhoto2
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberPhoto2"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICMemberPhoto2"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberPhoto2"] = value;
        }
    }

    public static byte[] MemberPhoto3
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberPhoto3"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICMemberPhoto3"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberPhoto3"] = value;
        }
    }

    public static byte[] MemberPhoto4
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberPhoto4"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICMemberPhoto4"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberPhoto4"] = value;
        }
    }

    public static byte[] MemberPhoto5
    {
        get
        {
            if (HttpContext.Current.Session["RICMemberPhoto5"] == null)
            {
                return null;
            }
            else
            {
                return (byte[])HttpContext.Current.Session["RICMemberPhoto5"];
            }
        }
        set
        {
            HttpContext.Current.Session["RICMemberPhoto5"] = value;
        }
    }
    public static string Alias1
    {
        get
        {
            if (HttpContext.Current.Session["RICAlias1"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAlias1"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAlias1"] = value;
        }
    }
    public static string Alias2
    {
        get
        {
            if (HttpContext.Current.Session["RICAlias2"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAlias2"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAlias2"] = value;
        }
    }
    public static string Alias3
    {
        get
        {
            if (HttpContext.Current.Session["RICAlias3"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAlias3"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAlias3"] = value;
        }
    }
    public static string Alias4
    {
        get
        {
            if (HttpContext.Current.Session["RICAlias4"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAlias4"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAlias4"] = value;
        }
    }
    public static string Alias5
    {
        get
        {
            if (HttpContext.Current.Session["RICAlias5"] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session["RICAlias5"].ToString().Replace("'", "^");
            }
        }
        set
        {
            HttpContext.Current.Session["RICAlias5"] = value;
        }
    }
}
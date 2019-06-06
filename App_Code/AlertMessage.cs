using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI; // Alert Box

/// <summary>
/// Display alert message box
/// </summary>
public class AlertMessage
{
    public AlertMessage()
    {

    }

    public void DisplayMessage(string message) // display alert message box
    {
        message = "alert(\"" + message + "\");";
        var page = HttpContext.Current.CurrentHandler as Page;
        ScriptManager.RegisterStartupScript(page, GetType(), "ServerControlScript", message, true);
    }
}
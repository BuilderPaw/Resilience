using System;
using System.Collections.Generic;
using System.Data; // CommandType
using System.Data.SqlClient; /// SQL Connection
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Project follows Brad Adams Naming Convention Standard Guidelines - https://blogs.msdn.microsoft.com/brada/2005/01/26/internal-coding-guidelines/
/// Program uses static property encapsulated inside a public class - https://stackoverflow.com/questions/895595/how-do-i-persist-data-without-global-variables
/// "We should however look at the reasons why Globals are bad, and they are mostly regarded as bad because you break the rules of encapsulation.
///    Static data though, is not necesarrily bad, the good thing about static data is that you can encapsulate it, my example above is a very simplistic example of that,
///    probably in a real world scenario you would include your static data in the same class that does other work with the credentials." - Tim Jarvis
/// </summary>

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
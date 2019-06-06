using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data; // Data Source View
using System.Data.SqlClient; // SQL Connection
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services; // Script Service
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

[ScriptService]
public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString);
    AlertMessage alert = new AlertMessage();
    SqlQuery sqlQuery = new SqlQuery();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
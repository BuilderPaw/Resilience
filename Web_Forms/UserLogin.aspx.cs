using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // String Builder
using System.Web; // Http Cookie
using System.Web.Hosting; // Hosting Environment
using System.Web.Security; // Forms Authentication
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string group, displayName;
        string[] groupArray;
        StringBuilder groupsList = new StringBuilder();

        AuthenticateUser authUser = new AuthenticateUser("LDAP://MRSLGROUP");
        try
        {
            using (HostingEnvironment.Impersonate())
            {
                if (true == authUser.IsAuthenticated("MRSLGROUP", txtUsername.Text, txtPassword.Text)) // check if login details are valid - checking from Active Directory User Account details
                {
                    group = authUser.GetGroups(txtUsername.Text); // retrieve user groups + display name
                    groupArray = group.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    Session["Username"] = txtUsername.Text;
                    UserCredentials.Username = txtUsername.Text; // record username

                    displayName = groupArray[groupArray.Length - 1];
                    Session["DisplayName"] = displayName;
                    UserCredentials.DisplayName = displayName;
                    groupArray = groupArray.Take(groupArray.Count() - 1).ToArray(); // delete the last array item (display name), to keep this array variable set to usr groups only
                    for(int i =0; i <groupArray.Length; i++)
                    {
                        groupsList.Append(groupArray[i]);   // store group name
                        groupsList.Append("|");             // add a back slash delimeter
                    }
                    group = groupsList.ToString();          // set user groups
                    UserCredentials.Groups = group;

                    // upon login, check staff details and update necessary details
                    Staff(displayName, group);

                    RunStoredProcedure rsp = new RunStoredProcedure();
                    // encrypt password
                    string encryptedPassword = rsp.EncryptPassword(txtPassword.Text);
                    // update password stored in the database
                    rsp.StoredProcedureUpdateString("Proc_UpdatePassword", "password", encryptedPassword, "username", txtUsername.Text);

                    bool isCookiePersistent = false; // Create the ticket, and add the groups.
                    // set expiration of the authentication ticket - current set: 480 minutes / 8 hours
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(480), isCookiePersistent, group);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket); //Encrypt the ticket.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket); //Create a cookie, and then add the encrypted ticket to the cookie as data.

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    Response.Cookies.Add(authCookie); //Add the cookie to the outgoing cookies collection.
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false), false); //You can redirect now.
                }
                else
                {
                    bool passwordGiven = CheckIfPasswordIsGiven();

                    if (!passwordGiven)
                    {
                        errorLabel.Text = "Invalid details. Please check your username and password.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            bool passwordGiven = CheckIfPasswordIsGiven();

            if (!passwordGiven)
            {
                errorLabel.Text = "Error logging in user. " + ex.Message;
            }
        }
    }

    // upon login, check staff details and update necessary details
    private void Staff(string displayName, string group)
    {
        // check whether the staff logged in has the same credentials compared from the previous credentials logged in - if not, update db
        RunStoredProcedure rsp = new RunStoredProcedure();
        var staffId = 0;
        var staffNameId = 0;
        try
        {
            staffId = rsp.StoredProcedureReturnInt("Proc_GetStaffId", "username", txtUsername.Text, "staffId");
        }
        catch
        {
            // set staffId to zero to add the staff details to db
            staffId = 0;
        }

        // if staff exist in the db - next step is to compare from previous login and update staff details
        if (staffId != 0)
        {
            staffNameId = rsp.StoredProcedureReturnInt("Proc_GetStaffNameId_Staff", "username", txtUsername.Text, "staffNameId");
            string staffName = rsp.StoredProcedureReturnString("Proc_GetStaffName", "staffId", staffId, "staffName");

            // staff name is different from ad compared to db
            if (!displayName.Equals(staffName))
            {
                // disable active staff name on logged in user
                rsp.StoredProcedureUpdateBool("Proc_UpdateStaffName_Int", "active", false, "staffNameId", staffNameId);
                
                // add or update staff name from db
                staffNameId = CheckStaffNameExist(displayName, staffNameId, staffId);
            }
        }
        // staff does not exist in db - create a new staff id
        else
        {
            // add or update staff name from db
            staffNameId = CheckStaffNameExist(displayName, staffNameId, staffId);

            // add a new staff name and return staff name id
            staffId = rsp.StoredProcedureInsertRow("Proc_AddStaff", "staffNameId", staffNameId, "username", txtUsername.Text, "staffId");
        }

        UserCredentials.StaffId = staffId;
        UserCredentials.StaffNameId = staffNameId;
        // upon login, update user's role and group access
        UpdateStaffDetails(group, staffId);
    }

    private int CheckStaffNameExist(string displayName, int staffNameId, int staffId)
    {
        RunStoredProcedure rsp = new RunStoredProcedure();

        // check if staff name exists in db
        int exist = rsp.StoredProcedureReturnInt("Proc_CheckStaffNameExist", "staffName", displayName, "count");

        // if staff name exists, activate the correct staff name from db
        if (exist > 0)
        {
            // activate staff name on logged in user
            rsp.StoredProcedureUpdateBool("Proc_UpdateStaffName_Varchar", "active", true, "staffName", displayName);

            // get staff name id
            staffNameId = rsp.StoredProcedureReturnInt("Proc_GetStaffNameId_StaffName", "staffName", displayName, "staffNameId");
        }
        // staff name does not exists in db, create a new staff name id and make it active
        else
        {
            // add a new staff name and return staff name id
            staffNameId = rsp.StoredProcedureInsertRow("Proc_AddStaffName", "staffName", displayName, "staffNameId");
        }
        // update staff name id in staff table
        rsp.StoredProcedureUpdateInt("Proc_UpdateStaffNameId", "staffNameId", staffNameId, "staffId", staffId);
        return staffNameId;
    }

    // upon login, update user's role and group access
    private void UpdateStaffDetails(string group, int staffId)
    {
        // set staff's role
        var role = "";
        if (group.Contains("MRBankingSeniorManager"))
        {
            role = "MR Senior Manager";
        }
        else if (group.Contains("MRBankingDutyManager"))
        {
            role = "MR Duty Manager";
        }
        else if (group.Contains("CUBankingDutyManager"))
        {
            role = "CU Duty Manager";
        }
        else if (group.Contains("MRBankingSupervisor"))
        {
            role = "MR Supervisor";
        }
        else if (group.Contains("MRBankingClearance"))
        {
            role = "MR Clearance";
        }
        else if (group.Contains("CUBankingClearance"))
        {
            role = "CU Clearance";
        }

        // update staff's role and group
        RunStoredProcedure rsp = new RunStoredProcedure();
        rsp.StoredProcedureUpdateString("Proc_UpdateRole", "role", role, "staffId", staffId);
        rsp.StoredProcedureUpdateString("Proc_UpdateGroup", "group", group, "staffId", staffId);

        UserCredentials.Role = role;
    }

    private bool CheckIfPasswordIsGiven()
    {
        bool passwordGiven = true;

        RunStoredProcedure rsp = new RunStoredProcedure();
        string password = rsp.StoredProcedureReturnString("Proc_GetPassword", "username", txtUsername.Text, "password");

        if (string.Equals(password, txtPassword.Text))
        {
            // hide the current objetcs displayed and display a textbox to write their new password
            divLogin.Visible = false;
            divNewPassword.Visible = true;
            txtNewPassword.Focus();
            passwordGiven = true;
        }
        else
        {
            passwordGiven = false;
        }

        return passwordGiven;
    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        // once the new password is submitted, redirect them to the default url
        // update the password for this user
        RunStoredProcedure rsp = new RunStoredProcedure();
        // join these two methods together
        // encrypt password
        string encryptedPassword = rsp.EncryptPassword(txtNewPassword.Text);
        // update password stored in the database
        rsp.StoredProcedureUpdateString("Proc_UpdatePassword", "password", encryptedPassword, "username", txtUsername.Text);
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password updated');location.href='/Web_Forms/Default.aspx';", true); // show alert textbox first then redirect to default url

        AlertMessage alert = new AlertMessage();
        alert.DisplayMessage("Password updated!");

        // hide the current objetcs displayed and display a textbox to write their new password
        divLogin.Visible = true;
        divNewPassword.Visible = false;
        txtUsername.Focus();
    }
}
using System;
using System.DirectoryServices;
using System.Text;
using System.Web.Hosting;

/// <summary>
/// This class mimics the Lightweight Directory Access Protocol (LDAP) Authentication stucture
/// wherein users login similar to their computer login - points at the Active Directory path
/// </summary>
public class AuthenticateUser
{
    private string path, filterAttribute;

    public AuthenticateUser(string pathWay)
    {
        path = pathWay;
    }

    public bool IsAuthenticated(string domain, string username, string password)
    {
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, password);

        using (HostingEnvironment.Impersonate()) // Provides application-management functions and application services to a managed application within its application domain. Impersonates the user represented by the application identity.
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");

                // we were having issues with search.FindAll() method listed below and it takes 15 seconds to load
                // below is the error message that is displayed
                // ExtendedErrorMessage = "8009030C: LdapErr: DSID-0C0904DC, comment: AcceptSecurityContext error, data 52e, v1db1"
                // possible solution reference : https://social.technet.microsoft.com/Forums/windowsserver/en-US/2786da89-3dc7-43d9-8a75-3db54825ff36/solved-ldap-authentication-error-code-49-80090308-comment-acceptsecuritycontext-error-data?forum=winserverDS 
                // solution implemented: create an exception for local users not found in active directory
                // reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions
                if (username.ToLower().Equals("malb"))
                {
                    throw new SystemException("user is not found in active directory");
                }

                foreach (SearchResult result in search.FindAll())
                {
                    if (null != result)
                    {
                        path = result.Path; 
                        filterAttribute = (string)result.Properties["cn"][0]; // Picks up the display name from Active Directory
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // check whether the username exist in the database
                RunStoredProcedure rsp = new RunStoredProcedure();
                int exist = rsp.StoredProcedureReturnInt("Proc_CheckStaffExist","username",username,"count");

                // if statement to check whether the username exist in the database
                if (exist > 0)
                {
                    string encryptedPassword = rsp.StoredProcedureReturnString("Proc_GetPassword", "username", username, "password");
                    string decryptedPassword = rsp.DecryptPassword(encryptedPassword);

                    // if it is false, check if there is any password stored and match if exist return true
                    if (string.Equals(decryptedPassword, password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else // else throw the exception
                {
                    throw new Exception("Error authenticating user. " + ex.Message);
                }
            }
            return true;
        }
    }

    public string GetGroups(string username)
    {
        DirectorySearcher search = new DirectorySearcher(path);
        search.Filter = "(cn=" + filterAttribute + ")";
        search.PropertiesToLoad.Add("memberOf");
        StringBuilder groupNames = new StringBuilder();

        using (HostingEnvironment.Impersonate())
        {
            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count, equalIndex, commaIndex;
                string dn, grp;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (string)result.Properties["memberOf"][propertyCounter];
                    equalIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalIndex)
                    {
                        return null;
                    }
                    grp = dn.Substring((equalIndex + 1), (commaIndex - equalIndex) - 1); // Retrieves the Group Name in Active Directory

                    if (grp.Contains("MRBanking") || grp.Contains("CUBanking")) // if group name contains the following conditions, add it to group names and append a back slash
                    {
                        groupNames.Append(grp);
                        groupNames.Append("|");
                    }
                }
                groupNames.Append(filterAttribute); // append the user's display name after the list of groups
            }
            catch (Exception ex)
            {
                // exception existed - user must've been using the local db
                // get user group access from local db
                RunStoredProcedure rsp = new RunStoredProcedure();
                string group = rsp.StoredProcedureReturnString("Proc_GetGroup", "username", username, "group");

                if (!string.IsNullOrEmpty(group))
                {
                    // get staff id and staff name respectively
                    int staffId = rsp.StoredProcedureReturnInt("Proc_GetStaffId", "username", username, "staffId");
                    string staffName = rsp.StoredProcedureReturnString("Proc_GetStaffName", "staffId", staffId, "staffName");

                    // add group access value with backslash delimiter - last value is staff name
                    groupNames.Append(group);
                    groupNames.Append("|");
                    groupNames.Append(staffName);
                }
                else
                {
                    throw new Exception("Error obtaining group names. " + ex.Message);
                }
            }
            return groupNames.ToString();
        }
    }
}
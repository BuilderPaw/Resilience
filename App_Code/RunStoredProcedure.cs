using System; // exception
using System.Configuration; // configuration manager
using System.Data;  // data table, data row
using System.Data.SqlClient; // sql connection, sql command, sql adapter
using System.Text; // encoding

/// <summary>
/// Paolo Santiago 28/03/2018
/// Helper that runs the stored procedure
/// And can return values back to the controller
/// </summary>
public class RunStoredProcedure
{
    public RunStoredProcedure()
    {

    }

    public DataTable ReturnTable(string query)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnTable = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(returnTable); // create data adapter
                da.Fill(dt); // this will query your database and return the result to your data table
                conn.Close(); // close connection
                da.Dispose(); // dispose adapter
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: GetTable method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return dt;
    }

    public int ReturnInteger(string query)
    {
        int count = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnValue = new SqlCommand(query, conn);
                conn.Open();
                count = (int)returnValue.ExecuteScalar(); // execute query and assign the count integer a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: ReturnInteger method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return count;
    }

    public string ReturnString(string query)
    {
        string value = "";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                SqlCommand returnValue = new SqlCommand(query, conn);
                conn.Open();
                value = (string)returnValue.ExecuteScalar(); // execute query and assign the value string a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: ReturnString method under RunStoredProcedure class: " + ex.Message);
            }
        }

        return value;
    }

    public void UpdatePassword(string username, string password)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                string query = string.Concat("UPDATE [Staff] SET [Password]='", password, "' WHERE Username='", username, "'");
                SqlCommand updatePassword = new SqlCommand(query, conn);
                conn.Open();
                updatePassword.ExecuteNonQuery(); // execute query and assign the count integer a value
                conn.Close(); // close connection
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: UpdatePassword method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    /*
     * Paolo Santiago 26/04/2019
     * Stored procedure in C#; using stored procedure to return value as supposed to hardcoding sql queries to retrieve data
     * reference: https://stackoverflow.com/questions/1260952/how-to-execute-a-stored-procedure-within-c-sharp-program
     */
    public int StoredProcedureReturnInt(string storedProc, string parameterName, string parameter, string parameterOut)
    {
        int integer = 0;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName),parameter));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.Int32;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                integer = Convert.ToInt32(cmd.Parameters[string.Concat("@",parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureReturnInt method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return integer;
    }

    public int StoredProcedureReturnInt(string storedProc, string parameterName, int parameter, string parameterOut)
    {
        int integer = 0;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName), parameter));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.Int32;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                integer = Convert.ToInt32(cmd.Parameters[string.Concat("@", parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureReturnInt method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return integer;
    }

    public string StoredProcedureReturnString(string storedProc, string parameterName, string parameter, string parameterOut)
    {
        var text = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName), parameter));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.String;
                output.Size = 200;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                text = Convert.ToString(cmd.Parameters[string.Concat("@", parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureReturnString method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return text;
    }

    public string StoredProcedureReturnString(string storedProc, string parameterName, int parameter, string parameterOut)
    {
        var text = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName), parameter));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.String;
                output.Size = 200;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                text = Convert.ToString(cmd.Parameters[string.Concat("@", parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureReturnString method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return text;
    }

    public void StoredProcedureUpdateString(string storedProc, string parameterName1, string parameter1, string parameterName2, int parameter2)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));
                
                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureUpdateString method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public void StoredProcedureUpdateString(string storedProc, string parameterName1, string parameter1, string parameterName2, string parameter2)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));

                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureUpdateString method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public void StoredProcedureUpdateBool(string storedProc, string parameterName1, bool parameter1, string parameterName2, int parameter2)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));

                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureUpdateBool method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public void StoredProcedureUpdateBool(string storedProc, string parameterName1, bool parameter1, string parameterName2, string parameter2)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));

                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureUpdateBool method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public void StoredProcedureUpdateInt(string storedProc, string parameterName1, int parameter1, string parameterName2, int parameter2)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));

                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureUpdateInt method under RunStoredProcedure class: " + ex.Message);
            }
        }
    }

    public int StoredProcedureInsertRow(string storedProc, string parameterName, string parameter, string parameterOut)
    {
        var id = 0;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName), parameter));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.Int32;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                id = Convert.ToInt32(cmd.Parameters[string.Concat("@", parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureInsertRow method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return id;
    }

    public int StoredProcedureInsertRow(string storedProc, string parameterName1, int parameter1, string parameterName2, string parameter2, string parameterOut)
    {
        var id = 0;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
        {
            try
            {
                conn.Open();

                // create a command object identifying the stored proc
                SqlCommand cmd = new SqlCommand(storedProc, conn);

                // set the command object so it knows to execute a stroed proc
                cmd.CommandType = CommandType.StoredProcedure;

                // clear existing parameters
                cmd.Parameters.Clear();

                // add parameter to command, which will be passed to the stored proc
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName1), parameter1));
                cmd.Parameters.Add(new SqlParameter(string.Concat("@", parameterName2), parameter2));

                SqlParameter output = new SqlParameter();
                output.ParameterName = string.Concat("@", parameterOut);
                output.DbType = DbType.Int32;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                // execute the command
                cmd.ExecuteScalar();
                id = Convert.ToInt32(cmd.Parameters[string.Concat("@", parameterOut)].Value);
            }
            catch (Exception ex) // capture exception
            {
                throw new Exception("Error: StoredProcedureInsertRow method under RunStoredProcedure class: " + ex.Message);
            }
        }
        return id;
    }

    private DataTable StoredProcedureReturnTable()
    {
        DataTable table = new DataTable();
        return table;
    }

    public string EncryptPassword(string password) // encrypts password
    {
        try
        {
            byte[] encryptedByte = new byte[password.Length];
            encryptedByte = Encoding.UTF8.GetBytes(password);
            string encrypted = Convert.ToBase64String(encryptedByte);
            return encrypted;
        }
        catch (Exception ex)
        {
            throw new Exception("Error: EncryptPassword method under RunStoredProcedure class: " + ex.Message);
        }
    }

    public string DecryptPassword(string encrypted)
    {
        UTF8Encoding encoder = new UTF8Encoding();
        Decoder utf8Decode = encoder.GetDecoder();
        byte[] decodeByte = Convert.FromBase64String(encrypted);
        int charCount = utf8Decode.GetCharCount(decodeByte, 0, decodeByte.Length);
        char[] decodedChar = new char[charCount];
        utf8Decode.GetChars(decodeByte, 0, decodeByte.Length, decodedChar, 0);
        string result = new String(decodedChar);
        return result;
    }
}
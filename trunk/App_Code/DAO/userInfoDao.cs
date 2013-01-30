using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

/// <summary>
///userInfoDao 的摘要说明
/// </summary>
public class userInfoDao
{
    protected string Conn()
    {
        return ConfigurationManager.ConnectionStrings["vodAdminConnectionString"].ConnectionString;
    }

    public userInfoDao() { }

    public userinfo getUser(string userName)
    {
        userinfo user = new userinfo();
        string query = "SELECT UserID,UserName,Password,Email,Type FROM userinfo WHERE UserName=?UserName;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?UserName", userName));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read() == true)
            {
                user.UserID = Convert.ToInt32(myDataReader["UserID"]);
                user.UserName = myDataReader["UserName"].ToString();
                user.Password = myDataReader["Password"].ToString();
                user.Email = myDataReader["Email"].ToString();
                user.Type = Convert.ToInt32(myDataReader["Type"]);
            }
            myDataReader.Close();

        }
        catch
        {
            return null;
        }
        finally
        {

            myConnection.Close();
        }
        return user;

    }

    public userinfo getUser(int userID)
    {
        userinfo user = new userinfo();
        string query = "SELECT UserID,UserName,Password,Email,Type FROM userinfo WHERE UserID=?userID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?userID", userID));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read() == true)
            {
                user.UserID = Convert.ToInt32(myDataReader["UserID"]);
                user.UserName = myDataReader["UserName"].ToString();
                user.Password = myDataReader["Password"].ToString();
                user.Email = myDataReader["Email"].ToString();
                user.Type = Convert.ToInt32(myDataReader["Type"]);
            }
            myDataReader.Close();

        }
        catch
        {
            return null;
        }
        finally
        {

            myConnection.Close();
        }
        return user;

    }

    public bool saveUser(userinfo user)
    {
        string query = "INSERT INTO userinfo (UserName,Password,Email,Type) VALUES (?UserName,?Password,?Email,?Type);";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?UserName", user.UserName));
        myCommand.Parameters.Add(new MySqlParameter("?Password", user.Password));
        myCommand.Parameters.Add(new MySqlParameter("?Email", user.Email));
        myCommand.Parameters.Add(new MySqlParameter("?Type", user.Type));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        finally
        {
            myConnection.Close();
        }
        return true;
    }

    public DataSet getUsers()
    {
        string query = "SELECT UserID,UserName,Password,Email,Type FROM userinfo";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlDataAdapter myda = new MySqlDataAdapter(query, myConnection);
        DataSet mydataset = new DataSet();
        try
        {
            myConnection.Open();
            myda.Fill(mydataset);
        }
        catch
        {
            return null;
        }
        finally
        {
            myConnection.Close();
        }
        return mydataset;
    }

    public bool delUser(string userId)
    {
        string query = "DELETE FROM userinfo WHERE UserID=?UserID;;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?UserID", userId));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        finally
        {
            myConnection.Close();
        }
        return true;
    }

    public bool updateUser(userinfo user)
    {
        string query = "UPDATE userinfo SET UserName=?UserName,Email=?Email,Type=?Type WHERE UserID=?UserID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?UserName", user.UserName));
        myCommand.Parameters.Add(new MySqlParameter("?Email", user.Email));
        myCommand.Parameters.Add(new MySqlParameter("?Type", user.Type));
        myCommand.Parameters.Add(new MySqlParameter("?UserID", user.UserID));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        finally
        {
            myConnection.Close();
        }
        return true;
    }


}
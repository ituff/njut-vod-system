using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

/// <summary>
///channelInfoDao 的摘要说明
/// </summary>
public class channelInfoDao
{
	public channelInfoDao()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    protected string Conn()
    {
        return ConfigurationManager.ConnectionStrings["vodAdminConnectionString"].ConnectionString;
    }

    public DataSet getChannels()
    {
        string query = "SELECT ChannelID,ChannelName,ChannelMMS FROM channelinfo";
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

    public bool delChannel(string channelId)
    {
        string query = "DELETE FROM channelinfo WHERE ChannelID=?ChannelID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", channelId));
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

    public bool updateChannel(channelinfo channel)
    {
        string query = "UPDATE channelinfo SET ChannelName=?ChannelName,ChannelMMS=?ChannelMMS WHERE ChannelID=?ChannelID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelName", channel.ChannelName));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelMMS", channel.ChannelMMS));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", channel.ChannelID));
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

    public channelinfo getChannel(int ChannelID)
    {
        channelinfo channel = new channelinfo();
        string query = "SELECT ChannelID,ChannelName,ChannelMMS FROM channelinfo WHERE ChannelID=?ChannelID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", ChannelID));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read() == true)
            {
                channel.ChannelID = Convert.ToInt32(myDataReader["ChannelID"]);
                channel.ChannelName = myDataReader["ChannelName"].ToString();
                channel.ChannelMMS = myDataReader["ChannelMMS"].ToString();
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
        return channel;

    }

    public channelinfo getChannel(string ChannelName)
    {
        channelinfo channel = new channelinfo();
        string query = "SELECT ChannelID,ChannelName,ChannelMMS FROM channelinfo WHERE ChannelName=?ChannelName;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelName", ChannelName));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read() == true)
            {
                channel.ChannelID = Convert.ToInt32(myDataReader["ChannelID"]);
                channel.ChannelName = myDataReader["ChannelName"].ToString();
                channel.ChannelMMS = myDataReader["ChannelMMS"].ToString();
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
        return channel;

    }

     public bool saveChannel(channelinfo channel)
    {
        string query = "INSERT INTO channelinfo (ChannelName,ChannelMMS) VALUES (?ChannelName,?ChannelMMS);";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelName", channel.ChannelName));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelMMS", channel.ChannelMMS));
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
using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

    public DataSet getChannels(string where)
    {
        string query = "SELECT ChannelID,ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo "+where;
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

    public List<channelinfo> getChannelList(string where)
    {
        string query = "SELECT ChannelID,ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo " + where;
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
        List<channelinfo> Channels = new List<channelinfo>();
        for (int i = 0; i < mydataset.Tables[0].Rows.Count; i++)
        {
            channelinfo channel = new channelinfo();
            channel.ChannelID = Convert.ToInt32(mydataset.Tables[0].Rows[i]["ChannelID"]);
            channel.ChannelName = mydataset.Tables[0].Rows[i]["ChannelName"].ToString();
            channel.ChannelMMS = mydataset.Tables[0].Rows[i]["ChannelMMS"].ToString();
            channel.PosterUrl = mydataset.Tables[0].Rows[i]["PosterURL"].ToString();
            channel.StreamType = mydataset.Tables[0].Rows[i]["StreamType"].ToString();
            channel.BroadCastUrl = mydataset.Tables[0].Rows[i]["broadCastUrl"].ToString();
            channel.IsMobileLiveStream = Convert.ToInt32(mydataset.Tables[0].Rows[i]["isMobileLiveStream"]);
            channel.ConnectStatus = Convert.ToInt32(mydataset.Tables[0].Rows[i]["ConnectStatus"]);
            channel.IsBroadcast = Convert.ToInt32(mydataset.Tables[0].Rows[i]["isBroadcast"]);
            channel.UserId = Convert.ToInt32(mydataset.Tables[0].Rows[i]["UserId"]);
            channel.IsRecord = Convert.ToInt32(mydataset.Tables[0].Rows[i]["isRecord"]);
            Channels.Add(channel);
        }
        return Channels;
    }

    public DataSet getChannels()
    {
        string query = "SELECT ChannelID,ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo";
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

    public DataSet getChannels(int userId)
    {
        string query = "SELECT ChannelID,SUBSTRING(ChannelName,1,4) AS CN,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo WHERE UserId=" + userId + " ORDER BY ChannelID DESC";
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
        string query = "UPDATE channelinfo SET ChannelName=?ChannelName,ChannelMMS=?ChannelMMS,PosterURL=?PosterURL,StreamType=?StreamType,isMobileLiveStream=?isMobileLiveStream,ConnectStatus=?ConnectStatus,isBroadcast=?isBroadcast,UserId=?UserId,isRecord=?isRecord,broadCastUrl=?broadCastUrl WHERE ChannelID=?ChannelID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelName", channel.ChannelName));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelMMS", channel.ChannelMMS));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", channel.ChannelID));
        myCommand.Parameters.Add(new MySqlParameter("?PosterURL", channel.PosterUrl));
        myCommand.Parameters.Add(new MySqlParameter("?StreamType", channel.StreamType));
        myCommand.Parameters.Add(new MySqlParameter("?isMobileLiveStream", channel.IsMobileLiveStream));
        myCommand.Parameters.Add(new MySqlParameter("?ConnectStatus", channel.ConnectStatus));
        myCommand.Parameters.Add(new MySqlParameter("?isBroadcast", channel.IsBroadcast));
        myCommand.Parameters.Add(new MySqlParameter("?UserId", channel.UserId));
        myCommand.Parameters.Add(new MySqlParameter("?isRecord", channel.IsRecord));
        myCommand.Parameters.Add(new MySqlParameter("?broadCastUrl", channel.BroadCastUrl));
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
        string query = "SELECT ChannelID,ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo WHERE ChannelID=?ChannelID;";
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
                channel.PosterUrl = myDataReader["PosterURL"].ToString();
                channel.StreamType = myDataReader["StreamType"].ToString();
                channel.BroadCastUrl = myDataReader["broadCastUrl"].ToString();
                channel.IsMobileLiveStream = Convert.ToInt32(myDataReader["isMobileLiveStream"]);
                channel.ConnectStatus = Convert.ToInt32(myDataReader["ConnectStatus"]);
                channel.IsBroadcast = Convert.ToInt32(myDataReader["isBroadcast"]);
                channel.UserId = Convert.ToInt32(myDataReader["UserId"]);
                channel.IsRecord = Convert.ToInt32(myDataReader["isRecord"]);
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
        string query = "SELECT ChannelID,ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl FROM channelinfo WHERE ChannelName=?ChannelName;";
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
                channel.PosterUrl = myDataReader["PosterURL"].ToString();
                channel.StreamType = myDataReader["StreamType"].ToString();
                channel.IsMobileLiveStream = Convert.ToInt32(myDataReader["isMobileLiveStream"]);
                channel.ConnectStatus = Convert.ToInt32(myDataReader["ConnectStatus"]);
                channel.IsBroadcast = Convert.ToInt32(myDataReader["isBroadcast"]);
                channel.UserId = Convert.ToInt32(myDataReader["UserId"]);
                channel.IsRecord = Convert.ToInt32(myDataReader["isRecord"]);
                channel.BroadCastUrl = myDataReader["broadCastUrl"].ToString();
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
        string query = "INSERT INTO channelinfo (ChannelName,ChannelMMS,PosterURL,StreamType,isMobileLiveStream,ConnectStatus,isBroadcast,UserId,isRecord,broadCastUrl) VALUES (?ChannelName,?ChannelMMS,?PosterURL,?StreamType,?isMobileLiveStream,?ConnectStatus,?isBroadcast,?UserId,?isRecord,?broadCastUrl);";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ChannelName", channel.ChannelName));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelMMS", channel.ChannelMMS));
        myCommand.Parameters.Add(new MySqlParameter("?PosterURL", channel.PosterUrl));
        myCommand.Parameters.Add(new MySqlParameter("?StreamType", channel.StreamType));
        myCommand.Parameters.Add(new MySqlParameter("?isMobileLiveStream", channel.IsMobileLiveStream));
        myCommand.Parameters.Add(new MySqlParameter("?ConnectStatus", channel.ConnectStatus));
        myCommand.Parameters.Add(new MySqlParameter("?isBroadcast", channel.IsBroadcast));
        myCommand.Parameters.Add(new MySqlParameter("?UserId", channel.UserId));
        myCommand.Parameters.Add(new MySqlParameter("?isRecord", channel.IsRecord));
        myCommand.Parameters.Add(new MySqlParameter("?broadCastUrl", channel.BroadCastUrl));
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
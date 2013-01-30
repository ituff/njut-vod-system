using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

/// <summary>
///programInfoDao 的摘要说明
/// </summary>
public class programInfoDao
{
    public programInfoDao()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    protected string Conn()
    {
        return ConfigurationManager.ConnectionStrings["vodAdminConnectionString"].ConnectionString;
    }

    public DataSet getPrograms()
    {
        string query = "SELECT ProgramID,ProgramName,ProgramUrl,ProgramDescribe,ChannelID,BeginTime,EndTime FROM programinfo";
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

    public bool delProgram(string programId)
    {
        string query = "DELETE FROM programinfo WHERE ProgramID=?ProgramID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ProgramID", programId));
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

    public bool updateProgram(programinfo program)
    {
        string query = "UPDATE programinfo SET ProgramName=?ProgramName,ProgramUrl=?ProgramUrl,ProgramDescribe=?ProgramDescribe,ChannelID=?ChannelID,BeginTime=?BeginTime,EndTime=?EndTime WHERE ProgramID=?ProgramID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ProgramName", program.ProgramName));
        myCommand.Parameters.Add(new MySqlParameter("?ProgramUrl", program.ProgramUrl));
        myCommand.Parameters.Add(new MySqlParameter("?ProgramDescribe", program.ProgramDescribe));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", program.ChannelID));
        myCommand.Parameters.Add(new MySqlParameter("?BeginTime", program.BeginTime));
        myCommand.Parameters.Add(new MySqlParameter("?EndTime", program.EndTime));
        myCommand.Parameters.Add(new MySqlParameter("?ProgramID", program.ProgramID));
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

    public programinfo getProgram(int programID)
    {
        programinfo program = new programinfo();
        string query = "SELECT ProgramID,ProgramName,ProgramUrl,ProgramDescribe,ChannelID,BeginTime,EndTime FROM programinfo WHERE ProgramID=?ProgramID;";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ProgramID", programID));
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read() == true)
            {
                program.ProgramID = Convert.ToInt32(myDataReader["ProgramID"]);
                program.ProgramName = myDataReader["ProgramName"].ToString();
                program.ProgramUrl = myDataReader["ProgramUrl"].ToString();
                program.ProgramDescribe = myDataReader["ProgramDescribe"].ToString();
                program.ChannelID= Convert.ToInt32(myDataReader["ChannelID"]);
                program.BeginTime = Convert.ToDateTime(myDataReader["BeginTime"]);
                program.EndTime = Convert.ToDateTime(myDataReader["EndTime"]);
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
        return program;

    }

    public bool saveProgram(programinfo program)
    {
        string query = "INSERT INTO programinfo (ProgramName,ProgramUrl,ProgramDescribe,ChannelID,BeginTime,EndTime) VALUES (?ProgramName,?ProgramUrl,?ProgramDescribe,?ChannelID,?BeginTime,?EndTime);";
        MySqlConnection myConnection = new MySqlConnection(Conn());
        MySqlCommand myCommand = new MySqlCommand(query, myConnection);
        myCommand.Parameters.Add(new MySqlParameter("?ProgramName", program.ProgramName));
        myCommand.Parameters.Add(new MySqlParameter("?ProgramUrl", program.ProgramUrl));
        myCommand.Parameters.Add(new MySqlParameter("?ProgramDescribe", program.ProgramDescribe));
        myCommand.Parameters.Add(new MySqlParameter("?ChannelID", program.ChannelID));
        myCommand.Parameters.Add(new MySqlParameter("?BeginTime", program.BeginTime));
        myCommand.Parameters.Add(new MySqlParameter("?EndTime", program.EndTime));
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
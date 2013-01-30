using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

/// <summary>
/// 类programinfo。
/// </summary>
[Serializable]
public partial class programinfo
{
    public programinfo()
    { }
    #region Model
    private int _programid;
    private string _programname;
    private string _programurl;
    private string _programdescribe;
    private int _channelid;
    private DateTime _begintime;
    private DateTime _endtime;

    public int ProgramID
    {
        set { _programid = value; }
        get { return _programid; }
    }

    public string ProgramName
    {
        set { _programname = value; }
        get { return _programname; }
    }

    public string ProgramUrl
    {
        set { _programurl = value; }
        get { return _programurl; }
    }

    public string ProgramDescribe
    {
        set { _programdescribe = value; }
        get { return _programdescribe; }
    }

    public int ChannelID
    {
        set { _channelid = value; }
        get { return _channelid; }
    }

    public DateTime BeginTime
    {
        set { _begintime = value; }
        get { return _begintime; }
    }

    public DateTime EndTime
    {
        set { _endtime = value; }
        get { return _endtime; }
    }
    #endregion Model
}



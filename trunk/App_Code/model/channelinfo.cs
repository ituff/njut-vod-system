using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

/// <summary>
/// 类channelinfo。
/// </summary>
[Serializable]
public partial class channelinfo
{
    public channelinfo()
    { }
    #region Model
    private int _channelid;
    private string _channelname;
    private string _channelmms;

    public int ChannelID
    {
        set { _channelid = value; }
        get { return _channelid; }
    }

    public string ChannelName
    {
        set { _channelname = value; }
        get { return _channelname; }
    }

    public string ChannelMMS
    {
        set { _channelmms = value; }
        get { return _channelmms; }
    }
    #endregion Model
}


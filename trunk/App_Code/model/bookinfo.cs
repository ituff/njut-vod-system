using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

/// <summary>
/// 类bookinfo。
/// </summary>
[Serializable]
public partial class bookinfo
{
    public bookinfo()
    { }
    #region Model
    private int _bookid;
    private int _userid;
    private int _channelid;

    public int BookID
    {
        set { _bookid = value; }
        get { return _bookid; }
    }

    public int UserID
    {
        set { _userid = value; }
        get { return _userid; }
    }

    public int ChannelID
    {
        set { _channelid = value; }
        get { return _channelid; }
    }
    #endregion Model
}



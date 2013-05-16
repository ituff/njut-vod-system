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
    private string _PosterUrl;
    private string _broadCastUrl;

    public string BroadCastUrl
    {
        get { return _broadCastUrl; }
        set { _broadCastUrl = value; }
    }


    public string PosterUrl
    {
        get { return _PosterUrl; }
        set { _PosterUrl = value; }
    }
    private string _streamType;

    public string StreamType
    {
        get { return _streamType; }
        set { _streamType = value; }
    }
    private int _isMobileLiveStream;


    public int IsMobileLiveStream
    {
        get { return _isMobileLiveStream; }
        set { _isMobileLiveStream = value; }
    }
    private int _connectStatus;

    public int ConnectStatus
    {
        get { return _connectStatus; }
        set { _connectStatus = value; }
    }
    private int _isBroadcast;

    public int IsBroadcast
    {
        get { return _isBroadcast; }
        set { _isBroadcast = value; }
    }
    private int _userId;

    public int UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }
    private int _isRecord;

    public int IsRecord
    {
        get { return _isRecord; }
        set { _isRecord = value; }
    }


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


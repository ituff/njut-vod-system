using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

/// <summary>
/// 类dvinfo。
/// </summary>
[Serializable]
public partial class dvinfo
{
    public dvinfo()
    { }
    #region Model
    private int _dvid;
    private int _userid;
    private string _dvname;
    private string _dvurl;
    private double _dvlength;
    private DateTime _uploadtime;

    public int DVID
    {
        set { _dvid = value; }
        get { return _dvid; }
    }

    public int UserID
    {
        set { _userid = value; }
        get { return _userid; }
    }

    public string DVName
    {
        set { _dvname = value; }
        get { return _dvname; }
    }

    public string DVUrl
    {
        set { _dvurl = value; }
        get { return _dvurl; }
    }

    public double DVLength
    {
        set { _dvlength = value; }
        get { return _dvlength; }
    }

    public DateTime UploadTime
    {
        set { _uploadtime = value; }
        get { return _uploadtime; }
    }
    #endregion Model
}



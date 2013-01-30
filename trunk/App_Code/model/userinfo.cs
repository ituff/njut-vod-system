using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;


[Serializable]
public partial class userinfo
{
    public userinfo()
    { }
    #region Model
    private int _userid;
    private string _username;
    private string _password;
    private string _email;
    private int _type = 0;

    public int UserID
    {
        set { _userid = value; }
        get { return _userid; }
    }

    public string UserName
    {
        set { _username = value; }
        get { return _username; }
    }

    public string Password
    {
        set { _password = value; }
        get { return _password; }
    }

    public string Email
    {
        set { _email = value; }
        get { return _email; }
    }

    public int Type
    {
        set { _type = value; }
        get { return _type; }
    }
    #endregion Model
}



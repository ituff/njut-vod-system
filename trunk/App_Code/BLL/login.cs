using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///login 的摘要说明
/// </summary>
public class login
{

    public login() { }
    public bool Login(string UserName, string PassWord)
    {
        userInfoDao userDao = new userInfoDao();
        userinfo user = userDao.getUser(UserName);
        encryptcs Encryptcs = new encryptcs();
        if (user == null) return false;
        if (user.Password.Equals(Encryptcs.Encrypt(PassWord))) return true;
        else return false;
    }

    public int userType(string UserName)
    {
        userInfoDao userDao = new userInfoDao();
        userinfo user = userDao.getUser(UserName);
        if (user == null) return 0;
        return user.Type;
    }

    public int userId(string UserName)
    {
        userInfoDao userDao = new userInfoDao();
        userinfo user = userDao.getUser(UserName);
        if (user == null) return 0;
        return user.UserID;
    }
}
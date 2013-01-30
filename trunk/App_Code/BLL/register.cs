using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///register 的摘要说明
/// </summary>
public class register
{

    public register() { }
    public bool Register(userinfo user)
    {
        encryptcs Encrytcs = new encryptcs();
        user.Password = Encrytcs.Encrypt(user.Password);
        userInfoDao userDao = new userInfoDao();
        return userDao.saveUser(user);
    }
}
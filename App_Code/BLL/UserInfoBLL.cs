
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
///UserInfoBLL 的摘要说明
/// </summary>
public class UserInfoBLL
{
    public UserInfoBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public DataSet Select()
    {
        userInfoDao userDao = new userInfoDao();
        return userDao.getUsers();
    }

    public userinfo Select(int userID) {
        userInfoDao userDao = new userInfoDao();
        return userDao.getUser(userID);
    }

    public bool Delete(string userID) {
        userInfoDao userDao = new userInfoDao();
        return userDao.delUser(userID);
    }

    public bool Update(userinfo user)
    {
        userInfoDao userDao = new userInfoDao();
        encryptcs Encrytcs = new encryptcs();
        user.Password = Encrytcs.Encrypt(user.Password);
        return userDao.updateUser(user);
    }

    public bool Insert(userinfo user)
    {
        encryptcs Encrytcs = new encryptcs();
        user.Password = Encrytcs.Encrypt(user.Password);
        userInfoDao userDao = new userInfoDao();
        return userDao.saveUser(user);
    }

}
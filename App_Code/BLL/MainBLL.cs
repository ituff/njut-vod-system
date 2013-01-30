using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///MainBLL 的摘要说明
/// </summary>
public class MainBLL
{
    public MainBLL() { }
    
    public string getUserName(int UserID)
	{
        userInfoDao userdao = new userInfoDao();
        userinfo user = userdao.getUser(UserID);
        if (user != null) return user.UserName;
        else return null;
	}
}
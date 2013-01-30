using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        login Login = new login();
        string userName = username.Text.Trim();
        string passWord=password.Text.Trim();
        if (userName.Length < 1) { ShowMessage("javascritp", "用户名不能为空"); return; }
        if (passWord.Length < 1) { ShowMessage("javascritp", "密码不能为空"); return; }
        if (Login.Login(userName, passWord))
        {
            Session["status"] = "true";
            Session["UserId"] = Login.userId(userName).ToString();
            Session["type"] = Login.userType(userName).ToString();
            ShowMessage("javascript", "登录成功;");
            if (Session["type"].Equals("1"))
                Response.Redirect("main.aspx");
        }
        else
        {
            Session["status"] = "false";
            Session["UserId"] = "0";
            Session["type"] = "0";
            ShowMessage("javascript", "登录失败;");
            Response.Redirect("logout.aspx");
        }
    }

    private void ShowMessage(string scriptKey, string message)
    {
        ClientScriptManager csm = Page.ClientScript;
        if (!csm.IsClientScriptBlockRegistered(scriptKey))
        {
            string strScript = "alert('" + message + "');";
            csm.RegisterClientScriptBlock(Page.GetType(), scriptKey, strScript, true);
        }
    }
}
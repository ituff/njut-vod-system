using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        userinfo user = new userinfo();
        string userName = username.Text.Trim();
        if (userName.Length < 1) { ShowMessage("javascript", "用户名不能为空！"); return; }
        else user.UserName = userName;
        string passWord = password1.Text.Trim();
        if (passWord.Length < 1) { ShowMessage("javascript", "密码不能为空！"); return; }
        else
        {
            if (passWord.Equals(password2.Text.Trim())) user.Password = passWord;
            else { ShowMessage("javascript", "两次密码不一致！"); return; }
        }
        string Email = email.Text.Trim();
        if (Email.Length < 1) ShowMessage("javascript", "电子邮箱不能为空！");
        else user.Email = Email;
        user.Type = 2;
        register registerBLL = new register();
        if (registerBLL.Register(user)) MessageBox.ShowAndRedirect(this, "注册成功！", "login.aspx");
        else ShowMessage("javascript", "注册失败;");

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
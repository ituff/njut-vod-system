using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        authentication();
        if (!Page.IsPostBack)
        {

        }
    }

    private void authentication()
    {
        if ((Session["status"] == null) || (!Session["status"].Equals("true"))) Response.Redirect("logout.aspx");
        if ((Session["type"] == null) || (!Session["type"].Equals("1"))) Response.Redirect("logout.aspx");
    }


    protected void addChannelBtn_Click(object sender, EventArgs e)
    {
        string UserlNameStr = UserNameTB.Text.Trim();
        string UserPasswordStr = UserPasswordTB.Text.Trim();
        string UserEmailStr = UserEmailTB.Text.Trim();
        int UserTypeInt = Convert.ToInt32(UserTypeDDL.SelectedItem.Value);
        if (UserlNameStr.Length < 1) { ShowMessage("javascript", "用户名不能为空！"); return; }
        if (UserPasswordStr.Length < 1) { ShowMessage("javascript", "密码不能为空！"); return; }
        if (UserEmailStr.Length < 1) { ShowMessage("javascript", "邮箱不能为空！"); return; }
        userinfo user = new userinfo();
        user.UserName = UserlNameStr;
        user.Password = UserPasswordStr;
        user.Email = UserEmailStr;
        user.Type = UserTypeInt;
        UserInfoBLL userlBll = new UserInfoBLL();
        if (userlBll.Insert(user)) ShowMessage("javascript", "添加成功！");
        else ShowMessage("javascript", "添加失败！");
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
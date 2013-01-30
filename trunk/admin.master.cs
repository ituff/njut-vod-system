using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initial();
    }

    public string userName;

    private void initial() {
        int userId = Convert.ToInt32(Session["UserId"]);
        MainBLL mainbll = new MainBLL();
        string username = mainbll.getUserName(userId);
        if (username != null) userName = username;
    }
}

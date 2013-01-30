using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addChannel : System.Web.UI.Page
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
        string ChannelNameStr = ChannelNameTB.Text.Trim();
        string ChannelMMSStr = ChannelMMSTB.Text.Trim();
        if (ChannelNameStr.Length < 1) { ShowMessage("javascript", "频道名称不能为空！"); return; }
        if (ChannelMMSStr.Length < 1) { ShowMessage("javascript", "频道地址不能为空！"); return; }
        channelinfo channel = new channelinfo();
        channel.ChannelName = ChannelNameStr;
        channel.ChannelMMS = ChannelMMSStr;
        ChannelBLL channelBll = new ChannelBLL();
        if (channelBll.Insert(channel)) ShowMessage("javascript", "添加成功！");
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
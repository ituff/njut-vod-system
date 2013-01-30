using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class channelView : System.Web.UI.Page
{
    private int id ;

    protected void Page_Load(object sender, EventArgs e)
    {
        authentication();
        id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
        if (!Page.IsPostBack)
        {
            dataBind();
        }
    }
    
    private void authentication()
    {
        if ((Session["status"] == null) || (!Session["status"].Equals("true"))) Response.Redirect("logout.aspx");
        if ((Session["type"] == null) || (!Session["type"].Equals("1"))) Response.Redirect("logout.aspx");
    }

    public string ChannelMMSStr;

    private void dataBind() {
        ChannelBLL channelbll = new ChannelBLL();
        channelinfo channel = channelbll.Select(id);
        ChannelNameTB.Text = channel.ChannelName;
        ChannelMMSTB.Text = channel.ChannelMMS;
        ChannelMMSStr = channel.ChannelMMS;

    }
    protected void updateChannelBtn_Click(object sender, EventArgs e)
    {
        string ChannelNameStr = ChannelNameTB.Text.Trim();
        string ChannelMMSStr = ChannelMMSTB.Text.Trim();
        if (ChannelNameStr.Length < 1) { ShowMessage("javascript", "频道名称不能为空！"); return; }
        if (ChannelMMSStr.Length < 1) { ShowMessage("javascript", "频道地址不能为空！"); return; }
        channelinfo channel = new channelinfo();
        if (id == null) id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
        channel.ChannelID = id;
        channel.ChannelName = ChannelNameStr;
        channel.ChannelMMS = ChannelMMSStr;
        ChannelBLL channelBll = new ChannelBLL();
        if (channelBll.Update(channel)) { dataBind(); ShowMessage("javascript", "更新成功！"); }
        else ShowMessage("javascript", "更新失败！");
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
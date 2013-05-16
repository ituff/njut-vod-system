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
        isMobileLiveStream();
        //ieStramPlayerPannel.Visible = true;
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
    protected int isMobileLiveStreamInt; 

    private void dataBind() {
        ChannelBLL channelbll = new ChannelBLL();
        channelinfo channel = channelbll.Select(id);
        ChannelNameTB.Text = channel.ChannelName;
        ChannelMMSTB.Text = channel.ChannelMMS;
        ChannelMMSStr = channel.ChannelMMS;
        if (channel.IsMobileLiveStream == 1) IsMobileLiveCB.Checked = true; else IsMobileLiveCB.Checked = false;
        if (channel.IsBroadcast == 1) IsBroadCastCB.Checked = true; else IsBroadCastCB.Checked = false;
        if (channel.IsRecord == 1) IsRecordCB.Checked = true; else IsRecordCB.Checked = false;
    }

    protected void isMobileLiveStream() {
        ChannelBLL channelbll = new ChannelBLL();
        channelinfo channel = channelbll.Select(id);
        isMobileLiveStreamInt = channel.IsMobileLiveStream;
        if (isMobileLiveStreamInt == 1) {
            mobileLiveStramPlaybackPannel.Visible = true;
            ieStramPlayerPannel.Visible = false;
            otherBrowserStramPlayerPannel.Visible = false;
        }
        else {
            mobileLiveStramPlaybackPannel.Visible = false;
            browserFilter();
        }
    }

    private void browserFilter() {
        string UserBrowser = Request.Browser.Browser;
        if (UserBrowser.ToLower().Equals("ie"))
        {
            ieStramPlayerPannel.Visible = true;
            otherBrowserStramPlayerPannel.Visible = false;
        }
        else
        {
            ieStramPlayerPannel.Visible = false;
            otherBrowserStramPlayerPannel.Visible = true;
        }
    }

    protected void updateChannelBtn_Click(object sender, EventArgs e)
    {
        string ChannelNameStr = ChannelNameTB.Text.Trim();
        string ChannelMMSStr = ChannelMMSTB.Text.Trim();
        int isMobileLiveInt = IsMobileLiveCB.Checked ? 1 : 0;
        int isBroadCastInt = IsBroadCastCB.Checked ? 1 : 0;
        int isRecordInt = IsRecordCB.Checked ? 1 : 0;
        int statusInt = 0;
        if (ChannelNameStr.Length < 1) { ShowMessage("javascript", "频道名称不能为空！"); return; }
        if (ChannelMMSStr.Length < 1) { ShowMessage("javascript", "频道地址不能为空！"); return; }
        channelinfo channel = new channelinfo();
        if (id == null) id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
        channel.ChannelID = id;
        channel.ChannelName = ChannelNameStr;
        channel.ChannelMMS = ChannelMMSStr;
        channel.IsMobileLiveStream = isMobileLiveInt;
        channel.IsBroadcast = isBroadCastInt;
        channel.IsRecord = isRecordInt;
        channel.ConnectStatus = statusInt;
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
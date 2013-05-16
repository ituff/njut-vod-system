using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

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
        string filepath;
        string filename="";
        string serverpath;
        string ChannelNameStr = ChannelNameTB.Text.Trim();
        string ChannelMMSStr = ChannelMMSTB.Text.Trim();
        int isMobileLiveInt = IsMobileLiveCB.Checked ? 1 : 0;
        int isBroadCastInt = IsBroadCastCB.Checked ? 1 : 0;
        int isRecordInt = IsRecordCB.Checked ? 1 : 0;
        int statusInt = 0;
        if (ChannelNameStr.Length < 1) {  MessageBox.Show(this, "频道名称不能为空！"); return; }
        if (ChannelMMSStr.Length < 1) {  MessageBox.Show(this, "频道地址不能为空！"); return; }
        try
        {
            if (imgFU.PostedFile.FileName == "")
              {
                MessageBox.Show(this, "请选择上传文件！");
            }
            else
            {
                filepath = imgFU.PostedFile.FileName; 
                filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                serverpath = Server.MapPath("~/poster/") + filename;
                imgFU.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
            }
        }
        catch (Exception ex)
        {
             MessageBox.Show(this,"上传发生错误！原因是：" + ex.ToString());
        } 
        channelinfo channel = new channelinfo();
        channel.ChannelName = ChannelNameStr;
        channel.ChannelMMS = ChannelMMSStr;
        channel.IsMobileLiveStream = isMobileLiveInt;
        channel.IsBroadcast = isBroadCastInt;
        channel.IsRecord = isRecordInt;
        channel.ConnectStatus = statusInt;
        channel.UserId=Convert.ToInt32(Session["UserId"]);
        channel.PosterUrl = "poster/" + filename;
        ChannelBLL channelBll = new ChannelBLL();
        if (channelBll.Insert(channel))  MessageBox.Show(this, "添加成功！");
        else  MessageBox.Show(this, "添加失败！");
    }
}
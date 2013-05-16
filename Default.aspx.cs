using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string liveChannelStr;
    public string programStr;
    public string mobileLiveStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        liveChannelDataBind();
        programDataBind();
        mobileLiveDataBind();
    }

    /*
     * 绑定互联网直播
     */
    protected void liveChannelDataBind()
    {
        ChannelBLL channelBll = new ChannelBLL();
        DataSet ds = channelBll.getInternetLiveChannel();
        int i = 0;
        for (; i < 3; i++)
        {
            liveChannelStr += metroBind.wideTile(ds.Tables[0].Rows[i].ItemArray[3].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "channelUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
        for (; i < ds.Tables[0].Rows.Count; i++)
        {
            liveChannelStr += metroBind.squareTile(ds.Tables[0].Rows[i].ItemArray[3].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "channelUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
    }

    /*
     * 绑定热门视频
     */
    protected void programDataBind()
    {
        ProgramBLL programlBll = new ProgramBLL();
        DataSet ds = programlBll.getPrograms();
        int i = 0;
        for (; i < 3; i++)
        {
            programStr += metroBind.wideTile(ds.Tables[0].Rows[i].ItemArray[8].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "programUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
        for (; i < ds.Tables[0].Rows.Count; i++)
        {
            programStr += metroBind.squareTile(ds.Tables[0].Rows[i].ItemArray[8].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "programlUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
    }

    /*
     * 移动直播绑定
     */
    protected void mobileLiveDataBind()
    {
        ChannelBLL channelBll = new ChannelBLL();
        DataSet ds = channelBll.getMobileLiveChannel();
        int i = 0;
        for (; i < 3; i++)
        {
            mobileLiveStr += metroBind.wideTileWithText2Style(ds.Tables[0].Rows[i].ItemArray[3].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "channelUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
        for (; i < ds.Tables[0].Rows.Count; i++)
        {
            mobileLiveStr += metroBind.squareTile(ds.Tables[0].Rows[i].ItemArray[3].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString(), "channelUser.aspx?id=" + ds.Tables[0].Rows[i].ItemArray[0].ToString());
        }
    }

}
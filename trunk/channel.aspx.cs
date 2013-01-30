using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class channel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        authentication();
        if (!Page.IsPostBack)
        {
            dataBind();
        }
    }
    
    private void authentication(){
        if ((Session["status"]==null) || (!Session["status"].Equals("true"))) Response.Redirect("logout.aspx");
        if ((Session["type"]==null) || (!Session["type"].Equals("1"))) Response.Redirect("logout.aspx");
     }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        dataBind();
    }

    //数据绑定
    private void dataBind() {
        ChannelBLL channelbll = new ChannelBLL();
        DataSet myDS = channelbll.Select();
        if (myDS != null)
        {
            GridView1.DataSource = myDS;
            GridView1.DataBind();
        }
        else return;
    }

    //取消
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        dataBind();
    }

    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        ChannelBLL channelbll = new ChannelBLL();
        ShowMessage("javascript", "确定删除！");
        if (channelbll.Delete(GridView1.DataKeys[e.RowIndex].Value.ToString())) ShowMessage("javascript", "删除成功！");
        else ShowMessage("javascript", "删除失败！");
        dataBind();
    }

    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        channelinfo channel = new channelinfo();
        channel.ChannelID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        channel.ChannelName = ((HyperLink)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        channel.ChannelMMS= ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        ChannelBLL channelbll = new ChannelBLL();
        if (channelbll.Update(channel)) ShowMessage("javascript", "更新成功！");
        else ShowMessage("javascript", "更新失败！");
        GridView1.EditIndex = -1;
        dataBind();
    }

    //消息
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
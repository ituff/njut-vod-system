using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Program : System.Web.UI.Page
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
        ProgramBLL programbll = new ProgramBLL();
        DataSet myDS = programbll.Select();
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

        ProgramBLL programbll = new ProgramBLL();
        ShowMessage("javascript", "确定删除！");
        if (programbll.Delete(GridView1.DataKeys[e.RowIndex].Value.ToString())) ShowMessage("javascript", "删除成功！");
        else ShowMessage("javascript", "删除失败！");
        dataBind();
    }

    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        programinfo program = new programinfo();
        ChannelBLL channelbll = new ChannelBLL();
        ProgramBLL programbll = new ProgramBLL();
        program.ProgramID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        program.ProgramName = ((HyperLink)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        program.ProgramUrl= ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        program.ProgramDescribe = (programbll.Select(program.ProgramID)).ProgramDescribe;
        program.ChannelID = Convert.ToInt32(((HyperLink)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim());
        program.BeginTime = Convert.ToDateTime(((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim());
        program.EndTime = Convert.ToDateTime(((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim());
        if (programbll.Update(program)) ShowMessage("javascript", "更新成功！");
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
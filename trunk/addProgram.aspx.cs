using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

public partial class addProgram : System.Web.UI.Page
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


    protected void addProgramBtn_Click(object sender, EventArgs e)
    {
        string filepath;
        string filename = "";
        string serverpath;
        string ProgramNameStr = ProgramNameTB.Text.Trim();
        string ProgramUrlStr = ProgramUrlTB.Text.Trim();
        string ProgramDecribeStr = ProgramDecribeTB.Text.Trim();
        string ChannelIDStr = ChannelIDTB.Text.Trim();
        string BeginTimeStr = BeginTimeTB.Text.TrimStart().TrimEnd();
        string EndTimeStr = EndTimeTB.Text.TrimStart().TrimEnd();
        if (ProgramNameStr.Length < 1) {  MessageBox.Show(this, "节目名称不能为空！"); return; }
        if (ProgramUrlStr.Length < 1) {  MessageBox.Show(this, "节目地址不能为空！"); return; }
        if (ProgramDecribeStr.Length < 1) {  MessageBox.Show(this, "节目描述不能为空！"); return; }
        if (ChannelIDStr.Length < 1) {  MessageBox.Show(this, "频道编号不能为空！"); return; }
        if (BeginTimeStr.Length < 1) {  MessageBox.Show(this, "开始时间不能为空！"); return; }
        if (EndTimeStr.Length < 1) {  MessageBox.Show(this, "开始时间不能为空！"); return; }
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
            MessageBox.Show(this, "上传发生错误！原因是：" + ex.ToString());
        } 
        programinfo program = new programinfo();
        ChannelBLL channelBll = new ChannelBLL();
        program.ProgramName = ProgramNameStr;
        program.ProgramUrl = ProgramUrlStr;
        program.ProgramDescribe = ProgramDecribeStr;
        program.PostUrl = "poster/"+filename;
        try
        {
            if (channelBll.Select(Convert.ToInt32(ChannelIDStr)) != null) program.ChannelID = Convert.ToInt32(ChannelIDStr);
            else {  MessageBox.Show(this, "频道编号不存在！"); return; }
        }
        catch
        {
             MessageBox.Show(this, "频道编号不存在！"); return;
        }
        finally { }
        try
        {
            program.BeginTime = Convert.ToDateTime(BeginTimeStr);
        }
        catch
        {
             MessageBox.Show(this, "开始时间格式不正确！"); return;
        }
        finally { }
        try
        {
            program.EndTime = Convert.ToDateTime(EndTimeStr);
        }

        catch
        {
             MessageBox.Show(this, "结束时间格式不正确！"); return;
        }
        finally { }
        program.UserID = Convert.ToInt32(Session["UserId"]);
        ProgramBLL programBll = new ProgramBLL();
        if (programBll.Insert(program)) {  MessageBox.Show(this, "添加成功！"); }
        else  MessageBox.Show(this, "添加失败！");
    }
}
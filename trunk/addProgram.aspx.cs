﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        string ProgramNameStr = ProgramNameTB.Text.Trim();
        string ProgramUrlStr = ProgramUrlTB.Text.Trim();
        string ProgramDecribeStr = ProgramDecribeTB.Text.Trim();
        string ChannelIDStr = ChannelIDTB.Text.Trim();
        string BeginTimeStr = BeginTimeTB.Text.TrimStart().TrimEnd();
        string EndTimeStr = EndTimeTB.Text.TrimStart().TrimEnd();
        if (ProgramNameStr.Length < 1) { ShowMessage("javascript", "节目名称不能为空！"); return; }
        if (ProgramUrlStr.Length < 1) { ShowMessage("javascript", "节目地址不能为空！"); return; }
        if (ProgramDecribeStr.Length < 1) { ShowMessage("javascript", "节目描述不能为空！"); return; }
        if (ChannelIDStr.Length < 1) { ShowMessage("javascript", "频道编号不能为空！"); return; }
        if (BeginTimeStr.Length < 1) { ShowMessage("javascript", "开始时间不能为空！"); return; }
        if (EndTimeStr.Length < 1) { ShowMessage("javascript", "开始时间不能为空！"); return; }
        programinfo program = new programinfo();
        ChannelBLL channelBll = new ChannelBLL();
        program.ProgramName = ProgramNameStr;
        program.ProgramUrl = ProgramUrlStr;
        program.ProgramDescribe = ProgramDecribeStr;
        try
        {
            if (channelBll.Select(Convert.ToInt32(ChannelIDStr)) != null) program.ChannelID = Convert.ToInt32(ChannelIDStr);
            else { ShowMessage("javascript", "频道编号不存在！"); return; }
        }
        catch
        {
            ShowMessage("javascript", "频道编号不存在！"); return;
        }
        finally { }
        try
        {
            program.BeginTime = Convert.ToDateTime(BeginTimeStr);
        }
        catch
        {
            ShowMessage("javascript", "开始时间格式不正确！"); return;
        }
        finally { }
        try
        {
            program.EndTime = Convert.ToDateTime(EndTimeStr);
        }

        catch
        {
            ShowMessage("javascript", "结束时间格式不正确！"); return;
        }
        finally { }
        ProgramBLL programBll = new ProgramBLL();
        if (programBll.Insert(program)) { ShowMessage("javascript", "添加成功！"); }
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
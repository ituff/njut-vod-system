using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class flow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        authentication();
        if (!Page.IsPostBack)
        {
            initial();
        }
    }

    public string DomainName;//本机所在域

    public string ReceivedPackets;//接收数据包

    public string ReceivedPacketsForwarded;//转发数据包

    public string ReceivedPacketsDelivered;//传送数据包

    public string ReceivedPacketsDiscarded;//丢弃数据包

    protected void initial()
    {
        flowControl fc = new flowControl();
        flowInfo fi = fc.flowInformation();
        DomainName = fi.DomainName;
        ReceivedPackets = fi.ReceivedPackets;
        ReceivedPacketsForwarded = fi.ReceivedPacketsForwarded;
        ReceivedPacketsDelivered = fi.ReceivedPacketsDelivered;
        ReceivedPacketsDiscarded = fi.ReceivedPacketsDiscarded;
    }

    private void authentication()
    {
         if ((Session["status"]==null) || (!Session["status"].Equals("true"))) Response.Redirect("logout.aspx");
        if ((Session["type"]==null) || (!Session["type"].Equals("1"))) Response.Redirect("logout.aspx");
     }


}
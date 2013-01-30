using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///flow 的摘要说明
/// </summary>
public partial class flowInfo
{
    public flowInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private string _DomainName;//本机所在域

    public string DomainName
    {
        get { return _DomainName; }
        set { _DomainName = value; }
    }
    private string _ReceivedPackets;//接收数据包

    public string ReceivedPackets
    {
        get { return _ReceivedPackets; }
        set { _ReceivedPackets = value; }
    }
    private string _ReceivedPacketsForwarded;//转发数据包

    public string ReceivedPacketsForwarded
    {
        get { return _ReceivedPacketsForwarded; }
        set { _ReceivedPacketsForwarded = value; }
    }
    private string _ReceivedPacketsDelivered;//传送数据包

    public string ReceivedPacketsDelivered
    {
        get { return _ReceivedPacketsDelivered; }
        set { _ReceivedPacketsDelivered = value; }
    }
    private string _ReceivedPacketsDiscarded;//丢弃数据包

    public string ReceivedPacketsDiscarded
    {
        get { return _ReceivedPacketsDiscarded; }
        set { _ReceivedPacketsDiscarded = value; }
    }


}
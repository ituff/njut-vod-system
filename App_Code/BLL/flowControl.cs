using System;
using System.Collections.Generic;
using System.Web;
using System.Net.NetworkInformation;

/// <summary>
///flowControl 的摘要说明
///流量控制
/// </summary>
public class flowControl
{
    public flowControl(){}
    public flowInfo flowInformation()
    {
        flowInfo fi = new flowInfo();
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
        fi.DomainName = properties.DomainName;
        fi.ReceivedPackets = ipstat.ReceivedPackets.ToString();
        fi.ReceivedPacketsForwarded = ipstat.ReceivedPacketsForwarded.ToString();
        fi.ReceivedPacketsDelivered = ipstat.ReceivedPacketsDelivered.ToString();
        fi.ReceivedPacketsDiscarded = ipstat.ReceivedPacketsDiscarded.ToString();
        return fi;
    }

} 
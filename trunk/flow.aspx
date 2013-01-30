<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="flow.aspx.cs" Inherits="flow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<meta http-equiv="refresh" content="5;URL=flow.aspx">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        网络管理 &gt; <span>流量监控</span></div>
        <div class="controlarea ">
    <table>
        <tr>
            <td>
                网络情况
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                本机所在域：
            </td>
            <td>
                <%=DomainName%>
            </td>
        </tr>
        <tr>
            <td>
                接收数据包：
            </td>
            <td>
                <%=ReceivedPackets%>
            </td>
        </tr>
        <tr>
            <td>
                转发数据包：
            </td>
            <td>
                <%=ReceivedPacketsForwarded%>
            </td>
        </tr>
        <tr>
            <td>
                传送数据包：
            </td>
            <td>
                <%=ReceivedPacketsDelivered%>
            </td>
        </tr>
        <tr>
            <td>
                丢弃数据包：
            </td>
            <td>
                <%= ReceivedPacketsDiscarded%>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

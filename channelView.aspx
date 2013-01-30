<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="channelView.aspx.cs" Inherits="channelView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        频道管理&gt; <span>频道查看</span></div>
    <div class="controlarea ">
        <br />
        <p>
            频道名称：<asp:TextBox ID="ChannelNameTB" runat="server" Width="200px" MaxLength="30"></asp:TextBox></p>
        <p>
            频道地址：<asp:TextBox ID="ChannelMMSTB" runat="server" Width="350px" MaxLength="200"></asp:TextBox></p>
        <br />
        <object id="player" height='320' width='480' style="margin-left: auto; margin-right: auto;"
            classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param name="AutoStart" value="1">
            <param name="EnableContextMenu" value="1">
            <param name="url" value="<%=ChannelMMSStr %>">
        </object>
        <br />
        <p><asp:Button ID="updateChannelBtn" runat="server" Text="更新频道" onclick="updateChannelBtn_Click" 
                 />&nbsp; <input type="button" name="Submit" value="返回" onclick="javascript:history.back(1)" /></p>
    </div>
</asp:Content>

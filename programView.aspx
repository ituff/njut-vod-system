<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="programView.aspx.cs" Inherits="programView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        节目管理&gt; <span>节目查看</span></div>
    <div class="controlarea ">
        <br />
        <p>
            节目名称：<asp:TextBox ID="ProgramNameTB" runat="server" Width="200px" MaxLength="50"></asp:TextBox></p>
        <p>
            节目地址：<asp:TextBox ID="ProgramUrlTB" runat="server" Width="350px" MaxLength="200"></asp:TextBox></p>
        <p>
            节目描述：<asp:TextBox ID="ProgramDecribeTB" runat="server" Width="350px" MaxLength="500"
                TextMode="MultiLine"></asp:TextBox></p>
        <p>
            所属频道：<%=ChannelNameStr %><asp:TextBox ID="ChannelIDTB" runat="server" Width="50px"
                MaxLength="11" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox></p>
        <p>
            开始时间：<asp:TextBox ID="BeginTimeTB" runat="server" Width="200px"></asp:TextBox>
            <span style="color: Red">&nbsp;<span style="color: Red"> 格式：</span>“YYYY-MM-DD HH:MM:SS”</span></p>
        <p>
            结束时间：<asp:TextBox ID="EndTimeTB" runat="server" Width="200px"></asp:TextBox>
            <span style="color: Red">&nbsp;格式：“YYYY-MM-DD HH:MM:SS”</span></p>
        <br />
        <video src="<%=ProgramUrlStr %>" controls="controls" height="320px" width="480px"
            autoplay>
         <object id="player" height='320' width='480' style="margin-left: auto; margin-right: auto;"
            classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param name="AutoStart" value="1">
            <param name="EnableContextMenu" value="1">
            <param name="url" value="<%=ProgramUrlStr %>">
        </object>
</video>
        <br />
        <p>
            <asp:Button ID="updateChannelBtn" runat="server" Text="更新节目" OnClick="updateProgramBtn_Click" />&nbsp;
            <input type="button" name="Submit" value="返回" onclick="javascript:history.back(1)" /></p>
    </div>
</asp:Content>

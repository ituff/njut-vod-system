<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="addChannel.aspx.cs" Inherits="addChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        频道管理&gt; <span>添加频道</span>
    </div>
    <div class="controlarea ">
        <br />
        <p>
            频道名称：<asp:TextBox ID="ChannelNameTB" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
        </p>
        <p>
            频道地址：<asp:TextBox ID="ChannelMMSTB" runat="server" Width="350px" MaxLength="200"></asp:TextBox>
        </p>
        <p>
            直播封面：<asp:FileUpload ID="imgFU" runat="server" /></p>
        <p>移动直播：<asp:CheckBox ID="IsMobileLiveCB" runat="server" /></p>
        <p>是否广播：<asp:CheckBox ID="IsBroadCastCB" runat="server" /></p>
        <p>是否记录：<asp:CheckBox ID="IsRecordCB" runat="server" /></p>
        <br />
        <p>
            <asp:Button ID="addChannelBtn" runat="server" Text="添加新频道"
                OnClick="addChannelBtn_Click" />
        </p>
    </div>
</asp:Content>

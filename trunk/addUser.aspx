<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="addUser.aspx.cs" Inherits="addUser"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        用户信息管理&gt; <span>添加新的用户</span></div>
    <div class="controlarea ">
        <br />
        <p>
            用户名：<asp:TextBox ID="UserNameTB" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
        <p>
            用户密码：<asp:TextBox ID="UserPasswordTB" runat="server" Width="350px" MaxLength="50"></asp:TextBox></p>
            <p>
            用户邮箱：<asp:TextBox ID="UserEmailTB" runat="server" Width="350px" MaxLength="50"></asp:TextBox></p>
            <p>
            用户类型：<asp:DropDownList ID="UserTypeDDL" runat="server">
                    <asp:ListItem Value="1">系统管理员</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">普通用户</asp:ListItem>
                </asp:DropDownList>
            </p>
        <br />
        <p>
            <asp:Button ID="addChannelBtn" runat="server" Text="添加新用户" 
                onclick="addChannelBtn_Click" /></p>
    </div>
</asp:Content>

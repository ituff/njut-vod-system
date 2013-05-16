<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>欢迎注册 inTube！</title>
    <link rel="stylesheet" href="css/login.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginWindows">
             <a href="login.aspx" title="返回" style="margin-left:10px;"><img src="img/back.png" style="margin-top:10px;border:none;"/></a>
            <div id="title" style="margin-top:-38px;">
              注册inTube，立即分享Live！
            </div>
            <div id="inputWindows">
                <p>用户名：<asp:TextBox ID="username" Height="25px" Width="240px" runat="server" MaxLength="20" x-webkit-speech></asp:TextBox></p>
                <p>密&#12288;码：<asp:TextBox ID="password1" Height="25px" Width="240px" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></p>
               <p>请重复：<asp:TextBox ID="password2" Height="25px" Width="240px" runat="server" MaxLength="30" /></p>
                <p>邮&#12288;箱：<asp:TextBox ID="email" Height="25px" Width="240px" runat="server" x-webkit-speech /></p>
                <div id="btnDiv">
                    <asp:ImageButton ID="registerBtn" runat="server"  Height="45px" Width="45px" BorderStyle="None" Font-Size="18px" OnClick="registerBtn_Click" ImageUrl="~/img/save.png" ToolTip="注册" style="margin-top:-5px;"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

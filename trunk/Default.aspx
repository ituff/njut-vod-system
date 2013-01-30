<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="gb2312" />
    <title>VOD Online Demo</title>
    <!-- Favicons -->
    <link rel="shortcut icon" type="image/png" href="img/favicons/favicon.png" />
    <link rel="icon" type="image/png" href="img/favicons/favicon.png" />
    <link rel="apple-touch-icon" href="img/favicons/apple.png" />
    <!-- Main Stylesheet -->
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <!-- Colour Schemes
Default colour scheme is blue. Uncomment prefered stylesheet to use it.
<link rel="stylesheet" href="css/brown.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/gray.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/green.css" type="text/css" media="screen" />
<link rel="stylesheet" href="css/pink.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/red.css" type="text/css" media="screen" />
-->
    <!-- Your Custom Stylesheet -->
    <link rel="stylesheet" href="css/custom.css" type="text/css" />
    <!--swfobject - needed only if you require <video> tag support for older browsers -->
    <script type="text/javascript" src="js/swfobject.js"></script>
    <!-- jQuery with plugins -->
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <!-- Could be loaded remotely from Google CDN : <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script> -->
    <script type="text/javascript" src="js/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="js/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="js/jquery.ui.tabs.min.js"></script>
    <!-- jQuery tooltips -->
    <script type="text/javascript" src="js/jquery.tipTip.min.js"></script>
    <!-- Superfish navigation -->
    <script type="text/javascript" src="js/jquery.superfish.min.js"></script>
    <script type="text/javascript" src="js/jquery.supersubs.min.js"></script>
    <!-- jQuery form validation -->
    <script type="text/javascript" src="js/jquery.validate_pack.js"></script>
    <!-- jQuery popup box -->
    <script type="text/javascript" src="js/jquery.nyroModal.pack.js"></script>
    <!-- Internet Explorer Fixes -->
    <!--[if IE]>
<link rel="stylesheet" type="text/css" media="all" href="css/ie.css"/>
<script src="js/html5.js"></script>
<![endif]-->
    <!--Upgrade MSIE5.5-7 to be compatible with MSIE8: http://ie7-js.googlecode.com/svn/version/2.1(beta3)/IE8.js -->
    <!--[if lt IE 8]>
<script src="js/IE8.js"></script>
<![endif]-->
    <script type="text/javascript">

        $(document).ready(function () {

            /* setup navigation, content boxes, etc... */
            Administry.setup();

            // validate signup form on keyup and submit
            var validator = $("#loginform").validate({
                rules: {
                    username: "required",
                    password: "required"
                },
                messages: {
                    username: "Enter your username",
                    password: "Provide your password"
                },
                // the errorPlacement has to take the layout into account
                errorPlacement: function (error, element) {
                    error.insertAfter(element.parent().find('label:first'));
                },
                // set new class to error-labels to indicate valid fields
                success: function (label) {
                    // set &nbsp; as text for IE
                    label.html("&nbsp;").addClass("ok");
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Header -->
    <header id="top">
		<div class="wrapper-login">
			<!-- Title/Logo - can use text instead of image -->
			<div id="title"><img SRC="img/logo.png" alt="Administry" /><!--<span>Administry</span> demo--></div>
			<!-- Main navigation -->
			<nav id="menu">
				<ul class="sf-menu">
					<li class="current"><a href="Default.aspx">登录</a></li>
					<li><a href="register.aspx">注册</a></li>
				</ul>
			</nav>
			<!-- End of Main navigation -->
			<!-- Aside links -->

			<!-- End of Aside links -->
		</div>
	</header>
    <!-- End of Header -->
    <!-- Page title -->
    <div id="pagetitle">
        <div class="wrapper-login">
        </div>
    </div>
    <!-- End of Page title -->
    <!-- Page content -->
    <div id="page">
        <!-- Wrapper -->
        <div class="wrapper-login">
            <section>
				 <p>
        <label class="required" for="username">
            用户名:</label><br />
        <asp:TextBox ID="username" class="full" runat="server" 
            x-webkit-speech MaxLength="20"></asp:TextBox>
    </p>
    <p>
        <label class="required" for="password">
            密&nbsp;码:</label><br />
        <asp:TextBox ID="password" class="full" runat="server" TextMode="Password" 
            MaxLength="30"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="loginBtn" class="btn btn-green big" runat="server" Text="登录" 
            onclick="loginBtn_Click" />
    </p>	
				</section>
            <!-- End of login form -->
        </div>
        <!-- End of Wrapper -->
    </div>
    <!-- End of Page content -->
    <!-- Page footer -->
    <footer id="bottom">
		<div class="wrapper-login">
			<p>Copyright &copy; 2012 <b><a HREF="http://green.njut.edu.cn" title="Green Studio" style="text-decoration:none;">Green Studio</a></b></p>
		</div>
	</footer>
    <!-- End of Page footer -->
    <!-- User interface javascript load -->
    </form>
    <script type="text/javascript" src="js/administry.js"></script>
</body>
</html>

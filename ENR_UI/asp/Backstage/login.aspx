<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ENR_UI.asp.Backstage.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>小说资源网后台管理</title>
    <link href="../css/login.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
</head>
<body>
    <div id="nav"></div>
		<h1>小说资源网后台管理</h1>
		<div id="login-box">
			<h1>登    陆</h1>
			<div class="form">
                <form action="../../ashx/PersonalLogin.ashx" method="post">
                    <div class="item">
                        <i class="fa fa-user"></i>
                        <input name="userName" type="text" placeholder="userName" />
                    </div>
                    <div class="item">
                        <i class="fa fa-unlock-alt"></i>
                        <input name="userPwd" type="password" placeholder="userPwd" />
                    </div>
                    <input type="submit" value="登   陆" />
                </form>
			</div>
		</div>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/Reception.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="ENR_UI.asp.Reception.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/BusinessPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
			<div class="content-box">
				<h1>登     陆</h1>
                <form method="post" action="../../ashx/UserLogin.ashx" name="userLogin" onsubmit="">
				<div id="form">	
				<div class="item-box">
					<div class="item"><label>用户名</label><input type="text" name="userName" placeholder="请输入用户名"></div>
				</div>
				<div class="item-box">
					<div class="item"><label>密    码</label><input type="password" name="userPwd" placeholder="请输入密码"></div>
				</div>
				<div class="item-box">
					<div class="item"><input type="submit" name="Submit" value="确定"></div>
					<div class="item"><a href="UserRegister.aspx"><input type="button" name="Register" value="注册"></a></div>
					<div class="item"><input type="button" name="Cancel" value="取消"></div>
				</div>
			    </div>
		    </form>
			</div>
		</div>
</asp:Content>

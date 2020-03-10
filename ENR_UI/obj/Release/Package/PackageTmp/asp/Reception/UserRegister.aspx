<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/Reception.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="ENR_UI.asp.Reception.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/BusinessPage.css" rel="stylesheet" />
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
			<div class="content-box">
				<h1>用户注册</h1>
                <form method="post" action="../../ashx/AddUser.ashx" name="userRegister" onsubmit="">
				<div id="form">
                    <table class="FormTable">
                        <tr>
                            <td><label>用户名：</label></td>
                            <td><input type="text" name="userName" placeholder="请输入用户名"></td>
                        </tr>
                        <tr>
                            <td><label>电子邮件：</label></td>
                            <td><input type="text" name="userEmail" placeholder="请输入电子邮箱"></td>
                        </tr>
                        <tr>
                            <td><label>用户密码：</label></td>
                            <td><input type="text" name="userPwd" placeholder="请输入密码"></td>
                        </tr>
                        <tr>
                            <td><label>确认密码：</label></td>
                            <td><input type="text" name="userRepeatPwd" placeholder="请再次输入密码"></td>
                        </tr>
                        <tr>
                            <td class="TableButton" colspan="2">
                                <input type="submit" name="Submit" value="提交">
                                <input type="reset" name="Cancel" value="取消">
                            </td>
                        </tr>
                    </table>
				</div>
                    </form>
			</div>
		</div>
</asp:Content>

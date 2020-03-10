<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/BackHomepage.master" AutoEventWireup="true" CodeBehind="UserPwd.aspx.cs" Inherits="ENR_UI.asp.Reception.UserPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form">
        <form method="post" action="../../ashx/UserPwd.ashx" name="userPwd" onsubmit="">
        <table class="FormTable">
                <tr>
                    <td><label>原密码：</label></td>
                    <td><input type="password" name="Pwd" placeholder="请输入原密码"></td>
                </tr>
                <tr>
                    <td><label>新密码：</label></td>
                    <td><input type="password" name="userPwd" placeholder="请输入新密码"></td>
                </tr>
            <tr>
                    <td><label>确认新密码：</label></td>
                    <td><input type="password" name="CheckPwd" placeholder="请再次输入新密码"></td>
                </tr>
                <tr>
                    <td class="TableButton" colspan="2">
                        <input type="submit" name="Submit" value="提交">
                    </td>
                </tr>
        </table>
            </form>
    </div>
</asp:Content>

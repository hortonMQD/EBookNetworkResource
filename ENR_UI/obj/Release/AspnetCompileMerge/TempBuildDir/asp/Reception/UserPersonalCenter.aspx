<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/BackHomepage.master" AutoEventWireup="true" CodeBehind="UserPersonalCenter.aspx.cs" Inherits="ENR_UI.asp.Reception.UserPersonalCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" action="../../ashx/UserPersonalCenter.ashx" name="UserPersonalCenter" onsubmit="">
    <table class="FormTable">
                <tr>
                    <td><label>用户名：</label></td>
                    <td><input type="text" name="userName" value="<%=info.UName %>"></td>
                </tr>
                <tr>
                    <td><label>电子邮箱：</label></td>
                    <td><input type="text" name="userEmail" value="<%=info.Email %>"></td>
                </tr>
                <tr>
                    <td class="TableButton" colspan="2">
                        <input type="submit" name="Submit" value="提交">
                    </td>
                </tr>
        </table>
        </form>
</asp:Content>

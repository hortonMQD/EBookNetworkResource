<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="EmployeePersonalCenter.aspx.cs" Inherits="ENR_UI.asp.Backstage.EmployeePersonalCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox">
        <form action="../../ashx/EmployeePersonalCenter.ashx" method="post">
        <table class="FormTable">
            <tr>
                <td><label>姓名：</label></td>
                <td><input type="text" name="personalName" placeholder="请输入姓名" value="<%=info.Name %>"></td>
            </tr>
            <tr>
                <td><label>联系方式：</label></td>
                <td><input type="text" name="personalTelephone" placeholder="请输入联系电话" value="<%=info.Telephone %>"></td>
            </tr>
            <tr>
                <td><label>入职时间：</label></td>
                <td><%=info.CreateTime %></td>
            </tr>
            <tr>
                <td><label>部门：</label></td>
                <td><%=info.DepartmentName %></td>
            </tr>
            <tr>
                <td><label>权限：</label></td>
                <td><%=info.LimitName %></td>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="DepartmentInformation.aspx.cs" Inherits="ENR_UI.asp.Backstage.DepartmentInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox">
        <form method="post" action="../../ashx/DepartmentUpdate.ashx?departID=<%=departmentInfo.Id %>">
        <table class="FormTable">
            <tr>
                <td><label>部门名称：</label></td>
                <td><input type="text" name="departName" placeholder="请输入部门名称" value="<%=departmentInfo.Name %>"></td>
            </tr>
            <tr>
                <td><label>部门主管：</label></td>
                <td>
                    <select name="departLeader">
                        <option value="<%=departmentInfo.Id %>" selected="selected"><%=departmentInfo.LeaderName %></option>
                        <%for (int i = 0; i < personalInfos.ToArray().Length; i++) { %>
                        <option value="<%=personalInfos[i].Id %>"><%=personalInfos[i].Name %></option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <tr>
                <td><label>是否启用：</label></td>
                <td>
                    <select name="departIsTrue">
                        <%if (departmentInfo.IsTrue.Equals("0")){ %>
                            <option value="0" selected="selected">不启用</option>
                            <option value="1">启用</option>
                        <%} else { %>
                            <option value="0">不启用</option>
                            <option value="1" selected="selected">启用</option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <tr>
                <td><label>是否为行政部门：</label></td>
                <td>
                    <select name="departIsAdmin">
                        <%if (departmentInfo.IsAdmin.Equals("0")){ %>
                            <option value="0" selected="selected">否</option>
                            <option value="1">是</option>
                        <%} else { %>
                            <option value="0">否</option>
                            <option value="1" selected="selected">是</option>
                        <%} %>
                    </select>
                </td>
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

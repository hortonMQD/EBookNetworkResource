<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="ENR_UI.asp.Backstage.DepartmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formBox" style="text-align:center">
        <table class="FormTable">
            <tr>
                <td>序号</td>
                <td>部门名称</td>
                <td>部门主管</td>
                <td>创立时间</td>
                <td>是否为行政部门</td>
                <td>是否启用</td>
                <%if (personalInfo.Limit.Equals("010")) { %>
                <td>操作</td>
                <%} %>
            </tr>
            <%for (int i = contentIndex; i < departmentInfos.ToArray().Length & Count<15; i++) { %>
                <tr>
                    <td><%=i+1 %></td>
                    <td><%=departmentInfos[i].Name %></td>
                    <td><%=departmentInfos[i].LeaderName %></td>
                    <td><%=departmentInfos[i].CreateTime %></td>
                    <%if (departmentInfos[i].IsAdmin.Equals("1")) { %>
                        <td>是</td>
                    <%}else{ %>
                        <td>否</td>
                    <%} %>
                    <%if (departmentInfos[i].IsTrue.Equals("1")) { %>
                        <td>启用</td>
                    <%}else{ %>
                        <td>未启用</td>
                    <%} %>
                    <%if (personalInfo.Limit.Equals("010")) { %>
                    <td><a href="DepartmentInformation.aspx?departID=<%=departmentInfos[i].Id %>">修改</a></td>
                    <%} %>
                </tr>
            <% Count++; } %>
        </table>
        <div class="pageTool">
                <a href="DepartmentList.aspx?pageIndex=1">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="DepartmentList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="DepartmentList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>
                <%} %>
                
                <a href="DepartmentList.aspx?pageIndex=<%=pageTotal %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
    </div>
</asp:Content>

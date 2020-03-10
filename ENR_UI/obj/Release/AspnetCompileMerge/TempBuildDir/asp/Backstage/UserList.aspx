<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ENR_UI.asp.Backstage.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox" style=" text-align:center">
        <table class="FormTable">
            <tr>
                <td>序号</td>
                <td>用户名</td>
                <td>邮箱</td>
                <td>操作</td>
            </tr>
            <%if (userInfos.ToArray().Length != 0) { for (int i = contentIndex; i < userInfos.ToArray().Length; i++) { %>
                <tr>
                    <td><%=i + 1 %></td>
                    <td><%=userInfos[i].UName %></td>
                    <td><%=userInfos[i].Email %></td>
                    <td><a href="UserInformation.aspx?userID=<%=userInfos[i].Id %>">查看详情</a></td>
                </tr>
            <% Count++; } } else {  %>
                <tr>
                    <td rowspan="4">暂无用户数据</td>
                </tr>
            <%} %>
        </table>
        <div class="pageTool">
                <a href="UserList.aspx?pageIndex=1">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="UserList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="UserList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>
                <%} %>
                
                <a href="UserList.aspx?pageIndex=<%=pageTotal %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
    </div>
</asp:Content>

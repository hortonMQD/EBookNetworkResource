<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="ENR_UI.asp.Backstage.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox" style="text-align:center">
        <table class="FormTable">
            <tr>
                <td>序号</td>
                <td>用户名</td>
                <td>姓名</td>
                <td>所属部门</td>
                <td>权限</td>
                <td>联系电话</td>
                <td>入职时间</td>
                <td>是否离职</td>
                <td>离职时间</td>
                <td>操作</td>
            </tr>
            <%if (personalInfos.ToArray().Length != 0) { for (int i = contentIndex; i < personalInfos.ToArray().Length & Count < 15; i++) { %>
                <tr>
                    <td><%=i + 1 %></td>
                    <td><%=personalInfos[i].PId %></td>
                    <td><%=personalInfos[i].Name %></td>
                    <td><%=personalInfos[i].DepartmentName %></td>
                    <td><%=personalInfos[i].LimitName %></td>
                    <td><%=personalInfos[i].Telephone %></td>
                    <td><%=personalInfos[i].CreateTime %></td>
                    <%if (personalInfos[i].IsDimission.Equals("1")) { %>
                        <td>离职</td>
                    <%} else { %>
                        <td>在职</td>
                    <%} %>
                    <td><%=personalInfos[i].DimissionTime %></td>
                    <td><a href="EmployeeInformation.aspx?personalID=<%=personalInfos[i].Id %>">修改</a></td>
                </tr>
            <% Count++; } } else { %>
            <tr>
                <td rowspan="10">暂无员工数据</td>
            </tr>
            <%} %>
        </table>
        <div class="pageTool">
                <a href="EmployeeList.aspx?pageIndex=1">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="EmployeeList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="EmployeeList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>
                <%} %>
                
                <a href="EmployeeList.aspx?pageIndex=<%=pageTotal %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
    </div>
</asp:Content>

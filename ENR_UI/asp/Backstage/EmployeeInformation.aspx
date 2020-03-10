<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="EmployeeInformation.aspx.cs" Inherits="ENR_UI.asp.Backstage.EmployeeInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox">
        <form action="../../ashx/EmployeeInformation.ashx?personalID=<%=info.Id %>" method="post">
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
                <td>
                    <select name="departName">
                        <option value="<%=info.Department%>" selected="selected"><%=info.DepartmentName%></option>
                    <%for(int i = 0;i<departmentInfos.ToArray().Length;i++){  if (departmentInfos[i].Name.Equals("董事长办公室")) { continue; }%>
                            <option value="<%=departmentInfos[i].Id%>"><%=departmentInfos[i].Name%></option>
                    <% } %>
                    </select>
                </td>
            </tr>
            <tr>
                <td><label>权限：</label></td>
                <td>
                    <select name="limitName">
                        <option value="<%=info.Limit%>" selected="selected"><%=info.LimitName%></option>
                    <%for(int i = 0;i<limitInfos.ToArray().Length;i++){ %>
                            <option value="<%=limitInfos[i].Id%>"><%=limitInfos[i].Name%></option>
                    <% } %>
                    </select></td>
            </tr>
            <tr>

                <td>是否离职：</td>
                <td>
                    <select name="PersonalIsDimission">
                        <%if (info.IsDimission.Equals("0")){ %>
                            <option value="0" selected="selected">在职</option>
                            <option value="1">已离职</option>
                        <%} else { %>
                            <option value="0">在职</option>
                            <option value="1" selected="selected">已离职</option>
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

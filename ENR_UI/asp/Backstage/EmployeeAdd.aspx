<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="EmployeeAdd.aspx.cs" Inherits="ENR_UI.asp.Backstage.EmployeeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="formBox">
        <form action="../../ashx/EmployeeAdd.ashx" method="post">
        <table class="FormTable">
            <tr>
                <td><label>用户名：</label></td>
                <td><input type="text" name="Pid" placeholder="请输入用户名"></td>
            </tr>
            <tr>
                <td><label>姓名：</label></td>
                <td><input type="text" name="personalName" placeholder="请输入姓名"></td>
            </tr>
            <tr>
                <td><label>联系方式：</label></td>
                <td><input type="text" name="personalTelephone" placeholder="请输入联系电话"></td>
            </tr>
            <tr>
                <td><label>部门：</label></td>
                <td>
                    <select name="departName">
                        <%if (personalInfo.Limit.Equals("002")) { %>
                            <option value="<%=personalInfo.Department%>" selected="selected"><%=personalInfo.DepartmentName%></option>
                        <%}else if(personalInfo.Limit.Equals("010")){ for (int i = 0; i < departmentInfos.ToArray().Length; i++) { if (departmentInfos[i].IsAdmin.Equals("1") && departmentInfos[i].IsTrue.Equals("0")) { continue; }%>
                            <option value="<%=departmentInfos[i].Id%>"><%=departmentInfos[i].Name%></option>
                       <% }  }%>
                    </select>
                </td>
            </tr>
            <tr>
                <td><label>权限：</label></td>
                <td>
                    <select name="limitName">
                        <%if (personalInfo.Limit.Equals("010")) { for (int i = 0; i < limitInfos.ToArray().Length; i++) { %>
                            <option value="<%=limitInfos[i].Id%>"><%=limitInfos[i].Name%></option>
                        <% } } else if (personalInfo.Limit.Equals("002")) {%>
                            <option value="001" selected="selected">一级</option>
                        <% }%>
                    </select></td>
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

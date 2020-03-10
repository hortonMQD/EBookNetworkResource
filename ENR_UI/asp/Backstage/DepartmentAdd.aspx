<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="DepartmentAdd.aspx.cs" Inherits="ENR_UI.asp.Backstage.DepartmentAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form method="post" action="../../ashx/DepartmentAdd.ashx">
    <div class="formBox">
        <table class="FormTable">
            <tr>
                <td><label>部门名称：</label></td>
                <td><input type="text" name="departName" placeholder="请输入部门名称"></td>
            </tr>
            <tr>
                <td><label>部门主管：</label></td>
                <td>
                    <select name="departLeader">
                        <%for (int i = 0; i < personalInfos.ToArray().Length; i++) { %>
                        <option value="<%=personalInfos[i].Id %>"><%=personalInfos[i].Name %></option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <tr>
                <td><label>是否为行政部门：</label></td>
                <td>
                    <select name="departIsAdmin">
                            <option value="0">否</option>
                            <option value="1">是</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="TableButton" colspan="2">
                    <input type="submit" name="Submit" value="提交">
                    <input type="reset" value="取消" />
                </td>
            </tr>
        </table>
    </div>
      </form>

</asp:Content>

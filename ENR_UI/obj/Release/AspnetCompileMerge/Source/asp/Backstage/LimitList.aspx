<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="LimitList.aspx.cs" Inherits="ENR_UI.asp.Backstage.LimitList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox" style="text-align:center">
        <table class="FormTable">
            <tr>
                <td>序号</td>
                <td>权限名称</td>
                <td>可执行操作</td>
            </tr>
            <%for (int i = 0; i < limitInfos.ToArray().Length; i++){ %>
                <tr>
                    <td><%=i+1 %></td>
                    <td><%=limitInfos[i].Name %></td>
                    <td><%=limitInfos[i].Operation %></td>
                </tr>
            <%} %>
            
        </table>
    </div>
</asp:Content>

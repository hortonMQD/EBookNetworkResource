<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs" Inherits="ENR_UI.asp.Backstage.UserInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
    <link href="../css/color.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formBox" style="border:1px solid #ddd; text-align:center">
        <table class="FormTable">
            <tr>
                <td>用户名</td>
                <td>邮箱</td>
            </tr>
            <tr>
                <td><%=userInfo.UName %></td>
                <td><%=userInfo.Email %></td>
            </tr>
        </table>
    </div>
    <div class="formBox" style="border:1px solid #ddd; margin-top:20px;margin-bottom:20px; text-align:center">
        <table class="FormTable">
            <tr class="table-td-color">
                <td>序号</td>
                <td>小说名称</td>
                <td>作者</td>
                <td>连载状态</td>
                <td>小说类型</td>
                <td>上传时间</td>
                <td>是否删除</td>
                <td>审核结果</td>
                <td>审核人</td>
                <td>查看详情</td>
            </tr>
            <%for (int i = 0; i < bookInfos.ToArray().Length; i++){ %>
                <tr>
                    <td class="table-td-border-color"><%=i+1 %></td>
                    <td><%=bookInfos[i].Name %></td>
                    <td><%=bookInfos[i].Author %></td>
                    <td><%=bookInfos[i].SerialState %></td>
                    <td><%=bookInfos[i].BookTypeName %></td>
                    <td><%=bookInfos[i].UploadTime %></td>
                    <%if (bookInfos[i].IsDelete.Equals("1")){  %>
                        <td>已删除</td>
                    <%}else{ %>
                        <td>未删除</td>
                    <%} %>
                    
                    <td><%=bookInfos[i].IsPass %></td>
                    <td><%=bookInfos[i].PersonalName1 %></td>
                    <td><a href="AuditBookInformation.aspx?bookID=<%=bookInfos[i].Id %>">查看详情</a></td>
                </tr>
            <%} %>
        </table>
    </div>
</asp:Content>

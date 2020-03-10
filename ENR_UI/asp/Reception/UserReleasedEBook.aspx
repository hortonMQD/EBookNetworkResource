<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/BackHomepage.master" AutoEventWireup="true" CodeBehind="UserReleasedEBook.aspx.cs" Inherits="ENR_UI.asp.Reception.UserReleasedEBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/BusinessPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Content2">
		<div class="list">
            <ul>
                <%if (bookInfos.ToArray().Length != 0) {  for (int i = contentIndex; i < bookInfos.ToArray().Length & Count < 15; i++) {  %>
                <li>
                    <div class="s">
                        上传时间：<%=bookInfos[i].UploadTime %><br />
                        <%if (bookInfos[i].IsDelete.Equals("1"))
                            { %>  已删除<br /> 
                        审核结果：<%=bookInfos[i].IsPass %><br />
                        <%} else { %>
                        审核结果：<%=bookInfos[i].IsPass %><br />
                        操作：<a href="UserBookInformation.aspx?bookID=<%=bookInfos[i].Id %>">修改</a>、<a href="../../ashx/BookDelete.ashx?bookID=<%=bookInfos[i].Id %>">删除</a>
                        <%} %>
                        
                    </div>
                    <a href="UserBookInformation.aspx?bookID=<%=bookInfos[i].Id %>"><img src="../Img.aspx?url=../ashx/Covers/<%=bookInfos[i].ImageName %>"><%=bookInfos[i].Name %></a>
                    <div class="text">
                        <u><%=bookInfos[i].Text %></u>
                    </div>
                </li>
                <% Count++; } }else { %>
                        <li>暂无上传数据</li>
                <%} %>
            </ul>
		</div>
        <div class="pageTool">
                <a href="UserReleasedEBook.aspx?pageIndex=1">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="UserReleasedEBook.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="UserReleasedEBook.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>
                <%} %>
                
                <a href="UserReleasedEBook.aspx?pageIndex=<%=pageTotal %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
        </form>
</asp:Content>

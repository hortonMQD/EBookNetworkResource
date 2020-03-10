<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="ENR_UI.asp.Backstage.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/BusinessPage.css" />
    <link rel="stylesheet" href="../css/BackIndex.css" />
	<link rel="stylesheet" href="../css/font-awesome.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form ID="Content2">
	    <div class="list">
		    <ul>
                <%if (bookInfos.ToArray().Length != 0) {  for (int i = contentIndex; i < bookInfos.ToArray().Length & Count < 15; i++) { %>
                            <li>
                                <div class="s">
                                    作者：<%=bookInfos[i].Author %><br />
                                    大小：<%=bookInfos[i].FileSize %><br />
                                    状态：<%=bookInfos[i].SerialState %><br />
                                    上传时间：<%=bookInfos[i].UploadTime %>
                                </div>
                                <a href="AuditBookInformation.aspx?bookID=<%=bookInfos[i].Id %>"><img src="../Img.aspx?url=../ashx/Covers/<%=bookInfos[i].ImageName %>"><%=bookInfos[i].Name %></a>
                                <div class="text">
                                    <u><%=bookInfos[i].Text %></u>
                                </div>
                            </li>
                  <% Count++; } }else { %>
                        <li>
                            暂无书籍数据
                        </li>
                <%} %>
		    </ul>
    	</div>
        
        <div class="pageTool">
                <a href="BookList.aspx?pageIndex=1">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="BookList.aspx?pageIndex=<%=pageIndex-1 %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="BookList.aspx?pageIndex=<%=pageIndex+1 %>">下一页</a>
                <%} %>
                
                <a href="BookList.aspx?pageIndex=<%=pageTotal %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
    </form>
</asp:Content>

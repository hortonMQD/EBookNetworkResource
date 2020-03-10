<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/ReceptionInformation.master" AutoEventWireup="true" CodeBehind="ClassificationOfBooks.aspx.cs" Inherits="ENR_UI.asp.Reception.ClassificationOfBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right-box">
    <div class="on">
        <%if (departmentInfo.Id.Equals("20"))
            { %>
            <div class="title-box title-box-color"><div class="h1-color-box"><h1>最新电子书</h1></div></div>
        <%}
            else if (departmentInfo.Id.Equals("21"))
            { %>
            <div class="title-box title-box-color"><div class="h1-color-box"><h1>热门电子书</h1></div></div>
        <%}
            else
            {%>
            <div class="title-box title-box-color"><div class="h1-color-box"><h1><%=departmentInfo.Name %></h1></div></div>
        <%} %>
		<div class="list">
            <ul>
                <%if (bookInfos.ToArray().Length != 0) { for (int i = contentIndex; i < bookInfos.ToArray().Length & Count < 15; i++) { %>
                            <li>
                                <div class="s">
                                    作者：<%=bookInfos[i].Author %><br />
                                    大小：<%=bookInfos[i].FileSize %><br />
                                    状态：<%=bookInfos[i].SerialState %><br />
                                    上传时间：<%=bookInfos[i].UploadTime %>
                                </div>
                                <a href="BookInformation.aspx?bookID=<%=bookInfos[i].Id %>"><img onerror="<%=bookInfos[i].ImageUrl %>" src="../Img.aspx?url=../ashx/Covers/<%=bookInfos[i].ImageName %>"><%=bookInfos[i].Name %></a>
                                <div class="text">
                                    <u><%=bookInfos[i].Text %></u>
                                </div>
                            </li>
                  <% Count++; } }else { %>
                        <li>
                            暂无书籍数据
                        </li>
                  <%} %>
                <li>
            </ul>
		</div>
        
        <div class="pageTool">
                <a href="ClassificationOfBooks.aspx?pageIndex=1&departID=<%=departmentInfo.Id %>">首页</a>
                <%if (pageIndex == 1){%>
                上一页
                <%}else{ %>
                 <a href="ClassificationOfBooks.aspx?pageIndex=<%=pageIndex-1 %>&departID=<%=departmentInfo.Id %>">上一页</a>
                <%} %>
               
                <%if (pageIndex == pageTotal){%>
                下一页
                <%}else{ %>
                <a href="ClassificationOfBooks.aspx?pageIndex=<%=pageIndex+1 %>&departID=<%=departmentInfo.Id %>">下一页</a>
                <%} %>
                
                <a href="ClassificationOfBooks.aspx?pageIndex=<%=pageTotal %>&departID=<%=departmentInfo.Id %>">尾页</a>
                每页15条数据  当前是第<%=pageIndex %>页  共<%=pageTotal %>页，<%=total %>条数据
            </div>
    </div>	
        </div>
</asp:Content>

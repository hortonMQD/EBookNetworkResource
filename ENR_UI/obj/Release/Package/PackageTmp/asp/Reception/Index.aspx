<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/Reception.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ENR_UI.asp.Reception.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Index.css" rel="stylesheet" />
    <link href="../css/color.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <style>
        .text u{
	display: block;line-height: 25px;text-decoration: none;overflow: hidden;
}
        .text a img{
	width: 90px;
	height: 100px;
	float: left;
	margin-right: 12px;
	border: 0 none;
}
.text{
	overflow: hidden;margin-top: 5px;display:block;height: 75px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div id="content">
			<div id="left-box">
				<div class="top-box">
					<div class="title-box title-box-color">
						<div class="h1-color-box"><h1>最多点击</h1></div><a href="ClassificationOfBooks.aspx?departID=21" class="color-a">更多</a>
					</div>
					<div class="list-box">
						<ul>
                            <%for (int i = 0; i < 15 && i < DownLoadBookInfos.ToArray().Length; i++) { %>
                                    <li><u><em>作者：<%=DownLoadBookInfos[i].Author %></em><a href="BookInformation.aspx?bookID=<%=DownLoadBookInfos[i].Id %>"><%=DownLoadBookInfos[i].Name %></a></u></li>
                              <%} %>
						</ul>
					</div>
				</div>
				<div class="bottom-box">
					<div class="title-box title-box-color">
						<div class="h1-color-box"><h1>最新入库</h1></div><a href="ClassificationOfBooks.aspx?departID=20" class="color-a">更多</a>
					</div>
					<div class="list-box">
						<ul>
                            <%for (int i = 0; i < 20 && i < bookInfos.ToArray().Length; i++)
    { %>
                                <li><u><em>作者：<%=bookInfos[i].Author %></em><a href="BookInformation.aspx?bookID=<%=bookInfos[i].Id %>"><%=bookInfos[i].Name %></a></u></li>
                            <%} %>
						</ul>
					</div>
				
				</div>
			</div>
			<div id="right-box">
				<div class="top-box">
					<div class="title-box title-box-color">
						<div class="h1-color-box"><h1>电子书更新</h1></div><a href="ClassificationOfBooks.aspx?departID=20" class="color-a">更多</a>
					</div>
					<div class="list-box">
						<ul>
                            <%for (int i = 0; i < 10 && i < bookInfos.ToArray().Length; i++){ %>
                                    <li><u><em><%=bookInfos[i].UploadTime %></em><span>作者：<%=bookInfos[i].Author %></span><a href="#">[<%=bookInfos[i].BookTypeName %>]</a><a href="BookInformation.aspx?bookID=<%=bookInfos[i].Id %>"><%=bookInfos[i].Name %></a></u></li>
                              <%} %>
						</ul>
					</div>
				</div>
				<div class="bottom-box">
                    <%for (int i = 0; i < (departCount / 2 + departCount % 2); i++) { %>
                        <div class="listBox-box">
                             <%for (int z = 0; z < 2 && z < departmentInfos.ToArray().Length; z++) {
                                     int bookIndex = 0;%>
                                    <div class="ClassList-box">
							            <div class="title-box title-box-color">
								            <div class="h1-color-box"><h1><%=departmentInfos[0].Name %></h1></div><a href="ClassificationOfBooks.aspx?departID=<%=departmentInfos[0].Id %>" class="color-a">更多>></a>
                                        </div>
                                        <div class="list-box">
								            <ul>
                                                <%for (int y = 0; bookIndex < 5 && y < bookInfos.ToArray().Length; y++) { %>
                                                    <%if (bookInfos[y].BookTypeID.Equals(departmentInfos[0].Id)) {  if (bookIndex == 0) { %>
                                                        <li class="text" style="overflow: hidden;margin-top: 5px;margin-bottom:5px;display:block;height: 110px;">
                                                            <a href="BookInformation.aspx?bookID=<%=bookInfos[y].Id %>"><img  src="../Img.aspx?url=../ashx/Covers/<%=bookInfos[y].ImageName %>" onerror="<%=bookInfos[y].ImageUrl %>" style="width:90px;height:100px;margin-right:12px;margin-top: 5px;margin-bottom:5px;border: 0 none;"><%=bookInfos[y].Name %></a>
                                                            <div><u style="display: block;text-decoration: none;overflow:initial;line-height:initial;"><%=bookInfos[y].Text %></u></div>
                                                        </li>
                                                <%} else { %>
                                                        <li><u><em><%=bookInfos[y].UploadTime %></em><span>作者：<%=bookInfos[y].Author %></span><a href="ClassificationOfBooks.aspx?departID=<%=bookInfos[y].BookTypeID %>">[<%=bookInfos[y].BookTypeName %>]</a><a href="BookInformation.aspx?bookID=<%=bookInfos[y].Id %>"><%=bookInfos[y].Name %></a></u></li>
                                               <% }bookIndex++;} }%>
								            </ul>
							            </div>
							        </div>
                            <% departmentInfos.Remove(departmentInfos[0]);}%>
                            </div>
                    <%}%>
				</div>
			</div>
            </div>
</asp:Content>

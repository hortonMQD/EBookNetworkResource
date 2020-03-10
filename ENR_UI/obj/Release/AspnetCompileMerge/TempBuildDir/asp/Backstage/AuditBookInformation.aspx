<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Backstage/BackIndex.Master" AutoEventWireup="true" CodeBehind="AuditBookInformation.aspx.cs" Inherits="ENR_UI.asp.Backstage.AuditBookInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/BackIndex.css" />
	<link rel="stylesheet" href="../css/font-awesome.css" />
    <link rel="stylesheet" href="../css/BusinessPage.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Content2">
    <div class="right">
		<div class="top">
            <div class="left">
                <img src="../Img.aspx?url=../ashx/Covers/<%=info.ImageName %>" />
			</div>
			<div class="right">
                <h1><%=info.Name %></h1>
				<ul>
					<li>下载次数：<%=info.DownloadCount %></li>
					<li>文件大小：<%=info.FileSize %></li>
					<li>文件类型：txt</li>
                    <li>上传用户：<%=info.UploadUserText %></li>
					<li>上传时间：<%=info.UploadTime %></li>
					<li>连载状态：<%=info.SerialState %></li>
                    <li>小说类型：<%=info.BookTypeName %></li>
					<li>书籍作者：<%=info.Author %></li>
					<li>运行环境：安卓/iPhone/iPad/Kindle/平板</li>
				</ul>
			</div>
			</div>
        <div class="middle">
            <div class="title-box"><h1>小说详情</h1></div>
            <div class="text">
                <p><%=info.Text %></p>
				<br />
				<font>声明：本站提供TXT全集下载收集整理自网络，仅作为阅读交流之用，并无任何商业目的。版权归作者或出版社所有。如作者、出版社认为本站行为侵权，请联系本站，本站会立即删除您认为侵权的作品。</font>
				<p></p>
			</div>
        </div>
        <div class="bottom">
            <div class="title-box"><h1>下载地址</h1></div>
            <div>
                <ul>
                    <li>
                        <a class="downButton" href="../../ashx/Files/<%=info.FileName %>">小说文件下载</a>
                        <div class="text">兼容性最好的txt格式，支持所有设备</div>
					</li>
				</ul>
            </div>
        </div>
        <div class="AuditOpinion">
            <%if (!info.IsPass.Equals("未审核")){ %>
                <%if (info.IsPass.Equals("未通过")) {%>
                    审核结果：未通过<p /> 
                <%} else{ %>
                    审核结果：通过<p />
                <%} %>
                    审核意见：<%=info.Opinion1 %><p />
                    审核人：<%=info.PersonalName1 %>
            <%}else{ %>
                审核状态：未审核<p /> 
            <%} %>
        </div>
    </div>
    </div>
</asp:Content>

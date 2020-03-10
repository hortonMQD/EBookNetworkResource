<%@ Page Title="" Language="C#" MasterPageFile="~/asp/Reception/BackHomepage.master" AutoEventWireup="true" CodeBehind="UserBookInformation.aspx.cs" Inherits="ENR_UI.asp.Reception.UserBookInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/FormTableCss.css" rel="stylesheet" />
    <style type="text/css">
        .AuditOpinion {
        border: 1px solid #ddd;
        margin-top: 20px;
        margin-bottom: 20px;
        width: 100%;
    }
    </style>
    <script>
			
			function imgflush(g){	
				var f = new FileReader();
				f.readAsDataURL(g.files[0]);
				f.onload = function(){
					var img = document.getElementById("img-id");
                    img.src = f.result;
				}
			};
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form  method="post" enctype="multipart/form-data" action="../../ashx/UserUpdataBookInfomation.ashx?bookID=<%=info.Id %>" >
    <div id="form">
        <table class="FormTable">
                <tr>
                    <td class="TableButton" colspan="2"><img src="../Img.aspx?url=../ashx/Covers/<%=info.ImageName %>" id="img-id" style="width: 200px;height: 200px;"/></td>
                </tr>
                <tr>
                    <td><label>电子书封面：</label></td>
                    <td><input type="file" name="bookimage" id="bookImage" onchange="imgflush(this)"></td>
                </tr>
                <tr>
                    <td><label>图书名称：</label></td>
                    <td><input type="text" name="bookName" value="<%=info.Name %>"></td>
                </tr>
                 <tr>
                    <td><label>图书作者：</label></td>
                    <td><input type="text" name="bookAuthor" value="<%=info.Author%>" /></td>
                </tr>
                <tr>
                    <td><label>连载状态：</label></td>
                    <td>
                        <select name="bookState">
                            <%if (info.SerialState.Equals("已完结")) { %>
						    <option value="已完结"  selected="selected">已完结</option>
						    <option value="连载中">连载中</option>
                            <% } else { %>
                            <option value="已完结">已完结</option>
						    <option value="连载中" selected="selected">连载中</option>
                            <% } %>
					    </select>
                    </td>
                </tr>
                <tr>
                    <td><label>图书类型：</label></td>
                    <td>
                        <select name="bookType">
                            <option value="<%=info.BookTypeID%>" selected="selected"><%=info.BookTypeName%></option>
							<%for(int i = 0;i<departmentInfos.ToArray().Length;i++){  if (departmentInfos[i].Name.Equals("董事长办公室")) { continue; } %>
                            <option value="<%=departmentInfos[i].Id%>"><%=departmentInfos[i].Name%></option>
                            <% } %>
						</select>
                    </td>
                </tr>
                <tr>
                    <td><label>书籍简介：</label></td>
                    <td><textarea name="bookText" cols="80" rows="10" placeholder="请输入书籍简介"><%=info.Text%></textarea></td>
                </tr>
                <tr>
                    <td><label>新电子书文件上传：</label></td>
                    <td><input type="file" name="bookFile"></td>
                </tr>
                <tr>
                    <td colspan="2"><a href="../../ashx/Files/<%=info.FileName %>" download="">电子书文件下载</a></td>
                </tr>
            <%if (!info.IsDelete.Equals("1")){  %>
                <tr>
                    <td class="TableButton" colspan="2">
                        <input type="submit" name="Submit" value="提交">
                    </td>
                </tr>
            <%} %>
        </table>
    </div>
    </form>
    <div class="AuditOpinion">
            审核状态：<%=info.IsPass %><p />
            审核意见：<%=info.Opinion1 %><p />
        <%if (info.IsPass.Equals("未审核")) { %>  审核人：无  <%} else { %>  审核人:<%=personalName %>  <% } %>
        </div>
</asp:Content>

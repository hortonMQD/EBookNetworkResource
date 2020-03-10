using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ENR_UI.ashx
{
    /// <summary>
    /// UserUpdataBookInfomation 的摘要说明
    /// </summary>
    public class UserUpdataBookInfomation : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            bool result = isTrue(context);
            if (result)
            {
                HttpRequest request = context.Request;
                context.Response.ContentType = "text/html";
                HttpPostedFile file = request.Files["bookFile"];
                BookInfo info = getData(context, request,file);

                HttpPostedFile img = request.Files["bookImage"];      //获得第一个文件
                if (img.ContentLength > 0)
                {
                    info.ImageName = Path.GetFileName(img.FileName);
                    info.ImageUrl = request.MapPath("Covers/" + info.ImageName);
                }
                else { setImgUrlAndName(info); }


                if (new BookService().Updata(info))
                {
                    saveFile(file, img, request, info);
                    context.Session.Add("userID", info.UploadUserID);
                    Alert.AlertMessage("修改成功");
                    context.Response.Redirect("../asp/Reception/UserBookInformation.aspx?bookID=" + info.Id);
                } else {  Alert.AlertFailed("修改失败,请检查填写信息");  }

            } else { Alert.AlertFailed("修改失败,请将相关信息填写完整"); }
        }

        private void saveFile(HttpPostedFile file, HttpPostedFile img, HttpRequest request, BookInfo info)
        {
            if (request.Files["bookImage"].ContentLength > 0) { img.SaveAs(info.ImageUrl); }
            if (request.Files["bookFile"].ContentLength > 0) { file.SaveAs(info.FileUrl); }
        }

        private BookInfo setImgUrlAndName(BookInfo info)
        {
            info.ImageName = "暂无封面.jpg";
            info.ImageUrl = "../img/暂无封面.jpg";
            return info;
        }

        private BookInfo getData(HttpContext context, HttpRequest request, HttpPostedFile file)
        {
            BookInfo info = new BookInfo();
            info.Name = request["bookName"];
            info.Author = request["bookAuthor"];
            info.SerialState = request["bookState"];
            info.BookTypeID = request["bookType"];
            info.Text = request["bookText"];
            info.OldID = request["bookID"];
            info.UploadUserID = context.Session["userID"].ToString();
            info.FileName = Path.GetFileName(file.FileName);
            info.FileSize = file.ContentLength.ToString();
            info.FileUrl = request.MapPath("Files/" + info.FileName); //根据相对路径获取绝对路径，并追加文件名开始保存
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["bookName"] == null) { return false; }
            if (context.Request["bookAuthor"] == null) { return false; }
            if (context.Request["bookState"] == null) { return false; }
            if (context.Request["bookType"] == null) { return false; }
            if (context.Request["bookText"] == null) { return false; }
            if (context.Request.Files["bookFile"].ContentLength == 0) { return false; }
            return true;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
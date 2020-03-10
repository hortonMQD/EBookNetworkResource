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
    /// UserUploadEBook 的摘要说明
    /// </summary>
    public class UserUploadEBook : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                HttpRequest request = context.Request;
                context.Response.ContentType = "text/html";
                HttpPostedFile file = request.Files["bookFile"];
                BookInfo info = getData(context,file);
                HttpPostedFile img = null;
                if (request.Files["bookImage"].ContentLength > 0)
                {
                    img = request.Files["bookImage"];
                    info.ImageName = Path.GetFileName(img.FileName);
                    info.ImageUrl = request.MapPath("Covers/" + info.ImageName);
                } else { info = setImgUrlAndName(info); }

                if (new BookService().Add(info))
                {
                    saveFile(file, img, context, info);
                    context.Session.Add("userID", info.UploadUserID);
                    Alert.AlertMessage("上传成功");
                    context.Response.Redirect("../asp/Reception/UserUploadEbook.aspx");
                }
                else
                {
                    Alert.AlertMessage("上传失败，请重新上传");
                }
            }
            else
            {
                Alert.AlertMessage("上传失败，请将相关信息填写完整");
            }
        }


        private void saveFile(HttpPostedFile file, HttpPostedFile img, HttpContext context,BookInfo info)
        {
            if (context.Request.Files["bookImage"].ContentLength > 0) { img.SaveAs(info.ImageUrl); }
            if (context.Request.Files["bookFile"].ContentLength > 0) { file.SaveAs(info.FileUrl); }
        }


        private BookInfo setImgUrlAndName(BookInfo info)
        {
            info.ImageName = "暂无封面.jpg";
            info.ImageUrl = "../img/暂无封面.jpg";
            return info;
        }

        private BookInfo getData(HttpContext context,HttpPostedFile file)
        {
            BookInfo info = new BookInfo();
            info.Name = context.Request["bookName"];
            info.Author = context.Request["bookAuthor"];
            info.SerialState = context.Request["bookState"];
            info.BookTypeID = context.Request["bookType"];
            info.Text = context.Request["bookText"];
            info.UploadUserID = context.Session["userID"].ToString();
            info.FileName = Path.GetFileName(file.FileName);
            info.FileSize = file.ContentLength.ToString();
            info.FileUrl = context.Request.MapPath("Files/" + info.FileName); //根据相对路径获取绝对路径，并追加文件名开始保存
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
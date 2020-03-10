using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ENR_UI.ashx
{
    /// <summary>
    /// BookDelete 的摘要说明
    /// </summary>
    public class BookDelete : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            context.Response.ContentType = "text/html";
            BookInfo info = new BookInfo();
            info.Id = request["bookID"];
            if (new BookService().Delete(info))
            {
                Alert.AlertMessage("删除成功");
                context.Response.Redirect("../asp/Reception/UserReleasedEBook.aspx");
            }
            else
            {
                Alert.AlertFailed("删除失败");
            }
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
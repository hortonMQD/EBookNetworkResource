using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// DownLoad 的摘要说明
    /// </summary>
    public class DownLoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            context.Response.ContentType = "text/plain";
            BookInfo info = new BookInfo();
            info.Id = request["bookID"];
            BookService service = new BookService();
            if (service.UpdataDownload(info))
            {
                     
                context.Response.Redirect("../asp/Reception/BookInformation.aspx?bookID="+info.Id);
            }
            else
            {
                context.Response.Redirect("../asp/Reception/BookInformation.aspx?bookID=" + info.Id);
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
using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// Select 的摘要说明
    /// </summary>
    public class Select : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            context.Response.ContentType = "text/plain";
            context.Response.Redirect("../asp/Reception/ClassificationOfBooks.aspx?departID=22&bookName="+ request["bookName"]);
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
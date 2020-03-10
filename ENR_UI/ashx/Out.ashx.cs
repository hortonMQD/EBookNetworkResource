using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ENR_UI.ashx
{
    /// <summary>
    /// Out 的摘要说明
    /// </summary>
    public class Out : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Session.Contents.RemoveAll();
            context.Session.Abandon();
            Alert.AlertMessage("您已退出登录");
            context.Response.Redirect("../asp/Reception/Index.aspx");
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
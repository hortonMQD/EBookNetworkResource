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
    /// UserPersonalCenter 的摘要说明
    /// </summary>
    public class UserPersonalCenter : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                UserInfo info = getData(context);

                UserService service = new UserService();
                if (service.Update(info))
                {
                    Alert.AlertMessage("修改成功");
                    context.Session.Add("userID", info.Id);
                    context.Response.Redirect("../asp/Reception/UserPersonalCenter.aspx");
                } else { Alert.AlertFailed("修改失败，请检查填写的信息"); }

            } else { Alert.AlertFailed("修改失败，请检查填写的信息"); }
        }

        private UserInfo getData(HttpContext context)
        {
            UserInfo info = new UserInfo();
            info.Id = context.Session["userID"].ToString();
            info.UName = context.Request["userName"];
            info.Email = context.Request["userEmail"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["userName"] == null) { return false; }
            if (context.Request["userEmail"] == null) { return false; }
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
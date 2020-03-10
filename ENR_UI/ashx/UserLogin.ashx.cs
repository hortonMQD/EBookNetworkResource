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
    /// UserLogin 的摘要说明
    /// </summary>
    public class UserLogin : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                UserInfo info = getData(context);
                UserService service = new UserService();
                List<UserInfo> resultCount = service.SelectWithParamter(info);
                if (resultCount.ToArray().Length > 0)
                {
                    Alert.AlertMessage("登陆成功");
                    context.Session.Add("userID", resultCount[0].Id);
                    context.Response.Redirect("../asp/Reception/UserPersonalCenter.aspx");
                } else { Alert.AlertFailed("登陆失败，用户名或密码错误"); }
            } else { Alert.AlertFailed("登陆失败，用户名或密码错误"); }
            
        }

        private UserInfo getData(HttpContext context)
        {
            UserInfo info = new UserInfo();
            info.Id = null;
            info.Pwd = context.Request["userPwd"];
            info.UName = context.Request["userName"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["userName"] == null) { return false; }
            if (context.Request["userPwd"] == null) { return false; }
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
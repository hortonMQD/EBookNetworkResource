using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                UserInfo info = getData(context);

                UserService service = new UserService();
                if (service.Add(info))
                {
                    Alert.AlertMessage("注册成功");
                    context.Session.Add("userID", info.Id);
                    context.Response.Redirect("../asp/Reception/UserPersonalCenter.aspx");
                }
                else { Alert.AlertFailed("注册失败，请重试"); }
            } else { Alert.AlertFailed("注册失败，请检查输入数据是否为空"); }
            
        }


        private UserInfo getData(HttpContext context)
        {
            UserInfo info = new UserInfo();
            info.Pwd = context.Request["userPwd"];
            info.UName = context.Request["userName"];
            info.Email = context.Request["userEmail"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["userName"] == null) { return false; }
            if (context.Request["userEmail"] == null) { return false; }
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
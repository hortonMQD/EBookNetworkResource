
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
    /// UserPwd 的摘要说明
    /// </summary>
    public class UserPwd : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                HttpRequest request = context.Request;
                context.Response.ContentType = "text/html";
                UserInfo info = new UserInfo();
                info.Id = context.Session["userID"].ToString();
                info.Pwd = request["Pwd"];

                UserService service = new UserService();
                if (service.SelectWithParamter(info).ToArray().Length > 0)
                {
                    info.Pwd = request["userPwd"];
                    if (service.UpdatePwd(info))
                    {
                        Alert.AlertMessage("修改成功");
                        context.Session.Add("userID", info.Id);
                        context.Response.Redirect("../asp/Reception/UserPwd.aspx");
                    } else { Alert.AlertFailed("修改失败，请检查填写的信息"); }

                } else { Alert.AlertFailed("修改失败，请检查填写的信息"); }

            } else { Alert.AlertFailed("修改失败，请检查填写的信息"); }
        }


        private bool isTrue(HttpContext context)
        {
            if (context.Request["Pwd"] == null) { return false; }
            if (context.Request["userPwd"] != null && context.Request["checkPwd"] != null)
            {
                if (!context.Request["userPwd"].Equals(context.Request["checkPwd"])) { return false; }
            } else { return false; }
            
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
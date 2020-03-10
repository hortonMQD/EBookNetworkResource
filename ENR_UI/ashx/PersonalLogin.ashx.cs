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
    /// PersonalLogin 的摘要说明
    /// </summary>
    public class PersonalLogin : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/plain";
                PersonalInfo info = getData(context);

                PersonalService service = new PersonalService();
                List<PersonalInfo> resultCount = service.SelectWithParameter(info);

                if (resultCount.ToArray().Length > 0)
                {
                    for (int i = 0; i < resultCount.ToArray().Length; i++)
                    {
                        if (resultCount[i].PId.Equals(info.PId) && resultCount[i].Pwd.Equals(info.Pwd))
                        {
                            Alert.AlertMessage("登陆成功");
                            context.Session.Add("personalID", resultCount[i].Id);
                            context.Response.Redirect("../asp/Backstage/EmployeePersonalCenter.aspx");
                        }
                        else { Alert.AlertFailed("登陆失败，用户名或密码错误"); }
                    }

                } else { Alert.AlertFailed("登陆失败，请确定是否有此用户"); }

            } else { Alert.AlertFailed("登陆失败，用户名或密码错误"); }
        }


        private PersonalInfo getData(HttpContext context)
        {
            PersonalInfo info = new PersonalInfo();
            info.Id = null;
            info.Pwd = context.Request["userPwd"];
            info.PId = context.Request["userName"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["userPwd"] == null) { return false; }
            if (context.Request["userName"] == null) { return false; }
            return false;
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
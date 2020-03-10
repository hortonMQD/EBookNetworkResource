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
    /// EmployeePwd 的摘要说明
    /// </summary>
    public class EmployeePwd : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                HttpRequest request = context.Request;
                context.Response.ContentType = "text/html";
                PersonalInfo info = new PersonalInfo();
                info.Id = context.Session["personalID"].ToString();
                info.Pwd = request["Pwd"];

                PersonalService service = new PersonalService();
                if (service.SelectWithParameter(info).ToArray().Length > 0)
                {
                    info.Pwd = request["NewPwd"];
                    if (service.Update(info))
                    {
                        Alert.AlertMessage("修改成功");
                        context.Session.Add("personalID", info.Id);
                        context.Response.Redirect("../asp/Backstage/EmployeePwd.aspx");
                    } else { Alert.AlertFailed("修改失败，请重试"); }
                } else { Alert.AlertFailed("修改失败，原密码错误"); }
            } else { Alert.AlertFailed("修改失败，请检查填写内容是否正确"); }
        }


        private bool isTrue(HttpContext context)
        {
            if (context.Request["Pwd"] == null) { return false; }
            if (context.Request["NewPwd"] != null && context.Request["CheckPwd"] != null)
            {
                if (!context.Request["NewPwd"].Equals(context.Request["CheckPwd"])) { return false; }
            }
            else
            {
                return false;
            }
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
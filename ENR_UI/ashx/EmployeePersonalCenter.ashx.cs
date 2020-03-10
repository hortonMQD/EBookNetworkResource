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
    /// EmployeePersonalCenter 的摘要说明
    /// </summary>
    public class EmployeePersonalCenter : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                PersonalInfo info = getData(context);

                PersonalService service = new PersonalService();
                if (service.Update(info))
                {
                    Alert.AlertMessage("修改成功");
                    context.Session.Add("personalID", info.Id);
                    context.Response.Redirect("../asp/Backstage/EmployeePersonalCenter.aspx");
                } else { Alert.AlertFailed("修改失败"); }
            } else { Alert.AlertFailed("修改失败，请检查输入信息是否为空"); }
            
        }

        private PersonalInfo getData(HttpContext context)
        {
            PersonalInfo info = new PersonalInfo();
            info.Id = context.Session["personalID"].ToString();
            info.Name = context.Request["personalName"];
            info.Telephone = context.Request["personalTelephone"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if(context.Request["personalName"] == null) { return false; }
            if (context.Request["personalTelephone"] == null) { return false; }
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
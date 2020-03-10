using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// EmployeeAdd 的摘要说明
    /// </summary>
    public class EmployeeAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                PersonalInfo info = getData(context);

                PersonalService service = new PersonalService();
                if (service.Add(info))
                {
                    Alert.AlertMessage("入职成功");
                    context.Response.Redirect("../asp/Backstage/EmployeeAdd.aspx");
                }
                else { Alert.AlertFailed("入职失败"); }
            } else { Alert.AlertFailed("入职失败，请检查填写数据是否完整"); }
            
        }

        private PersonalInfo getData(HttpContext context)
        {
            PersonalInfo info = new PersonalInfo();
            info.PId = context.Request["Pid"];
            info.Name = context.Request["personalName"];
            info.Telephone = context.Request["personalTelephone"];
            info.Limit = context.Request["limitName"];
            info.Department = context.Request["departName"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["Pid"] == null) { return false; }
            if (context.Request["personalName"] == null) { return false; }
            if (context.Request["personalTelephone"] == null) { return false; }
            if (context.Request["limitName"] == null) { return false; }
            if (context.Request["departName"] == null) { return false; }
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
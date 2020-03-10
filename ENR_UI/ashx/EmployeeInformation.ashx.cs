using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// EmployeeInformation 的摘要说明
    /// </summary>
    public class EmployeeInformation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                PersonalInfo info = getData(context);
                if (new PersonalService().Update(info))
                {
                    Alert.AlertMessage("修改成功");
                    context.Response.Redirect("../asp/Backstage/EmployeeInformation.aspx?personalID=" + info.Id);
                }
                else { Alert.AlertFailed("修改失败"); }
            } else { Alert.AlertFailed("修改失败，请检查填写数据是否为空"); }
            
        }

        private PersonalInfo getData(HttpContext context)
        {
            PersonalInfo info = new PersonalInfo();
            info.Id = context.Request["personalID"];
            info.Name = context.Request["personalName"];
            info.Telephone = context.Request["personalTelephone"];
            info.Department = context.Request["departName"];
            info.Limit = context.Request["limitName"];
            info.IsDimission = context.Request["PersonalIsDimission"];
            return info;
        }


        private bool isTrue(HttpContext context)
        {
            if (context.Request["personalID"] == null) { return false; }
            if (context.Request["personalName"] == null) { return false; }
            if (context.Request["personalTelephone"] == null) { return false; }
            if (context.Request["departName"] == null) { return false; }
            if (context.Request["limitName"] == null) { return false; }
            if (context.Request["PersonalIsDimission"] == null) { return false; }
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
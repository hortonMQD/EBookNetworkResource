using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
    /// <summary>
    /// DepartmentUpdate 的摘要说明
    /// </summary>
    public class DepartmentUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                DepartmentInfo info = getData(context);

                DepartmentService service = new DepartmentService();
                if (!service.UpdateDepartmentWithParameter(info))
                {
                    Alert.AlertMessage("修改成功");
                    context.Response.Redirect("../asp/Backstage/DepartmentInformation.aspx?departID=" + info.Id);
                }
                else { Alert.AlertFailed("修改失败"); }
            } else { Alert.AlertFailed("修改失败，请检查输入数据是否为空"); }
            
        }

        private DepartmentInfo getData(HttpContext context)
        {
            DepartmentInfo info = new DepartmentInfo();
            info.Id = context.Request["departID"];
            info.Name = context.Request["departName"];
            info.Leader = context.Request["departLeader"];
            info.IsTrue = context.Request["departIsTrue"];
            info.IsAdmin = context.Request["departIsAdmin"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["departID"] == null) { return false; }
            if (context.Request["departName"] == null) { return false; }
            if (context.Request["departLeader"] == null) { return false; }
            if (context.Request["departIsTrue"] == null) { return false; }
            if (context.Request["departIsAdmin"] == null) { return false; }
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
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
    /// UpdateAuditOpinion 的摘要说明
    /// </summary>
    public class UpdateAuditOpinion : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool result = isTrue(context);
            if (result)
            {
                context.Response.ContentType = "text/html";
                AuditOpinionInfo info = getData(context);
                if (new AuditService().Update(info))
                {
                    Alert.AlertMessage("审核成功");
                    context.Session.Add("personalID", info.Auditor);
                    context.Response.Redirect("../asp/Backstage/UnAuditedList .aspx");
                } else { Alert.AlertFailed("审核失败，请检查填写的信息"); }

            } else { Alert.AlertFailed("审核失败，请检查填写的信息"); }

        }

        private AuditOpinionInfo getData(HttpContext context)
        {
            AuditOpinionInfo info = new AuditOpinionInfo();
            info.Id = context.Request["bookID"];
            info.Auditor = context.Session["personalID"].ToString();
            info.Opinion = context.Request["opinion"];
            info.IsPass = context.Request["auditResult"];
            return info;
        }

        private bool isTrue(HttpContext context)
        {
            if (context.Request["bookID"] == null) { return false; }
            if (context.Request["opinion"] == null) { return false; }
            if (context.Request["auditResult"] == null) { return false; }
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
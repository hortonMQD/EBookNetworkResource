using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENR_UI.ashx
{
     class Alert
    {
        /// <summary>
        /// 跳转到登录成功页面
        /// </summary>
        /// <param name="url">跳转链接</param>
        /// <param name="message"></param>
        public static void Redirect(string url, string message = "登录成功")
        {
            ResponseScript("window.location = '" + url + "';");
        }

        /// <summary>
        /// 弹框，并返回上一页
        /// </summary>
        /// <param name="message"></param>
        public static void AlertFailed(string message)
        {
            ResponseScript("alert('" + message + "');javascript:history.go(-1);");
        }


        /// <summary>
        /// 弹框
        /// </summary>
        /// <param name="message"></param>
        public static void AlertMessage(string message = "登录失败")
        {
            ResponseScript("alert('" + message + "');");
        }



        /// <summary>
        /// Script脚本
        /// </summary>
        /// <param name="script"></param>
        public static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n//<![CDATA[\n");
            HttpContext.Current.Response.Write(script);
            HttpContext.Current.Response.Write("\n//]]>\n</script>\n");
        }
    }
}
using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENR_UI.asp.Reception
{
    public partial class UserPersonalCenter : System.Web.UI.Page
    {
        protected UserInfo info = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserService service = new UserService();
            info.Id = Session["userID"].ToString();
            info = service.SelectWithParamter(info)[0];
        }
    }
}
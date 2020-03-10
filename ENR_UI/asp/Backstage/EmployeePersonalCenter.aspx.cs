using ENR_Bll;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENR_UI.asp.Backstage
{
    public partial class EmployeePersonalCenter : System.Web.UI.Page
    {
        protected PersonalInfo info = new PersonalInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            info.Id = Session["personalID"].ToString();
            info = new PersonalService().SelectWithParameter(info)[0];
            Session["personalID"] = info.Id;
        }
    }
}
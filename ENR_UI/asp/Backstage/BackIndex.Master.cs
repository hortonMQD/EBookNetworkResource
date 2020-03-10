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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected PersonalInfo info = new PersonalInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalService service = new PersonalService();
            info.Id = Session["personalID"].ToString();
            info = service.SelectWithParameter(info)[0];
        }
    }
}
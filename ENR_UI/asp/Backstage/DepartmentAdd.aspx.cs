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
    public partial class DepartmentAdd : System.Web.UI.Page
    {
        protected List<PersonalInfo> personalInfos = new List<PersonalInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalInfo info = new PersonalInfo();
            info.Id = null;
            info.IsDimission = "0";
            personalInfos = new PersonalService().SelectWithParameter(info);
        }
    }
}
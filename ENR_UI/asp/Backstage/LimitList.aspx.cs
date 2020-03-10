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
    public partial class LimitList : System.Web.UI.Page
    {
        protected List<LimitInfo> limitInfos = new List<LimitInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            limitInfos = new LimitService().SelectNoParameter();
        }
    }
}
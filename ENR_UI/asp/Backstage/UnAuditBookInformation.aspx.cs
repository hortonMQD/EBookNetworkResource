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
    public partial class UnAuditBookInformation : System.Web.UI.Page
    {
        protected BookInfo info = new BookInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            info.Id = Request["bookID"];
            info = new BookService().SelectBookWithParameter(info)[0];
        }
    }
}
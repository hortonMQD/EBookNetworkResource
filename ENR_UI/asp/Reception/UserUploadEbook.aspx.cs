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
    public partial class UserUploadEbook : System.Web.UI.Page
    {
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            departmentInfos = new DepartmentService().SelectDepartmentNoParameter();
        }

    }
}
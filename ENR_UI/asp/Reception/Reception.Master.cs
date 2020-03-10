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
    public partial class Reception : System.Web.UI.MasterPage
    {

        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo();
            departmentInfo.Id = null;
            departmentInfo.IsAdmin = "0";
            departmentInfo.IsTrue = "1";
            departmentInfos = new DepartmentService().SelectDepartmentWithParameter(departmentInfo);
        }
    }
}
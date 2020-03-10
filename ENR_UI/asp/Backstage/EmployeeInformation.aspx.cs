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
    public partial class EmployeeInformation : System.Web.UI.Page
    {
        protected PersonalInfo info = new PersonalInfo();
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected List<LimitInfo> limitInfos = new List<LimitInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            info.Id = Request["personalID"];
            info = new PersonalService().SelectWithParameter(info)[0];
            departmentInfos = new DepartmentService().SelectDepartmentNoParameter();
            limitInfos = new LimitService().SelectNoParameter();
        }
    }
}
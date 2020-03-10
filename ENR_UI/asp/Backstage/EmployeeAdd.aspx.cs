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
    public partial class EmployeeAdd : System.Web.UI.Page
    {
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected List<LimitInfo> limitInfos = new List<LimitInfo>();
        protected PersonalInfo personalInfo = new PersonalInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalService service = new PersonalService();
            personalInfo.Id = Session["personalID"].ToString();
            personalInfo = service.SelectWithParameter(personalInfo)[0];
            if (personalInfo.Limit.Equals("010"))
            {
                departmentInfos = new DepartmentService().SelectDepartmentNoParameter();
                limitInfos = new LimitService().SelectNoParameter();
            }
        }
    }
}
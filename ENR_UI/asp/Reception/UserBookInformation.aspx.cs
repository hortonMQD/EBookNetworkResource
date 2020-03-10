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
    public partial class UserBookInformation : System.Web.UI.Page
    {
        protected BookInfo info = new BookInfo();
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected String personalName;
        protected void Page_Load(object sender, EventArgs e)
        {
            info.Id = Request["bookID"];
            info = new BookService().SelectBookWithParameter(info)[0];
            departmentInfos = new DepartmentService().SelectDepartmentNoParameter();
            if (!info.IsPass.Equals("未审核"))
            {
                PersonalInfo personalInfo = new PersonalInfo();
                personalInfo.Id = info.PersonalID1;
                personalName = new PersonalService().SelectWithParameter(personalInfo)[0].Name;
            }
        }
    }
}
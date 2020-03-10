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
    public partial class ReceptionInformation : System.Web.UI.MasterPage
    {
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected List<BookInfo> bookInfos = new List<BookInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo();
            departmentInfo.Id = null;
            departmentInfo.IsAdmin = "0";
            departmentInfos = new DepartmentService().SelectDepartmentWithParameter(departmentInfo);
            BookInfo info = new BookInfo();
            info.Id = null;
            info.BookTypeID = Request["departID"];
            info.IsDelete = "0";
            info.IsTrue = "1";
            bookInfos = new BookService().SelectNewBookWithParameter(info);
        }
    }
}
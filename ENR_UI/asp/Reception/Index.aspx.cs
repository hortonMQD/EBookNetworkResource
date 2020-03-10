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
    public partial class Index : System.Web.UI.Page
    {
        protected List<DepartmentInfo> departmentInfos = new List<DepartmentInfo>();
        protected List<BookInfo> bookInfos = new List<BookInfo>();
        protected List<BookInfo> DownLoadBookInfos = new List<BookInfo>();
        protected int departCount;
        protected int departIndex=0;
        protected DepartmentInfo departmentInfo = new DepartmentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            departmentInfo.Id = null;
            departmentInfo.IsAdmin = "0";
            departmentInfos = new DepartmentService().SelectDepartmentWithParameter(departmentInfo);
            departCount = departmentInfos.ToArray().Length;

            BookInfo bookInfo = new BookInfo();
            bookInfo.Id = null;
            bookInfo.IsTrue = "1";
            bookInfo.IsDelete = "0";
            bookInfos = new BookService().SelectNewBookWithParameter(bookInfo);
            DownLoadBookInfos = new BookService().SelectFireBookWithParameter(bookInfo);
        }
    }
}
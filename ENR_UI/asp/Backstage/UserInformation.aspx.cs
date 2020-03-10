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
    public partial class UserInformation : System.Web.UI.Page
    {
        protected UserInfo userInfo = new UserInfo();
        protected List<BookInfo> bookInfos = new List<BookInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            userInfo.Id = Request["userID"];
            BookInfo info = new BookInfo();
            info.Id = null;
            info.UploadUserID = userInfo.Id;
            bookInfos = new BookService().SelectBookWithParameter(info);
            userInfo = new UserService().SelectWithParamter(userInfo)[0];
        }
    }
}
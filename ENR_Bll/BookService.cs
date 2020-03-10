using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class BookService
    {
        private BookDal dal = new BookDal();

        public BookService() { }

        /// <summary>
        /// 添加图书信息
        /// </summary>
        /// <param name="info">图书对象</param>
        /// <returns>若成功返回true</returns>
        public bool Add(BookInfo info)
        {
            return isTrue(dal.AddBookWithParameter(info));
        }


        public bool Updata(BookInfo info)
        {
            return isTrue(dal.UpdataBookWithParameter(info));
        }

        public bool Delete(BookInfo info)
        {
            return isTrue(dal.DeleteBookWithParameter(info));
        }


        public bool UpdataDownload(BookInfo info)
        {
            return isTrue(dal.UpdataDownloadBookWithParameter(info));
        }


        public List<BookInfo> SelectBookWithParameter(BookInfo info)
        {
            return dal.SelectBookWithParameter(info);
        }
        

        public List<BookInfo> SelectNewBookWithParameter(BookInfo info)
        {
            return dal.SelectBookWithParameter(info);
        }

        public List<BookInfo> SelectFireBookWithParameter(BookInfo info)
        {
            return dal.SelectFireBookWithParameter(info);
        }

        public List<BookInfo> SelectFireBookNoParameter()
        {
            return dal.SelectFireBookNoParameter();
        }


        public List<BookInfo> SelectNewBookNoParameter()
        {
            return dal.SelectBookNoParameter();
        }

        public List<BookInfo> SelectBookNoParameter()
        {
            return dal.SelectBookNoParameter();
        }




        public List<BookInfo> SelectBookWithParameter(BookInfo info, String pageIndex)
        {
            return dal.SelectBookWithParameter(info, pageIndex);
        }

        public List<BookInfo> SelectBookNoParameter(String pageIndex)
        {
            return dal.SelectBookNoParameter(pageIndex);
        }

        public List<BookInfo> SelectFireBookWithParameter(BookInfo info, String pageIndex)
        {
            return dal.SelectFireBookWithParameter(info, pageIndex);
        }

        public List<BookInfo> SelectFireBookNoParameter(String pageIndex)
        {
            return dal.SelectFireBookNoParameter(pageIndex);
        }

        /// <summary>
        /// 根据传入参数返回bool值
        /// </summary>
        /// <param name="result">int参数</param>
        /// <returns>大于0返回true</returns>
        public bool isTrue(int result)
        {
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

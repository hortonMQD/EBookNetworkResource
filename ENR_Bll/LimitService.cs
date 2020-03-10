using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class LimitService
    {
        private LimitDal dal = new LimitDal();

        public LimitService() { }

        public List<LimitInfo> SelectWithParameter(LimitInfo info)
        {
            return dal.SelectWithParameter(info);
        }

        public List<LimitInfo> SelectNoParameter()
        {
            return dal.SelectNoParameter();
        }
    }
}

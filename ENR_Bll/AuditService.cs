using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class AuditService
    {
        private AuditDal dal = new AuditDal();
        public AuditService() { }


        public bool Update(AuditOpinionInfo info)
        {
            return isTrue(dal.Update(info));
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

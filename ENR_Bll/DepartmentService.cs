using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class DepartmentService
    {
        public DepartmentService() { }

        private DepartmentDal dal = new DepartmentDal();


        public bool AddDepartmentWithParameter(DepartmentInfo info)
        {
            return isTrue(dal.AddDepartmentWithParameter(info));
        }

        public bool UpdateDepartmentWithParameter(DepartmentInfo info)
        {
            return isTrue(dal.UpdateDepartmentWithParameter(info));
        }


        public List<DepartmentInfo> SelectDepartmentWithParameter(DepartmentInfo info)
        {
            return dal.SelectDepartmentWithParameter(info);
        }

        public List<DepartmentInfo> SelectDepartmentNoParameter()
        {
            return dal.SelectDepartmenNoParameter();
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

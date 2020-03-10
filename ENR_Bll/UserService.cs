using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class UserService
    {
        public UserService() { }

        private UserDal dal = new UserDal();

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回true</returns>
        public bool login(UserInfo info)
        {
            return isTrue(dal.SelectUserWithParameter(info).ToArray().Length);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回true</returns>
        public bool Add(UserInfo info)
        {
            return isTrue(dal.AddUserWithParameter(info));
        }

        /// <summary>
        /// 依据参数查询用户信息
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>用户信息集合</returns>
        public List<UserInfo> SelectWithParamter(UserInfo info)
        {
            return dal.SelectUserWithParameter(info);
        }

        public List<UserInfo> SelectNoParamter()
        {
            return dal.SelectUserNoParameter();
        }

        /// <summary>
        /// 修改用户个人信息
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回true</returns>
        public bool Update(UserInfo info)
        {
            return isTrue(dal.UpdateUserWithParameter(info));
        }


        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回true</returns>
        public bool UpdatePwd(UserInfo info)
        {
            return isTrue(dal.UpdataPwdWithParameter(info));
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

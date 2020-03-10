using ENR_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class UserDal
    {

        private DBTool db = new DBTool();
        public UserDal() { }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="info">参数为用户对象</param>
        /// <returns>若成功返回大于0的int类型数据</returns>
        public int AddUserWithParameter(UserInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@user_id",info.Id),
                new SqlParameter("@user_pwd",info.Pwd),
                new SqlParameter("@user_name",info.UName),
                new SqlParameter("@user_email",info.Email)
                };
            String sql = "insert [User](ID,UName,Email,pwd) values(@user_id,@user_name,@user_email,@user_pwd);";
            result = db.NoQueryCmd(sql, parameter);
            return result;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回大于0的int类型数据</returns>
        public int UpdateUserWithParameter(UserInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@user_id",info.Id),
                new SqlParameter("@user_name",info.UName),
                new SqlParameter("@user_email",info.Email)
                };
            String sql = "update [User] set UName = @user_name,Email = @user_email where ID = @user_id";
            result = db.NoQueryCmd(sql, parameter);
            return result;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="info">用户对象</param>
        /// <returns>若成功返回大于0的int类型数据</returns>
        public int UpdataPwdWithParameter(UserInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@user_id",info.Id),
                new SqlParameter("@user_pwd",info.Pwd)
                };
            String sql = "update [User] set pwd = @user_pwd where ID = @user_id";
            result = db.NoQueryCmd(sql, parameter);
            return result;
        }


        public List<UserInfo> SelectUserWithParameter(UserInfo info)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "Select ID,UName,Email,pwd from [User] where 1=1";
            if (info.Id != null) { sql = sql + " and ID = @user_id "; parameter.Add(new SqlParameter("@user_id", info.Id)); }
            if (info.UName != null) { sql = sql + " and UName = @user_name "; parameter.Add(new SqlParameter("@user_name", info.UName)); }
            if (info.Email != null) { sql = sql + " and Email = @user_email "; parameter.Add(new SqlParameter("@user_email", info.Email)); }
            if (info.Pwd != null) { sql = sql + " and pwd = @user_pwd;"; parameter.Add(new SqlParameter("@user_pwd", info.Pwd)); }
            return setBasicData(db.SelectWithParamterReader(sql, parameter.ToArray()));
        }


        public List<UserInfo> SelectUserNoParameter()
        {
            String sql = "Select ID,UName,Email,pwd from [User]";
            return setBasicData(db.SelectNoParamterReader(sql));
        }



        /// <summary>
        /// 将从User表中查询到的数据转换为List
        /// </summary>
        /// <param name="reader">数据集合</param>
        /// <returns>List<UserInfo></returns>
        public List<UserInfo> setBasicData(SqlDataReader reader)
        {
            List<UserInfo> infos = new List<UserInfo>();
            while (reader.Read())
            {
                UserInfo info = new UserInfo();
                info.Id = reader["ID"].ToString();
                info.Pwd = reader["pwd"].ToString();
                info.UName = reader["UName"].ToString();
                info.Email = reader["Email"].ToString();
                infos.Add(info);
            }
            db.getSqlConnection().Close();
            return infos;
        }


    }
}

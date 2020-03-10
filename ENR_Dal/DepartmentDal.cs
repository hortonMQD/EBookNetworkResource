using ENR_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class DepartmentDal
    {
        private DBTool db = new DBTool();

        public DepartmentDal() { }


        public int AddDepartmentWithParameter(DepartmentInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@ID",info.Id),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@leader",info.Leader),
                new SqlParameter("@isAdministrative",info.IsAdmin)
                };
            String sql = "insert Department(ID,name,leader,createTime,isTrue,isAdministrative) values(@ID,@name,@leader,GETDATE(),'1',@isAdministrative);";
            result = db.NoQueryCmd(sql, parameter);
            return result;
        }



        public int UpdateDepartmentWithParameter(DepartmentInfo info)
        {
            int result = 0;
            String sql = "update Department set ID = @ID ";
            List<SqlParameter> parameter = new List<SqlParameter>();
            if (info.Name != null) { sql = sql + " ,name = @name "; parameter.Add(new SqlParameter("@name", info.Name)); }
            if (info.Leader != null) { sql = sql + " ,leader = @leader "; parameter.Add(new SqlParameter("@leader", info.Leader)); }
            if (info.IsTrue != null) { sql = sql + " ,isTrue = @isTrue "; parameter.Add(new SqlParameter("@isTrue", info.IsTrue)); }
            if (info.IsAdmin != null) { sql = sql + " ,isAdministrative = @isAdministrative "; parameter.Add(new SqlParameter("@isAdministrative", info.IsAdmin)); }
            sql += " where ID = @ID";
            parameter.Add(new SqlParameter("@ID", info.Id));
            result = db.NoQueryCmd(sql, parameter.ToArray());
            return result;

        }



        public List<DepartmentInfo> SelectDepartmentWithParameter(DepartmentInfo info)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "Select ID,name,leader,(select name from Personal where ID = leader) as 'leaderName',createTime,isTrue,isAdministrative from Department where 1=1";
            if (info.Id != null) { sql = sql + " and ID = @id "; parameter.Add(new SqlParameter("@id", info.Id)); }
            if (info.Name != null) { sql = sql + " and name = @name "; parameter.Add(new SqlParameter("@name", info.Name)); }
            if (info.Leader != null) { sql = sql + " and leader = @leader "; parameter.Add(new SqlParameter("@leader", info.Leader)); }
            if (info.CreateTime != null) { sql = sql + " and createTime = @createTime"; parameter.Add(new SqlParameter("@createTime", info.CreateTime)); }
            if (info.IsTrue != null) { sql = sql + " and isTrue = @isTrue"; parameter.Add(new SqlParameter("@isTrue", info.IsTrue)); }
            if (info.IsAdmin != null) { sql = sql + " and isAdministrative = @isAdministrative"; parameter.Add(new SqlParameter("@isAdministrative", info.IsAdmin)); }
            sql += " order by createTime desc";
            return setBasicData(db.SelectWithParamterReader(sql, parameter.ToArray()));
        }

        public List<DepartmentInfo> SelectDepartmenNoParameter()
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "Select ID,name,leader,(select name from Personal where ID = leader) as 'leaderName',createTime,isTrue,isAdministrative from Department order by createTime desc";
            return setBasicData(db.SelectWithParamterReader(sql, parameter.ToArray()));
        }



        /// <summary>
        /// 将从Department表中查询到的数据转换为List
        /// </summary>
        /// <param name="reader">数据集合</param>
        /// <returns>List<DepartmentInfo></returns>
        public List<DepartmentInfo> setBasicData(SqlDataReader reader)
        {
            List<DepartmentInfo> infos = new List<DepartmentInfo>();
            while (reader.Read())
            {
                DepartmentInfo info = new DepartmentInfo();
                info.Id = reader["ID"].ToString();
                info.Name = reader["name"].ToString();
                info.Leader = reader["leader"].ToString();
                info.LeaderName = reader["leaderName"].ToString();
                info.CreateTime = reader["createTime"].ToString();
                info.IsTrue = reader["isTrue"].ToString();
                info.IsAdmin = reader["isAdministrative"].ToString();
                infos.Add(info);
            }
            db.getSqlConnection().Close();
            return infos;
        }
    }
}

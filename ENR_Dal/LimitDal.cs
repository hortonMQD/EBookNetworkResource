using ENR_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class LimitDal
    {
        private DBTool db = new DBTool();
        public LimitDal() { }

        public List<LimitInfo> SelectNoParameter()
        {
            String sql = "select ID,name,operation from Limit";
            return setBasicData(db.SelectNoParamterReader(sql));
        }


        public List<LimitInfo> SelectWithParameter(LimitInfo info)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "select ID,name,operation from Limit where 1=1";
            if (info.Id != null) { sql = sql + " and ID = @id "; parameter.Add(new SqlParameter("@id", info.Id)); }
            if (info.Name != null) { sql = sql + " and name = @name "; parameter.Add(new SqlParameter("@name", info.Name)); }
            if (info.Operation != null) { sql = sql + " and operation = @operation "; parameter.Add(new SqlParameter("@operation", info.Operation)); }
            sql += " order by ID";
            return setBasicData(db.SelectWithParamterReader(sql, parameter.ToArray()));
        }



        public List<LimitInfo> setBasicData(SqlDataReader reader)
        {
            List<LimitInfo> infos = new List<LimitInfo>();
            while (reader.Read())
            {
                LimitInfo info = new LimitInfo();
                info.Id = reader["ID"].ToString();
                info.Name = reader["name"].ToString();
                info.Operation = reader["operation"].ToString();
                infos.Add(info);
            }
            db.getSqlConnection().Close();
            return infos;
        }

    }
}

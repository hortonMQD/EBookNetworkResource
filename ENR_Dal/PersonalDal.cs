using ENR_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class PersonalDal
    {
        private DBTool db = new DBTool();

        public PersonalDal() { }

        public List<PersonalInfo> SelectPersonalWithParameter(PersonalInfo info)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "select ID,PID,name,pwd,department,(select name from Department where ID=department) as 'departmentName'" +
                ",limit,telephone,createTime,isDimission,dimissionTime,(select name from Limit where ID = limit) as 'limitName' from Personal where 1=1";
            if (info.Id != null) { sql = sql + " and ID = @id "; parameter.Add(new SqlParameter("@id", info.Id)); }
            if (info.PId != null) { sql = sql + " and PID = @pid "; parameter.Add(new SqlParameter("@pid", info.PId)); }
            if (info.Name != null) { sql += " and name like @Name "; parameter.Add(new SqlParameter("@Name", "%" + info.Name + "%")); }
            if (info.Pwd != null) { sql = sql + " and pwd = @pwd "; parameter.Add(new SqlParameter("@pwd", info.Pwd)); }
            if (info.Department != null) { sql = sql + " and department = @department "; parameter.Add(new SqlParameter("@department", info.Department)); }
            if (info.Limit != null) { sql = sql + " and limit = @limit "; parameter.Add(new SqlParameter("@limit", info.Limit)); }
            if (info.Telephone != null) { sql = sql + " and telephone = @telephone "; parameter.Add(new SqlParameter("@telephone", info.Telephone)); }
            if (info.CreateTime != null) { sql = sql + " and createTime = @createTime "; parameter.Add(new SqlParameter("@createTime", info.CreateTime)); }
            if (info.IsDimission != null) { sql = sql + " and isDimission = @isDimission "; parameter.Add(new SqlParameter("@isDimission", info.IsDimission)); }
            if (info.DimissionTime != null) { sql = sql + " and dimissionTime = @dimissionTime "; parameter.Add(new SqlParameter("@dimissionTime", info.DimissionTime)); }
            sql += " order by createTime";
            return setBasicData(db.SelectWithParamterReader(sql, parameter.ToArray()));
        }

        public List<PersonalInfo> SelectPersonalNoParameter()
        {
            String sql = "select ID,PID,name,pwd,department,(select name from Department where ID=department) as 'departmentName'" +
                ",limit,(select name from Limit where ID = limit) as 'limitName',telephone,createTime,isDimission,dimissionTime from Personal  order by createTime";
            return setBasicData(db.SelectNoParamterReader(sql));
        }


        public int UpdatePersonalWithParameter(PersonalInfo info)
        {
            int result = 0;
            List<SqlParameter> parameter = new List<SqlParameter>();
            String sql = "update Personal set ID = @id";
            if (info.Name != null) { sql = sql + " ,name = @name"; parameter.Add(new SqlParameter("@name", info.Name)); }
            if (info.Pwd != null) { sql = sql + " ,pwd = @pwd"; parameter.Add(new SqlParameter("@pwd", info.Pwd)); }
            if (info.Department != null) { sql = sql + " ,department = @department "; parameter.Add(new SqlParameter("@department", info.Department)); }
            if (info.Limit != null) { sql = sql + " ,limit = @limit "; parameter.Add(new SqlParameter("@limit", info.Limit)); }
            if (info.Telephone != null) { sql = sql + " ,telephone = @telephone "; parameter.Add(new SqlParameter("@telephone", info.Telephone)); }
            if (info.CreateTime != null) { sql = sql + " ,createTime = @createTime "; parameter.Add(new SqlParameter("@createTime", info.CreateTime)); }
            if (info.IsDimission != null) { sql = sql + " ,isDimission = @isDimission "; parameter.Add(new SqlParameter("@isDimission", info.IsDimission)); }
            if (info.DimissionTime != null){ sql = sql + " ,dimissionTime = @dimissionTime "; parameter.Add(new SqlParameter("@dimissionTime", info.DimissionTime));}
            sql+= " where ID = @id";
            parameter.Add(new SqlParameter("@id", info.Id));
            result = db.NoQueryCmd(sql, parameter.ToArray());
            return result;
        }


        public int AddPersonalWithParameter(PersonalInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@ID",info.Id),
                new SqlParameter("@PID",info.PId),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@limit",info.Limit),
                new SqlParameter("@department",info.Department),
                new SqlParameter("@telephone",info.Telephone)
                };
            String sql = "insert Personal(ID,PID,name,pwd,department,limit,telephone,createTime) " +
                " values(@ID,@PID,@name,'123456',@department,@limit,@telephone,GETDATE());";
            result = db.NoQueryCmd(sql, parameter);
            return result;
        }





        public List<PersonalInfo> setBasicData(SqlDataReader reader)
        {
            List<PersonalInfo> infos = new List<PersonalInfo>();
            while (reader.Read())
            {
                PersonalInfo info = new PersonalInfo();
                info.Id = reader["ID"].ToString();
                info.PId = reader["PID"].ToString();
                info.Name = reader["name"].ToString();
                info.Pwd = reader["pwd"].ToString();
                info.Department = reader["department"].ToString();
                info.DepartmentName = reader["departmentName"].ToString();
                info.Limit = reader["limit"].ToString();
                info.LimitName = reader["limitName"].ToString();
                info.Telephone = reader["telephone"].ToString();
                info.CreateTime = reader["createTime"].ToString();
                info.IsDimission = reader["isDimission"].ToString();
                info.DimissionTime = reader["dimissionTime"].ToString();
                infos.Add(info);
            }
            db.getSqlConnection().Close();
            return infos;
        }

    }
}

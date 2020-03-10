using ENR_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class AuditDal
    {
        private DBTool db = new DBTool();

        public AuditDal() { }

        public int Update(AuditOpinionInfo info)
        {
            int result = 0;
            SqlParameter[][] parameter = new SqlParameter[2][];
            String[] SQL = new String[2];
            parameter[0] = new SqlParameter[] { new SqlParameter("@ID", info.Id) };
            SQL[0] = "update Book set isTrue = '1' where ID = @ID";
            SQL[1] = "update AuditOpinion set isPass=@isPass,opinion=@opinion,auditor=@auditor where ID = (select auditOpinion from Book where ID = @ID)";
            parameter[1] = new SqlParameter[]
                {
                new SqlParameter("@ID",info.Id),
                new SqlParameter("@isPass",info.IsPass),
                new SqlParameter("@opinion",info.Opinion),
                new SqlParameter("@auditor",info.Auditor)
                };
            result = db.NoQueryCmdByAffair(SQL, parameter);
            return result;
        }
    }
}

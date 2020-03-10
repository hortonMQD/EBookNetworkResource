using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Model
{
    public class PersonalInfo
    {
        private String id;
        private String pId;
        private String name;
        private String pwd;
        private String oldPwd;
        private String department;
        private String departmentName;
        private String limit;
        private String limitName;
        private String telephone;
        private String createTime;
        private String isDimission;
        private String dimissionTime;

        public PersonalInfo()
        {
            id = IDUtils.GetGuid16String();
        }

        public string Id { get => id; set => id = value; }
        public string PId { get => pId; set => pId = value; }
        public string Name { get => name; set => name = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Department { get => department; set => department = value; }
        public string Limit { get => limit; set => limit = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string CreateTime { get => createTime; set => createTime = value; }
        public string IsDimission { get => isDimission; set => isDimission = value; }
        public string DimissionTime { get => dimissionTime; set => dimissionTime = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string LimitName { get => limitName; set => limitName = value; }
    }
}

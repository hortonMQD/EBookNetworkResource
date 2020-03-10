using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Model
{
    public class DepartmentInfo
    {
        private String id;
        private String name;
        private String leaderName;
        private String leader;
        private String createTime;
        private String isTrue;
        private String isAdmin;

        public DepartmentInfo()
        {
            id = IDUtils.GetGuid16String();
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Leader { get => leader; set => leader = value; }
        public string CreateTime { get => createTime; set => createTime = value; }
        public string IsTrue { get => isTrue; set => isTrue = value; }
        public string LeaderName { get => leaderName; set => leaderName = value; }
        public string IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}

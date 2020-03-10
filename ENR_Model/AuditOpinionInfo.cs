using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Model
{
    public class AuditOpinionInfo
    {
        private String id;
        private String isPass;
        private String opinion;
        private String createTime;
        private String auditor;

        public AuditOpinionInfo()
        {
            id = IDUtils.GetGuid16String();
        }

        public string Id { get => id; set => id = value; }
        public string IsPass { get => isPass; set => isPass = value; }
        public string Opinion { get => opinion; set => opinion = value; }
        public string CreateTime { get => createTime; set => createTime = value; }
        public string Auditor { get => auditor; set => auditor = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Model
{
    public class LimitInfo
    {
        private String id;
        private String name;
        private String operation;

        public LimitInfo()
        {
            id = IDUtils.GetGuid16String();
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Operation { get => operation; set => operation = value; }
    }
}

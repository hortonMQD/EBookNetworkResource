using ENR_Dal;
using ENR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Bll
{
    public class PersonalService
    {
        private PersonalDal dal = new PersonalDal();

        public PersonalService() { }

        public bool login(PersonalInfo info)
        {
            return isTrue(dal.SelectPersonalWithParameter(info).ToArray().Length);
        }

        public bool Add(PersonalInfo info)
        {
            return isTrue(dal.AddPersonalWithParameter(info));
        }

        public List<PersonalInfo> SelectWithParameter(PersonalInfo info)
        {
            return dal.SelectPersonalWithParameter(info);
        }

        public List<PersonalInfo> SelectPersonalNoParameter()
        {
            return dal.SelectPersonalNoParameter();
        }

        public bool Update(PersonalInfo info)
        {
            return isTrue(dal.UpdatePersonalWithParameter(info));
        }


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

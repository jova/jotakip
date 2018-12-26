using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        IPersonalDal personalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            this.personalDal = personalDal;
        }

        public Personal Get(int personalId)
        {
            return personalDal.Get(x => x.Id == personalId);
        }

        public List<Personal> GetList()
        {
            return personalDal.GetList();
        }
    }
}

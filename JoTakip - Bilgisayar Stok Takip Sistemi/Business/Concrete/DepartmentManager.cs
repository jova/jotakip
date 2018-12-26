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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            this.departmentDal = departmentDal;
        }

        public Department Get(int departmentId)
        {
            return departmentDal.Get(x => x.Id == departmentId);
        }

        public List<Department> GetList()
        {
            return departmentDal.GetList();
        }

    }
}

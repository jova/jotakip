using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        void PromoteManager(int departmentId, int personalId);
        List<Department> GetList();
        Department Get(int departmentId);
    }
}

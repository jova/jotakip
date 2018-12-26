using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IUserService
    {
        void Add(User salesman);
        void Update(User salesman);
        void Delete(User salesman);
        List<User> GetList();
    }
}

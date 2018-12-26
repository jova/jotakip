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
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Add(User user)
        {
            userDal.Add(user);
        }

        public void Delete(User user)
        {
            userDal.Delete(user);
        }

        public User Get(int userId)
        {
            return userDal.Get(x => x.Id == userId);
        }

        public List<User> GetList()
        {
            return userDal.GetList();
        }

        public void Update(User user)
        {
            userDal.Update(user);
        }
    }
}

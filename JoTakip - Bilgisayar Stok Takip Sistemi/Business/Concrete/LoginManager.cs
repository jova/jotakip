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
    public class LoginManager : ILoginService
    {
        private IUserDal userDal;

        public LoginManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public bool Login(string username, string password)
        {
            User user = userDal.Get(x => x.Username == username);

            if (user == null) return false;
            return user.Password == password;
        }
    }
}

using System;
using Business;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddAdminUser()
        {
            User user = new User() { Name = "ersoy", LastName = "toraman", Username = "user", Password = "pass", StillEmployed = true, DepartmentId = 0, Gender = Core.Gender.Male, UserType = Core.UserType.Admin };

            IUserService userService = IocUtil.Resolve<IUserService>();

            userService.Add(user);

            Assert.AreNotEqual(null, userService.Get(user.Id));
        }
    }
}

using System;
using EmployeeLib.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeLibTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void TestGetAllUsers()
        {
            var users = new UserRepository().GetAllUsers();
            Assert.IsTrue(users.Count == 3);
        }

        [TestMethod]
        public void TestGetSingleUser()
        {
            var user = new UserRepository().GetUserById(1);
            Assert.IsTrue(user._userID == 1);
        }
    }
}

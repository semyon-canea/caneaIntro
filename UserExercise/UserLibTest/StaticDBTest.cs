using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.BLL;
using EmployeeLib.DAL;
using EmployeeLib.DBSim;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeLibTest
{
    [TestClass]
    public class StaticDBTest
    {
        [TestMethod]
        public void TestAddNewUser()
        {
            var johan = new UserEntity()
            {
                FirstName = "Johan",
                LastName = "Tavelin",
                UserName = "johan.tavelin",
                IsActive = true,
                IsSuspended = false,
                ContactInformations = new List<ContactInformationEntity>()
                {
                    new ContactInformationEntity()
                    {
                        Email = "johan.tavelin@canea.se",
                        Phone = null,
                    }
                } 
            };
            StaticDB.SaveChanges(johan);

            var user = new UserRepository().GetUserById(johan._userID);

            Assert.IsTrue(user.UserName == johan.UserName);
            Assert.IsTrue(user.ContactInformations.Count == 1);
            Assert.IsTrue(user.ContactInformations.Single().UserID == johan._userID);

        }

        [TestMethod]
        public void TestUpdateUser()
        {
            const string testString = "test";

            var user = new UserRepository().GetUserById(1);
            user.FirstName = testString;

            var contactInfo = user.ContactInformations.Single();
            contactInfo.Phone = testString;

            StaticDB.SaveChanges(user);

            var updatedUser = new UserRepository().GetUserById(1);

            Assert.IsTrue(user.FirstName == updatedUser.FirstName);
            Assert.IsTrue(contactInfo.Phone == user.ContactInformations.Single().Phone);
        }

        [TestMethod]
        public void TestRemovedContactInformationFromUser()
        {
            var user = new UserRepository().GetUserById(1);
            user.ContactInformations.Clear();
            
            StaticDB.SaveChanges(user);

            var updatedUser = new UserRepository().GetUserById(1);

            Assert.IsTrue(updatedUser.ContactInformations.Count == 0);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            var contact = new ContactInformationEntity()
            {
                Email = "Test.Test@canea.se",
                Phone = null,
            };
            var test = new UserEntity()
            {
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test.Test",
                IsActive = true,
                IsSuspended = false,
                ContactInformations = new List<ContactInformationEntity>() { contact }
            };
            StaticDB.SaveChanges(test);
            Assert.IsTrue(contact.ID_ContactInformation > 0);
            Assert.IsTrue(test._userID > 0);

            var user = new UserRepository().GetUserById(test._userID);

            StaticDB.DeleteObject(user);

            Assert.IsTrue(StaticDB.Users.SingleOrDefault(x => x._userID == test._userID) == null);
            Assert.IsTrue(StaticDB.ContactInformations.SingleOrDefault(x => x.ID_ContactInformation == contact.ID_ContactInformation) == null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;

namespace EmployeeLib.DBSim
{
    public static class StaticDB
    {
        private static readonly IList<UserEntity> users;
        private static readonly IList<ContactInformationEntity> contactInformations;

        public static IList<UserEntity> Users => users.Select(CreateUserCopy).OrderBy(x => x._userID).ToList();

        public static IList<ContactInformationEntity> ContactInformations => contactInformations.Select(CreateContactInformationCopy).OrderBy(x => x.ID_ContactInformation).ToList();

        static StaticDB()
        {
            users = new List<UserEntity>();
            contactInformations = new List<ContactInformationEntity>();
            AddDefaultData();
        }

        private static void AddDefaultData()
        {
            var jacob = new UserEntity()
            {
                _userID = 1,
                FirstName = "Jacob",
                LastName = "Larsson",
                UserName = "jacob.larsson",
                IsActive = true,
                IsSuspended = false
            };
            var jacobContact = new ContactInformationEntity()
            {
                ID_ContactInformation = 1,
                Email = "jacob.larsson@canea.se",
                Phone = "0725706069",
                UserID = 1
            };
            users.Add(jacob);
            contactInformations.Add(jacobContact);
            var lars = new UserEntity()
            {
                _userID = 2,
                FirstName = "Lars",
                LastName = "Olsson",
                UserName = "lars.olsson",
                IsActive = true,
                IsSuspended = false
            };
            var larsContact = new ContactInformationEntity()
            {
                ID_ContactInformation = 2,
                Email = "lars.olsson@canea.se",
                Phone = "0733551102",
                UserID = 2
            };
            users.Add(lars);
            contactInformations.Add(larsContact);
            var hampus = new UserEntity()
            {
                _userID = 3,
                FirstName = "Hampus",
                LastName = "Lilja",
                UserName = "hampus.lilja",
                IsActive = true,
                IsSuspended = true // Suspended!
            };
            var hampusContact = new ContactInformationEntity()
            {
                ID_ContactInformation = 3,
                Email = "hampus.lilja@canea.se",
                Phone = null,
                UserID = 3
            };
            users.Add(hampus);
            contactInformations.Add(hampusContact);
        }

        public static void SaveChanges(UserEntity entity)
        {
            if (entity._userID > 0)
            {
                var oldEntity = users.Single(x => x._userID == entity._userID);

                // Remove ContactInfos that have been removed from the user entity
                var oldContactInfos = contactInformations.Where(x => x.UserID == oldEntity._userID).ToList();
                var contactInfoIdsToUpdate =
                    entity.ContactInformations.Where(x => x.ID_ContactInformation > 0)
                        .Select(x => x.ID_ContactInformation)
                        .ToList();
                foreach (var contactInfo in oldContactInfos.Where(x => contactInfoIdsToUpdate.All(id => id != x.ID_ContactInformation)))
                {
                    contactInformations.Remove(contactInfo);
                }

                users.Remove(oldEntity);
                users.Add(CreateUserCopy(entity));
            }
            else
            {
                entity._userID = users.Select(x => x._userID).Max() + 1;
                users.Add(CreateUserCopy(entity));
            }
            
            foreach (var contactInformation in entity.ContactInformations)
            {
                contactInformation.UserID = entity._userID;
                SaveChanges(contactInformation);
            }
        }

        public static void SaveChanges(ContactInformationEntity entity)
        {
            if (entity.ID_ContactInformation > 0)
            {
                var oldEntity = contactInformations.Single(x => x.ID_ContactInformation == entity.ID_ContactInformation);
                contactInformations.Remove(oldEntity);
                contactInformations.Add(CreateContactInformationCopy(entity));
            }
            else
            {
                entity.ID_ContactInformation = contactInformations.Select(x => x.ID_ContactInformation).Max() + 1;
                contactInformations.Add(CreateContactInformationCopy(entity));
            }
        }

        public static void DeleteObject(UserEntity entity)
        {
            var oldEntity = users.Single(x => x._userID == entity._userID);
            var oldContactInfos = contactInformations.Where(x => x.UserID == entity._userID).ToList();
            foreach (var contactInfo in oldContactInfos)
            {
                contactInformations.Remove(contactInfo);
            }
            users.Remove(oldEntity);
        }

        public static void DeleteObject(ContactInformationEntity entity)
        {
            var oldEntity = contactInformations.Single(x => x.ID_ContactInformation == entity.ID_ContactInformation);
            contactInformations.Remove(oldEntity);
        }

        // Create copy to assure that only we have the reference!
        private static UserEntity CreateUserCopy(UserEntity entity)
        {
            return new UserEntity()
            {
                _userID = entity._userID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                IsActive = entity.IsActive,
                IsSuspended = entity.IsSuspended
            };
        }

        // Create copy to assure that only we have the reference!
        private static ContactInformationEntity CreateContactInformationCopy(ContactInformationEntity entity)
        {
            return new ContactInformationEntity()
            {
                ID_ContactInformation = entity.ID_ContactInformation,
                Email = entity.Email,
                Phone = entity.Phone,
                UserID = entity.UserID
            };
        }
    }
}

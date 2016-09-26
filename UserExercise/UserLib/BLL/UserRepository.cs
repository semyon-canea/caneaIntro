using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;
using EmployeeLib.DBSim;

namespace EmployeeLib.BLL
{
    public sealed class UserRepository
    {
        public IList<UserEntity> GetAllUsers()
        {
            var contactInfos = StaticDB.ContactInformations;
            var users = StaticDB.Users;

            // Add contactInformation to UserEntity
            foreach (var user in users)
            {
                var contactInfo = contactInfos.SingleOrDefault(info => info.UserID == user._userID);
                if (contactInfo != null)
                {
                    user.ContactInformations.Add(contactInfo);
                }
            }
            return users;
        }

        public UserEntity GetUserById(long userId)
        {
            var user = StaticDB.Users.Single(x => x._userID == userId);

            // Add contactInformation to UserEntity
            var contactInfo = StaticDB.ContactInformations.SingleOrDefault(info => info.UserID == userId);
            if (contactInfo != null)
            {
                user.ContactInformations.Add(contactInfo);
            }
            return user;
        }
    }
}

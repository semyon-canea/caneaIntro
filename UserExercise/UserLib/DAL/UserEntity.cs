using System.Collections.Generic;

namespace EmployeeLib.DAL
{
    public class UserEntity
    {
        public long _userID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; } 
        public bool IsSuspended { get; set; }

        public UserEntity()
        {
            ContactInformations = new List<ContactInformationEntity>();
        }

        #region Navigation Properties

        public IList<ContactInformationEntity> ContactInformations { get; set; } // Should always be null or one. Incorrect data otherwise!

        #endregion Navigation Properties


    }
}

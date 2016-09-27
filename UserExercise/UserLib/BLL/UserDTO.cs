using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.BLL
{
    public class UserDTO
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string UserName { get; }
        public bool IsActive { get; }
        public bool IsSuspended { get; }

        public IList<ContactInformationDTO> ContactInformation { get; }


        public UserDTO(long id, string firstName, string lastName, string userName, bool isActive, bool isSuspended, IList<ContactInformationDTO> contactInformation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            IsActive = isActive;
            IsSuspended = isSuspended;
            ContactInformation = contactInformation;
        }

        public bool IsPersisted => Id > 0;
    }
}

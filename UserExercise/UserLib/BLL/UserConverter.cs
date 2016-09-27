using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public sealed class UserConverter
    {
        public UserDTO ConvertToUserDTO(UserEntity entity)
        {
            var converter = new ContactInformationConverter();
            List<ContactInformationDTO> contactInformation = null;
            if (entity.ContactInformations != null)
            {
                contactInformation = entity.ContactInformations.Select(
                        contactInformationEntity => converter.ConvertToContactInformationDto(contactInformationEntity))
                    .ToList();
            }
            return new UserDTO(entity._userID, entity.FirstName,entity.LastName,entity.UserName,entity.IsActive, entity.IsSuspended, contactInformation);
        }
    }
}

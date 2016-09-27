using System.Linq;
using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public sealed class UserConverter
    {
        public UserDTO ConvertToUserDTO(UserEntity entity)
        {
            var converter = new ContactInformationConverter();
            ContactInformationDTO contactInformation = null;
            if (entity.ContactInformations != null)
            {
                contactInformation = converter.ConvertToContactInformationDto(entity.ContactInformations.First());
            }
            return new UserDTO(entity._userID, entity.FirstName,entity.LastName,entity.UserName,entity.IsActive, entity.IsSuspended, contactInformation);
        }
    }
}

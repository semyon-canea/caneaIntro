using EmployeeLib.BLL;
using UserLib.BLL;

namespace User.UI.Logic
{
    // ReSharper disable once InconsistentNaming
    public class UserBOConverter
    {
        public UserBO ConvertUserDTO(UserDTO source)
        {
            var contactInfo = new ContactInformationBOConverter().ConvertContactInformationDTO(source.ContactInformation);
            return new UserBO(source.Id, source.FirstName, source.LastName, source.UserName, source.IsActive, contactInfo);
        }

        public UserUpdateData ConvertUserBO(UserBO source)
        {
            var contactInfo = new ContactInformationBOConverter().ConvertContactInformationUpdateData(source.ContactInformation);
            return new UserUpdateData(source.Id,source.FirstName,source.LastName,source.UserName,source.IsActive,contactInfo);
        }
    }
}

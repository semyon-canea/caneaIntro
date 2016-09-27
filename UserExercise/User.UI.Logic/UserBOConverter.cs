using EmployeeLib.BLL;

namespace User.UI.Logic
{
    // ReSharper disable once InconsistentNaming
    public class UserBOConverter
    {
        public UserBO Convert(UserDTO source)
        {
            var contactInfo = new ContactInformationBOConverter().Convert(source.ContactInformation);
            return new UserBO(source.Id, source.FirstName, source.LastName, source.UserName, source.IsActive, contactInfo);
        }

    }
}

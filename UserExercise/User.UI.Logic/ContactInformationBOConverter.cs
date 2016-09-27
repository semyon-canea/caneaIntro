using EmployeeLib.BLL;

namespace User.UI.Logic
{
    public class ContactInformationBOConverter
    {
        public ContactInformationBO Convert(ContactInformationDTO source)
        {
            return new ContactInformationBO(source.Id, source.Email, source.Phone);
        }
    }
}
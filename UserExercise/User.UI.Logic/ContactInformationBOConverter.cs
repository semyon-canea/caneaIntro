using EmployeeLib.BLL;
using UserLib.BLL;

namespace User.UI.Logic
{
    public class ContactInformationBOConverter
    {
        public ContactInformationBO ConvertContactInformationDTO(ContactInformationDTO source)
        {
            return new ContactInformationBO(source.Id, source.Email, source.Phone);
        }
        public ContactInformationUpdateData ConvertContactInformationUpdateData(ContactInformationBO source)
        {
            return new ContactInformationUpdateData(source.Id, source.Email, source.Phone);
        }

    }
}
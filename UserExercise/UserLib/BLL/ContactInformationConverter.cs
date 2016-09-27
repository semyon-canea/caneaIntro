using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public class ContactInformationConverter
    {
        public ContactInformationDTO ConvertToContactInformationDto(ContactInformationEntity entity)
        {
            return new ContactInformationDTO(entity.ID_ContactInformation, entity.UserID,entity.Email, entity.Phone);
        }
    }
}
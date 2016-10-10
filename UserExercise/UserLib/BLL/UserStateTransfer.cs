using System.Linq;
using EmployeeLib.DAL;
using UserLib.BLL;

namespace EmployeeLib.BLL
{
    public sealed class UserStateTransfer
    {
        private readonly UserUpdateData source;
        private readonly UserEntity target;

        public UserStateTransfer(UserUpdateData source, UserEntity target)
        {
            this.source = source;
            this.target = target;
        }

        public void TransferState()
        {
            target._userID = source.Id;
            target.UserName = source.UserName;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.IsActive = source.IsActive;
            if (target.ContactInformations == null && source.ContactInformation == null)
            {
                return;
            }

            if (target.ContactInformations == null && source.ContactInformation != null)
            {
                CreateNewContactInfo(source.ContactInformation);

            }
            else if (target.ContactInformations != null && source.ContactInformation == null)
            {
                target.ContactInformations.Clear();
            }
            else
            {
                var toRemove = target.ContactInformations.Where(contactInfo => contactInfo.ID_ContactInformation != source.ContactInformation.Id).ToList();
                foreach (var contactInformationEntity in toRemove)
                {
                    target.ContactInformations.Remove(contactInformationEntity);
                }
                foreach (var contactInformationEntity in target.ContactInformations.Where(ci => ci.ID_ContactInformation == source.ContactInformation.Id))
                {
                    ContactStateTransfer(source.ContactInformation, contactInformationEntity);
                }
                if (!source.ContactInformation.IsPersisted)
                {
                    CreateNewContactInfo(source.ContactInformation);
                }
            }
        }

        private void CreateNewContactInfo(ContactInformationUpdateData contactInfo)
        {
            var contactEntity = new ContactInformationEntity();
            ContactStateTransfer(contactInfo, contactEntity);
            target.ContactInformations.Add(contactEntity);
        }

        public void ContactStateTransfer(ContactInformationUpdateData source, ContactInformationEntity target)
        {
            target.Email = source.Email;
            target.Phone = source.Phone;
            target.ID_ContactInformation = source.Id;
        }

    }
}

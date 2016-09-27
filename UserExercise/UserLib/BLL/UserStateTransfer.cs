using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public sealed class UserStateTransfer
    {
        private readonly UserDTO source;
        private readonly UserEntity target;

        public UserStateTransfer(UserDTO source, UserEntity target)
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
            target.IsSuspended = source.IsSuspended;
            target.IsActive = source.IsActive;
            if (target.ContactInformations == null && source.ContactInformation == null)
            {
                return;
            }

            if (target.ContactInformations == null && source.ContactInformation != null)
            {
                target.ContactInformations = new List<ContactInformationEntity>();
                foreach (var contactInfo in source.ContactInformation)
                {
                    CreateNewContactInfo(contactInfo);
                }
            }
            else if (target.ContactInformations != null && source.ContactInformation == null)
            {
                target.ContactInformations.Clear();
            }
            else
            {
                var toRemove = target.ContactInformations.Where(contactInfo => source.ContactInformation.All(c => c.Id != contactInfo.ID_ContactInformation)).ToList();
                foreach (var contactInformationEntity in toRemove)
                {
                    target.ContactInformations.Remove(contactInformationEntity);
                }
                foreach (var contactInformationEntity in target.ContactInformations)
                {
                    var sourceContactInfo =
                        source.ContactInformation.First(c => c.Id == contactInformationEntity.ID_ContactInformation);
                    ContactStateTransfer(sourceContactInfo,contactInformationEntity);
                }
                var newContactInfos = source.ContactInformation.Where(c => !c.IsPersisted);
                foreach (var contactInfo in newContactInfos)
                {
                    CreateNewContactInfo(contactInfo);
                }
            }
        }

        private void CreateNewContactInfo(ContactInformationDTO contactInfo)
        {
            var contactEntity = new ContactInformationEntity();
            ContactStateTransfer(contactInfo, contactEntity);
            target.ContactInformations.Add(contactEntity);
        }

        public void ContactStateTransfer(ContactInformationDTO source, ContactInformationEntity target)
        {
            target.Email = source.Email;
            target.Phone = source.Phone;
            target.UserID = source.UserId;
            target.ID_ContactInformation = source.Id;
        }

    }
}

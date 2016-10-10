using Canea.Common;

namespace User.UI.Logic
{
    public class UserBO:IObjectWithId
    {
        public UserBO(long id, string firstName, string lastName, string username, bool isActive, ContactInformationBO contactInformation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            IsActive = isActive;
            ContactInformation = contactInformation;
        }

        public UserBO() : this(id: 0, firstName: null, lastName: null, username: null, isActive: false, contactInformation: new ContactInformationBO())
        {

        }
        public long Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }

        public ContactInformationBO ContactInformation { get; set; }

        public bool IsPersisted => Id > 0;
    }
}

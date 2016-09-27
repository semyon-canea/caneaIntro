namespace User.UI.Logic
{
    // ReSharper disable once InconsistentNaming
    public class UserBO
    {
        public UserBO(long id, string firstName, string lastName, string userName, bool isActive, ContactInformationBO contactInformation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            IsActive = isActive;
            ContactInformation = contactInformation;
        }

        public UserBO() : this(id: 0, firstName: null, lastName: null, userName: null, isActive: false, contactInformation: new ContactInformationBO())
        {

        }
        public long Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public ContactInformationBO ContactInformation { get; set; }

        public bool IsPersisted => Id > 0;
    }
}

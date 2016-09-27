namespace UserLib.BLL
{
    public class UserUpdateData
    {
        public UserUpdateData(long userId, string firstName, string lastName, string userName, bool isActive, ContactInformationUpdateData contactInformation)
        {
            Id = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
            ContactInformation = contactInformation;
        }

        public long Id { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsActive { get; }
        public ContactInformationUpdateData ContactInformation { get; }
        public bool IsPersisted => Id > 0;
    }
}

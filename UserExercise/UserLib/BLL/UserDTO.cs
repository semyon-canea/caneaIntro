namespace EmployeeLib.BLL
{
    public class UserDTO
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string UserName { get; }
        public bool IsActive { get; }
        public bool IsSuspended { get; }

        public ContactInformationDTO ContactInformation { get; }

        public UserDTO(long id, string firstName, string lastName, string userName, bool isActive, bool isSuspended, ContactInformationDTO contactInformation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            IsActive = isActive;
            IsSuspended = isSuspended;
            ContactInformation = contactInformation;
        }
    }
}

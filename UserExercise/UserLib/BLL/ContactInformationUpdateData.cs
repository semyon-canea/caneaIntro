namespace UserLib.BLL
{
    public class ContactInformationUpdateData
    {
        public ContactInformationUpdateData(long id, long userId, string email, string phone)
        {
            Id = id;
            UserId = userId;
            Email = email;
            Phone = phone;
        }

        public string Email { get; }
        public string Phone { get; }
        public long UserId { get; }
        public long Id { get; }
        public bool IsPersisted => Id > 0;
    }
}
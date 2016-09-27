namespace UserLib.BLL
{
    public class ContactInformationUpdateData
    {
        public ContactInformationUpdateData(long id, string email, string phone)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }

        public string Email { get; }
        public string Phone { get; }
        public long Id { get; }
        public bool IsPersisted => Id > 0;
    }
}
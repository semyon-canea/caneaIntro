using System.Runtime.CompilerServices;

namespace User.UI.Logic
{
    public class ContactInformationBO
    {
        public ContactInformationBO(long id, string email, string phone)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }

        public ContactInformationBO() : this(id: 0, email: null, phone: null)
        {
        }

        public long Id { get; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsPersisted => Id > 0;
    }
}
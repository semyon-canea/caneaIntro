namespace EmployeeLib.BLL
{
    public class ContactInformationDTO
    {
        public long Id { get;  }
        public long UserId { get;  }
        public string Email { get;  }
        public string Phone { get;  }

        public ContactInformationDTO(long id, long userId, string email, string phone)
        {
            Id = id;
            UserId = userId;
            Email = email;
            Phone = phone;
        }
    }
}
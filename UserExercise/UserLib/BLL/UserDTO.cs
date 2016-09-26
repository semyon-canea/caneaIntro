using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.BLL
{
    public class UserDTO
    {
        public long Id { get; }
        public UserDTO(long id)
        {
            Id = id;
            throw new NotImplementedException();
        }

        public bool IsPersisted => Id > 0;
    }
}

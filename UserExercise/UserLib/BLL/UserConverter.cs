using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public sealed class UserConverter
    {
        public UserDTO ConvertToUserDTO(UserEntity entity)
        {
            return new UserDTO(entity._userID);
        }
    }
}

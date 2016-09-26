using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib.DAL;

namespace EmployeeLib.BLL
{
    public sealed class UserStateTransfer
    {
        private readonly UserDTO source;
        private readonly UserEntity target;

        public UserStateTransfer(UserDTO source, UserEntity target)
        {
            this.source = source;
            this.target = target;
        }

        public void TransferState()
        {
            throw new NotImplementedException();
        }
    }
}

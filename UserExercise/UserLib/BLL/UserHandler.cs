using System.Collections.Generic;
using System.Linq;
using EmployeeLib.DAL;
using EmployeeLib.DBSim;
using UserLib.BLL;

namespace EmployeeLib.BLL
{
    public sealed class UserHandler
    {
        public IList<UserDTO> GetUsers()
        {
            var enities = new UserRepository().GetAllUsers();
            var converter = new UserConverter();
            var dtos = enities.Select(entity => converter.ConvertToUserDTO(entity)).ToList();
            return dtos;
        }

        public UserDTO GetUser(long userId)
        {
            var entity = new UserRepository().GetUserById(userId);
            return new UserConverter().ConvertToUserDTO(entity);
        }

        public long SaveNewUser(UserUpdateData user)
        {
            var entity = new UserEntity();
            new UserStateTransfer(user, entity).TransferState();
            StaticDB.SaveChanges(entity);
            return entity._userID;
        }

        public long UpdateUser(UserUpdateData user)
        {
            var entity = new UserRepository().GetUserById(user.Id);
            new UserStateTransfer(user, entity).TransferState();
            StaticDB.SaveChanges(entity);
            return entity._userID;
        }

        public void DeleteUser(long userId)
        {
            var entity = new UserRepository().GetUserById(userId);
            StaticDB.DeleteObject(entity);
        }
    }
}

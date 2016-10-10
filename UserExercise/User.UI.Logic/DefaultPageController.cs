using System.Linq;
using Canea.Common.UI.View;
using EmployeeLib.BLL;

namespace User.UI.Logic
{
    public class DefaultPageController : ControllerBase<IDefaultPageView>
    {
        private readonly UserHandler _userHandler;
        public DefaultPageController()
        {
            _userHandler = new UserHandler();
        }

        protected override void InitializeViewModel()
        {
            SetUserList();
        }

        public void DeleteUser(long userId)
        {
            _userHandler.DeleteUser(userId);
            SetUserList();
        }

        public void SaveUser()
        {
            var user = new UserBOConverter().ConvertUserBO(View.Model.Users.SelectedItem);
            if (user.IsPersisted)
            {
                _userHandler.UpdateUser(user);
            }
            else
            {
                _userHandler.SaveNewUser(user);
            }
            SetUserList();
            View.Model.Users.ClearSelection();
        }

        private void SetUserList()
        {
            var converter = new UserBOConverter();
            View.Model.Users.Clear();
            View.Model.Users.AddRange(_userHandler.GetUsers().Select(converter.ConvertUserDTO).ToList());;
            View.UpdateUserDataSource();
        }
    }
}
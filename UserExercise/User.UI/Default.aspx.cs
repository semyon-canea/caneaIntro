using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeLib.BLL;
using User.UI.Logic;
using UserLib.BLL;

namespace User.UI
{
    public partial class _Default : Page
    {
        private readonly UserHandler _userHandler;
        private UserBO _selectedUser;

        public _Default()
        {
            _userHandler = new UserHandler();
        }

        public IList<UserBO> Users { get; set; }

        public UserBO SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SetUserFields();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetUserSource();
        }

        protected void editUser_OnServerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            long userId;
            if (button.CommandArgument != null && button.CommandArgument.Any() && long.TryParse(button.CommandArgument[0].ToString(), out userId))
            {
                SelectedUser = new UserBOConverter().Convert(_userHandler.GetUser(userId));
            }
        }

        protected void newUser_OnServerClick(object sender, EventArgs e)
        {
            SelectedUser = new UserBO();
        }

        protected void saveUser_OnServerClick(object sender, EventArgs e)
        {
            var userId = long.Parse(UserId.Value);

            var user = new UserUpdateData(userId, firstName.Text,
                lastName.Text, userName.Text, isActive.Checked,
                 new ContactInformationUpdateData(0, userId, email.Text, phone.Text));
            if (user.IsPersisted)
            {
                _userHandler.UpdateUser(user);
            }
            else
            {
                _userHandler.SaveNewUser(user);
            }
            SetUserSource();
        }

        protected void cancel_OnServerClick(object sender, EventArgs e)
        {
            SelectedUser = null;
        }

        protected void deleteUser_OnServerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            long userId;
            if (button.CommandArgument != null && button.CommandArgument.Any() && long.TryParse(button.CommandArgument[0].ToString(), out userId))
            {
                _userHandler.DeleteUser(userId);
                SetUserSource();
            }
        }

        private void SetUserSource()
        {
            var converter = new UserBOConverter();
            Users = _userHandler.GetUsers().Select(converter.Convert).ToList();
            Repeater1.DataSource = Users;
            Repeater1.DataBind();
        }

        private void SetUserFields()
        {
            if (SelectedUser == null)
            {
                return;
            }
            userName.Text = SelectedUser.UserName;
            firstName.Text = SelectedUser.FirstName;
            lastName.Text = SelectedUser.LastName;
            isActive.Checked = SelectedUser.IsActive;
            UserId.Value = SelectedUser.Id.ToString();
            if (SelectedUser.ContactInformation != null)
            {
                var contactInformationDto = SelectedUser.ContactInformation;
                email.Text = contactInformationDto.Email;
                phone.Text = contactInformationDto.Phone;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeLib.BLL;

namespace User.UI
{
    public partial class _Default : Page
    {
        private readonly UserHandler _userHandler;
        private UserDTO _selectedUser;

        public _Default()
        {
            _userHandler = new UserHandler();
        }

        public IList<UserDTO> Users { get; set; }

        public UserDTO SelectedUser
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

        private void SetUserSource()
        {
            Users = _userHandler.GetUsers();
            Repeater1.DataSource = Users;
            Repeater1.DataBind();
        }


        protected void editUser_OnServerClick(object sender, EventArgs e)
        {
            try
            {
                var button = (Button)sender;
                long userId;
                if (button.CommandArgument != null && button.CommandArgument.Any() && long.TryParse(button.CommandArgument[0].ToString(), out userId))
                {
                    SelectedUser = _userHandler.GetUser(userId);
                }
            }
            catch (Exception)
            {

                throw;
            }
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
            isSuspended.Checked = SelectedUser.IsSuspended;
            UserId.Value = SelectedUser.Id.ToString();
            if (SelectedUser.ContactInformation != null && SelectedUser.ContactInformation.Any())
            {
                var contactInformationDto = SelectedUser.ContactInformation.First();
                email.Text = contactInformationDto.Email;
                phone.Text = contactInformationDto.Phone;
            }
        }

        protected void newUser_OnServerClick(object sender, EventArgs e)
        {
            SelectedUser = new UserDTO(0, "", "", "", false, false, null);
        }

        protected void saveUser_OnServerClick(object sender, EventArgs e)
        {
            var userId = long.Parse(UserId.Value);

            var user = new UserDTO(userId, firstName.Text, lastName.Text, userName.Text, isActive.Checked,
                isSuspended.Checked,
                new List<ContactInformationDTO> { new ContactInformationDTO(0, userId, email.Text, phone.Text) });
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
            try
            {
                var button = (Button)sender;
                long userId;
                if (button.CommandArgument != null && button.CommandArgument.Any() && long.TryParse(button.CommandArgument[0].ToString(), out userId))
                {
                    _userHandler.DeleteUser(userId);
                    SetUserSource();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using System;
using System.Web.UI.WebControls;
using Canea.Common.UI.WebForms.View;
using User.UI.Logic;

namespace User.UI
{
    public partial class _Default : PageBase<DefaultPageController, DefaultPageModel>, IDefaultPageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateUserDataSource();
        }

        protected override void OnUnbind(EventArgs e)
        {
            base.OnUnbind(e);

            var modelSelectedUser = Model.SelectedUser;
            if (modelSelectedUser != null)
            {
                modelSelectedUser.FirstName = this.firstName.Text;
                modelSelectedUser.LastName = this.lastName.Text;
                modelSelectedUser.UserName = this.userName.Text;
                modelSelectedUser.IsActive = this.isActive.Checked;
                modelSelectedUser.ContactInformation.Email = this.email.Text;
                modelSelectedUser.ContactInformation.Phone = this.phone.Text;
            }
        }

        protected void editUser_OnServerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var userId = long.Parse(button.CommandArgument[0].ToString());
            Controller.EditUser(userId);
        }

        protected void newUser_OnServerClick(object sender, EventArgs e)
        {
            Model.SelectedUser = new UserBO();
        }

        protected void saveUser_OnServerClick(object sender, EventArgs e)
        {
            Controller.SaveUser();
        }

        protected void cancel_OnServerClick(object sender, EventArgs e)
        {
            Model.SelectedUser = null;
        }

        protected void deleteUser_OnServerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var userId = long.Parse(button.CommandArgument[0].ToString());
            Controller.DeleteUser(userId);
        }

        public void UpdateUserDataSource()
        {
            Repeater1.DataSource = Model.Users;
            Repeater1.DataBind();
        }
    }
}
using System;
using Canea.Common.UI.WebForms.View;
using Telerik.Web.UI;
using User.UI.Logic;

namespace User.UI
{
    public partial class _Default : PageBase<DefaultPageController, DefaultPageModel>, IDefaultPageView
    {

        protected override void OnUnbind(EventArgs e)
        {
            base.OnUnbind(e);

            var modelSelectedUser = Model.Users.SelectedItem;
            if (modelSelectedUser != null)
            {
                modelSelectedUser.FirstName = this.firstName.Text;
                modelSelectedUser.LastName = this.lastName.Text;
                modelSelectedUser.Username = this.userName.Text;
                modelSelectedUser.IsActive = this.isActive.Checked;
                modelSelectedUser.ContactInformation.Email = this.email.Text;
                modelSelectedUser.ContactInformation.Phone = this.phone.Text;
            }
        }

        protected void newUser_OnServerClick(object sender, EventArgs e)
        {
            var newUser = new UserBO();
            Model.Users.Add(newUser);
            Model.Users.SelectedItem = newUser;
        }

        protected void saveUser_OnServerClick(object sender, EventArgs e)
        {
            Controller.SaveUser();
        }

        protected void cancel_OnServerClick(object sender, EventArgs e)
        {
            Model.Users.SelectedItem = null;
        }

        public void UpdateUserDataSource()
        {
            userGrid.Rebind();
        }

        protected void userGrid_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            userGrid.DataSource = Model.Users;
        }

        protected void userGrid_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            var data = (GridDataItem) e.Item;
            var userId = long.Parse(data["Id"].Text);
            Controller.DeleteUser(userId);
        }
    }
}
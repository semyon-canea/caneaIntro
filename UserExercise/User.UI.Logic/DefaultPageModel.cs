using System.Collections.Generic;
using Canea.Common.UI.View;

namespace User.UI.Logic
{
    public class DefaultPageModel:ViewModelBase
    {

        public UserBO SelectedUser { get; set; }
        public IList<UserBO> Users { get; set; }
    }
}
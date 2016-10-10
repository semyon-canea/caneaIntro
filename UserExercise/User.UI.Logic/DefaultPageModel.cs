using Canea.Common.Collections;
using Canea.Common.UI.View;

namespace User.UI.Logic
{
    public class DefaultPageModel:ViewModelBase
    {
        public DefaultPageModel()
        {
            Users = new CollectionView<UserBO>();
        }
        public CollectionView<UserBO> Users { get; set; }
    }
}
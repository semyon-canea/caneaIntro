using Canea.Common.UI.View;

namespace User.UI.Logic
{
    public interface IDefaultPageView:IView<DefaultPageModel>
    {
        void UpdateUserDataSource();
    }
}
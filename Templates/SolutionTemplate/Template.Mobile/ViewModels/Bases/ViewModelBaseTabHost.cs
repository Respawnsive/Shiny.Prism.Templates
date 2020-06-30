using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using System.Threading.Tasks;

namespace $safeprojectname$.ViewModels
{
    public abstract class ViewModelBaseTabHost : ViewModelBasePage
    {
        protected ViewModelBaseTabHost(INavigationService navigationService) : base(navigationService)
        {

        }


        #region Services



        #endregion

        
        #region Properties



        #endregion

        
        #region Commands



        #endregion


        #region Methods

        public virtual async void SelectTab(string TabName, INavigationParameters param = null)
        {
            var res = await NavigationService.SelectTabAsync(TabName, param);
        }

        #endregion


        #region Lifecycle


        #endregion
    }
}

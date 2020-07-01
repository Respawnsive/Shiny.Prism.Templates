using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using $rootnamespace$.Helpers;

namespace $rootnamespace$.ViewModels
{
    public class $viewmodelName$ : ViewModelBaseTabHost
    {

        public $viewmodelName$(INavigationService navigationService) : base(navigationService)
        {
        }


        #region Services


        #endregion


        #region Properties

        #endregion


        #region Commands


        #endregion


        #region Methods


        #endregion


        #region LifeCycle

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }

        public override Task NavigateBackAsync()
        {
            return base.NavigateBackAsync();
        }

        #endregion

    }
}

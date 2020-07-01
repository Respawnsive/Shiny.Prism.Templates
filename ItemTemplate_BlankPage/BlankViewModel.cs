using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $rootnamespace$.ViewModels
{
	public class $viewmodelName$  : ViewModelBasePage
	{
        public $viewmodelName$(INavigationService navigationService) : base(navigationService)
        {
            try
            {
                NavigateBackCommand = ExecutionAwareCommand.FromTask(NavigateBackAsync)
                    .OnIsExecutingChanged(SetIsExecuting);
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }


        #region Services

        #endregion

        
        #region Properties



        #endregion

        
        #region Commands

        public ICommand NavigateBackCommand { get; }

        #endregion


        #region Methods


        #endregion


        #region Lifecycle


        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) => Task.FromResult(true);

        public virtual Task NavigateBackAsync() => NavigationService.GoBackAsync();

        #endregion
    }
}
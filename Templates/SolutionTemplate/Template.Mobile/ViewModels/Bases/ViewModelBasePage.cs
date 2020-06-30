using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Localizr;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using $safeprojectname$.Helpers;
using $safeprojectname$.Services;

namespace $safeprojectname$.ViewModels
{
    public abstract class ViewModelBasePage : ViewModelBase, IConfirmNavigationAsync
    {
        protected ViewModelBasePage(INavigationService navigationService) : base(navigationService)
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

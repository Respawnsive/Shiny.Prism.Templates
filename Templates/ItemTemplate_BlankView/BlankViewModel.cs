﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using $rootnamespace$.Helpers;

namespace $rootnamespace$.ViewModels
{
	public class $viewmodelName$  : ViewModelBase
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

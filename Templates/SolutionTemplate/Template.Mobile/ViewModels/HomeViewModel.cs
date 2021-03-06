﻿using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using $safeprojectname$.Helpers;
using $safeprojectname$.Views;

namespace $safeprojectname$.ViewModels
{
    public class HomeViewModel : ViewModelBasePage
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Create commands
            LoadCommand = ExecutionAwareCommand.FromTask(LoadDatas).OnIsExecutingChanged(SetIsExecuting);
            NavigateCmd = ExecutionAwareCommand.FromTask(Navigate).OnIsExecutingChanged(SetIsExecuting);
            //Subscribe to Properties changes
            this.WhenAnyValue(x => x.Property1).Subscribe(Property1Changed).DisposeWith(DestroyWith);
        }

        #region Services


        #endregion


        #region Properties

        [Reactive]
        public string Property1 { get; set; }

        #endregion


        #region Commands

        public ICommand LoadCommand { get; }
        public ICommand NavigateCmd { get; }

        #endregion


        #region Methods

        private void Property1Changed(string value)
        {
            Console.WriteLine($"Property1Changed with value : {value}");
        }

        private async Task LoadDatas()
        {
            try
            {
                //Load data for this ViewModel (fake)
                await Task.Delay(1000);
                Property1 = "Toto";
                await Task.Delay(1000);

            }
            catch(Exception ex)
            {
                DialogsService?.Toast(this["Msg_RedToast_Error_Unknown"]);
                Logger.Write(ex);
            }
            finally
            {

            }
        }

        private async Task Navigate()
        {

            await NavigationService.NavigateAsync(nameof(BlankPage));
        }

        #endregion


        #region LifeCycle

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Task.Run(() => LoadDatas());
        }

        #endregion


    }
}

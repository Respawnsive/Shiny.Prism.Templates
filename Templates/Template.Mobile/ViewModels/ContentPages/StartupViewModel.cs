using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Template.Mobile.Helpers;
using Template.Mobile.Views;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class StartupViewModel : ViewModelBase
    {
        public StartupViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoadCommand = ExecutionAwareCommand.FromTask(LoadApplication).OnIsExecutingChanged(res =>
            {
                if (res)
                    BusyCounter++;
                BusyCounter--;
            });
        }

        #region Services

        #endregion

        #region Properties


        [Reactive]
        public bool HasFailedOnce { get; set; }

        [Reactive]
        public string StatusLabel { get; set; }

        #endregion

        #region Commands

        public ICommand LoadCommand { get; }


        #endregion

        #region Methods

        private async Task LoadApplication()
        {
            string error = null;
            Device.BeginInvokeOnMainThread(() => BusyCounter++);
            try
            {
                // Manage here any long time initialization (DB, Localisation, etc...)

                //var taskToDo = LocalizationService.InitializeAsync();
                //var taskToWait = Task.Delay(3000);
                //await Task.WhenAll(taskToDo, taskToWait);

                StatusLabel = "Chargement du thème...";
                await ThemeHelper.InitTheme();
                await Task.Delay(1000);

                //Fake/Dev init
                StatusLabel = "Chargement de la BDD...";
                await Task.Delay(1000);
                StatusLabel = "Chargement de la langue...";
                await Task.Delay(1000);
                StatusLabel = "Chargement de XXX...";
                await Task.Delay(1000);
                StatusLabel = "Chargement de YYY...";
                await Task.Delay(1000);
                StatusLabel = "Lancement de l'application...";
                await Task.Delay(1000);
                
                // Manage startup navigation logic (ConfigPage or LoginProcess or HomePage or whatever...)
                string nextPage;
                //if (SettingsService.IsUserLogged())
                //{
                nextPage = $"/{nameof(MDPage)}/{nameof(NavigationPage)}/{nameof(HomePage)}";
                //}
                //else
                //{
                //    mainPage = $"/{nameof(LoginPage)}";
                //}

                await Device.InvokeOnMainThreadAsync(async () => await NavigationService.NavigateAsync(nextPage));
            }
            catch (Exception ex)
            {
                error = this["Msg_RedToast_Error_Unknown"];
                Logger.Write(ex);
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(error))
                {
                    //TODO resolve errors in DialogService before !!!
                    //DialogsService.Toast(error);
                    HasFailedOnce = true;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    BusyCounter--;
                });
            }
        }

        #endregion

        #region LifeCycle

        public override void Initialize(INavigationParameters parameters)
        {
            Task.Run(LoadApplication);
        }

        #endregion
    }
}

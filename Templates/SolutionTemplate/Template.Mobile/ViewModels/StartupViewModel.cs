using Prism.Commands;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using $safeprojectname$.Helpers;
using $safeprojectname$.Views;
using Xamarin.Forms;

namespace $safeprojectname$.ViewModels
{
    public class StartupViewModel : ViewModelBasePage
    {
        public StartupViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Create commands
            LoadCommand = ExecutionAwareCommand.FromTask(LoadApplication).OnIsExecutingChanged(SetIsExecuting);

            //Subscribe to Properties changes
            //this.WhenAnyValue(x => x.Property1).Subscribe(Property1Changed).DisposeWith(DestroyWith);
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
            try
            {
                SetIsExecuting(true);
                // Manage here any long time initialization (DB, Localisation, etc...)
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
                nextPage = $"{nameof(App)}:///{nameof(MDPage)}/{nameof(NavigationPage)}/{nameof(HomePage)}";
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
                    DialogsService?.Toast(error);
                    HasFailedOnce = true;
                }
                SetIsExecuting(false);
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

using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using $safeprojectname$.Helpers;
using $safeprojectname$.Models;
using $safeprojectname$.Views;
using Xamarin.Forms;

namespace $safeprojectname$.ViewModels
{
    public class MDViewModel : ViewModelBase
    {
        public MDViewModel(INavigationService navigationService/*, INotificationService notificationService*/) : base(navigationService)
        {
            //_notificationService = notificationService;

            //Create commands
            LogoutCommand = ExecutionAwareCommand.FromTask(LogoutUser).OnIsExecutingChanged(SetIsExecuting);
            //MenuNavigateCommand = ExecutionAwareCommand.FromTask(MenuNavigateTo).OnIsExecutingChanged(OnIsExecutingChanged);

            //Subscribe to Properties changes
            this.WhenAnyValue(x => x.SelectedMenuItem).Subscribe(MenuNavigateTo).DisposeWith(DestroyWith);

            Task.Run(() => LoadDatas());
        }


        #region Services

        //private readonly INotificationService _notificationService;

        #endregion


        #region Properties

        [Reactive]
        public List<MenuItemModel> MenuItems { get; set; }

        [Reactive]
        public MenuItemModel SelectedMenuItem { get; set; }

        [Reactive]
        public string UserDisplayName { get; set; }

        [Reactive]
        public string UserLogin { get; set; }

        #endregion


        #region Commands

        public ICommand LogoutCommand { get; }

        //public ICommand MenuNavigateCommand { get; }

        #endregion


        #region Methods

        private async Task LogoutUser()
        {
            try
            {
                if (await DialogsService?.ConfirmAsync(this["Msg_Confirm_Disconnect"], this["Msg_Confirm_Title"], this["Msg_Confirm_Ok"], this["Msg_Confirm_Cancel"]))
                {
                    DialogsService?.Loading(this["Msg_Loading_Disconnecting"]);
                    await Task.Delay(500);
                    //await DataService.ClearUserDataAsync();
                    SettingsService?.Clear();
                    //_notificationService.Unregister();
                    Logger.Write("LogoutUser", $"Day({DateTime.Now.ToString("yyyy_MM_dd")})");
                    await NavigationService.NavigateAsync($"{nameof(App)}:///{nameof(StartupPage)}");
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private async void MenuNavigateTo(MenuItemModel item)
        {
            try
            {
                if (item != null && item.IsActive && !String.IsNullOrWhiteSpace(item.NavigationPath))
                {
                    await NavigationService.NavigateAsync(item.NavigationPath);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private async Task LoadDatas()
        {
            try
            {
                //Load data for this ViewModel

                //Get User display
                UserDisplayName = "Prénom Nom"; //SettingsService.UserPrenom + " " + SettingsService.UserNom;
                UserLogin = "prenom.nom@email.com"; //SettingsService.UserEmail;

                //Create NavigationMenu
                MenuItems = new List<MenuItemModel>
                {
                    new MenuItemModel
                    {
                        Title = this["HomePage_Title"],
                        ItemImageSource = "ic_home.png",
                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(HomePage)}"
                    },
                    //Add any new MenuItem in MasterDetail menu
                    //new MenuItemModel
                    //{
                    //    Title = this["NewPage_Title"],
                    //    ItemImageSource = "newpage_icon.png",
                    //    NavigationPath = $"{nameof(NavigationPage)}/{nameof(NewPage)}"
                    //},
                };

#if DEBUG
                MenuItems.Add(new MenuItemModel
                {
                    Title = this["Debug_BottomTabsPage_Title"],
                    ItemImageSource = "ic_bug_report.png",
                    NavigationPath = $"{nameof(NavigationPage)}/{nameof(Debug_BottomTabsPage)}?selectedTab={nameof(Debug_ImagesView)}"
                });

                MenuItems.Add(new MenuItemModel
                {
                    Title = this["WalkThrough_Title"],
                    ItemImageSource = "ic_bug_report.png",
                    NavigationPath = $"{nameof(WalkThroughPage)}"
                });
#endif

                //await Device.InvokeOnMainThreadAsync(notificationService.RegisterAsync);

                //MessagingCenter.Unsubscribe<object, string>(this, "NotifURL");
                //MessagingCenter.Subscribe<object, string>(this, "NotifURL", async (sender, url) =>
                //{
                //    await NavigationService.NavigateAsync(url);
                //});

                //if (SelectedMenuItem == null)
                //    SelectedMenuItem = MenuItems.Count > 0 ? MenuItems[0] : null;

            }
            catch (Exception ex)
            {
                DialogsService?.Toast(this["Msg_RedToast_Error_Unknown"]);
                Logger.Write(ex);
            }
            finally
            {

            }
        }

        #endregion


        #region LifeCycle

        public override void OnAppearing()
        {
            //if (!string.IsNullOrWhiteSpace(_notificationService.PendingUrl))
            //{
            //    NavigationService.NavigateAsync(_notificationService.PendingUrl);
            //    _notificationService.PendingUrl = null;
            //}
            base.OnAppearing();
        }

        public override void Destroy()
        {
            //MessagingCenter.Unsubscribe<object, string>(this, "NotifURL");
            base.Destroy();
        }

        #endregion

    }
}

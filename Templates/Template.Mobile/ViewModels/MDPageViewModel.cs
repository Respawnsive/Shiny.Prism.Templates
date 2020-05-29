using Prism.Commands;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Mobile.Helpers;
using Template.Mobile.Models;
using Template.Mobile.Views;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class MDPageViewModel : ViewModelBase
    {
        public MDPageViewModel(INavigationService navigationService/*, INotificationService notificationService*/) : base(navigationService)
        {
            try
            {
                //_notificationService = notificationService;
                //Create NavigationMenu here
                MenuItems = new List<MenuItemModel>
                {
                    new MenuItemModel
                    {
                        Title = "Accueil",// this["HomePage_Title"],
                        ItemImageSource = "ic_home.png",
                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(HomePage)}"
                    },
                    new MenuItemModel
                    {
                        Title = "DEBUG Images",// this["TakeInChargePageTitle"],
                        ItemImageSource = "ic_bug_report.png",
                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(Debug_ImagesListPage)}"
                    },
                    new MenuItemModel
                    {
                        Title = "DEBUG Theme",// this["TakeInChargePageTitle"],
                        ItemImageSource = "ic_bug_report.png",
                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(Debug_ThemingPage)}"
                    },
                    new MenuItemModel
                    {
                        Title = this["SamplePage_Title"],
                        ItemImageSource = "ic_bug_report.png",
                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(SamplePage)}"
                    },
                };

                //#if DEBUG
                //                MenuItems.Insert(0, new MenuItemModel
                //                {
                //                        Title = "DEBUG",
                //                        ItemImageSource = "ic_bug_report.png",
                //                        NavigationPath = $"{nameof(NavigationPage)}/{nameof(Debug_ThemingPage)}"
                //                });
                //#endif

                //Device.InvokeOnMainThreadAsync(notificationService.RegisterAsync);

                //MessagingCenter.Unsubscribe<object, string>(this, "NotifURL");
                //MessagingCenter.Subscribe<object, string>(this, "NotifURL", async (sender, url) =>
                //{
                //    await NavigationService.NavigateAsync(url);
                //});

                SelectedMenuItem = MenuItems.Count > 0 ? MenuItems[0] : null;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        #region Private Properties/Instances

        //private readonly INotificationService _notificationService;

        #endregion

        #region Bindable Properties

        [Reactive]
        public List<MenuItemModel> MenuItems { get; set; }

        [Reactive]
        public MenuItemModel SelectedMenuItem { get; set; }

        public string UserDisplayName => "Prénom Nom"; //SettingsService.UserPrenom + " " + SettingsService.UserNom;
        public string UserLogin => "prenom.nom@email.com";
        #endregion

        #region Commands

        #region MenuNavigateCommand

        private DelegateCommand<MenuItemModel> _menuNavigateCommand;
        public DelegateCommand<MenuItemModel> MenuNavigateCommand => (_menuNavigateCommand = _menuNavigateCommand ?? new DelegateCommand<MenuItemModel>(MenuNavigateCommandExecuteAsync, MenuNavigateCommandCanExecute));

        private bool MenuNavigateCommandCanExecute(MenuItemModel selectedItem)
        {
            if (selectedItem != null)
                //Conditions pour exécuter la command
                return selectedItem.IsActive;
            return false;
        }

        private async void MenuNavigateCommandExecuteAsync(MenuItemModel selectedItem)
        {
            try
            {
                if (selectedItem != null)
                {
                    await NavigationService.NavigateAsync(selectedItem.NavigationPath);
                    Logger.Write("MenuNavigateCommandExecuteAsync", $"{selectedItem.NavigationPath}");
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        #endregion

        #region LogoutCommand

        private DelegateCommand<object> _logoutCommand;
        public DelegateCommand<object> LogoutCommand => (_logoutCommand = _logoutCommand ?? new DelegateCommand<object>(LogoutCommandExecuteAsync, LogoutCommandCanExecute));

        private bool LogoutCommandCanExecute(object parameter)
        {
            //Conditions pour exécuter la command
            return !IsBusy;
        }

        private async void LogoutCommandExecuteAsync(object parameter)
        {
            try
            {
                //if (await Dialogs.ConfirmDialog(this["Msg_Confirm_Disconnect"]))
                //{
                //    Dialogs.DisplayLoading(this["Msg_Loading_Disconnecting"]);
                //    await Task.Delay(500);
                //    await DataService.ClearUserDataAsync();
                //    SettingsService.ClearUser();
                //    _notificationService.Unregister();
                //    Logger.Write("LogoutCommandExecuteAsync", $"Day({DateTime.Now.ToString("yyyy_MM_dd")})");
                //    await NavigationService.NavigateAsync($"{nameof(TracioApp)}:///{nameof(LoginPage)}");
                //}
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #endregion

        #region Navigation & LifeCycle


        public override void Destroy()
        {
            MessagingCenter.Unsubscribe<object, string>(this, "NotifURL");
            base.Destroy();
        }

        public override Task NavigateBackAsync()
        {
            return NavigationService.GoBackAsync();
        }

        #endregion

        public override void OnAppearing()
        {
            //if (!string.IsNullOrWhiteSpace(_notificationService.PendingUrl))
            //{
            //    NavigationService.NavigateAsync(_notificationService.PendingUrl);
            //    _notificationService.PendingUrl = null;
            //}
        }

        
    }
}

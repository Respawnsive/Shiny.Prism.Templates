using System.Collections.Generic;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Apizr;
using $safeprojectname$.Models.SampleApi;
using $safeprojectname$.Services;
using Xamarin.Forms;

namespace $safeprojectname$.ViewModels
{
    public class Debug_SamplesViewModel : ViewModelBase
    {
        private readonly IApizrManager<ISampleApiService> _sampleApiManager;

        public Debug_SamplesViewModel(INavigationService navigationService, IApizrManager<ISampleApiService> sampleApiManager) : base(navigationService)
        {
            _sampleApiManager = sampleApiManager;
        }


        #region Properties

        [Reactive]
        public ObservableCollection<User> Users { get; set; }

        #endregion


        #region Commands

        //public ICommand LoadCommand { get; }

        #endregion


        #region Methods

        private async Task GetUsersAsync()
        {
            IList<User>? users;
            try
            {
                var userList = await _sampleApiManager.ExecuteAsync((ct, api) => api.GetUsersAsync(ct), CancellationToken.None);
                users = userList.Data;
            }
            catch (ApizrException<UserList> e)
            {
                var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
                UserDialogs.Instance.Toast(new ToastConfig(message) { BackgroundColor = Color.Red, MessageTextColor = Color.White });

                users = e.CachedResult?.Data;
            }

            if (users != null)
                Users = new ObservableCollection<User>(users);
        }

        #endregion

        #region Lifecycle

        public override void OnAppearing()
        {
            base.OnAppearing();
            Device.InvokeOnMainThreadAsync(GetUsersAsync);
        } 

        #endregion
    }
}

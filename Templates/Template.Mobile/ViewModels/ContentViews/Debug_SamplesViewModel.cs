using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Template.Mobile.Models.SampleApi;
using Template.Mobile.Services;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class Debug_SamplesViewModel : ViewModelBase
    {
        private readonly ISampleApiService _sampleApiService;

        public Debug_SamplesViewModel(INavigationService navigationService, ISampleApiService sampleApiService) : base(navigationService)
        {
            _sampleApiService = sampleApiService;
        }


        [Reactive]
        public ObservableCollection<User> Users { get; set; }

        private async Task GetUsersAsync()
        {
            var userList = await _sampleApiService.GetUsersAsync(0);
            if (!userList.Data.IsEmpty())
                Users = new ObservableCollection<User>(userList.Data);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Device.BeginInvokeOnMainThread(async() => await GetUsersAsync());
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Template.Mobile.Models.SampleApi;
using Template.Mobile.Services.SampleApi;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class SamplePageViewModel : ViewModelBase
    {
        private readonly ISampleApiService _sampleApiService;

        public SamplePageViewModel(INavigationService navigationService, ISampleApiService sampleApiService) : base(navigationService)
        {
            _sampleApiService = sampleApiService;
        }

        [Reactive] public ObservableCollection<User> Users { get; set; }

        private async Task GetUsersAsync()
        {
            var userList = await _sampleApiService.GetUsersAsync(0);
            if (!userList.Data.IsEmpty())
                Users = new ObservableCollection<User>(userList.Data);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            Device.InvokeOnMainThreadAsync(GetUsersAsync);
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Template.Mobile.Models.SampleApi;
using Template.Mobile.Services;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class Debug_BottomTabsViewModel : ViewModelBase
    {

        public Debug_BottomTabsViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnAppearing()
        {
            base.OnAppearing();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }

    }
}

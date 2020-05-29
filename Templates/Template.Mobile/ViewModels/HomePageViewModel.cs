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
    public class HomePageViewModel : ViewModelBase
    {

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        [Reactive] public string Property1 { get; set; }


    }
}

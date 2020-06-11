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
    public class LoadingViewModel : ViewModelBase
    {

        public LoadingViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

    }
}

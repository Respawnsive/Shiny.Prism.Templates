using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Template.Mobile.Services;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        [Reactive] public string Property1 { get; set; }


    }
}

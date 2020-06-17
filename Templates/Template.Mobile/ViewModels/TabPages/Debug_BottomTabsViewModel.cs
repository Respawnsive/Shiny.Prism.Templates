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
            Titre1 = "Titre1";
            Titre2 = "Titre2";
            Titre3 = "Titre3";
        }


        [Reactive]
        public string Titre1 { get; set; }


        [Reactive]
        public string Titre2 { get; set; }

        [Reactive]
        public string Titre3 { get; set; }

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

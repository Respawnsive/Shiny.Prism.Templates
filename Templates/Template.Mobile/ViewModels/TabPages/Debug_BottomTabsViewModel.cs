using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Template.Mobile.Models.SampleApi;
using Template.Mobile.Services.SampleApi;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class Debug_BottomTabsViewModel : ViewModelBase
    {

        public Debug_BottomTabsViewModel(INavigationService navigationService) : base(navigationService)
        {
            //SampleContentViewViewModel = new LoadingViewModel(navigationService);
            //Debug_ImagesList_LazyViewViewModel = new Debug_ImagesViewModel(navigationService);
            //Debug_Theming_LazyViewViewModel = new Debug_ThemesViewModel(navigationService);
        }

        //public LoadingViewModel SampleContentViewViewModel { get; }

        //public Debug_ImagesViewModel Debug_ImagesList_LazyViewViewModel { get; }

        //public Debug_ThemesViewModel Debug_Theming_LazyViewViewModel { get; }

        //[Reactive, DefaultValue(0)] 
        //public int SelectedViewModelIndex { get; set; }

    }
}

using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace Template.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = this["MainView_Title"];
            MyText = "Wellcome";
        }

        [Reactive] 
        public string MyText { get; set; }
    }
}

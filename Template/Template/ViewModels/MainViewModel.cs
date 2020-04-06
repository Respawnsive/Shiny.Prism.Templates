using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace Template.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            MyText = "Wellcome";
        }

        [Reactive] 
        public string MyText { get; set; }
    }
}

using System.Diagnostics;
using System.Linq;
using Prism.Events;
using Prism.Ioc;
using Template.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Template.Mobile
{
    [AutoRegisterForNavigation]
    public partial class App
    {
        public App()
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync($"/{nameof(MainView)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //REGISTER ALL THE PAGES FOR PRISM NAVIGATION
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        protected override void OnNavigationError(INavigationError navigationError)
        {
#if DEBUG
            // Ensure we always break here while debugging!
            Debugger.Break();
#else
            Helpers.Logger.Write(navigationError.Exception)(
                new[] {(nameof(navigationError.NavigationUri), navigationError.NavigationUri)}
                    .Concat(navigationError.Parameters
                        .Select(x => (x.Key, x.Value.ToString())))
                    .ToArray());
#endif

            base.OnNavigationError(navigationError);
        }
    }
}

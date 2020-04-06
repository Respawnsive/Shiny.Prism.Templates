using Prism.Ioc;
using System;
using System.Diagnostics;
using System.Linq;
using DynamicData;
using Prism.Events;
using Prism.Logging;
using Shiny.Logging;
using Template.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Template
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
            Utils.Logger.Write(navigationError.Exception)(
                new[] {(nameof(navigationError.NavigationUri), navigationError.NavigationUri)}
                    .Concat(navigationError.Parameters
                        .Select(x => (x.Key, x.Value.ToString())))
                    .ToArray());
#endif

            base.OnNavigationError(navigationError);
        }
    }
}

using System;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using UIKit;

namespace Template.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.ShinyFinishedLaunching(new Startup(), ConfigureServices);

            global::Xamarin.Forms.Forms.Init(); 
            Rg.Plugins.Popup.Popup.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // todo: Add platform specific service implementations here if needed
        }

        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
            => this.ShinyPerformFetch(completionHandler);

        public override void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, Action completionHandler)
            => this.ShinyHandleEventsForBackgroundUrl(sessionIdentifier, completionHandler);
    }
}

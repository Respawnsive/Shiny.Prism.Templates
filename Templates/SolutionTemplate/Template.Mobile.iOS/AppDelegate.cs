using System;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using Microsoft.Extensions.DependencyInjection;
using Sharpnado.MaterialFrame.iOS;
using Sharpnado.Presentation.Forms.iOS;
using Shiny;
using $safeprojectname$.Mobile.Helpers;
using $safeprojectname$.Services;
using $safeprojectname$.Mobile.Services;
using UIKit;

namespace $safeprojectname$
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
            try
            {
                this.ShinyFinishedLaunching(new Startup(), ConfigureServices);

                //Forms Init
                Xamarin.Forms.Forms.SetFlags(new string[] { "CarouselView_Experimental", "IndicatorView_Experimental" });
                global::Xamarin.Forms.Forms.Init();

                //Plugins Init
                global::Xamarin.Forms.FormsMaterial.Init();
                Rg.Plugins.Popup.Popup.Init();
                Xamarin.Forms.Nuke.FormsHandler.Init();
                iOSMaterialFrameRenderer.Init();
                SharpnadoInitializer.Initialize();
                AnimationViewRenderer.Init();

                //Launch FormsApp
                LoadApplication(new App());
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }

            return base.FinishedLaunching(app, options);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //Add platform-specific service implementations here if needed
            services.AddSingleton<IPlatformThemeService, PlatformThemeService>();
        }

        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
            => this.ShinyPerformFetch(completionHandler);

        public override void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, Action completionHandler)
            => this.ShinyHandleEventsForBackgroundUrl(sessionIdentifier, completionHandler);
    }
}

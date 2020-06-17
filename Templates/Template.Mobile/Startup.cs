using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Prism;
using Template.Mobile.Modules;

namespace Template.Mobile
{
    public class Startup : PrismStartup
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add Xamarin Essentials
            services.RegisterModule<EssentialsModule>();

            // Add Settings
            services.RegisterModule<SettingsModule>();

            // Add Logging
            services.RegisterModule<LoggingModule>();

            // Add Dialogs
            services.RegisterModule<DialogsModule>();

            // Add APIs
            services.RegisterModule<WebApiModule>();

            // Add Localization
            services.RegisterModule<LocalizationModule>();
        }
    }
}

using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Localization.Resx;
using Shiny.Prism;
using Template.Mobile.Modules;
using Template.Mobile.Resources.Text;
using Template.Resources.Text;

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

            // Add Localization
            services.UseLocalization<ResxTextProvider<MobileTextResources>>(options =>
                options.AddTextProvider<ResxTextProvider<TextResources>>()
                    .WithDefaultInvariantCulture(CultureInfo.CreateSpecificCulture("fr")));
        }
    }
}

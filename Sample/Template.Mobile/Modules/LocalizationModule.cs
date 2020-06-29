using System.Globalization;
using Localizr;
using Localizr.Resx;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Template.Mobile.Resources.Text;
using Template.Resources.Text;

namespace Template.Mobile.Modules
{
    public class LocalizationModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddLocalizr<ResxTextProvider<MobileTextResources>>(options =>
                options.AddTextProvider<ResxTextProvider<TextResources>>()
                    .WithDefaultInvariantCulture(CultureInfo.CreateSpecificCulture("fr-FR"))
                    .WithAutoInitialization());
        }
    }
}

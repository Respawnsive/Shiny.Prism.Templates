using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Template.Mobile.Services.Localization;
using Template.Resources.Text;

namespace Template.Mobile.Modules
{
    public class LocalizationModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddTextProvider<ResxTextProvider>(TextResources.ResourceManager, 1);
            services.AddSingleton<ILocalizationService, LocalizationService>();
        }
    }
}

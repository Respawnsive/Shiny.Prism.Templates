using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Template.Resources.Text;
using Template.Services.Localization;

namespace Template.Modules
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

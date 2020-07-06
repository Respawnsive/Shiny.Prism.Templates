using Microsoft.Extensions.DependencyInjection;
using Prism.Behaviors;
using Prism.Navigation;
using Prism.Plugin.Popups;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using Shiny;
using $safeprojectname$.Services;

namespace $safeprojectname$.Modules
{
    public class DialogsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // Add RG.Popup with Prism.Plugin.Popups
            //services.AddSingleton<IPopupNavigation>(serviceProvider => PopupNavigation.Instance);
            //services.AddSingleton<IPageBehaviorFactory, PopupPageBehaviorFactory>();
            //services.AddSingleton<INavigationService, PopupPageNavigationService>();

            // Add Acr.UserDialogs with loader customizations
            services.AddSingleton<IDialogService, DialogsService>();
        }
    }
}

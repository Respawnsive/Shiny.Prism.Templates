using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Jobs;
using Shiny.Prism;
using Template.Modules;
using Template.Services.Localization;

namespace Template
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

            // Add Localization
            services.RegisterModule<LocalizationModule>();

            // Add Dialogs
            services.RegisterModule<DialogsModule>();

            // Add final global startup task
            services.AddSingleton<GlobalStartupTask>();
        }

        public class GlobalStartupTask : ShinyStartupTask
        {
            private readonly IJobManager _jobManager;
            private readonly ILocalizationService _localizationService;

            public GlobalStartupTask(IJobManager jobManager, ILocalizationService localizationService)
            {
                _jobManager = jobManager;
                _localizationService = localizationService;
            }

            public override void Start()
            {
                // Initialize LocalizationService in a background job
                _jobManager.RunTask("LocalizationInitialization", token => _localizationService.InitializeAsync(token: token));
            }
        }
    }
}

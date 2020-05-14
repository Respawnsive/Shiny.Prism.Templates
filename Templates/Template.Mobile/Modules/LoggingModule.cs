using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Logging;
using Template.Mobile.Services.Settings.App;

namespace Template.Mobile.Modules
{
    public class LoggingModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
#if DEBUG
            Log.UseConsole();
            Log.UseDebug();
#endif

            try
            {
                var appSettingsService = services.BuildServiceProvider().Resolve<IAppSettingsService>(true);
                services.UseAppCenterLogging(appSettingsService.AppCenterSecret, appSettingsService.AppCenterTrackCrashes, appSettingsService.AppCenterTrackEvents);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"CRASH: {ex.Message} | {ex.StackTrace}");
                throw;
            }
        }
    }
}

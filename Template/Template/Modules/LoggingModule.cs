using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Logging;
using Template.Helpers;
using Template.Services.Settings;
using Template.Services.Settings.App;

namespace Template.Modules
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

                AppCenter.LogLevel = LogLevel.Verbose;
                Crashes.ShouldProcessErrorReport = report => true;
                Crashes.ShouldAwaitUserConfirmation = () => false;
                Task.Run(async () =>
                {
                    if (await Crashes.HasCrashedInLastSessionAsync())
                    {
                        var rapport = await Crashes.GetLastSessionCrashReportAsync();
                        var detail = "Date du crash initial : " + rapport.AppErrorTime.ToString("dd/MM/yyyy HH:mm:ss");
                        Logger.Write(rapport.StackTrace)(("LastSessionCrash", detail));
                    }
                });
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"CRASH: {ex.Message} | {ex.StackTrace}");
                throw;
            }
        }
    }
}

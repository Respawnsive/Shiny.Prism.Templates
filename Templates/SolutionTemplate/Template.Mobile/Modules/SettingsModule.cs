using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shiny;
using $safeprojectname$.Services;

namespace $safeprojectname$.Modules
{
    public class SettingsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            var embeddedResourceStream = Assembly.GetAssembly(typeof(IAppSettingsService)).GetManifestResourceStream($"{typeof(AppSettingsService).Namespace}.Settings.App.appsettings.json");
            if (embeddedResourceStream != null)
            {
                using (var streamReader = new StreamReader(embeddedResourceStream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    var appsettings = JsonConvert.DeserializeObject<AppSettingsService>(jsonString);
                    if (appsettings == null)
                        return;

                    services.AddSingleton<IAppSettingsService>(appsettings);
                    services.AddSingleton<ISettingsService, SettingsService>();
                }
            }
        }
    }
}

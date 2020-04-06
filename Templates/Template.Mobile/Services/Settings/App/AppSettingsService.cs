using System.Globalization;
using Newtonsoft.Json;

namespace Template.Mobile.Services.Settings.App
{
    public class AppSettingsService : IAppSettingsService
    {
        [JsonConstructor]
        public AppSettingsService()
        {

        }

        public string AppSettingsConfiguration { get; set; }
        public string AppCenterSecret { get; set; }
        public bool AppCenterTrackCrashes { get; set; }
        public bool AppCenterTrackEvents { get; set; }
        public CultureInfo DefaultCulture { get; set; }
    }
}

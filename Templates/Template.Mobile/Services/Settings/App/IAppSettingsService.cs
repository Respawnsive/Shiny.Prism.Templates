using System.Globalization;

namespace Template.Mobile.Services.Settings.App
{
    public interface IAppSettingsService
    {
        string AppSettingsConfiguration { get; set; }
        string AppCenterSecret { get; set; }
        bool AppCenterTrackCrashes { get; set; }
        bool AppCenterTrackEvents { get; set; }
        CultureInfo DefaultCulture { get; }
    }
}
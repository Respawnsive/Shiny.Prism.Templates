using System.Globalization;
using Template.Mobile.Services.Settings.App;

namespace Template.Mobile.Services.Settings
{
    public interface ISettingsService
    {
        IAppSettingsService AppSettings { get; }
        CultureInfo SelectedCulture { get; }
        string UnclearableString { get; set; }
        bool ClearableBool { get; set; }
        string SecureClearableString { get; set; }

        void Clear();
    }
}

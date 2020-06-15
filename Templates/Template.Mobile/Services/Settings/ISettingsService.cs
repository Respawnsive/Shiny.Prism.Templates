using System.Globalization;

namespace Template.Mobile.Services
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

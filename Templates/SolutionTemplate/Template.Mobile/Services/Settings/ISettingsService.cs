using System.Globalization;

namespace $safeprojectname$.Services
{
    public interface ISettingsService
    {
        #region Properties

        IAppSettingsService AppSettings { get; }
        CultureInfo SelectedCulture { get; }
        bool IsAuthenticated { get; }


        #region Demonstration only - should be removed

        string UnclearableString { get; set; }
        string ClearableString { get; set; }
        string ClearableWithDefaultString { get; set; }
        bool ClearableBool { get; set; }
        string SecureClearableString { get; set; }

        #endregion 

        #endregion

        #region Methods

        IObservable<bool> WhenAuthenticationStatusChanged();

        void Clear(); 

        #endregion
    }
}

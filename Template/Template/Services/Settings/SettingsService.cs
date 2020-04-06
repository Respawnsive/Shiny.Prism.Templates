using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Settings;
using Template.Services.Settings.App;

namespace Template.Services.Settings
{
    /// <summary>
    /// Will sync user settings with device preferences
    /// Will notify property changed
    /// Will return to default attribute value when decorated or type value when not on Clear(), excepted for those in KeysNotToClear
    /// Will save in a secure crypted way if decorated with Secure attribute
    /// Will load app settings from json
    /// </summary>
    public class SettingsService : ReactiveObject, ISettingsService
    {
        #region Fields

        private readonly ISettings _settings; 

        #endregion

        public SettingsService(ISettings settings, IAppSettingsService appSettings)
        {
            // Init user device settings
            _settings = settings;
            SetDefaultValues();
            _settings.Bind(this);
            _settings.KeysNotToClear.Add($"{GetType().FullName}.{nameof(UnclearableString)}");

            // Load json app settings
            AppSettings = appSettings;
        }

        #region Properties

        public IAppSettingsService AppSettings { get; }

        [Reactive, DefaultValue(null)]
        public CultureInfo SelectedCulture { get; set; }

        #region Examples (should be removed)

        [Reactive, DefaultValue("DEFAULT_VALUE")]
        public string UnclearableString { get; set; }

        [Reactive, DefaultValue(false)]
        public bool ClearableBool { get; set; }

        [Reactive, DefaultValue(null), Secure]
        public string SecureClearableString { get; set; } 

        #endregion

        #endregion

        #region Methods

        public void Clear()
        {
            _settings.Clear();
            _settings.UnBind(this);
            SetDefaultValues();
            _settings.Bind(this);
        }

        private void SetDefaultValues()
        {
            // Iterate through each property
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                // Set default value if DefaultValueAttribute is present
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(this, attr.Value);
            }
        } 

        #endregion
    }
}

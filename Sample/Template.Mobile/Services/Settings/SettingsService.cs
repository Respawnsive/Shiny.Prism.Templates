using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny.Settings;
using Template.Mobile.Services.Settings;

namespace Template.Mobile.Services
{
    /// <summary>
    /// Will sync user settings with device preferences
    /// Will notify property changed
    /// On Clear() call, will return to default attribute value when decorated with DefaultValueAttribute or to default type value if not,
    /// excepted for those decorated with UnclearableAttribute
    /// Will save in a secure encrypted way if decorated with Secure attribute
    /// Will load app settings from json
    /// </summary>
    public class SettingsService : ReactiveObject, ISettingsService
    {
        #region Fields

        private readonly ISettings _settings;
        private readonly BehaviorSubject<bool> _authenticationStatusChanged;

        #endregion

        public SettingsService(ISettings settings, IAppSettingsService appSettings)
        {
            _settings = settings;
            AppSettings = appSettings;
            SetDefaultValues();
            _settings.Bind(this);

            _authenticationStatusChanged = new BehaviorSubject<bool>(IsAuthenticated);
            this.WhenAnyValue(x => x.AuthToken)
                .Subscribe(_ => _authenticationStatusChanged.OnNext(IsAuthenticated));
        }

        #region Properties

        public IAppSettingsService AppSettings { get; }

        [Reactive, DefaultValue(null)]
        public CultureInfo SelectedCulture { get; set; }

        [Reactive]
        internal string AuthToken { get; set; }

        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(AuthToken);

        #region Demonstration only - should be removed

        [Reactive, Unclearable]
        public string UnclearableString { get; set; }

        [Reactive]
        public string ClearableString { get; set; }

        [Reactive, DefaultValue("DEFAULT_VALUE")]
        public string ClearableWithDefaultString { get; set; }

        [Reactive, DefaultValue(false)]
        public bool ClearableBool { get; set; }

        [Reactive, DefaultValue(null), Secure]
        public string SecureClearableString { get; set; }

        #endregion

        #endregion

        #region Methods

        public IObservable<bool> WhenAuthenticationStatusChanged() => _authenticationStatusChanged;

        public void Clear()
        {
            var props = TypeDescriptor.GetProperties(this)
                .Cast<PropertyDescriptor>()
                .Where(prop => !prop.IsReadOnly)
                .ToList();

            // Iterate through each clearable property
            foreach (var prop in props.Where(prop => !(prop.Attributes[typeof(UnclearableAttribute)] is UnclearableAttribute)))
                // Clear property if clearable
                _settings.Remove($"{GetType().FullName}.{prop.Name}");

            // Disable settings sync while returning to default
            _settings.UnBind(this);

            // Return to default values
            SetDefaultValues();

            // Enable settings sync back
            _settings.Bind(this);
        }

        private void SetDefaultValues(IEnumerable<PropertyDescriptor> props = null)
        {
            if (props == null)
                props = TypeDescriptor.GetProperties(this)
                    .Cast<PropertyDescriptor>()
                    .Where(prop => !prop.IsReadOnly)
                    .ToList();

            // Iterate through each property
            foreach (var prop in props)
                // Set default attribute value if decorated with DefaultValueAttribute
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(this, attr.Value);
                // Set default type value if not decorated with DefaultValueAttribute and UnclearableAttribute
                else if (!(prop.Attributes[typeof(UnclearableAttribute)] is UnclearableAttribute))
                    prop.SetValue(this, default);
        } 

        #endregion
    }
}

﻿using System;
using System.Globalization;

namespace Template.Mobile.Services
{
    public interface ISettingsService
    {
        IAppSettingsService AppSettings { get; }
        CultureInfo SelectedCulture { get; }


        #region Demonstration only - should be removed

        string UnclearableString { get; set; }
        string ClearableString { get; set; }
        string ClearableWithDefaultString { get; set; }
        bool ClearableBool { get; set; }
        string SecureClearableString { get; set; } 

        #endregion

        void Clear();
    }
}

﻿using System.Globalization;

namespace $safeprojectname$.Services
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
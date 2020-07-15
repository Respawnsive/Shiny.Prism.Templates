using System;

using Sharpnado.MaterialFrame;
using Sharpnado.Presentation.Forms.RenderedViews;
using Shiny;
using Template.Mobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Template.Mobile.Helpers
{
    public static class ThemeHelper
    {
        #region Dynamic Theme Constants

        public const string DynamicMaterialTheme = nameof(DynamicMaterialTheme);

        public const string DynamicPrimaryTextColor = nameof(DynamicPrimaryTextColor);
        public const string DynamicSecondaryTextColor = nameof(DynamicSecondaryTextColor);

        public const string DynamicMenuHeaderBorderColor = nameof(DynamicMenuHeaderBorderColor);
        public const string DynamicMenuBackgroundColor = nameof(DynamicMenuBackgroundColor);
        public const string DynamicMenuImageSource = nameof(DynamicMenuImageSource);

        public const string DynamicNavigationBarColor = nameof(DynamicNavigationBarColor);
        public const string DynamicBackgroundColor = nameof(DynamicBackgroundColor);

        public const string DynamicDudeBackgroundColor = nameof(DynamicDudeBackgroundColor);

        public const string DynamicBarTextColor = nameof(DynamicBarTextColor);
        public const string DynamicHeaderTextColor = nameof(DynamicHeaderTextColor);

        public const string DynamicTopShadow = nameof(DynamicTopShadow);
        public const string DynamicBottomShadow = nameof(DynamicBottomShadow);

        public const string DynamicHasShadow = nameof(DynamicHasShadow);

        public const string Elevation4dpColor = nameof(Elevation4dpColor);

        public const string DynamicLightThemeColor = nameof(DynamicLightThemeColor);

        public const string DynamicCornerRadius = nameof(DynamicCornerRadius);

        public const string DynamicIsVisible = nameof(DynamicIsVisible);

        public const string DynamicBackgroundImageSource = nameof(DynamicBackgroundImageSource);

        public const string DynamicBlurTheme = nameof(DynamicBlurTheme);
        public const string DynamicBlurStyle = nameof(DynamicBlurStyle);

        public const string DynamicIsTabBlurVisible = nameof(DynamicIsTabBlurVisible);

        public const string DynamicBottomBarBackground = nameof(DynamicBottomBarBackground);

        public const string DynamicBottomTabBlurStyle = nameof(DynamicBottomTabBlurStyle);

        public const string DynamicElevation = nameof(DynamicElevation);

        #endregion

        #region Private Theming Methods

        private static void SetDynamicResource(string targetResourceName, string sourceResourceName)
        {
            if (!Application.Current.Resources.TryGetValue(sourceResourceName, out var value))
            {
                throw new InvalidOperationException($"key {sourceResourceName} not found in the resource dictionary");
            }

            Application.Current.Resources[targetResourceName] = value;
        }

        private static void SetDynamicResource<T>(string targetResourceName, T value)
        {
            Application.Current.Resources[targetResourceName] = value;
        }

        private static void SetDarkMode()
        {
            //Set Android Specific StatusBar
            var statusBarColor = Color.Black;
            var platformTheme = ShinyHost.Resolve<IPlatformThemeService>();
            platformTheme?.SetStatusBarColor(statusBarColor, true);

            SetDynamicResource(DynamicMaterialTheme, MaterialFrame.Theme.Dark);
            SetDynamicResource(DynamicBlurTheme, MaterialFrame.Theme.Dark);

            SetDynamicResource(DynamicNavigationBarColor, "DarkElevation2dp");

            SetDynamicResource(DynamicBarTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicPrimaryTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicSecondaryTextColor, "TextSecondaryDarkColor");

            SetDynamicResource(DynamicBackgroundColor, "DarkSurface");
            SetDynamicResource(DynamicDudeBackgroundColor, "DarkSurface");

            SetDynamicResource(DynamicMenuBackgroundColor, "DarkSurface");
            SetDynamicResource(DynamicMenuImageSource, new FileImageSource() { File = "menu_background_dark.png" });
            SetDynamicResource(DynamicMenuHeaderBorderColor, "DarkElevation2dp");

            SetDynamicResource(Elevation4dpColor, "DarkElevation4dp");
            SetDynamicResource(DynamicElevation, 4);
            SetDynamicResource(DynamicCornerRadius, 5);

            SetDynamicResource(DynamicIsVisible, false);

            //SetDynamicResource(DynamicTopShadow, ShadowType.None);
            //SetDynamicResource(DynamicBottomShadow, ShadowType.None);
            SetDynamicResource(DynamicHasShadow, false);

            SetDynamicResource(DynamicIsTabBlurVisible, false);
            SetDynamicResource(DynamicBottomBarBackground, "DarkElevation4dp");

            SetDynamicResource(DynamicBackgroundImageSource, new FileImageSource());

            }

        private static void SetLightMode(bool isAcrylic)
        {
            //Set Android Specific StatusBar
            var statusBarColor = GetResourceColor("PrimaryColor").AddLuminosity(-0.1);
            var platformTheme = ShinyHost.Resolve<IPlatformThemeService>();
            platformTheme?.SetStatusBarColor(statusBarColor, false);

            SetDynamicResource(DynamicMaterialTheme, isAcrylic ? MaterialFrame.Theme.Acrylic : MaterialFrame.Theme.Light);
            SetDynamicResource(DynamicBlurTheme, isAcrylic ? MaterialFrame.Theme.Acrylic : MaterialFrame.Theme.Light);

            SetDynamicResource(DynamicNavigationBarColor, "Accent");

            SetDynamicResource(DynamicBarTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryLightColor");
            SetDynamicResource(DynamicPrimaryTextColor, "TextPrimaryLightColor");
            SetDynamicResource(DynamicSecondaryTextColor, "TextSecondaryLightColor");

            SetDynamicResource(DynamicBackgroundColor, isAcrylic ? "AcrylicSurface" : "LightSurface");
            SetDynamicResource(DynamicDudeBackgroundColor, isAcrylic ? "AcrylicSurface" : "LightSurface");

            SetDynamicResource(DynamicMenuBackgroundColor, "AcrylicSurface");
            SetDynamicResource(DynamicMenuImageSource, new FileImageSource() { File = "menu_background_light.png" });
            SetDynamicResource(DynamicMenuHeaderBorderColor, "Accent");

            SetDynamicResource(Elevation4dpColor, isAcrylic ? "AcrylicFrameBackgroundColor" : "OnSurfaceColor");

            SetDynamicResource(DynamicLightThemeColor, isAcrylic ? "AcrylicFrameBackgroundColor" : "OnSurfaceColor");

            SetDynamicResource(DynamicElevation, 4);
            SetDynamicResource(DynamicCornerRadius, isAcrylic ? 10 : 5);

            SetDynamicResource(DynamicIsVisible, false);

            //SetDynamicResource(DynamicTopShadow, isAcrylic ? ShadowType.AcrylicTop : ShadowType.Top);
            //SetDynamicResource(DynamicBottomShadow, ShadowType.Bottom);
            SetDynamicResource(DynamicHasShadow, true);

            SetDynamicResource(DynamicIsTabBlurVisible, false);
            SetDynamicResource(DynamicBottomBarBackground, "AcrylicFrameBackgroundColor");

            SetDynamicResource(DynamicBackgroundImageSource, new FileImageSource());
        }

        private static void SetDarkBlur()
        {
            //Set Android Specific StatusBar
            var statusBarColor = Color.Black;
            var platformTheme = ShinyHost.Resolve<IPlatformThemeService>();
            platformTheme?.SetStatusBarColor(statusBarColor, true);

            SetDynamicResource(DynamicBackgroundImageSource, new FileImageSource { File = "background_darkblur.png" });

            SetDynamicResource(DynamicNavigationBarColor, "DarkElevation2dp");

            SetDynamicResource(DynamicBarTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicPrimaryTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicSecondaryTextColor, "TextSecondaryDarkColor");

            SetDynamicResource(DynamicMenuBackgroundColor, "DarkSurface");
            SetDynamicResource(DynamicMenuImageSource, new FileImageSource() { File = "menu_background_dark.png" });
            SetDynamicResource(DynamicMenuHeaderBorderColor, "DarkElevation2dp");

            SetDynamicResource(DynamicBackgroundColor, Color.Transparent);
            SetDynamicResource(DynamicDudeBackgroundColor, "DarkSurface");

            SetDynamicResource(DynamicCornerRadius, 5);
            SetDynamicResource(DynamicElevation, 0);

            SetDynamicResource(DynamicIsVisible, false);

            //SetDynamicResource(DynamicTopShadow, ShadowType.None);
            //SetDynamicResource(DynamicBottomShadow, ShadowType.None);
            SetDynamicResource(DynamicHasShadow, true);

            SetDynamicResource(DynamicIsTabBlurVisible, true);
            SetDynamicResource(DynamicBottomTabBlurStyle, MaterialFrame.BlurStyle.Dark);
            SetDynamicResource(DynamicBottomBarBackground, Color.Transparent);

            SetDynamicResource(DynamicMaterialTheme, MaterialFrame.Theme.AcrylicBlur);
            SetDynamicResource(DynamicBlurTheme, MaterialFrame.Theme.AcrylicBlur);
            SetDynamicResource(DynamicBlurStyle, MaterialFrame.BlurStyle.Dark);
        }

        private static void SetLightBlur()
        {
            //Set Android Specific StatusBar
            var statusBarColor = GetResourceColor("PrimaryColor").AddLuminosity(-0.1);
            var platformTheme = ShinyHost.Resolve<IPlatformThemeService>();
            platformTheme?.SetStatusBarColor(statusBarColor, false);

            SetDynamicResource(DynamicBackgroundImageSource, new FileImageSource { File = "background_blur.png" });

            SetDynamicResource(DynamicNavigationBarColor, "Accent");

            SetDynamicResource(DynamicBarTextColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryLightColor");
            SetDynamicResource(DynamicPrimaryTextColor, "TextPrimaryLightColor");
            SetDynamicResource(DynamicSecondaryTextColor, "TextSecondaryLightColor");

            SetDynamicResource(DynamicBackgroundColor, Color.Transparent);
            SetDynamicResource(DynamicDudeBackgroundColor, Color.Transparent);

            SetDynamicResource(DynamicMenuBackgroundColor, "AcrylicSurface");
            SetDynamicResource(DynamicMenuImageSource, new FileImageSource() { File = "menu_background_light.png" });
            SetDynamicResource(DynamicMenuHeaderBorderColor, "Accent");

            SetDynamicResource(Elevation4dpColor, Color.Transparent);

            SetDynamicResource(DynamicCornerRadius, 10);
            SetDynamicResource(DynamicElevation, 0);

            SetDynamicResource(DynamicIsVisible, true);

            //SetDynamicResource(DynamicTopShadow, ShadowType.None);
            //SetDynamicResource(DynamicBottomShadow, ShadowType.None);
            SetDynamicResource(DynamicHasShadow, false);

            SetDynamicResource(DynamicIsTabBlurVisible, true);
            SetDynamicResource(DynamicBottomTabBlurStyle, MaterialFrame.BlurStyle.Light);
            SetDynamicResource(DynamicBottomBarBackground, Color.Transparent);

            SetDynamicResource(DynamicMaterialTheme, MaterialFrame.Theme.AcrylicBlur);
            SetDynamicResource(DynamicBlurTheme, MaterialFrame.Theme.AcrylicBlur);
            SetDynamicResource(DynamicBlurStyle, MaterialFrame.BlurStyle.Light);
        }

        #endregion

        #region Public Theming Methods

        public static void InitTheme()
        {
            //Here is the logic for Theming Initialisation (from Settings, from Device, both, fixed or dynamic, etc.)
            
            //Example for applying user Device choice (AppInfo.RequestedTheme from essentials)
            if (AppInfo.RequestedTheme == Xamarin.Essentials.AppTheme.Dark)
            {
                ApplyTheme(AppTheme.AcrylicDarkBlur);
            }
            else
            {
                ApplyTheme(AppTheme.Acrylic);
            }
        }

        public static void ApplyTheme(AppTheme newtheme)
        {
            _currentTheme = newtheme;
            switch (newtheme)
            {
                case AppTheme.Acrylic:
                    //Bug from DarkBlur to Acrylic, resolve thru DarkBlur to Light to Acrylic
                    SetLightMode(false);
                    SetLightMode(true);
                    break;
                case AppTheme.AcrylicDarkBlur:
                    SetDarkBlur();
                    break;
                case AppTheme.AcrylicBlur:
                    SetLightBlur();
                    break;
                case AppTheme.Light:
                    SetLightMode(false);
                    break;
                case AppTheme.Dark:
                    SetDarkMode();
                    break;
            }
        }

        public static T GetResource<T>(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }

        public static Color GetResourceColor(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (Color)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }

        private static AppTheme _currentTheme;
        public static AppTheme GetCurrentTheme()
        {
            return _currentTheme;
        }

        #endregion
    }

    /// <summary>
    /// Enum the different Themes
    /// </summary>
    public enum AppTheme
    {
        Light = 0,
        Dark = 1,
        Acrylic = 2,
        AcrylicDarkBlur = 3,
        AcrylicBlur = 4,
    }
}

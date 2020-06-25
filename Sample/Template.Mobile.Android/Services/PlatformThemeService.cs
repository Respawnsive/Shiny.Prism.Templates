using Android.OS;
using Plugin.CurrentActivity;
using Template.Mobile.Services;
using Xamarin.Essentials;

namespace Template.Mobile.Droid.Services
{
    public class PlatformThemeService : IPlatformThemeService
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var activity = CrossCurrentActivity.Current.Activity;
            var window = activity.Window;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(color.ToPlatformColor());

            //if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            //{
            //    var flag = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
            //    window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
            //}
        }
    }
}
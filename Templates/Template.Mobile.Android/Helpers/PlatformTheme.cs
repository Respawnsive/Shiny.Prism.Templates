﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Template.Mobile.Interfaces;
using Xamarin.Essentials;

namespace Template.Mobile.Droid.Helpers
{
    public class PlatformTheme : IPlatformTheme
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
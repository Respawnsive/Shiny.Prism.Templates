using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Template.Mobile.Services;
using UIKit;

namespace Template.Mobile.iOS.Services
{
    public class PlatformThemeService : IPlatformThemeService
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            //Nothing to do on iOS ? (safearea colors ?)
        }
    }
}
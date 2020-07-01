using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using $ext_safeprojectname$.Mobile.Services;
using UIKit;

namespace $safeprojectname$.Services
{
    public class PlatformThemeService : IPlatformThemeService
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            //Nothing to do on iOS ? (safearea colors ?)
        }
    }
}
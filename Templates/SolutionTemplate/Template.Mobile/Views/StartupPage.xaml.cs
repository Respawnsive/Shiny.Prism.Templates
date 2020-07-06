using System;
using $safeprojectname$.Helpers;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;

namespace $safeprojectname$.Views
{
    public partial class StartupPage : ContentPageBase
    {
        public StartupPage() : base(nameof(StartupPage))
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}

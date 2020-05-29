using System;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;

namespace Template.Mobile.Views
{
    public partial class StartupPage : ContentPageBase<StartupPageViewModel>
    {
        public StartupPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}

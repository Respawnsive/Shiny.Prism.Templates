using Prism.Commands;
using System;
using System.ComponentModel;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ThemesView : ContentViewBase<Debug_ThemesViewModel>
    {
        public Debug_ThemesView()
        {
            try
            {
                InitializeComponent();
                LaunchFakeProgress();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private async void LaunchFakeProgress()
        {
            try
            {
                await pgbar.ProgressTo(1, 5000, Easing.Linear);
                await pgbar.ProgressTo(0, 5000, Easing.Linear);
                await pgbar.ProgressTo(1, 5000, Easing.Linear);
                await pgbar.ProgressTo(0, 5000, Easing.Linear);
                await pgbar.ProgressTo(1, 5000, Easing.Linear);
                await pgbar.ProgressTo(0.5, 2500, Easing.Linear);
            }
            catch(Exception ex)
            {

            }
        }
    }
}

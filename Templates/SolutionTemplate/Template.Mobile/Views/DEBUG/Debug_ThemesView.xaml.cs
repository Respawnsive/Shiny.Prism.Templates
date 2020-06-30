using Prism.Commands;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using $safeprojectname$.Helpers;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ThemesView : ContentViewBase
    {
        public Debug_ThemesView() : base(nameof(Debug_ThemesView))
        {
            try
            {
                InitializeComponent();

                // TODO -> NEVER do this in real code
                // Simulating a complex view
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();

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
                Logger.Write(ex);
            }
        }
    }
}

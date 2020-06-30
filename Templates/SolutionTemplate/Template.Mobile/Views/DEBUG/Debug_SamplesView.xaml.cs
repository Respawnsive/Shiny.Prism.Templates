using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Helpers;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_SamplesView : ContentViewBase
    {
        public Debug_SamplesView() : base(nameof(Debug_SamplesView))
        {
            try
            {
                InitializeComponent();

                // TODO -> NEVER do this in real code
                // Simulating a complex view
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}
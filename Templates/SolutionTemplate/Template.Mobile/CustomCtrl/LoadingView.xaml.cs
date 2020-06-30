using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Helpers;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.CustomCtrl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingView : ContentView
    {
        public LoadingView() : base()
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
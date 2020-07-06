using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MDPage()
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

        //Dismiss menu after navigation -> return false
        //Keep menu after navigation -> return true;
        public bool IsPresentedAfterNavigation
        {
            get
            {
                if (Device.Idiom != TargetIdiom.Phone && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
                    //Not on a phone (tablet/pc/etc.) and Landscape -> we keep the menu displayed
                    return true;
                //phone or portrait -> we hide the menu
                return false;
            }
        }
    }
}
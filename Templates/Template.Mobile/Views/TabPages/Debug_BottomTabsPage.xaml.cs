using Sharpnado.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_BottomTabsPage : BottomTabbedPageBase
    {
        public Debug_BottomTabsPage() : base(nameof(Debug_BottomTabsPage))
        {
            try
            {
                InitializeComponent();
                On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPageBase
    {
        public HomePage() : base(nameof(HomePage))
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
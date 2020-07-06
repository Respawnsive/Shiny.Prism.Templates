using System;
using $safeprojectname$.Helpers;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlankPage : ContentPageBase
    {
        public BlankPage() : base(nameof(BlankPage))
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
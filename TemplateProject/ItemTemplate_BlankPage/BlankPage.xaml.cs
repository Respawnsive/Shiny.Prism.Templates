using System;
using $rootnamespace$.Helpers;
using Xamarin.Forms.Xaml;

namespace $rootnamespace$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class $safeitemname$ : ContentPageBase
    {
        public $safeitemname$() : base(nameof($safeitemname$))
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
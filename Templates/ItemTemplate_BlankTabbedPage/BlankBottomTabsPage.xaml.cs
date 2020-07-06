using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using $rootnamespace$.Helpers;
using $rootnamespace$.ViewModels;

namespace $rootnamespace$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class $safeitemname$ : BottomTabbedPageBase
    {
        public $safeitemname$() : base(nameof($safeitemname$))
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

        private void TabPage_OnBindingContextChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof($safeitemname$) && sender is ContentPage contentPage && contentPage.BindingContext is ViewModelBase viewModel)
            {
                var key = viewModel.GetType().Name.Replace("Model", "_Title");
                contentPage.Title = viewModel[key];
            }
        }
    }
}
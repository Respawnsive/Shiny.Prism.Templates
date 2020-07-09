using System;
using Template.Mobile.CustomCtrl;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;

namespace Template.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondWTPage : CustomWTTabbedPage
    {
        public SecondWTPage() : base(nameof(SecondWTPage))
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
            if (sender.GetType() != typeof(SecondWTPage) && sender is ContentPage contentPage && contentPage.BindingContext is ViewModelBase viewModel)
            {
                var key = viewModel.GetType().Name.Replace("Model", "_Title");
                contentPage.Title = viewModel[key];
            }
        }
    }
}
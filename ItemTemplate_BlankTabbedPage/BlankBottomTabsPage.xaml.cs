using Sharpnado.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

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
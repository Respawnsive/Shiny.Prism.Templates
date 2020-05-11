using System.ComponentModel;
using Template.Mobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ThemingPage : ContentPageBase<Debug_ThemingPageViewModel>
    {
        public Debug_ThemingPage()
        {
            InitializeComponent();
        }
    }
}

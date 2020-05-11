using Xamarin.Forms;
using Template.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using System;

namespace Template.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ImagesListPage : ContentPageBase<Debug_ImagesListPageViewModel>
    {
        public Debug_ImagesListPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }
    }
}

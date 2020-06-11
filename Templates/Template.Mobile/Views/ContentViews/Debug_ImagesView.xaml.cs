using Xamarin.Forms;
using Template.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using System;
using Template.Mobile.Helpers;

namespace Template.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ImagesView : ContentViewBase<Debug_ImagesViewModel>
    {
        public Debug_ImagesView()
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

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    //This dynamicaly changes the number of columns  when orientation changes
        //    ((Debug_ImagesListPageViewModel)this.BindingContext).RefreshColumnNumber();
        //}
    }
}

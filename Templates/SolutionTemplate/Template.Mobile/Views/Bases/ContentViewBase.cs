using System.Runtime.CompilerServices;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace $safeprojectname$.Views
{
    public class ContentViewBase : ContentView
    {
        public readonly string Tag;
        public ContentViewBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            this.ControlTemplate = (ControlTemplate)Application.Current.Resources["ThemedLoaderPageTemplate"];
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    ((ViewModelBase)this.Parent.BindingContext).OnRotationChanged();
        //}

    }
}

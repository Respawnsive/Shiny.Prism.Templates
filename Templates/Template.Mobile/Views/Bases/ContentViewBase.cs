using System.Runtime.CompilerServices;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Template.Mobile.Views
{
    public class ContentViewBase : ContentView
    {
        public readonly string Tag;
        public ContentViewBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            this.ControlTemplate = (ControlTemplate)Application.Current.Resources["ThemedLoaderPageTemplate"];
        }

    }
}

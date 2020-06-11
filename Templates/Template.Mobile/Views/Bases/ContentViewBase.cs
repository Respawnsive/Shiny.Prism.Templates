using System.Runtime.CompilerServices;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Template.Mobile.Views
{
    public class ContentViewBase : ContentViewBase<ViewModelBase>
    {
    }

    public class ContentViewBase<TViewModel> : ContentView where TViewModel : ViewModelBase
    {
        public readonly string Tag;
        public ContentViewBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
        }

        public TViewModel ViewModel => BindingContext as TViewModel;

    }
}

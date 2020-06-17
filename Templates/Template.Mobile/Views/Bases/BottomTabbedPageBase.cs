using System.Runtime.CompilerServices;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Template.Mobile.Views
{
    public class BottomTabbedPageBase : TabbedPage
    {
        public readonly string Tag;
        public BottomTabbedPageBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            iOSspec.Page.SetUseSafeArea(this, true);
        }

        /// <summary>
        /// Manage device orientation and raise all "Childs-ViewModels" OnRotationChanged()
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            foreach (var page in this.Children)
            {
                if (page.BindingContext != null)
                    ((ViewModelBase)page.BindingContext).OnRotationChanged();
            }
        }
        /// <summary>
        /// Gère l'interception du bouton retour (physique & logiciel/Navigationbar) 
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                var vm = ((ViewModelBase)(this.BindingContext));
                if (vm.GetType() == typeof(HomeViewModel) || vm.GetType() == typeof(MDViewModel))
                {
                    return base.OnBackButtonPressed();
                }
                else
                {
                    vm.NavigateBackAsync();
                    return true;
                }
            }
            catch
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}

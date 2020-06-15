using System.Runtime.CompilerServices;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Template.Mobile.Views
{
    public class ContentPageBase : ContentPage
    {
        public readonly string Tag;
        public ContentPageBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            iOSspec.Page.SetUseSafeArea(this, true);
            this.ControlTemplate = (ControlTemplate)Application.Current.Resources["ThemedLoaderPageTemplate"];
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

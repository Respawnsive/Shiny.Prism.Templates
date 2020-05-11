using System.Runtime.CompilerServices;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Template.Mobile.Views
{
    public class ContentPageBase : ContentPageBase<ViewModelBase>
    {
    }

    public class ContentPageBase<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        public readonly string Tag;
        public ContentPageBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            iOSspec.Page.SetUseSafeArea(this, true);
        }

        public TViewModel ViewModel => BindingContext as TViewModel;

        /// <summary>
        /// Gère l'interception du bouton retour (physique & logiciel/Navigationbar) 
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                var vm = ((ViewModelBase)(this.BindingContext));
                //TODO à réactiver quand HomePage ou MDPage ?
                //if (vm.GetType() == typeof(MainViewModel))
                //{
                //    return base.OnBackButtonPressed();
                //}
                //else
                //{
                    vm.NavigateBackAsync();
                    return true;
                //}
            }
            catch
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}

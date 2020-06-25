using Prism.Navigation;
using System;
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
            Console.WriteLine("#################");
            Console.WriteLine("New Page : " + Tag);
            Console.WriteLine("#################");
            Console.WriteLine("NavigationStack :");
            Console.WriteLine(GetNavigationStackString());
            Console.WriteLine("#################");
            Console.WriteLine("ModalStack :");
            Console.WriteLine(GetModalStackString());
            Console.WriteLine("#################");

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ((ViewModelBase)this.BindingContext).OnRotationChanged();
        }

        /// <summary>
        /// Gère l'interception du bouton retour (physique & logiciel/Navigationbar) 
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                var test = Navigation.NavigationStack;
                var vm = ((ViewModelBasePage)(this.BindingContext));
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

        private string GetNavigationStackString()
        {
            string path = @"\";
            foreach(var page in Navigation.NavigationStack)
            {
                path += page.GetType().ToString() + @"\";
            }
            return path;
        }

        private string GetModalStackString()
        {
            string path = @"\";
            foreach (var page in Navigation.ModalStack)
            {
                path += page.GetType().ToString() + @"\";
            }
            return path;
        }
    }
}

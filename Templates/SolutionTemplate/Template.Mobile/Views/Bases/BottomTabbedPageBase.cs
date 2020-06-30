using Prism;
using System;
using System.Runtime.CompilerServices;
using $safeprojectname$.ViewModels;
using Xamarin.Forms;
using iOSspec = Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace $safeprojectname$.Views
{
    public class BottomTabbedPageBase : TabbedPage
    {
        public readonly string Tag;
        public BottomTabbedPageBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
            iOSspec.Page.SetUseSafeArea(this, true);
            Console.WriteLine("#################");
            Console.WriteLine("NavigationStack :");
            Console.WriteLine(GetNavigationStackString());
            Console.WriteLine("#################");
            Console.WriteLine("ModalStack :");
            Console.WriteLine(GetModalStackString());
            Console.WriteLine("#################");
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
                //Logic for TabbedPage "backbutton"
                //Here (for exemple) we navigate to first tab if not already activated, and if it is, we navigate to the HomePage
                var vm = ((ViewModelBaseTabHost)(this.BindingContext));
                if (this.Children != null && this.Children.Count > 0 && !((IActiveAware)this.Children[0]).IsActive)
                {
                    //((IActiveAware)this.Children[0]).IsActive = true;
                    vm.SelectTab(nameof(Debug_SamplesView));
                }
                //else
                //{
                //vm.NavigationService.NavigateAsync($"{nameof(HomePage)}");
                //}
                return true;
            }
            catch
            {
                return base.OnBackButtonPressed();
            }
        }

        private string GetNavigationStackString()
        {
            string path = @"\";
            foreach (var page in Navigation.NavigationStack)
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

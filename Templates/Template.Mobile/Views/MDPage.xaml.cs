using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MDPage()
        {
            try
            {
                InitializeComponent();
                //MessagingCenter.Subscribe<object>(this, "ShowMenuBurger", sender =>
                //{
                //    this.IsPresented = true;
                //});
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        //Pour ne plus afficher le menu après navigation
        public bool IsPresentedAfterNavigation => false;
        //Pour garder affiché le menu après navigation
        //return true;
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Template.ViewModels;
using Xamarin.Forms;

namespace Template.Views
{
    public class ViewBase : ViewBase<ViewModelBase>
    {
    }

    public class ViewBase<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        public readonly string Tag;
        public ViewBase([CallerMemberName]string parent = "") : base()
        {
            Tag = parent;
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
                if (vm.GetType() == typeof(MainViewModel))
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

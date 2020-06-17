using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Mobile.Helpers;
using Template.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Template.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_SamplesView : ContentViewBase
    {
        public Debug_SamplesView() : base(nameof(Debug_SamplesView))
        {
            try
            {
                InitializeComponent();

                // TODO -> NEVER do this in real code
                // Simulating a complex view
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using $rootnamespace$.Helpers;

namespace $rootnamespace$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class $safeitemname$ : ContentViewBase
    {
        public $safeitemname$() : base(nameof($safeitemname$))
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}
using System;
using $safeprojectname$.Helpers;

namespace $safeprojectname$.Resources.Dictionaries
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Styles
    {
        public Styles()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }
    }
}
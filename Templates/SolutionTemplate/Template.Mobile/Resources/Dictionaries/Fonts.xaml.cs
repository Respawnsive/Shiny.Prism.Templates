using System;
using $safeprojectname$.Helpers;

namespace $safeprojectname$.Resources.Dictionaries
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fonts
    {
        public Fonts()
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
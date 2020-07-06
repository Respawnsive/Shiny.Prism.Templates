using System;
using Template.Mobile.Helpers;

namespace Template.Mobile.Resources.Dictionaries
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
using System;
using Template.Mobile.Helpers;

namespace Template.Mobile.Resources.Dictionaries
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Converters
    {
        public Converters()
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
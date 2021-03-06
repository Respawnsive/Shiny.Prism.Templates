﻿using Xamarin.Forms;
using $safeprojectname$.ViewModels;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using System;
using $safeprojectname$.Helpers;
using System.Threading.Tasks;

namespace $safeprojectname$.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Debug_ImagesView : ContentViewBase
    {
        public Debug_ImagesView() : base(nameof(Debug_ImagesView))
        {
            try
            {
                InitializeComponent();

                // TODO -> NEVER do this in real code
                // Simulating a complex view(Xaml) to load
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }

        
    }
}

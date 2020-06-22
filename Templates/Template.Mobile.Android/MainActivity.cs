using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Lottie.Forms.Droid;
using Plugin.CurrentActivity;
using Sharpnado.Presentation.Forms.Droid;
using Shiny;
using System;
using System.Collections;
using System.Collections.Generic;
using DynamicData.Kernel;
using Shiny.Push;

namespace Template.Mobile.Droid
{
    [Activity(Label = "Template", Icon = "@drawable/appicon", Theme = "@style/Theme.App", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                //Forms Init
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                //Plugins Init
                global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                UserDialogs.Init(this);
                Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
                Android.Glide.Forms.Init(this);
                SharpnadoInitializer.Initialize();
                AnimationViewRenderer.Init();

                //var extra = Intent.Extras?.GetParcelable("data");
                
                //Launch FormsApp
                LoadApplication(new Mobile.App());

                this.ShinyOnCreate();
            }
            catch(Exception ex)
            {
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            try
            {
                base.OnNewIntent(intent);

                this.ShinyOnNewIntent(intent);
            }
            catch(Exception ex)
            {

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            this.ShinyRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            try
            {
                base.OnConfigurationChanged(newConfig);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
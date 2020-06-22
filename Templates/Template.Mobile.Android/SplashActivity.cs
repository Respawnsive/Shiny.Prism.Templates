using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Template.Mobile.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, LaunchMode = LaunchMode.SingleTask)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            var mainIntent = new Intent(Application.Context, typeof(MainActivity));

            if (Intent.Extras != null)
                mainIntent.PutExtras(Intent.Extras);
            
            StartActivity(mainIntent);
        }
    }
}
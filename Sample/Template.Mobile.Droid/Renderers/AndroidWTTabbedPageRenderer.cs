using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using Template.Mobile.CustomCtrl;
using Template.Mobile.Droid.Renderers;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomWTTabbedPage), typeof(AndroidWTTabbedPageRenderer))]
namespace Template.Mobile.Droid.Renderers
{
    public class AndroidWTTabbedPageRenderer : TabbedPageRenderer
    {

        public AndroidWTTabbedPageRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            for (int i = 0; i < ViewGroup.ChildCount; i++)
            {
                var root = (Android.Widget.RelativeLayout) ViewGroup.GetChildAt(i);
                for (int j = 0; j < root.ChildCount; j++)
                {
                    var view = root.GetChildAt(j);
                    if (view.GetType() == typeof(BottomNavigationView))
                    {
                        view.Visibility = ViewStates.Gone;
                    }
                }
            }

        }
    }


}
using System.ComponentModel;
using System.Threading.Tasks;
using CoreGraphics;
using Xamarin.Forms;
using Template.Mobile.CustomCtrl;
using Template.Mobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Task = System.Threading.Tasks.Task;

[assembly: ExportRenderer(typeof(CustomWTTabbedPage), typeof(iOSWTTabbedPageRenderer))]
namespace Template.Mobile.iOS.Renderers
{
    public class iOSWTTabbedPageRenderer : TabbedRenderer
    {
        //protected override void OnElementChanged(VisualElementChangedEventArgs e)
        //{
        //    base.OnElementChanged(e);
        //    HideTabBar();
        //}

        private void HideTabBar()
        {
            TabBar.Hidden = true;
            View.Frame = new CGRect(View.Frame.X, View.Frame.Y, View.Frame.Width, View.Frame.Height + 49);
            TabBar.Frame = new CGRect(TabBar.Frame.X, TabBar.Frame.Y, TabBar.Frame.Width, 0);
        }

        //public override void ViewWillAppear(bool animated)
        //{
        //    base.ViewWillAppear(animated);
        //    HideTabBar();
        //}

        //public override void ViewDidAppear(bool animated)
        //{
        //    base.ViewWillAppear(animated);
        //    HideTabBar();
        //}

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            HideTabBar();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(() => SelectNextTab(1)) { Direction = UISwipeGestureRecognizerDirection.Left, ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously });
            NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(() => SelectNextTab(-1)) { Direction = UISwipeGestureRecognizerDirection.Right, ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously });
        }

        void SelectNextTab(int direction)
        {
            int nextIndex = TabbedPage.GetIndex(Tabbed.CurrentPage) + direction;
            if (nextIndex < 0 || nextIndex >= Tabbed.Children.Count) return;
            var nextPage = Tabbed.Children[nextIndex];
            UIView.Transition(Platform.GetRenderer(Tabbed.CurrentPage).NativeView, Platform.GetRenderer(nextPage).NativeView, 0.15, UIViewAnimationOptions.TransitionCrossDissolve, null);
            Tabbed.CurrentPage = nextPage;
        }

        static bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer) => !gestureRecognizer.Equals(otherGestureRecognizer);
    }

}
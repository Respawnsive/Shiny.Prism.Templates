using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Button;
using Template.Mobile.CustomCtrl;
using Template.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMaterialStepper), typeof(AndroidMaterialStepperRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Template.Mobile.Droid.Renderers
{

    public class AndroidMaterialStepperRenderer : MaterialStepperRenderer
    {
        public AndroidMaterialStepperRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            var customStepper = e.NewElement as CustomMaterialStepper;
            var formsColor = customStepper.TintColor;
            if (Control != null)
            {
                //Get the 2 MaterialButtons corresponding to Stepper buttons (+ and -)
                var button1 = (MaterialButton)Control.GetChildAt(0);
                var button2 = (MaterialButton)Control.GetChildAt(1);
                //Create the ColorStateList from FormsColor "TintColor"
                int[][] states = new int[][]
                  {
                    new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
                    new int[] {-Android.Resource.Attribute.StateEnabled}, // disabled
                    new int[] {-Android.Resource.Attribute.StateChecked}, // unchecked
                    new int[] { Android.Resource.Attribute.StateChecked }  // pressed
                  };

                int[] colors = new int[]
                {
                    formsColor.ToAndroid(),
                    formsColor.MultiplyAlpha(0.25).ToAndroid(),
                    Xamarin.Forms.Color.Black.ToAndroid(),
                    Xamarin.Forms.Color.Black.ToAndroid()
                };
                //Apply color
                ColorStateList myStateList = new ColorStateList(states, colors);
                button1.StrokeColor = myStateList;
                button2.StrokeColor = myStateList;
                button1.SetTextColor(formsColor.ToAndroid());
                button2.SetTextColor(formsColor.ToAndroid());
            }
        }
    }
}
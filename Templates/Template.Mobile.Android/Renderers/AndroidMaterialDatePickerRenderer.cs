using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util.Logging;
using Template.Mobile.CustomCtrl;
using Template.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMaterialDatePicker), typeof(AndroidMaterialDatePickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Template.Mobile.Droid.Renderers
{
    public class AndroidMaterialDatePickerRenderer : MaterialDatePickerRenderer
    {

        public AndroidMaterialDatePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            var custompicker = e.NewElement as CustomMaterialDatePicker;
            var formsTitle = custompicker.Title;
            var formsColor = custompicker.TitleColor;
            if (Control != null)
            {
                //Get the MaterialPickerEditText corresponding to DatePicker EditText
                //Create the ColorStateList from FormsColor "TintColor"
                int[][] states = new int[][]
                  {
                    new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
                    new int[] {-Android.Resource.Attribute.StateEnabled}, // disabled
                    new int[] {Android.Resource.Attribute.StateFocused}, // focused
                    new int[] {-Android.Resource.Attribute.StateFocused}, // unfocused
                    new int[] {Android.Resource.Attribute.StateSelected}, // selected
                    new int[] {-Android.Resource.Attribute.StateSelected}, // unselected
                  };

                int[] colors = new int[]
                {
                    formsColor.ToAndroid(),
                    formsColor.MultiplyAlpha(0.25).ToAndroid(),
                    formsColor.ToAndroid(),
                    formsColor.MultiplyAlpha(0.25).ToAndroid(),
                    formsColor.ToAndroid(),
                    formsColor.MultiplyAlpha(0.25).ToAndroid(),
                };
                Control.SetHint(formsTitle, e.NewElement);
                Control.DefaultHintTextColor = new ColorStateList(states, colors);
            }
        }
    }
}
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
using Java.Util.Logging;
using Template.Mobile.CustomCtrl;
using Template.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMaterialDatePicker), typeof(AndroidMaterialDatePickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Template.Mobile.Droid.Renderers
{
    /// <summary>
    /// Renderer for PlaceHolder and PlaceHolderColor (not included yet in MaterialDatePicker Base)
    /// </summary>
    public class AndroidMaterialDatePickerRenderer : MaterialDatePickerRenderer
    {

        public AndroidMaterialDatePickerRenderer(Context context) : base(context)
        {

        }

        MaterialPickerTextInputLayout InputLayout;
        protected override MaterialPickerTextInputLayout CreateNativeControl()
        {
            InputLayout = base.CreateNativeControl();
            return InputLayout;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            var custompicker = e.NewElement as CustomMaterialDatePicker;
            if (custompicker != null && InputLayout != null)
            {
                InputLayout.HintEnabled = true;
                InputLayout.Hint = custompicker.PlaceHolder;
                InputLayout.ApplyTheme(custompicker.TextColor, custompicker.PlaceHolderColor);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var custompicker = Element as CustomMaterialDatePicker;
            if (e != null && InputLayout != null)
            {
                if (e.PropertyName == "TextColor" || e.PropertyName == "BackgroundColor")
                {
                    InputLayout.ApplyTheme(custompicker.TextColor, custompicker.PlaceHolderColor);
                }
            }
        }
    }
}
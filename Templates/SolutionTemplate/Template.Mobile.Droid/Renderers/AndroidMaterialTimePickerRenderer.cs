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
using $ext_safeprojectname$.Mobile.CustomCtrl;
using $safeprojectname$.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMaterialTimePicker), typeof(AndroidMaterialTimePickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace $safeprojectname$.Renderers
{
    /// <summary>
    /// Renderer for PlaceHolder and PlaceHolderColor (not included yet in MaterialTimePicker Base)
    /// </summary>
    public class AndroidMaterialTimePickerRenderer : MaterialTimePickerRenderer
    {

        public AndroidMaterialTimePickerRenderer(Context context) : base(context)
        {

        }

        MaterialPickerTextInputLayout InputLayout;
        protected override MaterialPickerTextInputLayout CreateNativeControl()
        {
            InputLayout = base.CreateNativeControl();
            return InputLayout;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            var custompicker = e.NewElement as CustomMaterialTimePicker;
            if (InputLayout != null)
            {
                InputLayout.HintEnabled = true;
                InputLayout.Hint = custompicker.PlaceHolder;
                InputLayout.ApplyTheme(custompicker.TextColor, custompicker.PlaceHolderColor);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var custompicker = Element as CustomMaterialTimePicker;
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
﻿using MaterialComponents;
using Template.Mobile.CustomCtrl;
using Template.Mobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMaterialStepper), typeof(iOSMaterialStepperRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Template.Mobile.iOS.Renderers
{

    public class iOSMaterialStepperRenderer : MaterialStepperRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null || Control == null)
                return;

            var customStepper = e.NewElement as CustomMaterialStepper;
            
            Control.IncrementButton.SetBorderColor(customStepper.TintColor.ToUIColor(), UIKit.UIControlState.Normal);
            Control.IncrementButton.SetTitleColor(customStepper.TintColor.ToUIColor(), UIKit.UIControlState.Normal);
            
            Control.DecrementButton.SetBorderColor(customStepper.TintColor.ToUIColor(), UIKit.UIControlState.Normal);
            Control.DecrementButton.SetTitleColor(customStepper.TintColor.ToUIColor(), UIKit.UIControlState.Normal);

        }

    }
}
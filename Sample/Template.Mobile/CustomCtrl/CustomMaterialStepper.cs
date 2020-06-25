using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Template.Mobile.CustomCtrl
{
    public class CustomMaterialStepper : Stepper
    {
        public CustomMaterialStepper()
        {

        }

        public static readonly BindableProperty TintColorProperty =
              BindableProperty.Create(
                 propertyName: "TintColor",
                  returnType: typeof(Color),
                  declaringType: typeof(CustomMaterialStepper),
                  defaultValue: (Color)App.Current.Resources["Accent"],
                  defaultBindingMode: BindingMode.TwoWay);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace $safeprojectname$.CustomCtrl
{
    public class CustomMaterialTimePicker : TimePicker
    {
        public CustomMaterialTimePicker()
        {

        }

        public static readonly BindableProperty PlaceHolderProperty =
              BindableProperty.Create(
                 propertyName: "PlaceHolder",
                  returnType: typeof(string),
                  declaringType: typeof(CustomMaterialDatePicker),
                  defaultValue: "",
                  defaultBindingMode: BindingMode.TwoWay);

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        
        public static readonly BindableProperty PlaceHolderColorProperty =
              BindableProperty.Create(
                 propertyName: "PlaceHolderColor",
                  returnType: typeof(Color),
                  declaringType: typeof(CustomMaterialDatePicker),
                  defaultValue: (Color)App.Current.Resources["Accent"],
                  defaultBindingMode: BindingMode.TwoWay);

        public Color PlaceHolderColor
        {
            get { return (Color)GetValue(PlaceHolderColorProperty); }
            set { SetValue(PlaceHolderColorProperty, value); }
        }
    }
}

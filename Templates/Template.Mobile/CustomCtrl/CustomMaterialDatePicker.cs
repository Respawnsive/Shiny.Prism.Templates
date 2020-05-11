using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Template.Mobile.CustomCtrl
{
    public class CustomMaterialDatePicker : DatePicker
    {
        public CustomMaterialDatePicker()
        {

        }

        public static readonly BindableProperty TitleProperty =
              BindableProperty.Create(
                 propertyName: "Title",
                  returnType: typeof(string),
                  declaringType: typeof(CustomMaterialDatePicker),
                  defaultValue: "",
                  defaultBindingMode: BindingMode.TwoWay);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        
        public static readonly BindableProperty TitleColorProperty =
              BindableProperty.Create(
                 propertyName: "TitleColor",
                  returnType: typeof(Color),
                  declaringType: typeof(CustomMaterialDatePicker),
                  defaultValue: (Color)App.Current.Resources["Accent"],
                  defaultBindingMode: BindingMode.TwoWay);

        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }
    }
}

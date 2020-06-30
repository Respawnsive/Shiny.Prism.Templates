using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace $safeprojectname$.CustomCtrl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableCellBase : Frame
    {
        public SelectableCellBase()
        {
            InitializeComponent();
        }

        #region ColorSelected_Tint

        public static readonly BindableProperty ColorSelected_TintProperty =
              BindableProperty.Create(
                 propertyName: "ColorSelected_Tint",
                  returnType: typeof(Color),
                  declaringType: typeof(SelectableCellBase),
                  defaultValue: Color.Transparent,
                  defaultBindingMode: BindingMode.TwoWay,
                  propertyChanged: ColorSelected_TintPropertyChanged);

        public Color ColorSelected_Tint
        {
            get { return (Color)GetValue(ColorSelected_TintProperty); }
            set { SetValue(ColorSelected_TintProperty, value); }
        }

        private static void ColorSelected_TintPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableCellBase)bindable;
            if (control != null && newValue != null && newValue.GetType() == typeof(Color))
            {
                control.wrapperframe.BorderColor = (Color)newValue;
            }
        }

        #endregion

        #region ColorSelected_Background

        public static readonly BindableProperty ColorSelected_BackgroundProperty =
              BindableProperty.Create(
                 propertyName: "ColorSelected_Background",
                  returnType: typeof(Color),
                  declaringType: typeof(SelectableCellBase),
                  defaultValue: Color.Transparent,
                  defaultBindingMode: BindingMode.TwoWay,
                  propertyChanged: ColorSelected_BackgroundPropertyChanged);

        public Color ColorSelected_Background
        {
            get { return (Color)GetValue(ColorSelected_BackgroundProperty); }
            set { SetValue(ColorSelected_BackgroundProperty, value); }
        }

        private static void ColorSelected_BackgroundPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableCellBase)bindable;
            if (control != null && newValue != null && newValue.GetType() == typeof(Color))
            {
                control.wrapperframe.BackgroundColor = (Color)newValue;
            }
        }

        #endregion

    }
}
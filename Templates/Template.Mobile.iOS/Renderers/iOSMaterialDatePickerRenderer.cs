using Template.Mobile.CustomCtrl;
using Template.Mobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;

[assembly: ExportRenderer(typeof(CustomMaterialDatePicker), typeof(iOSMaterialDatePickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Template.Mobile.iOS.Renderers
{
    /// <summary>
    /// Renderer for PlaceHolder and PlaceHolderColor (not included yet in MaterialDatePicker Base)
    /// </summary>
    public class iOSMaterialDatePickerRenderer : MaterialDatePickerRenderer, IMaterialEntryRenderer
    {
        string IMaterialEntryRenderer.Placeholder => ((CustomMaterialDatePicker)Element)?.PlaceHolder ?? string.Empty;
        Color IMaterialEntryRenderer.PlaceholderColor => ((CustomMaterialDatePicker)Element)?.PlaceHolderColor ?? Color.Default;
        Color IMaterialEntryRenderer.TextColor => Element?.TextColor ?? Color.Default;
        Color IMaterialEntryRenderer.BackgroundColor => Element?.BackgroundColor ?? Color.Default;
    }
}
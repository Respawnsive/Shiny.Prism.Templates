using $safeprojectname$.Mobile.CustomCtrl;
using $safeprojectname$.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;

[assembly: ExportRenderer(typeof(CustomMaterialTimePicker), typeof(iOSMaterialTimePickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace $safeprojectname$.Renderers
{
    /// <summary>
    /// Renderer for PlaceHolder and PlaceHolderColor (not included yet in MaterialTimePicker Base)
    /// </summary>
    public class iOSMaterialTimePickerRenderer : MaterialTimePickerRenderer, IMaterialEntryRenderer
    {
        string IMaterialEntryRenderer.Placeholder => ((CustomMaterialTimePicker)Element)?.PlaceHolder ?? string.Empty;
        Color IMaterialEntryRenderer.PlaceholderColor => ((CustomMaterialTimePicker)Element)?.PlaceHolderColor ?? Color.Default;
        Color IMaterialEntryRenderer.TextColor => Element?.TextColor ?? Color.Default;
        Color IMaterialEntryRenderer.BackgroundColor => Element?.BackgroundColor ?? Color.Default;
    }
}
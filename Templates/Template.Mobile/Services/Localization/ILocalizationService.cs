using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Mobile.Services.Localization
{
    public interface ILocalizationService
    {
        Task InitializeAsync(CultureInfo cultureInfo = null, CancellationToken token = default);

        string GetText(string key);
    }
}

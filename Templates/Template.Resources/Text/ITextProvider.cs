using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Resources.Text
{
    public interface ITextProvider
    {
        int? Priority { get; }

        Task<IDictionary<string, string>> GetLocalizationsAsync(CultureInfo cultureInfo, CancellationToken token = default);
    }
}

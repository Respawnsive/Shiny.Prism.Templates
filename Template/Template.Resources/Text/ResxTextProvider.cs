using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Resources.Text
{
    public class ResxTextProvider : IResxTextProvider
    {
        private readonly ResourceManager _resourceManager;

        public ResxTextProvider(ResourceManager resourceManager, int priority)
        {
            _resourceManager = resourceManager;
            Priority = priority;
        }

        public int Priority { get; }

        public Task<IDictionary<string, string>> GetLocalizationsAsync(CultureInfo cultureInfo, CancellationToken token = default)
        {
            var localizations = _resourceManager?.GetResourceSet(cultureInfo, true, false)
                ?.Cast<DictionaryEntry>().ToDictionary(e => e.Key.ToString(), e => e.Value.ToString());

            return Task.FromResult<IDictionary<string, string>>(localizations);
        }
    }
}

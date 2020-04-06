using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Shiny;
using Template.Resources.Text;
using Template.Services.Settings;
using Template.Utils;

namespace Template.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ISettingsService _settingsService;
        private readonly IEnumerable<ITextProvider> _textProviders;
        private IList<IDictionary<string, string>> _providersLocalizations;
        private readonly AsyncLock _locker = new AsyncLock();

        public LocalizationService(ISettingsService settingsService, IEnumerable<ITextProvider> textProviders)
        {
            _settingsService = settingsService;
            _textProviders = textProviders.OrderBy(x => x.Priority).ToList();
        }

        public async Task InitializeAsync(CultureInfo askedCulture = null, CancellationToken token = default)
        {
            try
            {
                using (var locked = await _locker.LockAsync(token))
                {
                    _providersLocalizations = new List<IDictionary<string, string>>();

                    #region Asked culture

                    /*
                     * Priority 1: Check if potential asked culture is available in each provider
                     */
                    if (askedCulture != null)
                    {
                        foreach (var textProvider in _textProviders)
                        {
                            var localizations = await textProvider.GetLocalizationsAsync(askedCulture, token);
                            if (!localizations.IsEmpty())
                                _providersLocalizations.Add(localizations);
                        }
                    }

                    #endregion

                    #region Selected culture

                    /*
                     * Priority 2: Check if potential selected culture is available in each provider
                     */
                    if (_settingsService.SelectedCulture != null && _settingsService.SelectedCulture != askedCulture)
                    {
                        foreach (var textProvider in _textProviders)
                        {
                            var localizations = await textProvider.GetLocalizationsAsync(_settingsService.SelectedCulture, token);
                            if (!localizations.IsEmpty())
                                _providersLocalizations.Add(localizations);
                        }
                    }

                    #endregion

                    #region UI culture

                    /*
                     * Priority 3: Check if UI culture is available in each provider
                     */
                    if (CultureInfo.CurrentUICulture != askedCulture && CultureInfo.CurrentUICulture != _settingsService.SelectedCulture)
                    {
                        foreach (var textProvider in _textProviders)
                        {
                            var localizations = await textProvider.GetLocalizationsAsync(CultureInfo.CurrentUICulture, token);
                            if (!localizations.IsEmpty())
                                _providersLocalizations.Add(localizations);
                        } 
                    }

                    #endregion

                    #region Default culture

                    /*
                     * Priority 4: Check if default culture is available in each provider
                     */
                    if (_settingsService.AppSettings.DefaultCulture != null && _settingsService.AppSettings.DefaultCulture != askedCulture && 
                        _settingsService.AppSettings.DefaultCulture != _settingsService.SelectedCulture && _settingsService.AppSettings.DefaultCulture != CultureInfo.CurrentUICulture)
                    {
                        foreach (var textProvider in _textProviders)
                        {
                            var localizations = await textProvider.GetLocalizationsAsync(_settingsService.AppSettings.DefaultCulture, token);
                            if (!localizations.IsEmpty())
                                _providersLocalizations.Add(localizations);
                        }
                    }

                    #endregion

                    #region Invariant culture

                    /*
                     * Priority 5: Check if invariant culture is available in each provider
                     */
                    if (CultureInfo.InvariantCulture != askedCulture && CultureInfo.InvariantCulture != _settingsService.SelectedCulture &&
                        CultureInfo.InvariantCulture != CultureInfo.CurrentUICulture && CultureInfo.InvariantCulture != _settingsService.AppSettings.DefaultCulture)
                    {
                        foreach (var textProvider in _textProviders)
                        {
                            var localizations = await textProvider.GetLocalizationsAsync(CultureInfo.InvariantCulture, token);
                            if (!localizations.IsEmpty())
                                _providersLocalizations.Add(localizations);
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        public string GetText(string key)
        {
            try
            {
                foreach (var providerLocalizations in _providersLocalizations)
                {
                    if (providerLocalizations.TryGetValue(key, out var value))
                        return value;
                }

                return $"[{key}]";
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return $"[{key}]";
            }
        }
    }
}

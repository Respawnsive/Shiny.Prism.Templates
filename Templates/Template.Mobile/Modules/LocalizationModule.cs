using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Template.Mobile.Resources.Text;
using Template.Mobile.Services.Localization;
using Template.Resources.Text;

namespace Template.Mobile.Modules
{
    public class LocalizationModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddTextProvider<ResxTextProvider<TextResources>>();
            services.AddTextProvider<ResxTextProvider<MobileTextResources>>();
            services.AddSingleton<ILocalizationService, LocalizationService>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Localization.Resx;
using Template.Mobile.Resources.Text;
using Template.Resources.Text;

namespace Template.Mobile.Modules
{
    public class LocalizationModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            services.UseLocalization<ResxTextProvider<MobileTextResources>>(options =>
                options.AddTextProvider<ResxTextProvider<TextResources>>());
        }
    }
}

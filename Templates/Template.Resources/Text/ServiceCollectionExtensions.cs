using System;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Resources.Text
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTextProvider<T>(this IServiceCollection services, int? priority = null) where T : class, ITextProvider
        {
            services.AddSingleton<ITextProvider, T>(serviceProvider => serviceProvider.GetRequiredService<Func<int?, T>>().Invoke(priority));
        }
    }
}

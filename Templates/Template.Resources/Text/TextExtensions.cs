using System;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Resources.Text
{
    public static class TextExtensions
    {
        public static void AddTextProvider<T>(this IServiceCollection services, int priority) where T : class, ISimpleTextProvider
        {
            services.AddSingleton<ITextProvider, T>(serviceProvider => serviceProvider.GetService<Func<int, T>>().Invoke(priority));
        }

        public static void AddTextProvider<T>(this IServiceCollection services, ResourceManager resourceManager, int priority) where T : class, IResxTextProvider
        {
            services.AddSingleton<ITextProvider, T>(serviceProvider => serviceProvider.GetService<Func<ResourceManager, int, T>>().Invoke(resourceManager, priority));
        }
    }
}

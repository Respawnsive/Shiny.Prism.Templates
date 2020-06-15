using System;
using System.Net;
using System.Net.Http;
using HttpTracer;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using Shiny;
using Template.Mobile.Services;

namespace Template.Mobile.Modules
{
    /// <summary>
    /// Auto-magically:
    /// . generate api interface implementation with Refit and set a base uri
    /// . set http tracing level with HttpTracer with some overall decompression settings
    /// . add at least transient http error policies with Polly
    /// </summary>
    public class ApiModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddRefitClient<ISampleApiService>()
                .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://reqres.in/"))
                .ConfigurePrimaryHttpMessageHandler(() => new HttpTracerHandler(new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                }, HttpMessageParts.All))
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }));
        }
    }
}

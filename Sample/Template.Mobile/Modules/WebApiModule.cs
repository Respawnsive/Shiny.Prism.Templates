using System;
using System.Net;
using System.Net.Http;
using Apizr;
using Apizr.Policing;
using HttpTracer;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Registry;
using Refit;
using Shiny;
using Template.Mobile.Services;

namespace Template.Mobile.Modules
{
    public class WebApiModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // Polly
            var registry = new PolicyRegistry
            {
                {
                    "TransientHttpError", HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
                    }, LoggedPolicies.OnLoggedRetry).WithPolicyKey("TransientHttpError")
                }
            };
            services.AddPolicyRegistry(registry);

            // Caching
            services.UseRepositoryCache();

            // Apizr
            services.UseApizrFor<ISampleApiService>();
        }
    }
}

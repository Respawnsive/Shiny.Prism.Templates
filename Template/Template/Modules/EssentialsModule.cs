using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Template.Modules
{
    public class EssentialsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            // todo: Add needed Essentials APIs
            //services.AddSingleton<IBrowser, BrowserImplementation>();
            //services.AddSingleton<IPhoneDialer, PhoneDialerImplementation>();
            //services.AddSingleton<IMap, MapImplementation>();
            //services.AddSingleton<IEmail, EmailImplementation>();
        }
    }
}

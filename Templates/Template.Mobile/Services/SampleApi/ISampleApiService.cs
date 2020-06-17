using System.Threading;
using System.Threading.Tasks;
using Apizr;
using Apizr.Caching;
using Apizr.Logging;
using Apizr.Policing;
using Refit;
using Template.Mobile.Models.SampleApi;

[assembly: Policy("TransientHttpError")]
namespace Template.Mobile.Services
{
    [WebApi("https://reqres.in/"), Cache, Trace]
    public interface ISampleApiService
    {
        [Get("/api/users")]
        Task<UserList> GetUsersAsync(CancellationToken cancellationToken);
    }
}

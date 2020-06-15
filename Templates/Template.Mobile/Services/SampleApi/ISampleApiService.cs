using System.Threading.Tasks;
using Refit;
using Template.Mobile.Models.SampleApi;

namespace Template.Mobile.Services
{
    public interface ISampleApiService
    {
        [Get("/api/users?page={page}")]
        Task<UserList> GetUsersAsync(int page);
    }
}

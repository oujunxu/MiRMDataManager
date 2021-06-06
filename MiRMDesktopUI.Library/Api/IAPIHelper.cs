using MiRMDesktopUI.Library.Models;
using System.Threading.Tasks;
using MiRMDesktopUI.Library.Api;
using System.Net.Http;

namespace MiRMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}
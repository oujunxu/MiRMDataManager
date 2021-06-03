using MiRMDesktopUI.Library.Models;
using System.Threading.Tasks;
using MiRMDesktopUI.Library.Api;

namespace MiRMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}
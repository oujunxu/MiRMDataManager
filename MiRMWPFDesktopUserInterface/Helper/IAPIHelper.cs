using MiRMWPFDesktopUserInterface.Models;
using System.Threading.Tasks;

namespace MiRMWPFDesktopUserInterface.Helper
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}
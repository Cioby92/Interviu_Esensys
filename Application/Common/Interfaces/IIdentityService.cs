using Essensys.Application.Common.Models;
using System.Threading.Tasks;

namespace Essensys.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserId(string CNP);
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}

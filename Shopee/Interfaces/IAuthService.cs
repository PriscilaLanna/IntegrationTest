using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> ExecuteAsync();
    }
}
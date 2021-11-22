using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenResponse> ExecuteAsync();
    }
}
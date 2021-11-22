using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IAccessTokenService
    {
        Task<AccessTokenResponse> ExecuteAsync(string code, int shopId, int main_account_id);
    }
}
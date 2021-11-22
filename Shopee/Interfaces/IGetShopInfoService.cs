using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IGetShopInfoService
    {
        Task<GetShopInfoResponse> ExecuteAsync();
    }
}
using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IGetMerchantInfoService
    {
        Task<GetMerchantInfoResponse> ExecuteAsync();
    }
}
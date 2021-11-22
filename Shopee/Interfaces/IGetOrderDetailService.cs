using Shopee.Models.OrderDetail;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IGetOrderDetailService
    {
        Task<GetOrderDetailResponse> ExecuteAsync(string orderSn);
    }
}
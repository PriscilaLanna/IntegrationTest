using Shopee.Models.OrderDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IGetOrderService
    {
        Task<GetOrderDetailResponse> ExecuteAsync();
    }
}
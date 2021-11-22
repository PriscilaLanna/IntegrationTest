using Shopee.Models.Product.Request;
using Shopee.Models.Product.Response;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IPostProductService
    {
        Task<ProductResponse> ExecuteAsync(ProductRequest product);
    }
}
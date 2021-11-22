using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IGetProfileService
    {
        Task<GetProfileResponse> ExecuteAsync();
    }
}
using Shopee.Models;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IWebHookService
    {
        void ExecuteAsync(string body);
    }
}
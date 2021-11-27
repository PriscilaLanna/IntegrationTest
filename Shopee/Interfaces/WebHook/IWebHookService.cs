using Shopee.Models;
using Shopee.Models.WebHook;
using System.Threading.Tasks;

namespace Shopee.Interfaces
{
    public interface IWebHookService
    {
        void ExecuteAsync(WebHookRequest webhook, string authorizationy);
    }
}
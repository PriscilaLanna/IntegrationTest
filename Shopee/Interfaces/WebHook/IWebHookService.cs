using Shopee.Models.WebHook;

namespace Shopee.Interfaces
{
    public interface IWebHookService
    {
        void ExecuteAsync(string url, string authorization, WebHookRequest webhook);
    }
}
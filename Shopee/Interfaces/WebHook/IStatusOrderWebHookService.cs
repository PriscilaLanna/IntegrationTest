using Shopee.Models.WebHook;

namespace Shopee.Interfaces
{
    public interface IStatusOrderWebHookService
    {
        void ExecuteAsync(WebHookRequest webhook);
    }
}
using Microsoft.Extensions.Options;
using Shopee.Enum;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.WebHook;
using System;

namespace Shopee.Services
{
    public class StatusOrderWebHookService : IStatusOrderWebHookService
    {

        private readonly PartnerConfig _partner;

        public StatusOrderWebHookService(IOptions<PartnerConfig> partner)
        {
            _partner = partner.Value;
        }

        public void ExecuteAsync(WebHookRequest webhook)
        {
            if (OrderStatus.READY_TO_SHIP.ToString() == webhook.Data.Status)
                throw new NotImplementedException();
        }
    }
}
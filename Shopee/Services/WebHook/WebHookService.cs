using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopee.Enum;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.WebHook;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Shopee.Services
{
    public class WebHookService : IWebHookService
    {
        private readonly IStatusOrderWebHookService _statusOrderWebHookService;
        private readonly PartnerConfig _partner;

        public WebHookService(IOptions<PartnerConfig> partner,
                              IStatusOrderWebHookService statusOrderWebHookService)
        {
            _statusOrderWebHookService = statusOrderWebHookService;
            _partner = partner.Value;
        }

        public void ExecuteAsync(string url, string authorization, WebHookRequest webhook)
        {
            if (!VerifyPushContent(url, JsonConvert.SerializeObject(webhook), authorization))
                throw new ArgumentException("Requisição inválida");

            switch (webhook.Code)
            {
                case (int)CodeDefinition.OrderStatus:
                    _statusOrderWebHookService.ExecuteAsync(webhook);
                    break;
                default:
                    break;
            }
        }

        private bool VerifyPushContent(string url, string requestBody, string authorization)
        {
            var baseString = url + '|' + requestBody;
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(_partner.PartnerKey));
            byte[] calAuthByte = hash.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            var calAuth = BitConverter.ToString(calAuthByte).Replace("-", "").ToLower();

            return calAuth == authorization;
        }
    }
}
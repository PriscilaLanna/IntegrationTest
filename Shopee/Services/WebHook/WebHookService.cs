using Microsoft.Extensions.Options;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.WebHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class WebHookService : IWebHookService
    {

        private readonly PartnerConfig _partner;

        public WebHookService(IOptions<PartnerConfig> partner)
        {
            _partner = partner.Value;
        }

        public void ExecuteAsync(WebHookRequest webhook, string authorization)
        {
            if (!VerifyPushContent("", "", authorization))
                 throw new ArgumentException("Requisição inválida");
        }

        public bool VerifyPushContent(string url, string requestBody, string authorization)
        {
            var baseString = url + '|' + requestBody;
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(_partner.PartnerKey));
            byte[] calAuthByte = hash.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            var calAuth = BitConverter.ToString(calAuthByte).Replace("-", "").ToLower();
            
            return calAuth == authorization;
        }
    }
}
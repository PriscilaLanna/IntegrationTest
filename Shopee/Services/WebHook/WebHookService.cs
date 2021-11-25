using Shopee.Interfaces;
using Shopee.Models;
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
        public void ExecuteAsync(string body)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPushContent(string url, string requestBody, string authorization)
        {
            var baseString = url + '|' + requestBody;
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(PartnerConfig.Partner_Key));
            byte[] calAuthByte = hash.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            var calAuth = BitConverter.ToString(calAuthByte).Replace("-", "").ToLower();
            
            return calAuth == authorization;
        }
    }
}
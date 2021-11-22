using Shopee.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class WebHookService : IWebHookService
    {
        public void ExecuteAsync(string body)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPushContent(string url, string requestBody, int partnerKey, string authorization)
        {
            throw new NotImplementedException();
        }
    }
}

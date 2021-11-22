using Shopee.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Shopee.Services
{
    public abstract class BaseServiceShopee
    {
        private readonly IProviderCache _provider;

        public BaseServiceShopee(IProviderCache provider)
        {
            _provider = provider;
        }

        public string GetUrlAuth(string endpoint) => $"https://partner.test-stable.shopeemobile.com{endpoint}{GetCommonParametersPublic(endpoint)}";

        public string GetUrlCommonsParametersRequest(string endpoint) => $"https://partner.test-stable.shopeemobile.com{endpoint}{GetCommonParametersRequest(endpoint)}";

        public int GetShopId() => int.Parse(_provider.GetCache("shopId").ToString());

        public List<int> GetMerchantIds() => _provider.GetListCache("merchantIds");

        //public void ResetAllCache() => _provider.Reset();

        private string GetCommonParametersPublic(string endpoint)
        {
            var signParameters = GenerateSignPublic(endpoint);

            var parameters = new CommonParameters()
            {
                Partner_Id = PartnerConfig.Partner_Id,
                Sign = signParameters.Sign,
                TimeStamp = signParameters.TimeStamp
            };

            return $"?partner_id={parameters.Partner_Id}&sign={parameters.Sign}&timestamp={parameters.TimeStamp}";
        }

        private string GetCommonParametersRequest(string endpoint)
        {
            var accessToken = _provider.GetCache("accessToken").ToString();
            int.TryParse(_provider.GetCache("shopId").ToString(), out var shopId);

            var signParameters = GenerateSign(endpoint, accessToken, shopId);

            var parameters = new CommonParameters()
            {
                Partner_Id = PartnerConfig.Partner_Id,
                Sign = signParameters.Sign,
                TimeStamp = signParameters.TimeStamp,
                Shop_Id = shopId,
                AccessToken = accessToken
            };

            return $"?shop_id={parameters.Shop_Id}&partner_id={parameters.Partner_Id}&access_token={parameters.AccessToken}&sign={parameters.Sign}&timestamp={parameters.TimeStamp}";
        }

        private SignParameters GenerateSignPublic(string endPoint)
        {
            var timeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            var base_string = String.Format("{0}{1}{2}", PartnerConfig.Partner_Id, endPoint, timeStamp);
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(PartnerConfig.Partner_Key));
            byte[] tmp_sign = hash.ComputeHash(Encoding.UTF8.GetBytes(base_string));
            var sign = BitConverter.ToString(tmp_sign).Replace("-", "").ToLower();

            return new SignParameters { TimeStamp = timeStamp, Sign = sign };
        }

        private SignParameters GenerateSign(string endPoint, string acessToken, int shopId)
        {
            var timeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            var base_string = String.Format("{0}{1}{2}{3}{4}", PartnerConfig.Partner_Id, endPoint, timeStamp, acessToken, shopId);
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(PartnerConfig.Partner_Key));
            byte[] tmp_sign = hash.ComputeHash(Encoding.UTF8.GetBytes(base_string));
            var sign = BitConverter.ToString(tmp_sign).Replace("-", "").ToLower();

            return new SignParameters { TimeStamp = timeStamp, Sign = sign };
        }

        //private SignParameters GenerateSignMerchant(string endPoint, string acessToken, int merchantId)
        //{
        //    var timeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

        //    var base_string = String.Format("{0}{1}{2}{3}{4}", PartnerConfig.Partner_Id, endPoint, timeStamp, acessToken, merchantId);
        //    var hash = new HMACSHA256(Encoding.UTF8.GetBytes(PartnerConfig.Partner_Key));
        //    byte[] tmp_sign = hash.ComputeHash(Encoding.UTF8.GetBytes(base_string));
        //    var sign = BitConverter.ToString(tmp_sign).Replace("-", "").ToLower();

        //    return new SignParameters { TimeStamp = timeStamp, Sign = sign };
        //}

        private class SignParameters
        {
            public long TimeStamp { get; set; }
            public string Sign { get; set; }
        }
    }
}
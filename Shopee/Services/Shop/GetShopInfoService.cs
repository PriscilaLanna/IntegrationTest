using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class GetShopInfoService : BaseServiceShopee, IGetShopInfoService
    {
        private readonly HttpClient _httpClient;

        public GetShopInfoService(IProviderCache provider, IOptions<PartnerConfig> partner) : base(provider, partner)
        {
            _httpClient = new HttpClient();
        }

        public async Task<GetShopInfoResponse> ExecuteAsync()
        {
            try
            {
                var url = $"{GetUrlCommonsParametersRequest("/api/v2/shop/get_shop_info")}";

                var response = await _httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<GetShopInfoResponse>(json);
                else
                    throw new HttpRequestException(json, null, response.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
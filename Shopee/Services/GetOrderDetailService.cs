using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models.OrderDetail;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class GetOrderDetailService : BaseServiceShopee, IGetOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public GetOrderDetailService(IProviderCache provider) : base(provider)
        {
            _httpClient = new HttpClient();
        }

        public async Task<GetOrderDetailResponse> ExecuteAsync(string orderSn)
        {
            try
            {
                var requestParameters = $"&order_sn_list={orderSn}";
                var url = $"{GetUrlCommonsParametersRequest("/api/v2/order/get_order_detail") + requestParameters}";

                var response = await _httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<GetOrderDetailResponse>(json);
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
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.Order;
using Shopee.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class GetOrderService : BaseServiceShopee, IGetOrderService
    {
        private readonly HttpClient _httpClient;
        IGetOrderDetailService _service;

        public GetOrderService(IProviderCache provider, IGetOrderDetailService service, IOptions<PartnerConfig> partner) : base(provider, partner)
        {
            _httpClient = new HttpClient();
            _service = service;
        }

        public async Task<GetOrderDetailResponse> ExecuteAsync()
        {
            try
            {
                var order = new GetOrderResponse();
                var detailsOrder = new List<GetOrderDetailResponse>();

                var response = await _httpClient.GetAsync(Url());
                string json = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(json);

                if (response.IsSuccessStatusCode && string.IsNullOrEmpty(error.Error))
                    order = JsonConvert.DeserializeObject<GetOrderResponse>(json);
                else
                    throw new HttpRequestException(json, null, response.StatusCode);

                string ordersSn = String.Join(",", order.Response.Order_List.Select(x => x.Order_Sn));

                return await _service.ExecuteAsync(ordersSn);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string Url()
        {
            var timeFrom = ((DateTimeOffset)DateTime.Now.AddDays(-14)).ToUnixTimeSeconds();
            var timeTo = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            var pageSize = 100;
            var requestParameters = $"&time_range_field=create_time&time_from={timeFrom}&time_to={timeTo}&page_size={pageSize}";
            var url = $"{GetUrlCommonsParametersRequest("/api/v2/order/get_order_list")}{requestParameters}";
            return url;
        }
    }
}
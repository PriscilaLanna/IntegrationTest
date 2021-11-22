using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.Order;
using Shopee.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class GetOrderService : BaseServiceShopee, IGetOrderService
    {
        private readonly HttpClient _httpClient;
        IGetOrderDetailService _service;

        public GetOrderService(IProviderCache provider, IGetOrderDetailService service) : base(provider)
        {
            _httpClient = new HttpClient();
            _service = service;
        }

        public async Task<List<GetOrderDetailResponse>> ExecuteAsync()
        {
            try
            {
                var timeFrom = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
                var timeTo = ((DateTimeOffset)DateTime.Now.AddDays(15)).ToUnixTimeSeconds();
                var pageSize = 100;
                var parameters = $"&time_range_field=create_time&time_from={timeFrom}&time_to={timeTo}&page_size={100}";

                var orders = new List<GetOrderResponse>();

                var url = $"{GetUrlCommonsParametersRequest("/api/v2/order/get_order_list")}{parameters}";

                var response = await _httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(json);

                if (response.IsSuccessStatusCode && string.IsNullOrEmpty(error.Error))
                    orders.Add(JsonConvert.DeserializeObject<GetOrderResponse>(json));
                else
                    throw new HttpRequestException(json, null, response.StatusCode);

                var detailsOrder = new List<GetOrderDetailResponse>();
                foreach (var order in orders)
                {
                    foreach (var orderList in order.Response.Order_List)
                    {
                        var detail = await _service.ExecuteAsync(orderList.Order_Sn);
                        detailsOrder.Add(detail);
                    }
                }

                return detailsOrder;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}
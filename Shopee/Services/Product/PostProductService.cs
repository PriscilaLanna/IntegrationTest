using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models.Product.Request;
using Shopee.Models.Product.Response;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class PostProductService : BaseServiceShopee, IPostProductService
    {
        private readonly HttpClient _httpClient;

        public PostProductService(IProviderCache provider) : base(provider)
        {
            _httpClient = new HttpClient();
        }

        public async Task<ProductResponse> ExecuteAsync(ProductRequest product)
        {
            try
            {
                var url = $"{GetUrlCommonsParametersRequest("/api/v2/product/add_item")}";
                var response = new HttpResponseMessage();
                
                response = await _httpClient.PostAsJsonAsync(url, product);

                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<ProductResponse>(json);
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
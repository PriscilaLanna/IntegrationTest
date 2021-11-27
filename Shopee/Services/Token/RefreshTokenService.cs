using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class RefreshTokenService : BaseServiceShopee, IRefreshTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IProviderCache _provider;

        public RefreshTokenService(IProviderCache provider, IOptions<PartnerConfig> partner) : base(provider, partner)
        {
            _httpClient = new HttpClient();
            _provider = provider;
        }

        public async Task<RefreshTokenResponse> ExecuteAsync()
        {
            try
            {
                var url = $"{GetUrlAuth("/api/v2/auth/access_token/get")}";

                int.TryParse(_provider.GetCache("shopId").ToString(), out var shopId);
                var refreshToken = _provider.GetCache("refreshToken").ToString();
                var response = new HttpResponseMessage();

                if (shopId > 0) 
                {
                    var body = new { refresh_token = refreshToken, partner_id = GetPartnerId(), shop_id = shopId };
                    response = await _httpClient.PostAsJsonAsync(url, body);
                }
              
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var refreshTokenResponse = JsonConvert.DeserializeObject<RefreshTokenResponse>(json);

                    _provider.SetCache(new KeyValuePair<string, object>("accessToken", refreshTokenResponse.Access_Token));
                    _provider.SetCache(new KeyValuePair<string, object>("refreshToken", refreshTokenResponse.Refresh_Token));

                    return refreshTokenResponse;
                }
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
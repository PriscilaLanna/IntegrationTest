using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class AccessTokenService : BaseServiceShopee, IAccessTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IProviderCache _provider;

        public AccessTokenService(IProviderCache provider, IOptions<PartnerConfig> partner) : base(provider, partner)
        {
            _httpClient = new HttpClient();
            _provider = provider;
        }

        public async Task<AccessTokenResponse> ExecuteAsync(string code, int shopId)
        {
            try
            {
                var url = $"{GetUrlAuth("/api/v2/auth/token/get")}";
                var response = new HttpResponseMessage();

                var body = new { code = code, partner_id = GetPartnerId(), shop_id = shopId };
                response = await _httpClient.PostAsJsonAsync(url, body);

                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var accessToken = JsonConvert.DeserializeObject<AccessTokenResponse>(json);

                    _provider.SetCache(new KeyValuePair<string, object>(nameof(shopId), shopId));
                    _provider.SetCache(new KeyValuePair<string, object>("accessToken", accessToken.Access_Token));
                    _provider.SetCache(new KeyValuePair<string, object>("refreshToken", accessToken.Refresh_Token));

                    return accessToken;
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
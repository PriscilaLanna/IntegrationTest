using Shopee.Interfaces;
using Shopee.Models;
using System;
using System.Threading.Tasks;

namespace Shopee.Services
{
    public class AuthService : BaseServiceShopee, IAuthService
    {

        public AuthService(IProviderCache provider) : base(provider)
        {
        }

        public async Task<AuthResponse> ExecuteAsync()
        {
            try
            {
                var redirectUrl = "https://localhost:44351/AccessTokenShopee/";
                var url = $"{GetUrlAuth("/api/v2/shop/auth_partner")}&redirect={redirectUrl}";

                return new AuthResponse { Url = url };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessTokenShopeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccessTokenShopeeController(IProviderCache provider, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> AccessToken([FromServices] IAccessTokenService accessTokenService, [FromQuery] string code, int shop_Id)  
        {
            var redirectUrl = _configuration["RedirectUrl"];
             
            try
            {
                var accessToken = await accessTokenService.ExecuteAsync(code, shop_Id);
                return Redirect(redirectUrl);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, JsonConvert.DeserializeObject<ErrorResponse>(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
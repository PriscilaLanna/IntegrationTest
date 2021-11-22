using Microsoft.AspNetCore.Mvc;
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
        public AccessTokenShopeeController(IProviderCache provider)
        {
        }

        [HttpGet]
        public async Task<ActionResult> AccessToken([FromServices] IAccessTokenService accessTokenService, [FromQuery] string code, int shop_Id, int main_account_id)  
        {
            var redirectUrl = "https://development-emissor.ao3tech.com/";
             
            try
            {
                var accessToken = await accessTokenService.ExecuteAsync(code, shop_Id, main_account_id);
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
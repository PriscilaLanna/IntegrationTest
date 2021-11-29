using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Models.WebHook;
using Shopee.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebHookShopeeController : ControllerBase
    {

        public WebHookShopeeController(IProviderCache provider)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Push([FromServices]IWebHookService service,[FromHeader] string authorization, [FromBody] WebHookRequest body)  
        {
            try
            {
                var url = "https://webhook.site/5d2b0c11-ec67-4952-a295-8606d3e0b236"; //TODO Alterar para pegar url da requisição
                service.ExecuteAsync(url, authorization, body);
                return Ok();
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
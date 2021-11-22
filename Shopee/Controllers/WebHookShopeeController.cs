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
    public class WebHookShopeeController : ControllerBase
    {

        public WebHookShopeeController(IProviderCache provider)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Push([FromServices]IWebHookService service, [FromBody] string body)  
        {
            try
            {
                service.ExecuteAsync(body);
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
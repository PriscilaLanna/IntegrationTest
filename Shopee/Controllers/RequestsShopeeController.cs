using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Shopee.Models;
using Shopee.Interfaces;
using System;
using System.Net.Http;
using Shopee.Models.Product.Request;

namespace Shopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestsShopeeController : ControllerBase
    {
        public RequestsShopeeController()
        {
        }

        [HttpGet("GetShopInfo")]
        public async Task<ActionResult> GetShopInfo([FromServices] IGetShopInfoService service)
        {
            try
            {
                var response = await service.ExecuteAsync();

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
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

        [HttpGet("GetProfile")]
        public async Task<ActionResult> GetProfile([FromServices] IGetProfileService service)
        {
            try
            {
                var response = await service.ExecuteAsync();

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
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

        [HttpGet("GetOrder")]
        public async Task<ActionResult> GetOrder([FromServices] IGetOrderService service)
        {
            try
            {
                var response = await service.ExecuteAsync();

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
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

        [HttpPost("PostProduct")]
        public async Task<ActionResult> PostProduct([FromServices] IPostProductService service, [FromBody] ProductRequest product)
        {
            try
            {
                var response = await service.ExecuteAsync(product);

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
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
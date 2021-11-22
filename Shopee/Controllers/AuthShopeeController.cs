using Microsoft.AspNetCore.Mvc;
using Shopee.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthShopeeController : ControllerBase
    {
        public AuthShopeeController()
        {
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IAuthService service)
        {
            try
            {
                return Ok(await service.ExecuteAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
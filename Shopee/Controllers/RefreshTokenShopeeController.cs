using Microsoft.AspNetCore.Mvc;
using Shopee.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shopee.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RefreshTokenShopeeController : ControllerBase
    {
        public RefreshTokenShopeeController()
        {
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IRefreshTokenService service)
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
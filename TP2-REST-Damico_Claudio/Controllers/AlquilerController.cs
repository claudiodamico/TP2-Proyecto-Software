using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/alquileres")]
    [ApiController]
    public class AlquilerController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(await Post());
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok(await Put());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok(await Delete());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TP2_REST_AccesData.Data;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly LibreriaDbContext _libreriaDb;

        public ClienteController(LibreriaDbContext libreria)
        {
            _libreriaDb = libreria;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Post());
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

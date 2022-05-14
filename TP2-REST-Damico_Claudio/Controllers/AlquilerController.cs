using Microsoft.AspNetCore.Mvc;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/alquileres")]
    [ApiController]
    public class AlquilerController : Controller
    {
        /// <summary>
        /// Get rentals
        /// </summary>
        [HttpGet]
        public IActionResult GetByEstado([FromQuery] int estadoId)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get rentals by customer
        /// </summary>
        [HttpGet("cliente/{id}")]
        public IActionResult GetAlquilerByCliente(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Modify rent
        /// </summary>
        [HttpPost]
        public IActionResult Post(AlquilerDto alquilerDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Modify rent by field 
        /// </summary>
        [HttpPatch]
        public IActionResult Patch(ModifyAlquilerDto modifyAlquilerDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

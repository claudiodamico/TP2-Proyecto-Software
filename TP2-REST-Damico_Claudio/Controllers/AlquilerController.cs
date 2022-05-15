using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/alquileres")]
    [ApiController]
    public class AlquilerController : Controller
    {
        private readonly IAlquilerService _alquilerService;

        public AlquilerController(IAlquilerService alquilerService)
        {
            _alquilerService = alquilerService;
        }

        /// <summary>
        /// Get rentals
        /// </summary>
        [HttpGet]
        public IActionResult GetByEstado([FromQuery] int estadoId)
        {
            try
            {
                return new JsonResult(_alquilerService.GetByEstadoId(estadoId)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
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
                return new JsonResult(_alquilerService.GetLibroByCliente(id))
                { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Modify rent
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromForm] AlquilerDto alquilerDTO)
        {
            try
            {
                var validar = _alquilerService.CreateAlquiler(alquilerDTO);
                if(validar != null)
                {
                    return (validar == null ? new JsonResult(_alquilerService.CreateAlquiler(alquilerDTO))
                    { StatusCode = 201 } : new JsonResult(validar)
                    { StatusCode = 400 });
                }

                return Conflict("Error");
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
        public IActionResult Patch([FromForm] ModifyAlquilerDto modifyAlquilerDto)
        {
            try
            {            
                _alquilerService.ModifyReserva(modifyAlquilerDto);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

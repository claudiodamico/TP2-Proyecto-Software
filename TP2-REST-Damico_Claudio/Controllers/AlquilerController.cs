using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Aplication.Validations;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/alquileres")]
    [ApiController]
    public class AlquilerController : Controller
    {
        private readonly IAlquilerService _alquilerService;
        private readonly IValidations _validations;
        private readonly IMapper _mapper;

        public AlquilerController(IAlquilerService alquilerService
            , IValidations validations,
            IMapper mapper)
        {
            _alquilerService = alquilerService;
            _validations = validations;
            _mapper = mapper;
        }

        /// <summary>
        /// Get rentals
        /// </summary>
        [HttpGet]
        public IActionResult GetByEstado([FromQuery] int estadoId)
        {
            try
            {
                return new JsonResult(_mapper.Map<List<Alquiler>>(_alquilerService.GetByEstadoId(estadoId))) { StatusCode = 200 };
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
                return new JsonResult(_mapper.Map<List<Alquiler>>(_alquilerService.GetLibroByCliente(id))) {StatusCode = 200};
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
             return new JsonResult(_alquilerService.CreateAlquiler(alquilerDTO)) {StatusCode = 201};        
        }

        /// <summary>
        /// Modify rent by field 
        /// </summary>
        [HttpPatch]
        public IActionResult Patch([FromForm] ModifyAlquilerDto modifyAlquilerDto)
        {
            _alquilerService.ModifyReserva(modifyAlquilerDto);

            return new StatusCodeResult(204);
        }
    }
}

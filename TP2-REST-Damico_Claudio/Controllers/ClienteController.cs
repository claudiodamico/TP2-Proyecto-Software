using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Aplication.Validations;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IValidations _validations;
        private readonly IMapper _mapper;

        public ClienteController(IClientesService clientesService,
            IMapper mapper, IValidations validations)
        {
            _clientesService = clientesService;
            _validations = validations;
            _mapper = mapper;
        }

        /// <summary>
        /// Get customers from name, last name or dni
        /// </summary>
        [HttpGet]
        public IActionResult GetClientes(string? nombre, string? apellido, string? dni)
        {
            {
                try
                {
                    return new JsonResult(_clientesService.GetCliente(nombre, apellido, dni)) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

        /// <summary>
        /// register customer
        /// </summary>
        [HttpPost]
        public IActionResult RegistrarCliente(ClienteDto cliente)
        {
            try
            {
                Response? validar = _validations.ValidarCliente(cliente);
                var clienteEntity = _clientesService.CrearCliente(cliente);
                if(clienteEntity != null)
                {
                    var clienteCreado = _mapper.Map<ClienteDto>(clienteEntity);
                    return Ok(clienteCreado);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }    
    }
}

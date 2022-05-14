using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;

        public ClienteController(IClientesService clientesService,
            IMapper mapper)
        {
            _clientesService = clientesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get customers from name, last name or dni
        /// </summary>
        [HttpGet]
        public IActionResult GetClientes([FromQuery] string? nombre, [FromQuery] string? apellido, [FromQuery] string? dni)
        {
            try
            {
                if (nombre != null && apellido == null && dni == null)
                {
                    var cliente = _clientesService.GetClienteByNombre(nombre);
                    var clienteMapped = _mapper.Map<ClienteDto>(cliente);

                    return Ok(clienteMapped);
                }

                else if (nombre == null && apellido != null && dni == null)
                {
                    var cliente = _clientesService.GetClienteByApellido(apellido);
                    var clienteMapped = _mapper.Map<ClienteDto>(cliente);

                    return Ok(clienteMapped);
                }

                else if (nombre == null && apellido == null && dni != null)
                {
                    var cliente = _clientesService.GetClienteByDni(dni);
                    var clienteMapped = _mapper.Map<ClienteDto>(cliente);

                    return Ok(clienteMapped);
                }

                else
                {
                    var cliente = _clientesService.GetAllClientes();
                    var clienteMapped = _mapper.Map<List<ClienteDto>>(cliente);

                    return Ok(clienteMapped);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// register customer
        /// </summary>
        [HttpPost]
        public IActionResult RegistrarCliente([FromForm] ClienteDto cliente)
        {
            try
            {
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

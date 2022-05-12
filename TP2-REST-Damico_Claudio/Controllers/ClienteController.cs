using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteService,
            IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClientes(string nombre, string apellido, string dni)
        {
            try
            {
                var clientes = _clienteService.GetClientes(nombre, apellido, dni);
                var clientesMapped = _mapper.Map<List<ClienteDto>>(clientes);

                if(clientes == null)
                {
                    return NotFound();
                }

                return Ok(clientesMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(await Post());
        }      
    }
}

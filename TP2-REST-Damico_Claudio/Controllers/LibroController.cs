using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibrosService _librosService;
        private readonly IMapper _mapper;

        public LibroController(ILibrosService librosService,
            IMapper mapper)
        {
            _librosService = librosService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetLibros([FromForm] bool? stock = null, string? autor = null, string? titulo = null)
        {
            try
            {
                if(stock != null && autor == null && titulo == null)
                {
                    var libroGet =  _librosService.GetLibroByStock(stock);
                    var libroMapped = _mapper.Map<LibroDto>(libroGet);

                    return Ok(libroMapped);
                }
                else if(stock == null && autor != null && titulo == null)
                {
                    var libroGet =  _librosService.GetLibroByAutor(autor);
                    var libroMapped = _mapper.Map<LibroDto>(libroGet);

                    return Ok(libroMapped);
                }
                else if(stock == null && autor == null && titulo != null)
                {
                    var libroGet = _librosService.GetLibroByTitulo(titulo);
                    var libroMapped = _mapper.Map<LibroDto>(libroGet);

                    return Ok(libroMapped);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

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

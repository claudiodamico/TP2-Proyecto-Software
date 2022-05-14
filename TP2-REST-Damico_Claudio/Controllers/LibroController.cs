using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;
using TP2_REST_Domain.Dtos;

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

        /// <summary>
        /// Get books from stock, autor or tittle.
        /// </summary>
        [HttpGet]
        public IActionResult GetLibros([FromQuery] bool? stock = null, [FromQuery] string? autor = null, [FromQuery] string? titulo = null)
        {
            try
            {
                if (stock != null && autor == null && titulo == null)
                {
                    var libro = _librosService.GetLibrosByStock(stock);
                    var libroMapped = _mapper.Map<LibroDto>(libro);

                    return Ok(libroMapped);
                }

                else if (stock == null && autor != null && titulo == null)
                {
                    var libro = _librosService.GetLibrosByAutor(autor);
                    var libroMapped = _mapper.Map<LibroDto>(libro);

                    return Ok(libroMapped);
                }

                else if (stock == null && autor == null && titulo != null)
                {
                    var libro = _librosService.GetLibrosByTitulo(titulo);
                    var libroMapped = _mapper.Map<LibroDto>(libro);

                    return Ok(libroMapped);
                }

                else
                {
                    var libro = _librosService.GetAllLibros();
                    var libroMapped = _mapper.Map<List<LibroDto>>(libro);

                    return Ok(libroMapped);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

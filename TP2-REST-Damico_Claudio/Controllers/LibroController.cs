using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_REST_Aplication.Services;

namespace TP2_REST_Damico_Claudio.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibrosService _librosService;

        public LibroController(ILibrosService librosService,
            IMapper mapper)
        {
            _librosService = librosService;
        }

        /// <summary>
        /// Get books from stock, autor or tittle.
        /// </summary>
        [HttpGet]
        public IActionResult GetLibros(string? stock = null, string? autor = null, string? titulo = null)
        {
            try
            {
                return new JsonResult(_librosService.GetLibro(stock, autor, titulo)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}


namespace TP2_REST_Domain.Dtos
{
    public class GetAlquilerByEstadoIdDto
    {
        public int AlquilerId { get; set; }
        public int EstadoId { get; set; }
        public string EstadoAlquiler { get; set; }
        public string ISBN { get; set; }
        public string LibroTitulo { get; set; }
        public string LibroAutor { get; set; }
        public string LibroEditorial { get; set; }
        public string LibroEdicion { get; set; }
        public int LibroStock { get; set; }
    }
}

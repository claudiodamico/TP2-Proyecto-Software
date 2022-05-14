
namespace TP2_REST_Domain.Dtos
{
    public class AlquilerDto
    {
        public int ClienteId { get; set; }
        public string ISBN { get; set; }
        public int Estado { get; set; }
        public string FechaAlquiler { get; set; }
        public string FechaReserva { get; set; }
    }
}

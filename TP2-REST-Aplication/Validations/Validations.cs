using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Aplication.Validations
{
    public interface IValidations
    {
        Response? ValidarAlquiler(AlquilerDto alquilerDto);
        Response? ValidarModifyReserva(ModifyAlquilerDto modifyAlquilerDto);
        Response? ValidarCliente(ClienteDto clienteDto);
    }

    public class Validations : IValidations
    {
        private readonly IAlquilerRepository _alquilerRepository;

        public Validations(IAlquilerRepository alquilerRepository)
        {
            _alquilerRepository = alquilerRepository;
        }
    
        public static bool ValidarFecha(string fecha)
        {
            return DateTime.TryParse(fecha, out _);
        }

        public Response? ValidarAlquiler(AlquilerDto alquilerDto)
        {
            if (alquilerDto.FechaAlquiler == null && alquilerDto.FechaAlquiler == "" 
                && alquilerDto.FechaReserva == null && alquilerDto.FechaReserva == "")
                return new Response { CódigoError = 400, 
                    Error = "No se ingresó ninguna fecha. Ingresar la fecha correspondiente: alquiler o reserva."};

            if (alquilerDto.FechaAlquiler != null && alquilerDto.FechaAlquiler != "" 
                && alquilerDto.FechaReserva != null && alquilerDto.FechaReserva != "")
                return new Response { CódigoError = 400, 
                    Error = "Ingresar solo una fecha. Ingresar la fecha correspondiente: alquiler o reserva."};

            if (alquilerDto.FechaReserva == null && alquilerDto.FechaReserva == "")
                if (!Validations.ValidarFecha(alquilerDto.FechaReserva))
                    return new Response{ CódigoError = 400, 
                        Error = "Formato válido de fecha. Se debe utilizar el formato DD/MM/AAAA"};

            if (alquilerDto.FechaAlquiler == null && alquilerDto.FechaAlquiler == "")
                if (!Validations.ValidarFecha(alquilerDto.FechaAlquiler))
                    new Response { CódigoError = 400, 
                        Error = "Formato válido de fecha. Se debe utilizar el formato DD/MM/AAAA"};
            if (!_alquilerRepository.ExisteCliente(alquilerDto.ClienteId))
                return new Response { CódigoError = 400, 
                    Error = "No existe el cliente con el Id ingresado."};

            if (!_alquilerRepository.ExisteLibro(alquilerDto.ISBN))
                return new Response { CódigoError = 400, 
                    Error = "No existe un libro con el Isbn ingresado"};

            if (!_alquilerRepository.ExisteStock(alquilerDto.ISBN))
                return new Response { CódigoError = 400, 
                    Error = "No existe stock del libro requerido"};

            return null;
        }

        public Response? ValidarModifyReserva(ModifyAlquilerDto modifyAlquilerDto)
        {
            if (!_alquilerRepository.ExisteReservaDeCliente(modifyAlquilerDto.ClienteId))
                return new Response { CódigoError = 400, Error = "No existe reserva del cliente ingresado" };
            if (!_alquilerRepository.ExisteReservaDeLibro(modifyAlquilerDto.ISBN))
                return new Response { CódigoError = 400, Error = "No existe reserva del libro ingresado" };
            return null;
        }

        public Response? ValidarCliente(ClienteDto clienteDto)
        {
            if (_alquilerRepository.ExisteDNI(clienteDto.Dni))
                return new Response { CódigoError = 400, 
                    Error = "Ya existe un cliente con el DNI ingresado." };
            return null;
        }
    }
}
 
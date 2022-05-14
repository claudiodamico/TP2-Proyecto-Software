using System.Text.RegularExpressions;

namespace TP2_REST_Aplication.Validations
{
    public interface IValidations
    {
        bool ValidarEmail(string Email);
        bool ValidarString(string input);
        bool ValidarDni(string dni);
        bool ValidarFecha(string fecha);
        string ValidarLibro(string isbn);


    }
    public class Validations : IValidations
    {
        public bool ValidarEmail(string Email)
        {
            string formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(Email, formato) && (Regex.Replace(Email, formato, String.Empty).Length == 0);
        }

        public bool ValidarString(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        public bool ValidarDni(string dni)
        {
            return (int.TryParse(dni, out _)) && !(dni.Length < 8 || dni.Length > 8);
        }

        public bool ValidarFecha(string fecha)
        {
            return DateTime.TryParse(fecha, out _);
        }

        public string ValidarLibro(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}

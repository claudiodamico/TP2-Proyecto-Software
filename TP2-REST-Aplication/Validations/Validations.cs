using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP2_REST_Aplication.Validations
{
    public class Validations
    {
        public static bool ValidationEmail(string EmailAComprobar)
        {
            string formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(EmailAComprobar, formato) && (Regex.Replace(EmailAComprobar, formato, String.Empty).Length == 0);
        }

        public static bool ValidationString(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        public static bool ValidationDni(string dni)
        {
            return (int.TryParse(dni, out _)) && !(dni.Length < 8 || dni.Length > 8);
        }

        public static bool ValidationDate(string fecha)
        {
            return DateTime.TryParse(fecha, out _);
        }
    }
}

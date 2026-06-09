using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorCnpj.Application.Validators
{
    internal class NormalizaCnpj
    {
        public static string Normalizar(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return string.Empty;

            var stringFormatada = new string(cnpj
                .Where(char.IsLetterOrDigit)
                .ToArray());

            return stringFormatada;
        }
    }
}

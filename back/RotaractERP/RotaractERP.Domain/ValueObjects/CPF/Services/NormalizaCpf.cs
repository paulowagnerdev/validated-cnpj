using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.ValueObjects.CPF.Services
{
    internal class NormalizaCpf
    {
        public static string Normalizar(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;

            var stringFormatada = new string(cpf
                .Where(char.IsLetterOrDigit)
                .ToArray());

            return stringFormatada;
        }
    }
}

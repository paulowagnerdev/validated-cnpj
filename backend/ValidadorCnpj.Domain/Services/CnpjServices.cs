
using ValidadorCnpj.Application.Models;
using ValidadorCnpj.Application.Services.Interfaces;
using ValidadorCnpj.Application.Validators;

namespace ValidadorCnpj.Application.Services
{
    public class CnpjServices : ICnpjServices
    {
        public CnpjResult Valida(string cnpj)
        {
            return ValidaCnpj.IsValido(cnpj);
        }

        public string Formata(string cnpj)
        {
            return FormataCnpj.Formatar(cnpj);
        }

        public string Normaliza(string cnpj)
        {
            return NormalizaCnpj.Normalizar(cnpj);
        }
    }
}

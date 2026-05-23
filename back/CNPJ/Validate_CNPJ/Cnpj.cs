using Validate_CNPJ.Services;

namespace Validate_CNPJ;

static public class Cnpj
{
    public static bool Valida(string cnpj)
    {
        return ValidaCnpj.IsValido(cnpj);
    }
    
    public static string Formata(string cnpj)
    {
        return FormataCnpj.Formatar(cnpj);
    }
    
    public static string Normaliza(string cnpj)
    {
        return NormalizaCnpj.Normalizar(cnpj);
    }
}
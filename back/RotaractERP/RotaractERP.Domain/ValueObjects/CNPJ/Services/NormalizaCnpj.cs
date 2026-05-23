namespace RotaractERP.Domain.ValueObjects.CNPJ.Services;

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
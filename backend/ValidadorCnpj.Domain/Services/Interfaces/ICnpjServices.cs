using ValidadorCnpj.Application.Models;

namespace ValidadorCnpj.Application.Services.Interfaces
{
    public interface ICnpjServices
    {
        CnpjResult Valida(string cnpj);

        string Formata(string cnpj);

        string Normaliza(string cnpj);

    }
}

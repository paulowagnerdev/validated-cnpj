using RotaractERP.Domain.Entities.Interfaces;
using RotaractERP.Domain.ValueObjects.CNPJ.Services;

namespace RotaractERP.Domain.ValueObjects.CNPJ
{
    public class Cnpj : IDocumento
    {
        public string Numero { get; }
        public string Formatado => FormataCnpj.Formatar(Numero);
        public Cnpj(string numero)
        {
            if (!IsValido(numero))
                //throw new DomainException("CNPJ inválido");

            Numero = Normaliza(numero);
        }

        protected Cnpj() { }

        private bool IsValido(string cnpj)
        {
            return ValidaCnpj.IsValido(cnpj);
        }

        public string Normaliza(string cnpj)
        {
            return NormalizaCnpj.Normalizar(cnpj);
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}

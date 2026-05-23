using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.ValueObjects.Telefone
{
    public class Telefone
    {
        public string Numero { get; }

        protected Telefone() { }
        public Telefone(string numero)
        {
            numero = Limpar(numero);

            if (numero.Length < 10 || numero.Length > 11)
                //throw new DomainException("Telefone inválido");

            Numero = numero;
        }

        private string Limpar(string telefone)
        {
            return telefone
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace(" ", "");
        }

        public override string ToString() => Numero;
    }
}

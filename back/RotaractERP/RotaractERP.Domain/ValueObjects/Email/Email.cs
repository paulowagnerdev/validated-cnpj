using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.ValueObjects.Email
{
    public class Email
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco) || !endereco.Contains("@"))
                //throw new DomainException("Email inválido");

            Endereco = endereco.ToLower();
        }
        protected Email() { }

        public override string ToString() => Endereco;
    }
}

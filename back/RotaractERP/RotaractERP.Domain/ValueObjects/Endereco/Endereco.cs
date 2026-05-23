using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.ValueObjects.Endereco
{
    public class Endereco
    {
        public string Rua { get; }
        public string Numero { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Cep { get; }
        public string? Complemento { get; }

        protected Endereco() { }
        public Endereco(
            string rua,
            string numero,
            string bairro,
            string cidade,
            string estado,
            string cep,
            string? complemento = null)
        {
            if (string.IsNullOrWhiteSpace(rua))
               // throw new DomainException("Rua é obrigatória");

            if (string.IsNullOrWhiteSpace(numero))
               // throw new DomainException("Número é obrigatório");

            if (string.IsNullOrWhiteSpace(cidade))
              //  throw new DomainException("Cidade é obrigatória");

            if (string.IsNullOrWhiteSpace(estado))
               // throw new DomainException("Estado é obrigatório");

            if (string.IsNullOrWhiteSpace(cep))
              //  throw new DomainException("CEP é obrigatório");

            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = LimparCep(cep);
            Complemento = complemento;
        }

        private string LimparCep(string cep)
        {
            return cep.Replace("-", "").Trim();
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero} - {Bairro}, {Cidade}/{Estado}";
        }
    }
}

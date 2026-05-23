using RotaractERP.Domain.ValueObjects.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaractERP.Domain.Entities
{
    public class PessoaFisica : Pessoa
    {
        public Cpf Cpf { get; private set; }

        protected PessoaFisica() { }

        public PessoaFisica(
            string nome,
            int tipoPessoaId,
            Cpf cpf)
            : base(nome, tipoPessoaId)
        {
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
        }

       
    }
}

using RotaractERP.Domain.ValueObjects.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaractERP.Domain.Entities
{
    public class PessoaJuridica : Pessoa
    {
        public Cnpj Cnpj { get; private set; }

        protected PessoaJuridica() { }

        public PessoaJuridica(
            string nome,
            int tipoPessoaId,
            Cnpj cnpj)
            : base(nome, tipoPessoaId)
        {
            Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
        }


    }
}

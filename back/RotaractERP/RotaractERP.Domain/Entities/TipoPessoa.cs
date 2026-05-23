using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.Entities
{
    public class TipoPessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public bool IsAtivo { get; private set; }

        public TipoPessoa(string nome) 
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio!");

            Nome = nome;
            IsAtivo = true;
        }
        public void AtualizarDescricao(string descricao)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Tipo de Pessoa inativo não pode ser alterado");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição não pode ser vazia");

            Descricao = descricao;
        }
        public void Desativar()
        {
            IsAtivo = false;
        }

        public void Ativar()
        {
            IsAtivo = true;
        }
          
    }
}

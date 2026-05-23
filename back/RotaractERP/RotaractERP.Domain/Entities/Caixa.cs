using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.Entities
{
    public class Caixa
    {
        public int Id { get; private set; }
        public int ClubeId { get; private set; }
        public Clube Clube { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public bool IsAtivo { get; private set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
        public Caixa(int clubeId, string nome)
        {
            if (clubeId <= 0)
                throw new ArgumentException("ClubeId deve ser informado!", nameof(clubeId));

            ClubeId = clubeId;

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do caixa é obrigatório", nameof(nome));

            IsAtivo = true;
        }
        protected Caixa() { }
        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do caixa é obrigatório", nameof(nome));

            Nome = nome;
        }
        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}

using RotaractERP.Domain.Enums;

namespace RotaractERP.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public int ClubeId { get; private set; }
        public Clube Clube { get; private set; }
        public string Nome { get; private set; }
        public TipoMovimentacao Tipo { get; private set; }
        public bool IsAtivo { get; private set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
        public Categoria(string nome, TipoMovimentacao tipo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório", nameof(nome));

            Nome = nome;
            Tipo = tipo;
            IsAtivo = true;
        }

        public void Desativar()
        {
            IsAtivo = false;
        }
    }
}

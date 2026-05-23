using RotaractERP.Domain.Enums;

namespace RotaractERP.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; private set; }
        public Caixa Caixa { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public Categoria Categoria { get; private set; }
        public Voluntario Voluntario { get; private set; }
        public TipoMovimentacao Tipo { get; private set; }
        public DateTime Data { get; private set; }
        public StatusLancamento Status { get; private set; }
        public decimal Valor { get; private set; }
        public string? Descricao { get; private set; }
        public string? Observacoes { get; private set; }
        public int PessoaId { get; private set; }
        public int CaixaId { get; private set; }
        public int CategoriaId { get; private set; }
        public int VoluntarioId { get; private set; }

        protected Lancamento() { }

        public Lancamento(
            int caixaId,
            int pessoaId,
            int categoriaId,
            int voluntarioId,
            TipoMovimentacao tipo,
            decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero");

            CaixaId = caixaId;
            PessoaId = pessoaId;
            CategoriaId = categoriaId;
            VoluntarioId = voluntarioId;

            Tipo = tipo;
            Valor = valor;
            Data = DateTime.UtcNow;
            Status = StatusLancamento.Confirmado;
        }

        public void AtualizarDescricao(string descricao)
        {
            ValidarAlteracao();

            Descricao = descricao;
        }

        public void AtualizarObservacoes(string observacoes)
        {
            ValidarAlteracao();

            Observacoes = observacoes;
        }
        public void AlterarCategoria(Categoria categoria)
        {
            ValidarAlteracao();

            if (categoria is null)
                throw new ArgumentNullException(nameof(categoria));

            if (categoria.Tipo != Tipo)
                throw new ArgumentException("Categoria incompatível com o tipo de movimentação");

            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void Cancelar()
        {
            if (Status == StatusLancamento.Cancelado)
                throw new InvalidOperationException("Lançamento já está cancelado");

            Status = StatusLancamento.Cancelado;
        }

        private void ValidarAlteracao()
        {
            if (Status == StatusLancamento.Cancelado)
                throw new InvalidOperationException("Lançamento cancelado não pode ser alterado");
        }
    }
}

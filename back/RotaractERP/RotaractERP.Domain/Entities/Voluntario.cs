using RotaractERP.Domain.Enums; 

namespace RotaractERP.Domain.Entities
{
    public class Voluntario
    {
        public int Id { get; private set; }
        public int ClubeId { get; private set; }
        public Clube Clube { get; private set; }
        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public TipoVoluntario Tipo { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public bool IsAtivo { get; private set; }
        public string? Observacoes { get; private set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
        public Voluntario(int pessoaId, int clubeId, DateTime dataEntrada)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pessoaId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(clubeId);
            
            PessoaId = pessoaId;
            ClubeId = clubeId;

            if (dataEntrada == default)
                throw new ArgumentException("Data de entrada inválida", nameof(dataEntrada));

            DataEntrada = dataEntrada;
            IsAtivo = true;
        }
        public void AlterarTipo(TipoVoluntario novoTipo)
        {
            Tipo = novoTipo;
        }

        public void Desativar()
        {
            IsAtivo = false;
        }

        public void DefinirObservacoes(string observacoes)
        {
            Observacoes = observacoes;
        }
    }
}

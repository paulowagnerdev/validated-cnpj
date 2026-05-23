using RotaractERP.Domain.Entities.Interfaces;
using RotaractERP.Domain.ValueObjects.Email;
using RotaractERP.Domain.ValueObjects.Endereco;
using RotaractERP.Domain.ValueObjects.Telefone;

namespace RotaractERP.Domain.Entities
{
    public abstract class Pessoa
    {
        public int Id { get; protected set; }
        public TipoPessoa TipoPessoa { get; protected set; }
        public int TipoPessoaId { get; protected set; }
        public string Nome { get; protected set; }
        public Email? Email { get; protected set; }
        public Telefone? Telefone { get; protected set; }
        public Endereco? Endereco { get; protected set; }
        public bool IsAtivo { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public ICollection<Lancamento> Lancamentos { get; protected set; } = new List<Lancamento>();

        protected Pessoa() { }
        public Pessoa(string nome, int tipoPessoaId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("É necessário informar o nome!");

            if (tipoPessoaId <= 0)
                throw new ArgumentException("Tipo pessoa não informado");

            Nome = nome;
            TipoPessoaId = tipoPessoaId;
            IsAtivo = true;
            DataCadastro = DateTime.UtcNow;
        }
        public void AtualizarNome(string nome)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Pessoa inativa não pode ser alterada!");

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido", nameof(nome));

            Nome = nome;
        }
        public void AtualizarEmail(Email email)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Pessoa inativa não pode ser alterada!");

            Email = email ?? throw new ArgumentNullException(nameof(email));

        }

        public void AtualizarTelefone(Telefone telefone)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Pessoa inativa não pode ser alterada!");

            Telefone = telefone;
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Pessoa inativa não pode ser alterada!");

            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        }

        public void AlterarTipoPessoa(TipoPessoa tipoPessoa)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Pessoa inativa não pode ser alterada!");

            TipoPessoa = tipoPessoa ?? throw new ArgumentNullException(nameof(tipoPessoa));
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

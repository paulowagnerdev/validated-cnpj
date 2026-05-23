using RotaractERP.Domain.ValueObjects.CNPJ;
using RotaractERP.Domain.ValueObjects.Email;
using RotaractERP.Domain.ValueObjects.Telefone;

namespace RotaractERP.Domain.Entities
{
    public class Clube
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Email? Email { get; private set; }
        public Telefone? Telefone { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ICollection<Voluntario> Voluntarios { get; set; }
        public ICollection<Caixa> Caixas { get; set; }

        public Clube(string nome, Cnpj cnpj, Email email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            IsAtivo = true;
            DataCadastro = DateTime.UtcNow;
        }
        protected Clube() { }

        public void AtualizarContato(Email email, Telefone telefone)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Clube inativo não pode ser alterado");

            Email = email ?? throw new ArgumentNullException(nameof(email));
            Telefone = telefone;
        }
        public void AtualizarDescricao(string descricao)
        {
            if (!IsAtivo)
                throw new InvalidOperationException("Clube inativo não pode ser alterado");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição não pode ser vazia");

            Descricao = descricao;
        }




    }
}

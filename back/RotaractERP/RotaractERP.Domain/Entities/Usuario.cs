using RotaractERP.Domain.ValueObjects.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public int VoluntarioId { get; private set; }
        public Voluntario Voluntario { get; private set; }
        public Email? Email { get; private set; }
        public string Login { get; private set; }
        public string SenhaHash { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }


        public Usuario(string login,int voluntarioId, string senhaHash)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(voluntarioId);

            VoluntarioId = voluntarioId;

            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Senha inválida", nameof(login));

            if (string.IsNullOrWhiteSpace(senhaHash))
                throw new ArgumentException("Senha inválida", nameof(senhaHash));

            Login = login;
            SenhaHash = senhaHash;
            IsAtivo = true;
            DataCadastro = DateTime.UtcNow;
        }
        public void AlterarLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Senha inválida", nameof(login));

            Login = login;
        }
        public void AlterarSenha(string novaSenhaHash)
        {
            if (string.IsNullOrWhiteSpace(novaSenhaHash))
                throw new ArgumentException("Senha inválida", nameof(novaSenhaHash));

            SenhaHash = novaSenhaHash;
        }

        public void AtualizarEmail(Email email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public void Desativar()
        {
            IsAtivo = false;
        }
    }
}

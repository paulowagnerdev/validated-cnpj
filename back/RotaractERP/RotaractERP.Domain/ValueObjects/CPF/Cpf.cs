using RotaractERP.Domain.Entities.Interfaces;
using RotaractERP.Domain.ValueObjects.CPF.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotaractERP.Domain.ValueObjects.CPF
{
    public class Cpf : IDocumento
    {
        public string Numero { get; set; }
        protected Cpf() { }
        public Cpf(string cpf)
        {
            if (!IsValido(cpf))
            {
                throw new ArgumentException("Cpf é invalido!");
            }

            Numero = Normaliza(cpf);
        }
        private bool IsValido(string cpf)
        {
            return true;
        }
        public static string Normaliza(string cpf)
        {
            return NormalizaCpf.Normalizar(cpf);
        }

    }
}

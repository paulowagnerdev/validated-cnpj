using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCnpj.Application.Models;

namespace ValidadorCnpj.Application.Validators
{
    internal class ValidaCnpj
    {
        internal static CnpjResult IsValido(string cnpj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cnpj))
                    return CnpjResult.Falha("CNPJ Inválido: Valor nulo ou vazio!");
                
                cnpj = cnpj
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "")
                    .ToUpper();

                if (cnpj.Length != 14)
                    return CnpjResult.Falha("CNPJ Inválido: Valor menor de 14 caracteres!");
                
                if (!cnpj.Substring(0, 12).All(char.IsLetterOrDigit))
                    return CnpjResult.Falha("CNPJ Inválido: Valor informado invalido!");

                if (!char.IsDigit(cnpj[12]) || !char.IsDigit(cnpj[13]))
                    return CnpjResult.Falha("CNPJ Inválido: Valor informado invalido!");

                int dv1Calculado = CalcularDv(cnpj.Substring(0, 12), iniciarPesoEm: 2);
                int dv2Calculado = CalcularDv(cnpj.Substring(0, 12) + dv1Calculado, iniciarPesoEm: 2);

                int dv1Informado = cnpj[12] - '0';
                int dv2Informado = cnpj[13] - '0';

                bool result = dv1Calculado == dv1Informado &&
                       dv2Calculado == dv2Informado;

                if (result)
                {
                    return CnpjResult.Sucesso();
                }
                else
                {
                    return CnpjResult.Falha("CNPJ Inválido: Valor informado invalido!");
                }

                int ConverterParaValor(char c)
                {
                    return (int)c - 48;
                }

            }
            catch (ArgumentException argumentException)
            {
                throw argumentException;
            }

        }
        private static int ConverterParaValor(char c)
        {
            return (int)c - 48;
        }

        private static int CalcularDv(string baseCnpj, int iniciarPesoEm)
        {
            int soma = 0;
            int peso = iniciarPesoEm;

            for (int i = baseCnpj.Length - 1; i >= 0; i--)
            {
                int valor = ConverterParaValor(baseCnpj[i]);

                soma += valor * peso;

                peso++;
                if (peso > 9)
                    peso = 2;
            }

            int resto = soma % 11;
            return (resto == 0 || resto == 1) ? 0 : 11 - resto;
        }

    }
}

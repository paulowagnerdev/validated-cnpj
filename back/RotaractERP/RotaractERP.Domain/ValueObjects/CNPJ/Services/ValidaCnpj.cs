namespace RotaractERP.Domain.ValueObjects.CNPJ.Services;

internal class ValidaCnpj
    {
        internal static bool IsValido(string cnpj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cnpj))
                    throw new Exception("CNPJ INVALIDO!");

                cnpj = cnpj
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "")
                    .ToUpper();

                if (cnpj.Length != 14)
                    throw new Exception("CNPJ INVALIDO!");

                if (!cnpj.Substring(0, 12).All(char.IsLetterOrDigit))
                    throw new Exception("CNPJ INVALIDO!");

                if (!char.IsDigit(cnpj[12]) || !char.IsDigit(cnpj[13]))
                    throw new Exception("CNPJ INVALIDO!");

                int dv1Calculado = CalcularDv(cnpj.Substring(0, 12), iniciarPesoEm: 2);
                int dv2Calculado = CalcularDv(cnpj.Substring(0, 12) + dv1Calculado, iniciarPesoEm: 2);

                int dv1Informado = cnpj[12] - '0';
                int dv2Informado = cnpj[13] - '0';

                bool result = dv1Calculado == dv1Informado &&
                       dv2Calculado == dv2Informado;

                if (result)
                {
                    return true;
                }
                else
                {
                    throw new Exception("CNPJ INVALIDO!");
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
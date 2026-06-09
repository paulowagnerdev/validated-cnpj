namespace ValidadorCnpj.Application.Models
{
    public class CnpjResult
    {
        public bool IsValido { get; private set; }
        public string Mensagem { get; private set; }

        private CnpjResult(bool isValido, string mensagem)
        {
            IsValido = isValido;
            Mensagem = mensagem;
        }

        public static CnpjResult Sucesso()
        {
            return new CnpjResult(true, "Cnpj Válido");
        }

        public static CnpjResult Falha(string mensagem)
        {
            return new CnpjResult(false, mensagem);
        }
    }
}

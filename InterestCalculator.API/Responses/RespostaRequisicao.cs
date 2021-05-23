namespace InterestCalculator.API.Responses
{
    public class RespostaRequisicao
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public decimal? ValorFinal { get; set; }

        public RespostaRequisicao() { }

        public RespostaRequisicao(bool sucesso, string mensagem, decimal? valorFinal)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            ValorFinal = valorFinal;
        }
    }
}
namespace api_bot.models
{
    public class FaturaResponse
    {
        public bool Sucesso { get; set; }
        public bool BoletosEncontrado { get; set; }
        public string Mensagem { get; set; }
        public FaturaDto fatura { get; set; } 
    }
}
namespace api_bot.models
{
    public class CcrResponde
    {
        public bool Sucesso { get; set; }
        public bool BoletosEncontrado { get; set; }
        public string Mensagem { get; set; }
        public CcrDto ccr { get; set; } 
    }
}
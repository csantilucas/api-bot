namespace api_bot.models
{
    public class ContratoResponse
    {
        public bool Sucesso { get; set; }
        public bool ContratoEncontrado { get; set; }
        public string Mensagem { get; set; }
        public List<ContratoDto> Contratos { get; set; } 
    }
}
namespace api_bot.models
{
    public class CcrResponde
    {
        public bool Sucesso { get; set; }
        public bool CcrEncontrado { get; set; }
        public string Mensagem { get; set; }
        public List<CcrDto> ccr { get; set; } 
    }
}
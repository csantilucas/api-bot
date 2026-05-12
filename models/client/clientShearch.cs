namespace api_bot.models
{
    public class BuscaRequest
    {
        public string Documento { get; set; }
    }

}

namespace api_bot.models
{
    public class ClienteResponse
    {
        public bool Sucesso { get; set; }
        public bool ClienteEncontrado { get; set; }
        public string Mensagem { get; set; }
        public ClientDto Client { get; set; } 
    }
}
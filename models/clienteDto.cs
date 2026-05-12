namespace api_bot.models
{
    public class ClientDto
    {
        public int idCliente { get; set; }
        public string nomeResponsavel { get; set; }
        public string empresa { get; set; }
        public string cidade { get; set; }
        public string bloqueado { get; set; }
        public string Inativo { get; set; }
        public string cpfresponsavel { get; set; }
        public string email { get; set; }
    }
}
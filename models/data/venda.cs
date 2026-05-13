namespace api_bot.models.data
{
    public class ClientDebt
{
    public int NUMBER { get; set; }
    public DateTime DATA_ABERTURA { get; set; }
    public DateTime DATA_FECHAMENTO { get; set; }
    public decimal VALOR { get; set; }
    
    public int ID_CLIENTE { get; set; }
}
}
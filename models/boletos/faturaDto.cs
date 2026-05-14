namespace api_bot.models
{
   public class FaturaDto
        {
            public int id_boleto{get;set;}
            public int num_bol {get;set;}
            public DateTime dt_fechamento { get; set; }
            public decimal vlr_bol { get; set; }
            public string linha_dgt {get;set;}
        }

    public class FaturaDbtDto
    {

            public int id_boleto{get;set;}
            public int num_bol {get;set;}            
            public DateTime dt_fechamento { get; set; }
            public decimal vlr_bol { get; set; }
            public string linha_dgt {get;set;}
            public int boleto_pago{get;set;}

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api_bot.models
{   
    [Table("boleto_gerado")]
    public class Fatura
    {   
        [Key]
        public string ID_BOLETO_GERADO { get; set; }
        public int ID_CLIENTE { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }
        public string DT_EMISSAO { get; set; }
        public int VALOR_BOLETO { get; set; }
        public string LINHA_DIGITAVEL {get;set;}
        public int id_receber {get;set;}
        public int boleto_pago {get;set;}
        public int pedido_baixa {get;set;}
        
                
    }

    
}


//where id_receber>0 and boleto_pago=0 and pedido_baixa=0

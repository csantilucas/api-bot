using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_bot.models
{   
    [Table("boleto_gerado")]
    public class Client
    {   
        [Key]
        public string ID_BOLETO_GERADO { get; set; }
        public int ID_CLIENTE { get; set; }
        public string DT_VENCIMENTO { get; set; }
        public string DT_EMISSAO { get; set; }
        public int VALOR_BOLETO { get; set; }
        public int LINHA_DIGITAVEL {get;set;}
        
                
    }

    
}


//where id_receber>0 and boleto_pago=0 and pedido_baixa=0

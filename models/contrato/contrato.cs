using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api_bot.models

{
    [Table("ALPHA_SETOR_CONTRATOS")]
    
    public class Contrato
    {
        [Key]
        public int ID_SETOR_CONTRATO {get;set;}
        public int ID_CLIENTE{ get;set;}
        public int NUMERO_CONTRATO {get;set;}
        public DateTime DATA_VALIDADE {get;set;}
        
        [ForeignKey("ID_CLIENTE")]
        public virtual Client Cliente { get; set; }
        
        
    }
}
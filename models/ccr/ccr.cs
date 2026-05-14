using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api_bot.models

{
    [Table("UPAG_SIAPE")]
    
    public class Ccr
    {
        [Key]
        public int ID_UPAG {get;set;}
        public int ID_CLIENTE{ get;set;}
        public int COLETA_CCR_GUIDE {get;set;}
        public string DATA_COLETA {get;set;}
        public string quantidade {get;set;}
        
    }
}
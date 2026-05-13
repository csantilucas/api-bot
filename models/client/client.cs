using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_bot.models
{   
    [Table("PESSOA")]
    public class Client
    {   
        [Key]
        public int ID_CLIENTE { get; set; }
        public string NM_CONTATO { get; set; }
        public string NOME { get; set; }
        public string CIDADE { get; set; }
        public string BLOQUEA { get; set; }
        public string INATIVO { get; set; }
        public string CPF_CONTATO { get; set; }
        public string EMAIL { get; set; }
        public sbyte COLETA_GUIDE{ get;set;}
       [JsonIgnore] 
        public string CPF { get; set; }
        
    }

    
}


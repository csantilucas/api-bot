using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bot.models
{
    [Table("MOVIM")] // Agora o erro de 'Table' some
    public class Movim
    {
        [Key] // Agora o erro de 'Key' some
        public int ID_LAN { get; set; }
        public int NUMBER {get; set;}
        public DateTime DT_ENTREGA { get; set; }
        public string HORA_ABRIU { get; set; }
        public decimal TOTAL { get; set; }
        public decimal RECEBIDO { get; set; }
        public decimal VR_CREDITO { get; set; }
        public decimal VR_DEVOLUCAO { get; set; }
        public int ID_CLIENTE { get; set; }
        public int APLICACAO { get; set; }
        public int CANCELADA { get; set; }
        public int TIPOMOV { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Chats")]
    public class ChatModel
    {
        [Key]
        public int chatId { get; set; }

        public int equipeId { get; set; }
        [ForeignKey("equipeId")]
        public EquipeModel equipe { get; set; }

        public int amizadeId { get; set; }
        [ForeignKey("amizadeId")]
        public AmizadeModel amizade { get; set; }

        public string historico { get; set; }

        public DateTime dataChat { get; set; }
    }
}



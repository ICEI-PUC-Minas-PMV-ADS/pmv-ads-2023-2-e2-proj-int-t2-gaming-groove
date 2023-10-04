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
        [Display(Name = "Equipe")]
        public EquipeModel? equipe { get; set; }

        public int amizadeId { get; set; }
        [ForeignKey("amizadeId")]
        [Display(Name = "Amizade")]
        public AmizadeModel? amizade { get; set; }

        [Display(Name = "Histórico")]
        public string? historico { get; set; }

        [Display(Name = "Data")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataChat { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class ChatModel
    {
        [Key]
        public int chatID { get; set; }

        public EquipeModel equipe { get; set; }

        public AmizadeModel amizade { get; set; }

        public string historico { get; set; }

        public DateTime dataChat { get; set; }
    }
}



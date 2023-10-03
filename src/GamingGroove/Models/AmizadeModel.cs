using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Amizades")]
    public class AmizadeModel
    {
        [Key]
        public int amizadeId { get; set; }

        public int solicitanteId { get; set; }
        [ForeignKey("solicitanteId")]
        public UsuarioModel solicitante { get; set; }

        public int receptorId { get; set; }
        [ForeignKey("receptorId")]
        public UsuarioModel receptor { get; set; }

        public string estadoAmizade { get; set; }

        public DateTime dataAmizade { get; set; }


        public ICollection<ChatModel> chatAmizade { get; set; }
    }
}

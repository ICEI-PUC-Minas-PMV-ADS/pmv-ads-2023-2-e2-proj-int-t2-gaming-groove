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
        [Display(Name = "Solicitante")]
        public UsuarioModel? solicitante { get; set; }

        public int receptorId { get; set; }
        [ForeignKey("receptorId")]
        [Display(Name = "Receptor")]
        public UsuarioModel? receptor { get; set; }

        [Display(Name = "Estado da Amizade")]
        public EstadoAmizade? estadoAmizade { get; set; }

        [Display(Name = "Início da Amizade")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataAmizade { get; set; }


        public ICollection<ChatModel>? chatAmizade { get; set; }
    }

}

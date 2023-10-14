using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("UsuarioComunidade")]
    public class UsuarioComunidadeModel
    {
        [Key]
        public int usuarioComunidadeId { get; set; }

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        [Display(Name = "Usuário")]
        public UsuarioModel usuario { get; set; }

        public int comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        [Display(Name = "Comunidade")]
        public ComunidadeModel comunidade { get; set; }

        [Display(Name = "Cargo")]
        public CargosEnum cargo { get; set; }

        [Display(Name = "Data de Vínculo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataVinculoComunidade { get; set; }
    }
}


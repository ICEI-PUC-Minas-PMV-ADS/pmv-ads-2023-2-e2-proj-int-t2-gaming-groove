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
        public UsuarioModel usuario { get; set; }

        public int comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        public ComunidadeModel comunidade { get; set; }

        public CargoComunidade cargo { get; set; }

        public DateTime dataVinculoComunidade { get; set; }
    }

    public enum CargoComunidade {
        ADM,
        Membro
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Curtidas")]
    public class CurtidaModel
    {
        [Key]
        public int curtidaId { get; set; }

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public UsuarioModel usuario { get; set; }

        public int publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        public PublicacaoModel publicacao { get; set; }

        public DateTime dataCurtida { get; set; }
    }
}


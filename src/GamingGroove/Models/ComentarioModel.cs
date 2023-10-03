using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Comentarios")]
    public class ComentarioModel
    {
        [Key]
        public int comentarioId { get; set; }

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public UsuarioModel usuario { get; set; }

        public int publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        public PublicacaoModel publicacao { get; set; }

        public string textoComentario { get; set; }

        public byte[] midiaComentario { get; set; }

        public DateTime dataComentario { get; set; }
    }
}


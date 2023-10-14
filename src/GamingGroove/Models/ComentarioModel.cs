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
        [Display(Name = "Usuário")]
         public UsuarioModel? usuario { get; set; }

        [Display(Name = "Publicação")]
        public int publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        [Display(Name = "Publicação")]
        public PublicacaoModel? publicacao { get; set; }

        [Display(Name = "Conteúdo de Texto")]
        public string textoComentario { get; set; }

        [Display(Name = "Conteúdo de Mídia")]
        public byte[]? midiaComentario { get; set; }

        [Display(Name = "Data do Comentário")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataComentario { get; set; }
    }
}


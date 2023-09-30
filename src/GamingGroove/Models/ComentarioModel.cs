using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class ComentarioModel
    {
        [Key]
        public int comentarioID { get; set; }

        public UsuarioModel usuario { get; set; }

        public PublicacaoModel publicacao { get; set; }

        public string textoComentario { get; set; }

        public byte[] midiaComentario { get; set; }

        public DateTime dataComentario { get; set; }
    }
}


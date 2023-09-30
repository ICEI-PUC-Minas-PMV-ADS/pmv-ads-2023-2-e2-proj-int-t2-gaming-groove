using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class PublicacaoModel
    {
        [Key]
        public int publicacaoID { get; set; }

        public UsuarioModel usuario { get; set; }

        public ComunidadeModel comunidade { get; set; }

        public string? textoPublicacao { get; set; }

        public byte[]? midiaPublicacao { get; set; }

        public DateTime dataPublicacao { get; set; }
    }
}



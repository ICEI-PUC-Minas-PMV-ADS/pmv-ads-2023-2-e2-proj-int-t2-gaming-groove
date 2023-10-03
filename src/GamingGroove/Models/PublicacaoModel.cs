using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Publicacoes")]
    public class PublicacaoModel
    {
        [Key]
        public int publicacaoId { get; set; }

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public UsuarioModel usuario { get; set; }

        public int comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        public ComunidadeModel comunidade { get; set; }

        public string? textoPublicacao { get; set; }

        public byte[]? midiaPublicacao { get; set; }

        public DateTime dataPublicacao { get; set; }


        public ICollection<ComentarioModel> publicacaoComentario { get; set; }

        public ICollection<CurtidaModel> publicacaoCurtida { get; set; }

        public ICollection<DenunciaModel> publicacaoDenuncia { get; set; }
    }
}



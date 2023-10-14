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
        [Display(Name = "Usuário")]
        public UsuarioModel? usuario { get; set; }

        public int comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        [Display(Name = "Comunidade")]
        public ComunidadeModel? comunidade { get; set; }

        [Display(Name = "Conteúdo de Texto")]
        public string? textoPublicacao { get; set; }

        [Display(Name = "Conteúdo de Mídia")]
        public byte[]? midiaPublicacao { get; set; }

        [Display(Name = "Data da Publicação")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataPublicacao { get; set; }


        public ICollection<ComentarioModel>? publicacaoComentario { get; set; }

        public ICollection<CurtidaModel>? publicacaoCurtida { get; set; }

        public ICollection<DenunciaModel>? publicacaoDenuncia { get; set; }
    }
}



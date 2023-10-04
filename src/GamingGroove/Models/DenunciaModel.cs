using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Denuncias")]
    public class DenunciaModel
    {
        [Key]
        public int denunciaId { get; set; }

        public int denuncianteId { get; set; }
        [ForeignKey("denuncianteId")]
        [Display(Name = "Denunciante")]
        public UsuarioModel denunciante { get; set; }

        public int? denunciadoId { get; set; }
        [ForeignKey("denunciadoId")]
        [Display(Name = "Denunciado")]
        public UsuarioModel? denunciado { get; set; }

        public int? publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        [Display(Name = "Publicação")]
        public PublicacaoModel? publicacao { get; set; }

        public int? comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        [Display(Name = "Comunidade")]
        public ComunidadeModel? comunidade { get; set; }

        [Display(Name = "Descrição")]
        public string descricaoDenuncia { get; set; }

        [Display(Name = "Tipo de Denúncia")]
        public TiposDenuncia? TipoDenuncia { get; set; }

        [Display(Name = "Situação")]
        public SituacaoDenuncia? situacaoDenuncia { get; set; }

        [Display(Name = "Data da Denúncia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataDenuncia { get; set; }  
    }
}



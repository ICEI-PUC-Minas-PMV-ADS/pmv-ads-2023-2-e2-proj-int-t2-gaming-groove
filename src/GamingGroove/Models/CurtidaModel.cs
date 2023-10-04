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
        [Display(Name = "Usuário")]
        public UsuarioModel? usuario { get; set; }

        public int publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        [Display(Name = "Publicação")]
        public PublicacaoModel? publicacao { get; set; }

        [Display(Name = "Data da Curtida")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataCurtida { get; set; }  
    }
}


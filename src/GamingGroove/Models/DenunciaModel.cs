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
        public UsuarioModel denunciante { get; set; }

        public int denunciadoId { get; set; }
        [ForeignKey("denunciadoId")]
        public UsuarioModel denunciado { get; set; }

        public int publicacaoId { get; set; }
        [ForeignKey("publicacaoId")]
        public PublicacaoModel publicacao { get; set; }

        public int comunidadeId { get; set; }
        [ForeignKey("comunidadeId")]
        public ComunidadeModel comunidade { get; set; }

        public string descricaoDenuncia { get; set; }

        public string situacaoDenuncia { get; set; }

        public DateTime dataDenuncia { get; set; }
    }
}



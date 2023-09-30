using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class CurtidaModel
    {
        [Key]
        public int curtidaID { get; set; }

        public UsuarioModel usuario { get; set; }

        public PublicacaoModel publicacao { get; set; }

        public DateTime dataCurtida { get; set; }
    }
}


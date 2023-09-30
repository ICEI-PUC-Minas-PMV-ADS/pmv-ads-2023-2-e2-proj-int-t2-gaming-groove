using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class DenunciaModel
    {
        [Key]
        public int denunciaID { get; set; }

        public UsuarioModel denunciante_ { get; set; }

        public UsuarioModel denunciado_ { get; set; }

        public PublicacaoModel publicacao { get; set; }

        public ComunidadeModel comunidade { get; set; }

        public string descricaoDenuncia { get; set; }

        public string situacaoDenuncia { get; set; }

        public DateTime dataDenuncia { get; set; }
    }
}



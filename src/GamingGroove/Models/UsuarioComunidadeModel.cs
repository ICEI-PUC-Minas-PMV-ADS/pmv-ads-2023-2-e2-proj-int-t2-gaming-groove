using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class UsuarioComunidadeModel
    {
        [Key]
        public int usuarioComunidadeID { get; set; }

        public UsuarioModel usuario { get; set; }

        public ComunidadeModel comunidade { get; set; }

        public string cargo { get; set; }

        public DateTime dataVinculoComunidade { get; set; }
    }
}


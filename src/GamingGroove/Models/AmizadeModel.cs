using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class AmizadeModel
    {
        [Key]
        public int amizadeID { get; set; }

        public UsuarioModel solicitante_ { get; set; }

        public UsuarioModel receptor_ { get; set; }

        public string estadoAmizade { get; set; }

        public DateTime dataAmizade { get; set; }
    }
}

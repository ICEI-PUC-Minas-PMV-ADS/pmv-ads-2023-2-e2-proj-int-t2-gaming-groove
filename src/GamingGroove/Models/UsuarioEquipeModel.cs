using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class UsuarioEquipeModel
    {
        [Key]
        public int usuarioEquipeID { get; set; }

        public UsuarioModel usuario { get; set; }

        public EquipeModel equipe { get; set; }
        
        public string cargoEquipe { get; set; }

        public DateTime dataVinculoEquipe { get; set; }
    }
}


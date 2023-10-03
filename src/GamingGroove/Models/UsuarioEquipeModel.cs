using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("UsuarioEquipe")]
    public class UsuarioEquipeModel
    {
        [Key]
        public int usuarioEquipeId { get; set; }

        public int usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public UsuarioModel usuario { get; set; }

        public int equipeId { get; set; }
        [ForeignKey("equipeId")]
        public EquipeModel equipe { get; set; }
        
        public CargoEquipe cargoEquipe { get; set; }

        public DateTime dataVinculoEquipe { get; set; }
    }

    public enum CargoEquipe {
        ADM,
        Membro
    }
}


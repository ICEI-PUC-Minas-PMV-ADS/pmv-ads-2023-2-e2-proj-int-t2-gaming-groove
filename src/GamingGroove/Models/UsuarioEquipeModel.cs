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
        [Display(Name = "Usuário")]
        public UsuarioModel usuario { get; set; }

        public int equipeId { get; set; }
        [ForeignKey("equipeId")]
        [Display(Name = "Equipe")]
        public EquipeModel equipe { get; set; }
        
        [Display(Name = "Cargo")]
        public CargosEnum cargoEquipe { get; set; }

        [Display(Name = "Data de Vínculo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataVinculoEquipe { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Equipes")]
    public class EquipeModel
    {

        [Key]
        public int equipeId { get; set; }

        [Display(Name = "Nome")]
        public string nomeEquipe { get; set; }

        [Display(Name = "Ícone")]
        public byte[]? iconeEquipe { get; set; }

        [Display(Name = "Descrição")]
        public string? descricaoEquipe { get; set; }

        [Display(Name = "Jogo")]
        public JogosEnum jogoEquipe { get; set; }

        [Display(Name = "Data de Criação")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataCriacaoEquipe { get; set;}

       





        public ICollection<ChatModel>? chatEquipe { get; set; }

        public ICollection<UsuarioEquipeModel>? usuarioEquipe { get; set; }
    }
}


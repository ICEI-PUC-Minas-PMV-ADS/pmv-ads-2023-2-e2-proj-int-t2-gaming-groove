using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Equipes")]
    public class EquipeModel
    {
        [Key]
        public int equipeId { get; set; }

        public string nomeEquipe { get; set; }

        public byte[] iconeEquipe { get; set; }

        public string descricaoEquipe { get; set; }

        public string jogoEquipe { get; set; }

        public DateTime dataCriacaoEquipe { get; set; }

        public ICollection<ChatModel> chatEquipe { get; set; }

        public ICollection<UsuarioEquipeModel> usuarioEquipe { get; set; }

    }
}


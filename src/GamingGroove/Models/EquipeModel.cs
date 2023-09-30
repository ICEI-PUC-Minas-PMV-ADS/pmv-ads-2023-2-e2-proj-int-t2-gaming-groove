using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class EquipeModel
    {
        [Key]
        public int equipeID { get; set; }

        public string nomeEquipe { get; set; }

        public byte[] iconeEquipe { get; set; }

        public string descricaoEquipe { get; set; }

        public string jogoEquipe { get; set; }

        public DateTime dataCriacaoEquipe { get; set; }
    }
}


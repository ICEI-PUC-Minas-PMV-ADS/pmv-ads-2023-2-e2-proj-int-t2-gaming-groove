using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Comunidades")]
    public class ComunidadeModel
    {
        [Key]
        public int comunidadeId { get; set; }

        public string nomeComunidade { get; set; }
        
        public byte[] iconeComunidade { get; set; }

        public byte[] capaComunidade { get; set; }

        public string jogosRelacionados { get; set; }    

        public string descricaoComunidade { get; set; }    

        [DataType(DataType.Date)]
        public DateTime dataCriacaoComunidade { get; set; }    


        public ICollection<DenunciaModel> ComunidadeDenuncia { get; set; }

        public ICollection<PublicacaoModel> ComunidadePublicacao { get; set; }

        public ICollection<UsuarioComunidadeModel> usuarioComunidade { get; set; }
    }
}



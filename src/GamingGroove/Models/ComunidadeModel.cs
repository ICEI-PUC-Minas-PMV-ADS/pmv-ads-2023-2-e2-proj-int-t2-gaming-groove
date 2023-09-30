using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class ComunidadeModel
    {
        [Key]
        public int comunidadeID { get; set; }

        public string nomeComunidade { get; set; }
        
        public byte[] iconeComunidade { get; set; }

        public byte[] capaComunidade { get; set; }

        public string jogosRelacionados { get; set; }    

        public string descricaoComunidade { get; set; }    

        [DataType(DataType.Date)]
        public DateTime dataCriacaoComunidade { get; set; }    
    }
}



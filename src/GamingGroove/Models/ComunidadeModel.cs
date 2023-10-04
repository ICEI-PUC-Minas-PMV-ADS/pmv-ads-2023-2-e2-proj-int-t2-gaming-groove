using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Comunidades")]
    public class ComunidadeModel
    {
        [Key]
        public int comunidadeId { get; set; }

        [Display(Name = "Nome")]
        public string nomeComunidade { get; set; }
        
        [Display(Name = "Ícone")]
        public byte[]? iconeComunidade { get; set; }

        [Display(Name = "Imagem de Capa")]
        public byte[]? capaComunidade { get; set; }

        [Display(Name = "Jogos Relacionados")]
        public JogosEnum? jogosRelacionados { get; set; }    

        [Display(Name = "Descrição")]
        public string? descricaoComunidade { get; set; }    

        [Display(Name = "Data de Criação")]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataCriacaoComunidade { get; set; }  


        public ICollection<DenunciaModel>? ComunidadeDenuncia { get; set; }

        public ICollection<PublicacaoModel>? ComunidadePublicacao { get; set; }

        public ICollection<UsuarioComunidadeModel>? usuarioComunidade { get; set; }
    }
}



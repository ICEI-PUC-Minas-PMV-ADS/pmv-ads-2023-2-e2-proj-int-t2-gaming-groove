using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroove.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int usuarioId { get; set; }

        public string nomeUsuario { get; set; }
        
        public string nomeCompleto { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public byte[]? iconePerfil { get; set; }

        public byte[]? capaPerfil { get; set; }

        public byte[]? fotosGaleria { get; set; }

        public string? jogosFavoritos { get; set; }    

        public string? biografia { get; set; }    

        public DateTime? registrationDate { get; set; }

        public TipoUsuario? tipoUsuario { get; set; } 
        

        public ICollection<AmizadeModel> solicitanteAmizade { get; set; }
        public ICollection<AmizadeModel> receptorAmizade { get; set; }

        public ICollection<ComentarioModel> usuarioComentario { get; set; }

        public ICollection<CurtidaModel> usuarioCurtida { get; set; }

        public ICollection<DenunciaModel> denuncianteDenuncia { get; set; }
        public ICollection<DenunciaModel> denunciadoDenuncia { get; set; }

        public ICollection<PublicacaoModel> usuarioPublicacao { get; set; }

        public ICollection<UsuarioComunidadeModel> usuarioComunidade { get; set; }

        public ICollection<UsuarioEquipeModel> usuarioEquipe { get; set; }
        
    }

     public enum TipoUsuario {
        ADM,
        Usuario
    }
}

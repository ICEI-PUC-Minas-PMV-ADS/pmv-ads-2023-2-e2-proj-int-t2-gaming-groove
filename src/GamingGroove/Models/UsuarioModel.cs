using System.ComponentModel.DataAnnotations;

namespace GamingGroove.Models
{
    public class UsuarioModel
    {
        [Key]
        public int usuarioID { get; set; }

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

        public DateTime RegistrationDate { get; set; }
        
    }
}

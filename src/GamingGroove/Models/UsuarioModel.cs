using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GamingGroove.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "Informe um nome de usuário válido.")]
        [Display(Name = "Nome de Usuário")]
        public string? nomeUsuario { get; set; }
        
        [Required(ErrorMessage = "Informe seu nome completo.")]
        [Display(Name = "Nome Completo")]
        public string? nomeCompleto { get; set; }
        
        [Required(ErrorMessage = "Informe sua data de nascimento.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? dataNascimento { get; set; }

        [Required(ErrorMessage = "Informe um e-mail válido.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Sua senha deve ter entre 6 e 12 caracteres.")]
        [Display(Name = "Senha")]
        public string? senha { get; set; }

        [Display(Name = "Ícone de Perfil")]
        public byte[]? iconePerfil { get; set; }

        [Display(Name = "Imagem de Capa")]
        public byte[]? capaPerfil { get; set; }

        [Display(Name = "Fotos da Galeria")]
        public byte[]? fotosGaleria { get; set; }

        [Display(Name = "Jogos Favoritos")]
        public JogosEnum? primeiroJogo { get; set; }    
        public JogosEnum? segundoJogo { get; set; }
        public JogosEnum? terceiroJogo { get; set; }

        [Display(Name = "Biografia")]
        public string? biografia { get; set; }    

        [Display(Name = "Tipo de Usuário")]
        public CargosEnum? tipoUsuario { get; set; } 

        [Display(Name = "Data de Registro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? dataRegistro { get; set; }


        
        public ICollection<AmizadeModel>? solicitanteAmizade { get; set; }
        public ICollection<AmizadeModel>? receptorAmizade { get; set; }

        public ICollection<ComentarioModel>? usuarioComentario { get; set; }

        public ICollection<CurtidaModel>? usuarioCurtida { get; set; }

        public ICollection<DenunciaModel>? denuncianteDenuncia { get; set; }
        public ICollection<DenunciaModel>? denunciadoDenuncia { get; set; }

        public ICollection<PublicacaoModel>? usuarioPublicacao { get; set; }

        public ICollection<UsuarioComunidadeModel>? usuarioComunidade { get; set; }

        public ICollection<UsuarioEquipeModel>? usuarioEquipe { get; set; }
    }
}

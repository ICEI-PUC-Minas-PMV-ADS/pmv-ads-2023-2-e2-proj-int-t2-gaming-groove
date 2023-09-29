
namespace GamingGroove.Data.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; } // Na prática, você armazenaria hashes de senha, não a senha em si.

        public virtual ICollection<Post>? Posts { get; set; } // Um usuário pode ter muitos posts.
        // Adicione outros atributos necessários, como data de nascimento, foto de perfil, etc.
    }
}

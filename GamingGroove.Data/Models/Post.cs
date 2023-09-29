namespace GamingGroove.Data.Models;

public class Post
{
    public int PostId { get; set; }
    public string? Conteudo { get; set; }
    public DateTime DataDePublicacao { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }  // Cada post pertence a um usuário.
}
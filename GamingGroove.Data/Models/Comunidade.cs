namespace GamingGroove.Data.Models;

public class Comunidade
{
    public int ComunidadeId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public virtual ICollection<Usuario>? Membros { get; set; }  // Uma comunidade pode ter muitos membros.
}
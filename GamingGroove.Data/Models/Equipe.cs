namespace GamingGroove.Data.Models;

public class Equipe
{
    public int EquipeId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int LiderId { get; set; } // O ID do líder da equipe
    public virtual Usuario? Lider { get; set; } // O líder da equipe. Pode ser útil para, por exemplo, só permitir que o líder adicione/remove membros ou altere a descrição.
    public virtual ICollection<Usuario>? Membros { get; set; }  // Uma equipe pode ter muitos membros.
}
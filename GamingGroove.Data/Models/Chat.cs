namespace GamingGroove.Data.Models;

public class Chat
{
    public int ChatId { get; set; }
    public int Usuario1Id { get; set; }
    public virtual Usuario? Usuario1 { get; set; }
    public int Usuario2Id { get; set; }
    public virtual Usuario? Usuario2 { get; set; }
    public virtual ICollection<Mensagem>? Mensagens { get; set; }  // Um chat pode ter muitas mensagens.
}
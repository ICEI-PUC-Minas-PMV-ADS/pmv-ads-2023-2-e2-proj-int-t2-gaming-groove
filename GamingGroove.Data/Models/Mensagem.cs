namespace GamingGroove.Data.Models;

public class Mensagem
{
    public int MensagemId { get; set; }
    public string? Conteudo { get; set; }
    public DateTime DataDeEnvio { get; set; }
    public int ChatId { get; set; }
    public virtual Chat? Chat { get; set; }
}
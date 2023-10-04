using System.ComponentModel.DataAnnotations;

public enum TiposDenuncia {

    [Display(Name = "Linguajar Ofensivo")]
    LinguajarOfensivo,

    [Display(Name = "Discriminação / Discurso de Ódio")]
    Discriminação,

    [Display(Name = "Veiculação de Conteúdo Impróprio")]
    ConteúdoImpróprio,

    [Display(Name = "Nome Inadequado")]
    NomeInadequado
}
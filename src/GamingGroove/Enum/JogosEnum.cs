using System.ComponentModel.DataAnnotations;

public enum JogosEnum 
{
    [Display(Name = "League of Legends")]
    LeagueOfLegends,
    
    Fortnite,

    [Display(Name = "Counter-Strike")]
    CounterStrike,

    Valorant,

    [Display(Name = "Apex Legends")]
    ApexLegends,

    Minecraft,

    [Display(Name = "Overwatch 2")]
    Overwatch2,

    [Display(Name = "Dead by Daylight")]
    DeadByDaylight,
    
    [Display(Name = "Call of Duty: Warzone")]
    CallOfDutyWarzone,
}
using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum EventType
    {
        [Display(Name = "Encontro às cegas", Description = "Conheça pela essência da pessoa, não sua aparência")]
        BlindDate = 1,

        [Display(Name = "Encontro Rápido", Description = "Conheça várias pessoas em encontros rápidos e descubra seu pretendente ideal")]
        SpeedDating = 2,

        [Display(Name = "Encontro em grupo", Description = "Encontro realizado com muitos participantes com interesses parecidos e com livre interação")]
        GroupDate = 3,
    }
}
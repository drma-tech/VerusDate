using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum TravelFrequency
    {
        [Custom(Name = "Never / Rarely", Description = "Não viaja ou viaja com pouca frequência (geralmente nas férias ou em situações específicas)")]
        NeverRarely,

        [Custom(Name = "Sometimes / Frequently", Description = "Viaja com uma certa frequência (entre 30% e 70% do seu tempo), seja por conta do trabalho ou a lazer nos finais de semana")]
        SometimesFrequently,

        [Custom(Name = "Usually / Always / Nomad", Description = "É alguém que está em constante movimento (muitas vezes não tem residência permanente), como uma estrela do rock que passa 365 dias por ano em ônibus de turismo e quartos de hotel ou um nômade digital que trabalha online e tem liberdade geográfica de viver onde quer.")]
        UsuallyAlwaysNomad,
    }
}
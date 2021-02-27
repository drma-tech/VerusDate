using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VerusDate.Shared.Enum
{
    public enum Intent
    {
        [Display(GroupName = "Curto Prazo", Name = "Ficar / Sexo casual", Description = "Pode resumir-se a um encontro de apenas um dia ou uma noite. Este pode implicar somente uma troca de beijos e carícias ou resultar também num envolvimento mais íntimo de carácter sexual, mas que não se prolongará por muito no tempo.")]
        OneNightStand = 11,

        [Display(GroupName = "Curto Prazo", Name = "Amizade colorida", Description = "Pessoa com quem se possui uma relação afetiva e sem compromisso, baseada em relações sexuais e não no compromisso formal, de fidelidade ou com outras características de um relacionamento amoroso.")]
        FriendsWithBenefits = 12,

        [Display(GroupName = "Longo Prazo", Name = "Namoro / Relacionamento sério", Description = "Namoro significa a relação afetiva mantida entre duas pessoas que se unem pelo desejo de estarem juntas e partilharem novas experiências. É uma relação em que o casal está comprometido socialmente, mas sem estabelecer um vínculo matrimonial perante a lei civil ou religiosa.")]
        Relationship = 21,

        [Display(GroupName = "Longo Prazo", Name = "Morar juntos / Casar", Description = "Para quem tem a intenção de casar (vínculo estabelecido entre duas pessoas, mediante o reconhecimento governamental, cultural, religioso ou social) ou morar juntos em um curto/médio período de tempo")]
        Married = 22
    }

    public static class Extension
    {
        public static bool IsShortTerm(this Intent[] intent, bool exclusive = false)
        {
            if (exclusive)
            {
                return intent.Any(a => a == Intent.OneNightStand || a == Intent.FriendsWithBenefits) && !intent.IsLongTerm();
            }
            else
            {
                return intent.Any(a => a == Intent.OneNightStand || a == Intent.FriendsWithBenefits);
            }
        }

        public static bool IsShortTerm(this IReadOnlyList<Intent> intent, bool exclusive = false)
        {
            return intent.ToArray().IsShortTerm(exclusive);
        }

        public static bool IsLongTerm(this Intent[] intent, bool exclusive = false)
        {
            if (exclusive)
            {
                return intent.Any(a => a == Intent.Relationship || a == Intent.Married) && !intent.IsShortTerm();
            }
            else
            {
                return intent.Any(a => a == Intent.Relationship || a == Intent.Married);
            }
        }

        public static bool IsLongTerm(this IReadOnlyList<Intent> intent, bool exclusive = false)
        {
            return intent.ToArray().IsLongTerm(exclusive);
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VerusDate.Shared.Enum
{
    public enum Intent
    {
        // SHORT-TERM

        [Display(Name = "Sexo casual", Description = "quem quer um encontro sexual único, no qual existe a expectativa de que não haja mais relações entre os participantes sexuais")]
        OneNightStand = 11,

        [Display(Name = "Ficar / Amizade colorida", Description = "semelhante a um relacionamento de sexo casual, mas com uma diferença importante: uma amizade platônica estabelecida")]
        FriendsWithBenefits = 12,

        // LONG-TERM

        [Display(Name = "Relacionamento sério", Description = "quem tem a intenção de se envolver (sexual e/ou amorosamente) com alguem a longo prazo")]
        Relationship = 21,

        [Display(Name = "Morar juntos / Casar", Description = "quem tem a intenção de casar ou morar juntos em um curto período de tempo")]
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
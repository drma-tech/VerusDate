using System.Collections.Generic;
using System.Linq;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Intentions
    {
        [Custom(Group = "Casual_Group", Name = "Casual_Name", Description = "Casual_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Casual,

        [Custom(Group = "Serious_Group", Name = "Serious_Name", Description = "Serious_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Serious,

        [Custom(Group = "Married_Group", Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Married
    }

    public enum IntentOld
    {
        [Custom(Group = "OneNightStand_Group", Name = "OneNightStand_Name", Description = "OneNightStand_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        OneNightStand = 11,

        [Custom(Group = "FriendsWithBenefits_Group", Name = "FriendsWithBenefits_Name", Description = "FriendsWithBenefits_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        FriendsWithBenefits = 12,

        [Custom(Group = "Relationship_Group", Name = "Relationship_Name", Description = "Relationship_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Relationship = 21,

        [Custom(Group = "Married_Group", Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Married = 22

        //RELACIONAMENTO CASUAL = Casual dating is a type of relationship between people who go on dates and spend time together in an ongoing way without the expectation of entering into a long-term, committed relationship.
        //RELACIONAMENTO SÉRIO - MONOGÂMICO = Monogamy is a relationship with only one partner at a time, rather than multiple partners. A monogamous relationship can be sexual or emotional, but it’s usually both.
        //RELACIONAMENTO SÉRIO - NÁO MONOGÂMICO = There are no one-size-fits-all rules for doing relationships. It’s about finding out what works for you. For some people this means being monogamous – having only one partner. For others it means being non-monogamous, which means having more than one partner, or having one partner but having sex with other people as well.
        //CASAMENTO / MORAR JUNTOS
    }

    public static class Extension
    {
        public static bool IsShortTerm(this Intentions[] intent, bool exclusive = false)
        {
            if (exclusive)
            {
                return intent.Any(a => a == Intentions.Casual) && !intent.IsLongTerm();
            }
            else
            {
                return intent.Any(a => a == Intentions.Casual);
            }
        }

        public static bool IsShortTerm(this IReadOnlyList<Intentions> intent, bool exclusive = false)
        {
            return intent.ToArray().IsShortTerm(exclusive);
        }

        public static bool IsLongTerm(this Intentions[] intent, bool exclusive = false)
        {
            if (exclusive)
            {
                return intent.Any(a => a == Intentions.Serious || a == Intentions.Married) && !intent.IsShortTerm();
            }
            else
            {
                return intent.Any(a => a == Intentions.Serious || a == Intentions.Married);
            }
        }

        public static bool IsLongTerm(this IReadOnlyList<Intentions> intent, bool exclusive = false)
        {
            return intent.ToArray().IsLongTerm(exclusive);
        }
    }
}
using Newtonsoft.Json;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    public class Badge : ModelBase
    {
        public BadgeType Rank { get; private set; } = new BadgeType(10, "fas fa-crown", "Rank", "Nível alcançado");

        public BadgeType Seniority { get; private set; } = new BadgeType(10, "", "Seniority", "Seniority");

        public BadgeType CompletedProfile { get; private set; } = new BadgeType(1, "", "Completed Profile", "Completed Profile");

        public BadgeType VerifiedProfile { get; private set; } = new BadgeType(3, "fas fa-user-check", "Verified Profile", "Validação de todos os itens da lista de pendências");

        public BadgeType Popular { get; private set; } = new BadgeType(1, "far fa-grin-stars", "Popular", "Tem uma relação de 70% ou mais de likes");

        public override void LoadDefatultData()
        {
            throw new System.NotImplementedException();
        }
    }

    public class BadgeType
    {
        public BadgeType(int MaxLevel, string ClassIcon, string Title, string Description)
        {
            this.MaxLevel = MaxLevel;
            this.ClassIcon = ClassIcon;
            this.Title = Title;
            this.Description = Description;
        }

        public int Level { get; private set; }

        [JsonIgnore]
        public int MaxLevel { get; private set; }

        [JsonIgnore]
        public string ClassIcon { get; private set; }

        [JsonIgnore]
        public string Title { get; private set; }

        [JsonIgnore]
        public string Description { get; private set; }

        public void IncreaseLevel()
        {
            if (Level == MaxLevel) return;

            Level++;
        }

        public void DecreaseLevel()
        {
            if (Level == 0) return;

            Level--;
        }

        public bool Completed() => Level == MaxLevel;
    }
}
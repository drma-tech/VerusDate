using System.Text.Json.Serialization;

namespace VerusDate.Shared.Model.Profile
{
    public class ProfileBadge
    {
        public BadgeType Rank { get; set; } = new BadgeType(10, "fas fa-crown", "Rank", "Nível alcançado");

        public BadgeType Seniority { get; set; } = new BadgeType(10, "", "Seniority", "Seniority");

        public BadgeType CompletedProfile { get; set; } = new BadgeType(1, "", "Completed Profile", "Completed Profile");

        public BadgeType VerifiedProfile { get; set; } = new BadgeType(3, "fas fa-user-check", "Verified Profile", "Validação de todos os itens da lista de pendências");

        public BadgeType Popular { get; set; } = new BadgeType(1, "far fa-grin-stars", "Popular", "Tem uma relação de 70% ou mais de likes");
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

        public int Level { get; set; }

        [JsonIgnore]
        public int MaxLevel { get; set; }

        [JsonIgnore]
        public string ClassIcon { get; set; }

        [JsonIgnore]
        public string Title { get; set; }

        [JsonIgnore]
        public string Description { get; set; }

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
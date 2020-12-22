using VerusDate.Shared.Core;
using VerusDate.Shared.ValueType;

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
}
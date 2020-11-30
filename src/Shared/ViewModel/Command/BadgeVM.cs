using Dapper.Contrib.Extensions;
using VerusDate.Shared.Core;
using VerusDate.Shared.ValueType;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("Badge")]
    public class BadgeVM : ViewModelCommand
    {
        [ExplicitKey]
        public string IdUser { get; set; }

        [Write(false)]
        public BadgeType Rank { get; private set; } = new BadgeType(10, "fas fa-crown", "Rank", "Nível alcançado");

        [Write(false)]
        public BadgeType Seniority { get; private set; } = new BadgeType(10, "", "Seniority", "Seniority");

        [Write(false)]
        public BadgeType CompletedProfile { get; private set; } = new BadgeType(1, "", "Completed Profile", "Completed Profile");

        [Write(false)]
        public BadgeType VerifiedProfile { get; private set; } = new BadgeType(3, "fas fa-user-check", "Verified Profile", "Validação de todos os itens da lista de pendências");

        [Write(false)]
        public BadgeType Popular { get; private set; } = new BadgeType(1, "far fa-grin-stars", "Popular", "Tem uma relação de 70% ou mais de likes");

        public override void LoadDefatultData()
        {
            throw new System.NotImplementedException();
        }
    }
}
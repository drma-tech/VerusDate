using Dapper.Contrib.Extensions;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    [Table("Badge")]
    public class BadgeVM : ViewModelType
    {
        /// <summary>
        /// Use for API
        /// </summary>
        public BadgeVM()
        {
        }

        /// <summary>
        /// Use for insert
        /// </summary>
        /// <param name="id"></param>
        public BadgeVM(string id)
        {
            Id = id;
        }

        [ExplicitKey]
        public string Id { get; private set; }

        public ValueType.BadgeType Rank { get; private set; } = new ValueType.BadgeType(10);
        public ValueType.BadgeType Seniority { get; private set; } = new ValueType.BadgeType(10);
        public ValueType.BadgeType CompletedProfile { get; private set; } = new ValueType.BadgeType(1);
        public ValueType.BadgeType VerifiedProfile { get; private set; } = new ValueType.BadgeType(3);
        public ValueType.BadgeType Popular { get; private set; } = new ValueType.BadgeType(1);
    }
}
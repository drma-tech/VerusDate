using Dapper.Contrib.Extensions;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    [Table("Badge")]
    public class BadgeVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        public bool Validated { get; set; }
        public bool Popular { get; set; }

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
    }
}
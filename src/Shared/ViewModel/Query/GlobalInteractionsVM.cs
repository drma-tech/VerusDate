using Dapper.Contrib.Extensions;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel.Query
{
    public class GlobalInteractionsVM : ViewModelQuery
    {
        [ExplicitKey]
        public string Id { get; set; }

        public int TotalMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int TotalLikes { get; set; }
        public int TotalBlinks { get; set; }
    }
}
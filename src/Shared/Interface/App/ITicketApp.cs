using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface ITicketApp
    {
        Task<IEnumerable<TicketVM>> GetList(CancellationToken cancellationToken);

        Task<IEnumerable<TicketVoteVM>> GetMyVotes(string IdUser, CancellationToken cancellationToken);

        Task<bool> Add(TicketVM obj);

        Task<bool> Vote(string IdTicket, string IdUser, CancellationToken cancellationToken);
    }
}
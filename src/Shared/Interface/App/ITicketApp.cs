using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Interface.App
{
    public interface ITicketApp
    {
      

        Task<bool> Add(TicketVM obj);

        Task<bool> Vote(string IdTicket, string IdUser, CancellationToken cancellationToken);
    }
}
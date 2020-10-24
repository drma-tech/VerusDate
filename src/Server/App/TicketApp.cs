using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.App
{
    public class TicketApp : ITicketApp
    {
        private readonly IRepository _repos;

        public TicketApp(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<bool> Add(TicketVM obj)
        {
            return await _repos.Insert(obj);
        }

        public async Task<IEnumerable<TicketVM>> GetList(CancellationToken cancellationToken)
        {
            return await _repos.GetAll<TicketVM>(cancellationToken);
        }

        public async Task<IEnumerable<TicketVoteVM>> GetMyVotes(string IdUser, CancellationToken cancellationToken)
        {
            return await _repos.Query<TicketVoteVM>("SELECT * FROM TicketVote WHERE IdUser = @IdUser", new { IdUser }, cancellationToken);
        }

        public async Task<bool> Vote(string IdTicket, string IdUser, CancellationToken cancellationToken)
        {
            var query = "UPDATE Ticket SET TotalVotes = TotalVotes + 1 WHERE Id = @IdTicket; INSERT INTO TicketVote (IdTicket,IdUser) VALUES (@IdTicket,@IdUser);";

            return await _repos.Execute(query, new { IdTicket, IdUser }, cancellationToken);
        }
    }
}
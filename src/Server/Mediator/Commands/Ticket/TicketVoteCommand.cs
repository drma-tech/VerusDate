using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;

namespace VerusDate.Server.Mediator.Commands.Ticket
{
    public class TicketVoteCommand : IBaseCommand<bool>
    {
        public string IdTicket { get; set; }
        public string IdUser { get; set; }
    }

    public class TicketVoteHandler : IRequestHandler<TicketVoteCommand, bool>
    {
        private readonly IRepository _repo;

        public TicketVoteHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(TicketVoteCommand request, CancellationToken cancellationToken)
        {
            var query = new StringBuilder("UPDATE Ticket SET TotalVotes = TotalVotes + 1 WHERE Id = @IdTicket; INSERT INTO TicketVote (IdTicket,IdUser) VALUES (@IdTicket,@Id);");

            return await _repo.Execute(query, request, cancellationToken) > 0;
        }
    }
}
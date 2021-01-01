using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model.Support;

namespace VerusDate.Api.Mediator.Command.Support
{
    public class TicketVoteCommand : TicketVote, IRequest<TicketVote> { }

    public class TicketVoteHandler : IRequestHandler<TicketVoteCommand, TicketVote>
    {
        private readonly IRepository _repo;

        public TicketVoteHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<TicketVote> Handle(TicketVoteCommand request, CancellationToken cancellationToken)
        {
            //var query = new StringBuilder("UPDATE Ticket SET TotalVotes = TotalVotes + 1 WHERE Id = @IdTicket; INSERT INTO TicketVote (IdTicket,IdUser) VALUES (@IdTicket,@Id);");
            //TODO: ATUALIZAR TOTAL DE TICKET POR PERIODO

            request.SetKey(request.Key);

            return await _repo.Add(request, request.Key, cancellationToken);
        }
    }
}
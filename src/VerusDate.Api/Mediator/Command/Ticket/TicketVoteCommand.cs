using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model.Ticket;

namespace VerusDate.Api.Mediator.Command.Ticket
{
    public class TicketVoteCommand : TicketVote, IRequest<TicketVote>
    {
        public string IdTicket { get; set; }
    }

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

            request.Key = request.IdTicket;

            return await _repo.Add(request, request.IdTicket, cancellationToken);
        }
    }
}
using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Ticket
{
    public class TicketVoteCommand : Shared.Model.TicketVote, IRequest<Shared.Model.TicketVote> { }

    public class TicketVoteHandler : IRequestHandler<TicketVoteCommand, Shared.Model.TicketVote>
    {
        private readonly IRepository<Shared.Model.TicketVote> _repo;

        public TicketVoteHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.TicketVote>();
        }

        public async Task<Shared.Model.TicketVote> Handle(TicketVoteCommand request, CancellationToken cancellationToken)
        {
            //var query = new StringBuilder("UPDATE Ticket SET TotalVotes = TotalVotes + 1 WHERE Id = @IdTicket; INSERT INTO TicketVote (IdTicket,IdUser) VALUES (@IdTicket,@Id);");
            //TODO: ATUALIZAR TOTAL DE TICKET POR PERIODO

            request.Type = "TicketVote";

            return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}
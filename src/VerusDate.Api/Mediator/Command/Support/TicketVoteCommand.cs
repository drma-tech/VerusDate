using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Support
{
    public class TicketVoteCommand : TicketVoteModel, IRequest<TicketVoteModel>
    { }

    public class TicketVoteHandler : IRequestHandler<TicketVoteCommand, TicketVoteModel>
    {
        private readonly IRepository _repo;

        public TicketVoteHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<TicketVoteModel> Handle(TicketVoteCommand request, CancellationToken cancellationToken)
        {
            //var query = new StringBuilder("UPDATE Ticket SET TotalVotes = TotalVotes + 1 WHERE Id = @IdTicket; INSERT INTO TicketVote (IdTicket,IdUser) VALUES (@IdTicket,@Id);");
            //TODO: ATUALIZAR TOTAL DE TICKET POR PERIODO

            request.SetKey(request.Key);

            //var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            //obj.Gamification.AddXP(1);

            //await _repo.Update(obj, cancellationToken);

            return await _repo.Add(request, cancellationToken);
        }
    }
}
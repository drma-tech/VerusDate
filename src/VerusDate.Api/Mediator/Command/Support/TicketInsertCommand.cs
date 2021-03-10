using MediatR;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Support
{
    public class TicketInsertCommand : TicketModel, IRequest<TicketModel> { }

    public class TicketInsertHandler : IRequestHandler<TicketInsertCommand, TicketModel>
    {
        private readonly IRepository _repo;

        public TicketInsertHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<TicketModel> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>("Profile:" + request.IdUserOwner, new PartitionKey(request.IdUserOwner), cancellationToken);

            obj.Gamification.AddXP(5);

            await _repo.Update(obj, cancellationToken);

            return await _repo.Add(request, cancellationToken);
        }
    }
}
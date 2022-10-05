using MediatR;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
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
            if (request.VoteType == VoteType.PlusOne)
                await _repo.PatchItem<TicketModel>(nameof(CosmosType.Ticket) + ":" + request.Key, request.Key, new List<PatchOperation> { PatchOperation.Increment("/totalVotes", 1) }, cancellationToken);
            else if (request.VoteType == VoteType.MinusOne)
                await _repo.PatchItem<TicketModel>(nameof(CosmosType.Ticket) + ":" + request.Key, request.Key, new List<PatchOperation> { PatchOperation.Increment("/totalVotes", -1) }, cancellationToken);

            request.SetKey(request.Key);
            return await _repo.Add(request, cancellationToken);
        }
    }
}
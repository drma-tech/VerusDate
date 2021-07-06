using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetChatCommand : MediatorQuery<ChatModel>
    {
        public InteractionGetChatCommand() : base(CosmosType.Interaction)
        {
        }

        public string IdChat { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdChat = query["id"];
        }
    }

    public class InteractionGetChatHandler : IRequestHandler<InteractionGetChatCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public InteractionGetChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(InteractionGetChatCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ChatModel>(request.IdChat, request.IdChat.Split(":")[1], cancellationToken);
        }
    }
}
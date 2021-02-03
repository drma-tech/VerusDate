using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Chat
{
    public class ChatGetCommand : MediatorQuery<ChatModel>
    {
        public ChatGetCommand() : base(CosmosType.Chat)
        {
        }

        public string IdUserInteraction { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdUserInteraction = query["id"];
        }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public ChatGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            //recupera a interação, para garantir não pegar um chat qualquer
            var Id = InteractionModel.GetId(CosmosType.Chat, request.IdLoggedUser, request.IdUserInteraction);
            var obj = await _repo.Get<InteractionModel>(Id, new PartitionKey(Id), cancellationToken);

            return await _repo.Get<ChatModel>(obj.IdChat, new PartitionKey(obj.Key), cancellationToken);
        }
    }
}
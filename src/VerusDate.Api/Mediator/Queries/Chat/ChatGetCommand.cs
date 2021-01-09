using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Chat
{
    public class ChatGetCommand : MediatorQuery<ChatModel>
    {
        public string IdUserInteraction { get; set; }
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
            var Id = InteractionModel.GetId(request.IdLoggedUser, request.IdUserInteraction);
            var obj = await _repo.Get<InteractionModel>(Id, Id, cancellationToken: cancellationToken);

            return await _repo.Get<ChatModel>(obj.IdChat, obj.IdChat, cancellationToken: cancellationToken);
        }
    }
}
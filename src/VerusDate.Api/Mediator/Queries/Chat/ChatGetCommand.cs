using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Chat
{
    public class ChatGetCommand : MediatorQuery<Shared.Model.Interaction.Chat>
    {
        public string IdUserInteraction { get; set; }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, Shared.Model.Interaction.Chat>
    {
        private readonly IRepository _repo;

        public ChatGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Interaction.Chat> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            //recupera a interação, para garantir não pegar um chat qualquer
            var Id = Shared.Model.Interaction.Interaction.GetId(request.IdLoggedUser, request.IdUserInteraction);
            var obj = await _repo.Get<Shared.Model.Interaction.Interaction>(Id, Id, cancellationToken: cancellationToken);

            return await _repo.Get<Shared.Model.Interaction.Chat>(obj.IdChat, obj.IdChat, cancellationToken: cancellationToken);
        }
    }
}
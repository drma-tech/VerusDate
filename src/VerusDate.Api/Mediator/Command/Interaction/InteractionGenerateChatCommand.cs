using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model.Interaction;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionGenerateChatCommand : Shared.Model.Interaction.Interaction, IRequest<Chat> { }

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, Chat>
    {
        private readonly IRepository _repo;

        public InteractionGenerateChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Chat> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj1 = await _repo.Get<Shared.Model.Interaction.Interaction>(request.Id, request.Key, cancellationToken);

            if (!obj1.Match.Value.Value)
            {
                throw new NotificationException("Match ainda não ocorreu nesta interação");
            }
            else if (!string.IsNullOrEmpty(obj1.IdChat))
            {
                throw new NotificationException("Chat já gerado");
            }
            else
            {
                var IdChat = Guid.NewGuid().ToString();

                var obj2 = await _repo.Get<Shared.Model.Interaction.Interaction>(request.GetInvertedId(), request.IdUserInteraction, cancellationToken);

                obj1.IdChat = IdChat;
                obj2.IdChat = IdChat;

                await _repo.Update(obj1, request.Id, request.Key, cancellationToken);
                await _repo.Update(obj2, request.GetInvertedId(), request.IdUserInteraction, cancellationToken);

                return await _repo.Add(new Chat() { Id = IdChat }, IdChat, cancellationToken);
            }
        }
    }
}
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionGenerateChatCommand : InteractionModel, IRequest<ChatModel> { }

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public InteractionGenerateChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj1 = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

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
                var obj2 = await _repo.Get<InteractionModel>(request.GetInvertedId(), request.IdUserInteraction, cancellationToken);

                var chat = new ChatModel();

                chat.SetIds(null);

                obj1.IdChat = chat.Id;
                obj2.IdChat = chat.Id;

                await _repo.Update(obj1, request.Id, request.Key, cancellationToken);
                await _repo.Update(obj2, request.GetInvertedId(), request.IdUserInteraction, cancellationToken);

                return await _repo.Add(chat, chat.Id, cancellationToken);
            }
        }
    }
}
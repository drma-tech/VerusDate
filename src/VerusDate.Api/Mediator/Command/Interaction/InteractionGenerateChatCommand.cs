using MediatR;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionGenerateChatCommand : Shared.Model.Interaction, IRequest<Shared.Model.Chat> { }

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, Shared.Model.Chat>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;
        private readonly IRepository<Shared.Model.Chat> _repoChat;

        public InteractionGenerateChatHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
            _repoChat = factory.RepositoryOf<Shared.Model.Chat>();
        }

        public async Task<Shared.Model.Chat> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            //if (request.Id == request.IdInteraction) throw new InvalidOperationException();

            var obj1 = await _repo.GetAsync(request.Id, request.IdPrimary, cancellationToken);

            if (!obj1.Match.Value)
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

                var obj2 = await _repo.GetAsync(request.Id, request.IdSecondary, cancellationToken);

                obj1.IdChat = IdChat;
                obj2.IdChat = IdChat;

                await _repo.UpdateAsync(obj1, cancellationToken);
                await _repo.UpdateAsync(obj2, cancellationToken);

                return await _repoChat.CreateAsync(new Shared.Model.Chat() { Id = IdChat }, cancellationToken);
            }
        }
    }
}
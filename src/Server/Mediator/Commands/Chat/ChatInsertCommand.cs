using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Chat
{
    public class ChatInsertCommand : IRequest<int>
    {
        /// <summary>
        /// Chat (lista de conversas) realizado entre dois usuários
        /// </summary>
        public List<ChatVM> LstChat { get; private set; }
    }

    public class ChatInsertChatHandler : IRequestHandler<ChatInsertCommand, int>
    {
        private readonly IRepository _repo;

        public ChatInsertChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(ChatInsertCommand request, CancellationToken cancellationToken)
        {
            return await _repo.BulkInsert(request.LstChat, cancellationToken);
        }
    }
}
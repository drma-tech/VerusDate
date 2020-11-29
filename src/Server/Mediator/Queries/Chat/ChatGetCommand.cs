using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Queries.Chat
{
    public class ChatGetCommand : BaseCommandQuery<IEnumerable<ChatVM>>
    {
        [Required]
        public string IdChat { get; set; }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, IEnumerable<ChatVM>>
    {
        private readonly IRepository _repo;

        public ChatGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ChatVM>> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            await _repo.Execute(new StringBuilder("UPDATE Chat SET IsRead = 1 WHERE IdChat = @IdChat AND IdUserSender != @IdUser AND IsRead = 0"), request, cancellationToken);

            return await _repo.Query<ChatVM>(new StringBuilder("SELECT * FROM Chat WHERE IdChat = @IdChat"), request, cancellationToken);
        }
    }
}
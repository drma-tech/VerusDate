using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Helper;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionGenerateChatCommand : IBaseCommand<bool>
    {
        public string IdUser { get; set; }

        /// <summary>
        /// ID do usuário alvo
        /// </summary>
        [Required]
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionGenerateChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            if (request.IdUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction"), request);

            if (!obj.Match.Value)
            {
                throw new NotificationException("Match ainda não ocorreu nesta interação");
            }
            else if (!string.IsNullOrEmpty(obj.IdChat))
            {
                throw new NotificationException("Chat já gerado");
            }
            else
            {
                var IdChat = Guid.NewGuid();
                var sql = new StringBuilder();

                sql.AppendLine("UPDATE Interaction SET IdChat = @IdChat WHERE Id = @IdUser AND IdUserInteraction = @IdUserInteraction; ");
                sql.AppendLine("UPDATE Interaction SET IdChat = @IdChat WHERE Id = @IdUserInteraction AND IdUserInteraction = @IdUser; ");
                sql.AppendLine("INSERT INTO Chat (IdChat) VALUES (@IdChat); ");

                return await _repo.Execute(sql, new { IdChat, request.IdUser, request.IdUserInteraction }, cancellationToken) > 0;
            }
        }
    }
}
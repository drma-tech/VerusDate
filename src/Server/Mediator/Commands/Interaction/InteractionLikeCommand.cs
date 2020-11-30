using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionLikeCommand : IBaseCommand<bool>
    {
        public string IdUser { get; set; }

        /// <summary>
        /// ID do usuário alvo
        /// </summary>
        [Required]
        public string IdUserInteraction { get; set; }
    }

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionLikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction"), request);

            obj.ExecuteLike();

            var mergeLike = await _repo.Update(obj);

            var matched = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @IdUserInteraction AND IdUserInteraction = @Id"), request);

            if (matched != null && matched.Like.Value) //se o outro tbm deu like, gera o match para os dois
            {
                obj.ExecuteMatch();

                matched.ExecuteMatch();

                var mergeUser1 = await _repo.Update(obj);

                var mergeUser2 = await _repo.Update(matched);

                return mergeUser1 && mergeUser2;
            }
            else
            {
                return mergeLike;
            }
        }
    }
}
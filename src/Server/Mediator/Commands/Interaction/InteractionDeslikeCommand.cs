using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionDeslikeCommand : IBaseCommand<bool>
    {
        public string IdUser { get; set; }

        /// <summary>
        /// ID do usuário alvo
        /// </summary>
        [Required]
        public string IdUserInteraction { get; set; }
    }

    public class InteractionDeslikeHandler : IRequestHandler<InteractionDeslikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionDeslikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionDeslikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction"), request);

            if (obj == null)
            {
                obj = new InteractionVM() { IdUser = request.IdUser, IdUserInteraction = request.IdUserInteraction };
                obj.ExecuteDeslike();
                return await _repo.Insert(obj);
            }
            else
            {
                obj.ExecuteDeslike();
                return await _repo.Update(obj);
            }
        }
    }
}
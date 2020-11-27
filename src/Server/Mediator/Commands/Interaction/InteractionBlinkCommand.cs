using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlinkCommand : IBaseCommand<bool>
    {
        public string Id { get; set; }

        /// <summary>
        /// ID do usuário alvo
        /// </summary>
        [Required]
        public string IdUserInteraction { get; set; }
    }

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlinkHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction"), request);

            obj.ExecuteBlink();

            return await _repo.Update(obj);
        }
    }
}
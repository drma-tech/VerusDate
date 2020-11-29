using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlockCommand : IBaseCommand<bool>
    {
        public string Id { get; set; }

        /// <summary>
        /// ID do usuário alvo
        /// </summary>
        [Required]
        public string IdUserInteraction { get; set; }
    }

    public class InteractionBlockHandler : IRequestHandler<InteractionBlockCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlockHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlockCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction"), request);

            if (obj == null)
            {
                throw new InvalidOperationException("Block");
            }
            else
            {
                obj.ExecuteBlock();
                return await _repo.Update(obj);
            }
        }
    }
}
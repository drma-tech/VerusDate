using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Mediator;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : BaseCommandQuery<InteractionVM>
    {
        /// <summary>
        /// ID do usuário que o usuário logado interagiu
        /// </summary>
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, InteractionVM>
    {
        private readonly IRepository _repo;

        public InteractionGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InteractionVM> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            if (request.IdUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE IdUser = @IdUser AND IdUserInteraction = @IdUserInteraction"), request);

            if (obj == null)
            {
                obj = new InteractionVM() { IdUser = request.IdUser, IdUserInteraction = request.IdUserInteraction };
                await _repo.Insert(obj);
            }

            return obj;
        }
    }
}
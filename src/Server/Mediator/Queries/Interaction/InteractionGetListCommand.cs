using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Interaction
{
    public class InteractionGetListCommand : BaseCommandQuery<IEnumerable<InteractionVM>> { }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<InteractionVM>>
    {
        private readonly IRepository _repo;

        public InteractionGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<InteractionVM>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<InteractionVM>(new StringBuilder("SELECT * FROM Interaction WHERE Id = @IdUser"), request, cancellationToken);
        }
    }
}
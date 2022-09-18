using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model.Profile;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class InviteUpdateCommand : InviteModel, IRequest<bool>
    {
    }

    public class InviteUpdateHandler : IRequestHandler<InviteUpdateCommand, bool>
    {
        private readonly IRepository _repo;

        public InviteUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InviteUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request, cancellationToken);
        }
    }
}
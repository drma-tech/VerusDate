using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class InviteUpdateCommand : InviteModel, IRequest<InviteModel>
    {
    }

    public class InviteUpdateHandler : IRequestHandler<InviteUpdateCommand, InviteModel>
    {
        private readonly IRepository _repo;

        public InviteUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InviteModel> Handle(InviteUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request, cancellationToken);
        }
    }
}
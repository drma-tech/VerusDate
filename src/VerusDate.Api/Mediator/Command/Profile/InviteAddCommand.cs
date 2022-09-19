using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class InviteAddCommand : InviteModel, IRequest<InviteModel>
    {
    }

    public class InviteAddHandler : IRequestHandler<InviteAddCommand, InviteModel>
    {
        private readonly IRepository _repo;

        public InviteAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InviteModel> Handle(InviteAddCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, cancellationToken);
        }
    }
}
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class PrincipalAddCommand : ClientePrincipal, IRequest<ClientePrincipal> { }

    public class PrincipalAddHandler : IRequestHandler<PrincipalAddCommand, ClientePrincipal>
    {
        private readonly IRepository _repo;

        public PrincipalAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ClientePrincipal> Handle(PrincipalAddCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, cancellationToken);
        }
    }
}
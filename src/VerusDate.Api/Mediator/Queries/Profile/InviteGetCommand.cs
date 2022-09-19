using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class InviteGetCommand : MediatorQuery<InviteModel>
    {
        public InviteGetCommand() : base(CosmosType.Invite)
        {
        }

        public string Email { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            Email = query["Email"];
        }
    }

    public class InviteGetHandler : IRequestHandler<InviteGetCommand, InviteModel>
    {
        private readonly IRepository _repo;

        public InviteGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InviteModel> Handle(InviteGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<InviteModel>(request.GetId(request.Email), request.Email, cancellationToken);
        }
    }
}
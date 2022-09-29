using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdatePartnerCommand : CosmosBase, IRequest<ProfileModel>
    {
        public ProfileUpdatePartnerCommand() : base(CosmosType.Profile)
        {
        }

        public string id { get; set; }
        public string email { get; set; }
        public string LoggedUserId { get; set; }

        public override void SetIds(string id)
        {
            this.SetId(id);
            this.SetPartitionKey(id);
        }
    }

    public class ProfilePartnerAddHandler : IRequestHandler<ProfileUpdatePartnerCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfilePartnerAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileUpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            request.SetIds(request.id);

            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            obj.UpdatePartner(request.LoggedUserId, request.email);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}
using MediatR;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : ProfileModel, IRequest<bool> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            if (obj.DtUpdate != null) //terceira vez que atualiza
            {
                obj.Gamification.RemoveXP(100);
            }

            obj.UpdateProfile(request.Basic, request.Bio, request.Lifestyle, request.Interest);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}
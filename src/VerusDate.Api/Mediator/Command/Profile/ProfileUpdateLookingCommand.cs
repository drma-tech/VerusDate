using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommand : ProfileModel, IRequest<bool>
    { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileUpdateLookingCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileLookingAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileUpdateLookingCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            //if (obj.Preference == null) //primeira vez que atualiza a busca
            //{
            //    obj.Gamification.AddXP(30);
            //}
            //else
            //{
            //    obj.Gamification.RemoveXP(100);
            //}

            obj.UpdateLooking(request.Preference);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}
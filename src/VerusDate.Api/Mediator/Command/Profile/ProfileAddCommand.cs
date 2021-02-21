using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileAddCommand : ProfileModel, IRequest<ProfileModel> { }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            request.Gamification = new ProfileGamificationModel();
            
            request.Gamification.ResetFood();
            request.Gamification.AddXP(30);

            return await _repo.Add(request, cancellationToken);
        }
    }
}